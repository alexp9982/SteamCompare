using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace SteamCompare.ViewModel;

public partial class KeyPageViewModel : ObservableObject
{
    [ObservableProperty]
    string apikey;
        
        
    [ICommand]
    async Task Navigate() => await Shell.Current.GoToAsync(nameof(ComparePage), true, new Dictionary<string, object>
    {
        {"Apikey", apikey}
    });
}