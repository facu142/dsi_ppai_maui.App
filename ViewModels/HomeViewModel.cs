using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using dsi_ppai_maui.Views;

namespace dsi_ppai_maui.ViewModels
{
    public partial class HomeViewModel: ObservableObject
    {
        [RelayCommand]
        public async void GoToConsultarEncuesta()
        {
            await Shell.Current.GoToAsync(nameof(ConsultarEncuestaView));
        }

    }
}
