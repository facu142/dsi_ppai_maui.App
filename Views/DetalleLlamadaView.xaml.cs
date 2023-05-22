using CommunityToolkit.Maui.Storage;
using dsi_ppai_maui.ViewModels;
using System.Text;

namespace dsi_ppai_maui.Views;

public partial class DetalleLlamadaView : ContentPage
{
    public DetalleLlamadaView(DetalleLlamadaViewModel vm)
    {
        BindingContext = vm;
		InitializeComponent();
	}
}