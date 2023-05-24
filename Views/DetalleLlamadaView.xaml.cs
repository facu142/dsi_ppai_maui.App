using CommunityToolkit.Maui.Storage;
using dsi_ppai_maui.ViewModels;
using System.Text;

namespace dsi_ppai_maui.Views;

public partial class DetalleLlamadaView : ContentPage
{
    public DetalleLlamadaView(GestorConsulta gestorConsulta)
    {
        InitializeComponent();
        BindingContext = gestorConsulta;
    }
}