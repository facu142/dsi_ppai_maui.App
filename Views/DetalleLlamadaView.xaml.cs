using CommunityToolkit.Maui.Storage;
using dsi_ppai_maui.ViewModels;
using System.Text;

namespace dsi_ppai_maui.Views;

public partial class DetalleLlamadaView : ContentPage
{

    GestorConsulta _gestorConsulta;
    public DetalleLlamadaView(GestorConsulta gestorConsulta)
    {
        _gestorConsulta = gestorConsulta;
        InitializeComponent();
        BindingContext = gestorConsulta;
    }

    private void TomarSeleccionFormato(object sender, EventArgs e)
    {
        _gestorConsulta.GenerarCSVCommand.Execute(null);
    }
}