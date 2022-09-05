// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DI.Example;
using DI.Interface.DisposableServices;
using IHost host= Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services)=>
    services.AddTransient<ITransientOperation, DefaultOperation>()
        .AddScoped<IScopedOperation, DefaultOperation>()
        .AddSingleton<ISingletonOperation,DefaultOperation>()
        .AddTransient<OperationLogger>()
    )
    .ConfigureServices((_,services)=>
        services.AddTransient<TranscientDisposable>()
        .AddScoped<ScopedDisposable>()
        .AddSingleton<SingletonDisposable>())
    .Build();

ExemplifyScoping(host.Services, "Scope 1");
ExemplifyScoping(host.Services, "Scope 2");

ExemplifyDisposableScoping(host.Services,"Scope1");
Console.WriteLine();

ExemplifyDisposableScoping(host.Services,"Scope2");
Console.WriteLine();

await host.RunAsync();

static void ExemplifyScoping(IServiceProvider services, string scope){

    using IServiceScope serviceScope= services.CreateScope();
    IServiceProvider provider= serviceScope.ServiceProvider;

    OperationLogger logger= provider.GetRequiredService<OperationLogger>();
    logger.LogOperation($"{scope}-Call 1 .GetRequiredService<OperationLogger>()");

    Console.WriteLine("...");
    
    logger= provider.GetRequiredService<OperationLogger>();
    logger.LogOperation($"{scope}-Call 2 .GetRequiredService<OperationLogger>()");

    Console.WriteLine();
    }

static void ExemplifyDisposableScoping(IServiceProvider services, string scope){
    Console.WriteLine($"{scope}...");

    using IServiceScope serviceScope= services.CreateScope();
    IServiceProvider provider= serviceScope.ServiceProvider;

    _=provider.GetRequiredService<TranscientDisposable>();
    _=provider.GetRequiredService<ScopedDisposable>();
    _=provider.GetRequiredService<SingletonDisposable>();

}