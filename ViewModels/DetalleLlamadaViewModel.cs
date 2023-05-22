using CommunityToolkit.Mvvm.ComponentModel;
using dsi_ppai_maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.ViewModels
{
    [QueryProperty(nameof(DetalleLlamada), "DetalleLlamada")]
    public partial class DetalleLlamadaViewModel: ObservableObject
    {

        [ObservableProperty]
        private Llamada _detalleLlamada;

    }
}
