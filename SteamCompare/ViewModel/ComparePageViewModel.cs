using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace SteamCompare.ViewModel;

public partial class ComparePageViewModel : ObservableObject
{
    [ObservableProperty]
    string user1;

    [ObservableProperty]
    string user2;

    //$"{nameof(ListPage)}?User1={user1}?User2={user2}"
    [ICommand]
    async Task Navigate() => await Shell.Current.GoToAsync(nameof(ListPage), true, new Dictionary<string, object>
    {
        {"User1", user1},
        {"User2", user2}
    });
}