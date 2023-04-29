using Microsoft.Extensions.Hosting;

namespace example_di;

public sealed class Worker : BackgroundService
{
    readonly IService2 svc2;

    public Worker(IService2 svc2) => this.svc2 = svc2;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            svc2.TestSum();

            await Task.Delay(1_000, stoppingToken);
        }
    }
}