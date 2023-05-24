using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
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
			.UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<IFileSaver>(FileSaver.Default);

		// Home
		builder.Services.AddSingleton<HomeView>();
		//builder.Services.AddSingleton<HomeViewModel>();

        // Consultar encuesta
        builder.Services.AddSingleton<ConsultarEncuestaView>();
        //builder.Services.AddSingleton<ConsultarEncuestaViewModel>();

		// Detalle llamada
        builder.Services.AddTransient<DetalleLlamadaView>();
		

		builder.Services.AddSingleton<GestorConsulta>();

        return builder.Build();
	}
}
