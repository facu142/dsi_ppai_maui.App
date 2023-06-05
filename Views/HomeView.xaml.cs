using dsi_ppai_maui.ViewModels;

namespace dsi_ppai_maui.Views;

public partial class HomeView : ContentPage
{
    private readonly GestorConsulta _gestorConsulta;
    public HomeView(GestorConsulta gestorConsulta)
    {
        HabilitarVentana();
        _gestorConsulta = gestorConsulta;
        BindingContext = gestorConsulta;
    }

    private void OpcionConsultarEncuesta(object sender, EventArgs e)
    {
        _gestorConsulta.ConsultarEncuestaCommand.Execute(null);
    }

    private void HabilitarVentana()
    {
        InitializeComponent();
    }
}