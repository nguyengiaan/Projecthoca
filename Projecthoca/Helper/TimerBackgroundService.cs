using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Projecthoca.Helper;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
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
    private readonly IMemoryCache _cache;
   
    public TimerBackgroundService(IHubContext<Timehub> hubContext, IServiceScopeFactory scopeFactory, ILogger<TimerBackgroundService> logger, IMemoryCache cache)
    {
        _hubContext = hubContext;
        _scopeFactory = scopeFactory;
        _logger = logger;
        _timerCancellationTokenSource = new CancellationTokenSource();
        _cache = cache;
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
            var cacheKey = "Danhsachbamgiolist_1";
            var _kvc = scope.ServiceProvider.GetRequiredService<IKhuvuccau>();

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    if (_cache.TryGetValue(cacheKey, out  List<Thuehoca> list))
                    {
                        foreach (var item in list)
                        {
                            await _kvc.Demthoigian(item.Ma_khuvuccau);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Lỗi khi đếm thời gian.");
                }

                // Thêm một delay để giảm tải CPU và tránh vòng lặp vô hạn nhanh chóng
                await Task.Delay(1000, stoppingToken);
            }

        }

        _logger.LogInformation("Dịch vụ nền đã dừng.");
    }

    private void StopTimer()
    {
        _timerCancellationTokenSource?.Cancel();
    }
}
