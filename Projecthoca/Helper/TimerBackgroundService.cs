using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Projecthoca.Helper;
using Projecthoca.Service.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

public class TimerBackgroundService : BackgroundService
{
    private readonly IHubContext<Timehub> _hubContext;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<TimerBackgroundService> _logger;

    private readonly object _lockObject = new object();
    private string _maKhuvuc;
    private CancellationTokenSource _timerCancellationTokenSource;

    public TimerBackgroundService(IHubContext<Timehub> hubContext, IServiceScopeFactory scopeFactory, ILogger<TimerBackgroundService> logger)
    {
       
            _hubContext = hubContext;
            _scopeFactory = scopeFactory;
            _logger = logger;
            _timerCancellationTokenSource = new CancellationTokenSource(); // Khởi tạo _timerCancellationTokenSource
        
    }

    public void SetMaKhuvuc(string maKhuvuc)
    {
    lock (_lockObject)
    {
        _maKhuvuc = maKhuvuc;
        _timerCancellationTokenSource?.Cancel(); // Hủy bộ đếm thời gian hiện tại nếu có
        _timerCancellationTokenSource = new CancellationTokenSource(); // Tạo mới CancellationTokenSource
        _logger.LogInformation("Đã thiết lập mã khu vực: {maKhuvuc}", maKhuvuc);
    }
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            string maKhuvuc;
            lock (_lockObject)
            {
                maKhuvuc = _maKhuvuc;
            }
            if (string.IsNullOrEmpty(maKhuvuc))
            {
                await Task.Delay(5000, stoppingToken); // Nếu không có _maKhuvuc, đợi 5 giây
                continue;
            }

            using (var scope = _scopeFactory.CreateScope())
            {
                var _kvc = scope.ServiceProvider.GetRequiredService<IKhuvuccau>();

                try
                {
                    var data = await _kvc.KiemtraBamgio(_maKhuvuc);
                    if (data)
                    {
                        await _kvc.Demthoigian(_maKhuvuc);
                        var time = await _kvc.Laythoigian(_maKhuvuc);
                        await _hubContext.Clients.All.SendAsync("ReceiveTimeUpdate", _maKhuvuc, time); // Gửi thời gian cùng mã khu vực
                    }
                    else
                    {
                        StopTimer(); // Dừng bộ đếm thời gian
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Lỗi khi đếm thời gian.");
                }
            }

            try
            {
                await Task.Delay(1000, _timerCancellationTokenSource.Token); // Đợi 1 giây trước khi lặp lại
            }
            catch (TaskCanceledException)
            {
                // Bộ đếm thời gian đã bị hủy
            }
        }

        _logger.LogInformation("Dịch vụ nền đã dừng.");
    }

    private void StopTimer()
    {
        _timerCancellationTokenSource?.Cancel();
        _maKhuvuc = null;
    }
}
