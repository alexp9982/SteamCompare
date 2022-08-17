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
    
    [ObservableProperty] private string statusText;
    
    [ObservableProperty] private string invalidText;

    [ObservableProperty]
    ObservableCollection<string> games;

    public ListPageViewModel()
    {
        Games = new ObservableCollection<string>();
        ButtonEnabled = true;
    }

    [RelayCommand]
    async Task Settings() => await Shell.Current.GoToAsync(nameof(SettingsPage));

    [RelayCommand]
    async Task GetResults()
    {
        ButtonEnabled = false;
        InvalidText = "";
        StatusText = "Preparing...";
        Games.Clear();
        List<string> user1Games = new List<string>();
        List<string> user2Games = new List<string>();
        StatusText = "Checking API Key...";
        SteamWebInterfaceFactory webInterfaceFactory;
        try
        {
            webInterfaceFactory = new SteamWebInterfaceFactory(DataHolder.ApiKey);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            StatusText = "";
            InvalidText = "Your API key is not valid. Ensure you followed the instructions correctly and try again";
            ButtonEnabled = true;
            return;
        }
        StatusText = "Checking users...";

        var playerServiceInterface = webInterfaceFactory.CreateSteamWebInterface<PlayerService>(new HttpClient());
        var steamUserInterface = webInterfaceFactory.CreateSteamWebInterface<SteamUser>(new HttpClient());
        if (DataHolder.User1.Length == 17 && DataHolder.User1.All(char.IsDigit))
        {
            var ownedGames = await playerServiceInterface.GetOwnedGamesAsync(Convert.ToUInt64(DataHolder.User1),true,true);
            if (ownedGames.Data.GameCount == 0)
            {
                StatusText = "";
                InvalidText = "User 1 is not valid or has no games, ensure User 1 is correct and try again";
                ButtonEnabled = true;
                return;
            }
            foreach (var ownedGame in ownedGames.Data.OwnedGames)
            {
                user1Games.Add(ownedGame.Name);
            }
        }
        else
        {
            ISteamWebResponse<OwnedGamesResultModel> ownedGames;
            try
            {
                var user1ID = await steamUserInterface.ResolveVanityUrlAsync(DataHolder.User1);
                ownedGames = await playerServiceInterface.GetOwnedGamesAsync(user1ID.Data,true,true);
            }
            catch (Exception e)
            {
                StatusText = "";
                InvalidText = "User 1 is not valid, ensure User 1 is correct and try again";
                ButtonEnabled = true;
                Debug.WriteLine(e);
                return;
            }
            if (ownedGames.Data.GameCount == 0)
            {
                StatusText = "";
                InvalidText = "User 1 has no games, ensure User 1 is correct and try again";
                ButtonEnabled = true;
                return;
            }
            foreach (var ownedGame in ownedGames.Data.OwnedGames)
            {
                user1Games.Add(ownedGame.Name);
            }
        }
        if (DataHolder.User2.Length == 17 && DataHolder.User2.All(char.IsDigit))
        {
            var ownedGames = await playerServiceInterface.GetOwnedGamesAsync(Convert.ToUInt64(DataHolder.User2),true,true);
            if (ownedGames.Data.GameCount == 0)
            {
                StatusText = "";
                InvalidText = "User 2 is not valid or has no games, ensure User 2 is correct and try again";
                ButtonEnabled = true;
                return;
            }
            foreach (var ownedGame in ownedGames.Data.OwnedGames)
            {
                user2Games.Add(ownedGame.Name);
            }
        }
        else
        {
            ISteamWebResponse<OwnedGamesResultModel> ownedGames;
            try
            {
                var user2ID = await steamUserInterface.ResolveVanityUrlAsync(DataHolder.User2);
                ownedGames = await playerServiceInterface.GetOwnedGamesAsync(user2ID.Data,true,true);
            }
            catch (Exception e)
            {
                StatusText = "";
                InvalidText = "User 2 is not valid, ensure User 2 is correct and try again";
                ButtonEnabled = true;
                Debug.WriteLine(e);
                return;
            }
            if (ownedGames.Data.GameCount == 0)
            {
                StatusText = "";
                InvalidText = "User 2 has no games, ensure User 2 is correct and try again";
                ButtonEnabled = true;
                return;
            }
            foreach (var ownedGame in ownedGames.Data.OwnedGames)
            {
                user2Games.Add(ownedGame.Name);
            }
        }

        StatusText = "Parsing Results...";
        var combinedGames = user1Games.Intersect(user2Games);
        foreach (var combinedGame in combinedGames)
            Games.Add(combinedGame);
        StatusText = "Have Fun!";
        ButtonEnabled = true;
    }
}