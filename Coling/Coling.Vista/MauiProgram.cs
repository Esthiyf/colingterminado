using Coling.Vista.Servicios.Curriculum;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.Extensions.Logging;

namespace Coling.Vista
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
           
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<SweetAlertService>();

            builder.Services.AddSweetAlert2();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IInstitucionService, InstitucionService>();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
