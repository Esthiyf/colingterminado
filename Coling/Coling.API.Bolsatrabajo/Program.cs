using Coling.API.Bolsatrabajo.Contratos.Repositorio;
using Coling.API.Bolsatrabajo.Implementacion.Repositorio;
using Coling.API.Bolsatrabajo.Repositorio;
using Coling.Utilitarios.Middlewares;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddScoped<ISolicitudRepositorio,SolicitudRepositorio>();
        services.AddScoped<IOfertaLaboralRepositorio, OfertaLaboralRepositorio>();
      //  services.AddSingleton<AutorizacionRolMiddleware>();

        services.Configure<KestrelServerOptions>(options =>
        {
            options.AllowSynchronousIO = true;
        });
        //  services.AddSingleton<JwtMiddleware>();
    })//.ConfigureFunctionsWebApplication(x =>
   // {
   //     x.UseMiddleware<JwtMiddleware>();

   // })
    .Build();

host.Run();
