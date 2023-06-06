using dsi_ppai_maui.ViewModels;

namespace dsi_ppai_maui.Views;

public partial class ConsultarEncuestaView : ContentPage
{
     private readonly GestorConsulta _gestorConsulta;

    public ConsultarEncuestaView(GestorConsulta gestorConsulta)
    {
        HabilitarVentana();
        _gestorConsulta = gestorConsulta;
        BindingContext = gestorConsulta;

    }

    private void TomarSeleccionFechaInicio(object sender, DateChangedEventArgs e)
    {
        _gestorConsulta.TomarSeleccionPeriodoCommand.Execute(null);
    }
    private void TomarSeleccionFechaFin(object sender, DateChangedEventArgs e)
    {
        _gestorConsulta.TomarSeleccionPeriodoCommand.Execute(null);
    }

    private void TomarSeleccionLlamada(object sender, TappedEventArgs e)
    {
        _gestorConsulta.TomarSeleccionLlamadaCommand.Execute(e.Parameter);
    }

    public async void SolicitarPeriodoDeLlamada()
    {
        await DisplayAlert("Ingrese el periodo de la llamada", "", "OK");
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
