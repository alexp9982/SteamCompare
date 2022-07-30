using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Steam.Models.SteamCommunity;
using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;

namespace SteamCompare.ViewModel;

[QueryProperty(nameof(User1), "User1")]
[QueryProperty(nameof(User2), "User2")]

public partial class ListPageViewModel : ObservableObject
{
    SteamWebInterfaceFactory webInterfaceFactory = new SteamWebInterfaceFactory("CC0DC2D00878429DC7C1B02246A9CDFE");

    [ObservableProperty]
    string user1;

    [ObservableProperty]
    string user2;

    [ObservableProperty]
    bool buttonEnabled;

    //Waiting for Results...
    [ObservableProperty] private string statusText;

    //One of the entered users is not valid! Go back and try again
    [ObservableProperty] private string invalidText;

    [ObservableProperty]
    ObservableCollection<string> games;

    public ListPageViewModel()
    {
        Games = new ObservableCollection<string>();
        ButtonEnabled = true;
        string user2actual = user2;
    }

    [ICommand]
    Task Navigate() => Shell.Current.GoToAsync(nameof(ComparePage));

    [ICommand]
    async Task GetResults()
    {
        ButtonEnabled = false;
        InvalidText = "";
        StatusText = "Preparing...";
        Games.Clear();
        List<string> user1Games = new List<string>();
        List<string> user2Games = new List<string>();
        StatusText = "Checking users...";

        var playerServiceInterface = webInterfaceFactory.CreateSteamWebInterface<PlayerService>(new HttpClient());
        var steamUserInterface = webInterfaceFactory.CreateSteamWebInterface<SteamUser>(new HttpClient());
        if (user1.Length == 17 && user1.All(char.IsDigit))
        {
            var ownedGames = await playerServiceInterface.GetOwnedGamesAsync(Convert.ToUInt64(user1),true,true);
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
                var user1ID = await steamUserInterface.ResolveVanityUrlAsync(user1);
                ownedGames = await playerServiceInterface.GetOwnedGamesAsync(user1ID.Data,true,true);
            }
            catch (Exception e)
            {
                StatusText = "";
                InvalidText = "User 1 is not valid, ensure User 1 is correct and try again";
                ButtonEnabled = true;
                Console.WriteLine(e);
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
        if (user2.Length == 17 && user2.All(char.IsDigit))
        {
            var ownedGames = await playerServiceInterface.GetOwnedGamesAsync(Convert.ToUInt64(user2),true,true);
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
                var user2ID = await steamUserInterface.ResolveVanityUrlAsync(user2);
                ownedGames = await playerServiceInterface.GetOwnedGamesAsync(user2ID.Data,true,true);
            }
            catch (Exception e)
            {
                StatusText = "";
                InvalidText = "User 2 is not valid, ensure User 2 is correct and try again";
                ButtonEnabled = true;
                Console.WriteLine(e);
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