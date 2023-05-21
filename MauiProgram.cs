using dsi_ppai_maui.ViewModels;
using dsi_ppai_maui.Views;
using Microsoft.Extensions.Logging;

namespace dsi_ppai_maui;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif


		// Home
		builder.Services.AddSingleton<HomeView>();
		builder.Services.AddSingleton<HomeViewModel>();

        // Consultar encuesta
        builder.Services.AddSingleton<ConsultarEncuestaView>();
        builder.Services.AddSingleton<ConsultarEncuestaViewModel>();


        return builder.Build();
	}
}
