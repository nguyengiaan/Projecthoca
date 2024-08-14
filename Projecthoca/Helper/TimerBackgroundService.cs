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

    public TimerBackgroundService(IHubContext<Timehub> hubContext, IServiceScopeFactory scopeFactory, ILogger<TimerBackgroundService> logger)
    {
       
            _hubContext = hubContext;
            _scopeFactory = scopeFactory;
            _logger = logger;
            _timerCancellationTokenSource = new CancellationTokenSource(); // Khởi tạo _timerCancellationTokenSource
        
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {

            using (var scope = _scopeFactory.CreateScope())
            {
                var _kvc = scope.ServiceProvider.GetRequiredService<IKhuvuccau>();

                try
                { 
                
                    var data = await _kvc.Danhsachbamgio();
                    if (data!=null && data.Count >0)
                    {
                        foreach(var a in data )
                        {
                            var data1=await _kvc.Demthoigian(a.Ma_khuvuc);
                        
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
    }

    private void StopTimer()
    {
        _timerCancellationTokenSource?.Cancel();
    }
}
