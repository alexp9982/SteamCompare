using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SteamCompare.Classes;

namespace SteamCompare.ViewModel;

public partial class ComparePageViewModel : ObservableObject
{
    [ObservableProperty]
    string user1;

    [ObservableProperty]
    string user2;
    
    [RelayCommand]
    async Task Navigate()
    {
        DataHolder.User1 = User1;
        DataHolder.User2 = User2;
        await Shell.Current.GoToAsync(nameof(ListPage), true);
    }

    [RelayCommand]
    async Task Settings()
    {
        DataHolder.User1 = User1;
        DataHolder.User2 = User2;
        await Shell.Current.GoToAsync(nameof(SettingsPage));
    }
}