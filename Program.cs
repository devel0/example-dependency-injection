using example_di;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(services => services
    .AddHostedService<Worker>()
    .AddScoped<IService1, Service1>()
    // .AddScoped<IService1, BuggedService1>() // uncomment this to replace registered service1 with a bugged one
    .AddScoped<IService2, Service2>()
);

using var host = builder.Build();

host.Run();