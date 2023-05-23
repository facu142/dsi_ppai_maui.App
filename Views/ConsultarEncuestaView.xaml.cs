using dsi_ppai_maui.Models;
using dsi_ppai_maui.ViewModels;

namespace dsi_ppai_maui.Views;

public partial class ConsultarEncuestaView : ContentPage
{
    private readonly ConsultarEncuestaViewModel _viewModel;


    public ConsultarEncuestaView(ConsultarEncuestaViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _viewModel = vm;

    }

    private void FechaSeleccionada(object sender, DateChangedEventArgs e)
    {
        LlamadasCollectionView.IsVisible = true;
        FiltrarporPeriodo();
    }

    private void FiltrarporPeriodo()
    {
        LlamadasCollectionView.ItemsSource = _viewModel.Llamadas.Where(i => i.CambioDeEstado.Last().FechaHoraInicio >= FechaDesde.Date
                                                                         && i.CambioDeEstado.Last().FechaHoraInicio <= FechaHasta.Date
                                                                         && i.RespuestasDeEncuesta.Count > 0);
    }
}