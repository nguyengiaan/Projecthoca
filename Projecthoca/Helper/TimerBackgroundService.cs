using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Projecthoca.Helper;
using Projecthoca.Service.Interface;
using System;
using System.Linq;
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
        _timerCancellationTokenSource = new CancellationTokenSource();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (_timerCancellationTokenSource.IsCancellationRequested)
        {
            _logger.LogInformation("Dịch vụ đã được khởi động.");
            return;
        }

        using (var scope = _scopeFactory.CreateScope())
        {
            var _kvc = scope.ServiceProvider.GetRequiredService<IKhuvuccau>();

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var data = await _kvc.Danhsachbamgio();
                    if (data != null && data.Count > 0)
                    {
                        await Parallel.ForEachAsync(data, stoppingToken, async (a, token) =>
                        {
                            await _kvc.Demthoigian(a.Ma_khuvuc);
                        });
                    }
                    else
                    {
                        StopTimer();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Lỗi khi đếm thời gian.");
                }

            
            }
        }

        _logger.LogInformation("Dịch vụ nền đã dừng.");
    }

    private void StopTimer()
    {
        _timerCancellationTokenSource?.Cancel();
    }
}
