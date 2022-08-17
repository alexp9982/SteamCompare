using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SteamCompare.ViewModel;

public partial class SettingsPageViewModel : ObservableObject
{
    [RelayCommand]
    async Task Navigate() => await Shell.Current.GoToAsync("..", true);
}