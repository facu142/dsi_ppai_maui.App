using dsi_ppai_maui.ViewModels;

namespace dsi_ppai_maui.Views;

public partial class HomeView : ContentPage
{
    public HomeView(HomeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}