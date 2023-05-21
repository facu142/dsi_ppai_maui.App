using dsi_ppai_maui.ViewModels;

namespace dsi_ppai_maui.Views;

public partial class ConsultarEncuestaView : ContentPage
{
	public ConsultarEncuestaView(ConsultarEncuestaViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}