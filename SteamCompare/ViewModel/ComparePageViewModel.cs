using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SteamCompare.ViewModel;

[QueryProperty(nameof(Apikey), "Apikey")]

public partial class ComparePageViewModel : ObservableObject
{
    [ObservableProperty]
    string user1;

    [ObservableProperty]
    string user2;

    [ObservableProperty]
    string apikey;
    
    [RelayCommand]
    async Task Navigate() => await Shell.Current.GoToAsync(nameof(ListPage), true, new Dictionary<string, object>
    {
        {"User1", user1},
        {"User2", user2},
        {"Apikey", apikey}
    });
}