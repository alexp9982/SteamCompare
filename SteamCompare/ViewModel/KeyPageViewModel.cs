using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SteamCompare.Classes;

namespace SteamCompare.ViewModel;

public partial class KeyPageViewModel : ObservableObject
{
    [ObservableProperty]
    string apikey;


    [RelayCommand]
    async Task Navigate()
    {
        DataHolder.ApiKey = Apikey;
        await Shell.Current.GoToAsync(nameof(ComparePage), true);
    }

    [RelayCommand]
    async Task Settings()
    {
        DataHolder.ApiKey = Apikey;
        await Shell.Current.GoToAsync(nameof(SettingsPage), true);
    }
}