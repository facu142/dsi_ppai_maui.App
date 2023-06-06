using dsi_ppai_maui.Views;

namespace dsi_ppai_maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ConsultarEncuestaView), typeof(ConsultarEncuestaView));
     // Routing.RegisterRoute(nameof(DetalleLlamadaView), typeof(DetalleLlamadaView));
    }
}
