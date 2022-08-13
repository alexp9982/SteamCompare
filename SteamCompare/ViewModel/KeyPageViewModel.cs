using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SteamCompare.ViewModel;

public partial class KeyPageViewModel : ObservableObject
{
    [ObservableProperty]
    string apikey;
        
        
    [RelayCommand]
    async Task Navigate() => await Shell.Current.GoToAsync(nameof(ComparePage), true, new Dictionary<string, object>
    {
        {"Apikey", apikey}
    });
}