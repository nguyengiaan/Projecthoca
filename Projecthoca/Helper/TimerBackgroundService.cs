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
    private CancellationTokenSource _timerCancellationTokenSource;
    private static bool _isRunning = false; // Biến tĩnh để kiểm tra trạng thái dịch vụ
    private static readonly object _lock = new object(); // Đối tượng khóa để đảm bảo tính đồng bộ

    public TimerBackgroundService(IHubContext<Timehub> hubContext, IServiceScopeFactory scopeFactory, ILogger<TimerBackgroundService> logger)
    {
        _hubContext = hubContext;
        _scopeFactory = scopeFactory;
        _logger = logger;
        _timerCancellationTokenSource = new CancellationTokenSource(); // Khởi tạo _timerCancellationTokenSource
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        lock (_lock)
        {
            if (_isRunning)
            {
                _logger.LogInformation("Dịch vụ đã được khởi động.");
                return; // Nếu dịch vụ đã được khởi động, thoát khỏi phương thức
            }
            _isRunning = true; // Đánh dấu dịch vụ là đang chạy
        }

        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _kvc = scope.ServiceProvider.GetRequiredService<IKhuvuccau>();

                try
                {
                    var data = await _kvc.Danhsachbamgio();
                    if (data != null && data.Count > 0)
                    {
                        foreach (var a in data)
                        {
                            var data1 = await _kvc.Demthoigian(a.Ma_khuvuc);
                        }
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
        _isRunning = false; // Đánh dấu dịch vụ là đã dừng
    }

    private void StopTimer()
    {
        _timerCancellationTokenSource?.Cancel();
    }
}
