using dsi_ppai_maui.ViewModels;

namespace dsi_ppai_maui.Views;

public partial class ConsultarEncuestaView : ContentPage
{
    // private readonly GestorConsulta _viewModel;

    public ConsultarEncuestaView(GestorConsulta gestorConsulta)
    {
        InitializeComponent();
        BindingContext = gestorConsulta;

    }
}
