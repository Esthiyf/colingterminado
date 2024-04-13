using Coliiing.Vista.Servicios.Curriculum;
using Coliiing.Vista.Servicios.Personasss;
using Microsoft.Extensions.Logging;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Coliiing.Vista.Servicios.Afiliadoss;
using Coliiing.Vista.Servicios.BolsaTrabajo;

namespace Coliiing.Vista
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            builder.Services.AddSweetAlert2();
            builder.Services.AddHttpClient();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<IPersonaservice, PersonaService>();
            builder.Services.AddScoped<IInstitucionService, InstitucionService>();
            builder.Services.AddScoped<IEstudiosService, EstudiosService>();
            builder.Services.AddScoped<IProfesionService, ProfesionService>();
            builder.Services.AddScoped<IExperienciaLaboralService, ExperienciaLaboralService>();
            builder.Services.AddScoped<IAfiliadosService, AfiliadosService>();
            builder.Services.AddScoped<IOfertaLaboralService, OfertaLaboralService>();
            builder.Services.AddScoped<ISolicitudService, SolicitudService>();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
