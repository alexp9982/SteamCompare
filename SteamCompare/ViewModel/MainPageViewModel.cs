using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace SteamCompare.ViewModel;

public partial class MainPageViewModel : ObservableObject
{
    [ICommand]
    Task Navigate() => Shell.Current.GoToAsync(nameof(KeyPage));
}