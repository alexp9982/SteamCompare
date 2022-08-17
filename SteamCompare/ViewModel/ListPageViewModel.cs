using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Steam.Models.SteamCommunity;
using SteamCompare.Classes;
using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;

namespace SteamCompare.ViewModel;

public partial class ListPageViewModel : ObservableObject
{
    [ObservableProperty]
    bool buttonEnabled;

    [RelayCommand]
    async Task Settings() => await Shell.Current.GoToAsync(nameof(SettingsPage));
}