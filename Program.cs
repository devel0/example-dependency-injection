using System.Diagnostics;
using example_di;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

const int A = 0xffff;
const int B = 0x2fff;

var sw_non_di = new Stopwatch();
{    
    sw_non_di.Start();
    var sum = 0d;
    for (int i = 0; i < A; ++i)
    {
        for (int j = 0; j < B; ++j)
        {
            sum = new Service1().Sum(i, j);
        }
    }
    sw_non_di.Stop();    
}

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(services => services
    .AddHostedService<Worker>()
    .AddScoped<IService1, Service1>()
    // .AddScoped<IService1, BuggedService1>() // uncomment this to replace registered service1 with a bugged one
    .AddScoped<IService2, Service2>()
);

using var host = builder.Build();

var sw_di = new Stopwatch();
{    
    sw_di.Start();
    var sum = 0d;
    for (int i = 0; i < A; ++i)
    {
        for (int j = 0; j < B; ++j)
        {
            sum = host.Services.GetRequiredService<IService1>().Sum(i, j);
        }
    }
    sw_di.Stop();    
}

System.Console.WriteLine($"DI BENCHMARK");
System.Console.WriteLine($"  without : {sw_non_di.Elapsed}");
System.Console.WriteLine($"  with    : {sw_di.Elapsed}");

// host.Run();