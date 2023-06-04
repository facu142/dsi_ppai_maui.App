using dsi_ppai_maui.ViewModels;

namespace dsi_ppai_maui.Views;

public partial class ConsultarEncuestaView : ContentPage
{
     private readonly GestorConsulta _gestorConsulta;

    public ConsultarEncuestaView(GestorConsulta gestorConsulta)
    {
        InitializeComponent();
        _gestorConsulta = gestorConsulta;
        BindingContext = gestorConsulta;

    }

    private void FechaSeleccionada(object sender, DateChangedEventArgs e)
    {
        _gestorConsulta.FechaSeleccionadaCommand.Execute(null);
    }

    private void TomarSeleccionLlamada(object sender, TappedEventArgs e)
    {
        _gestorConsulta.TomarSeleccionLlamadaCommand.Execute(e.Parameter);
    }

    public async void SolicitarPeriodoDeLlamada()
    {
        await DisplayAlert("Ingrese el periodo de la llamada", "", "OK");
    }
}
