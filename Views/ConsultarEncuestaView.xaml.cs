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
        //LlamadasCollectionView.ItemsSource = _viewModel.Llamadas.Where(i => i.CambioDeEstado.Last().Estado.EsIniciada());

        // Loop llamadas con encuesta respondida
        LlamadasCollectionView.ItemsSource = _viewModel.Llamadas.Where(i => i.CambioDeEstado.Last().FechaHoraInicio >= FechaDesde.Date 
                                                                         && i.CambioDeEstado.Last().FechaHoraInicio <= FechaHasta.Date);
    }
}