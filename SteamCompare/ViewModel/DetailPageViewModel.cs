using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SteamCompare.ViewModel;

public partial class DetailPageViewModel : ObservableObject
{
    [RelayCommand]
    Task Navigate() => Shell.Current.GoToAsync(nameof(ComparePage));
}