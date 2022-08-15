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
using SteamKit2;
using static SteamKit2.GC.Dota.Internal.CMsgDOTAFrostivusTimeElapsed;

namespace SteamCompare.ViewModel;

[QueryProperty(nameof(User1), "User1")]
[QueryProperty(nameof(User2), "User2")]
[QueryProperty(nameof(Apikey), "Apikey")]

public partial class ListPageViewModel : ObservableObject
{
    [ObservableProperty]
    string user1;

    [ObservableProperty]
    string user2;

    [ObservableProperty]
    bool buttonEnabled;

    [ObservableProperty] 
    string apikey;

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

    [RelayCommand]
    Task Navigate() => Shell.Current.GoToAsync(nameof(ComparePage));

    [RelayCommand]
    void DebugWrite()
    {
        // dynamic playerService = WebAPI.GetInterface("IPlayerService", apikey);
        // KeyValue ownedGames = playerService.GetOwnedGames(steamid: Convert.ToUInt64(user1),
        //     include_appinfo: true, include_played_free_games: true);
        // Debug.Write(ownedGames);
        List<string> userGames = Class1.Bob(user1, apikey);
        Debug.Write(userGames);
        return;
    }

    [RelayCommand]
    async Task GetResults()
    {
        var user1a = user1;
        var user2a = user2;
        var apikeya = apikey;
        ButtonEnabled = false;
        InvalidText = "";
        StatusText = "Preparing...";
        Games.Clear();
        List<string> user1Games = new List<string>();
        List<string> user2Games = new List<string>();
        StatusText = "Checking input...";
        //using dynamic playerService = WebAPI.GetInterface("IPlayerService", apikey);
        //using dynamic steamUser = WebAPI.GetInterface("ISteamUser", apikey);
        try
        {
            KeyValue ownedGames;
            if (user1a.Length == 17 && user1a.All(char.IsDigit))
            {
                using (dynamic playerService = WebAPI.GetInterface("IPlayerService", apikeya))
                {
                    ownedGames = playerService.GetOwnedGames(steamid: Convert.ToUInt64(user1a),
                        include_appinfo: true, include_played_free_games: true);
                }
                var gameCount = ownedGames[ "game_count" ].AsString();
                if (string.IsNullOrWhiteSpace(gameCount))
                {
                    StatusText = "";
                    InvalidText = "User 1 is not valid or has no games, ensure User 1 is correct and try again";
                    ButtonEnabled = true;
                    return;
                }
            }

            else
            {
                string user1AsString;
                using (dynamic steamUser = WebAPI.GetInterface("ISteamUser", apikeya))
                {
                    KeyValue steamId = await steamUser.ResolveVanityURL(vanityurl: user1a);
                    user1AsString = (steamId[ "steamid" ].AsString());
                    if (string.IsNullOrWhiteSpace(user1AsString))
                    {
                        StatusText = "";
                        InvalidText = "User 1 is not valid, ensure User 1 is correct and try again";
                        ButtonEnabled = true;
                        return;
                    }
                }

                using (dynamic playerService = WebAPI.GetInterface("IPlayerService", apikeya))
                {
                    ownedGames = playerService.GetOwnedGames(steamid: Convert.ToUInt64(user1AsString),
                        include_appinfo: true, include_played_free_games: true);
                }

                var gameCount = ownedGames[ "game_count" ].AsString();
                if (string.IsNullOrWhiteSpace(gameCount))
                {
                    StatusText = "";
                    InvalidText = "User 1 has no games, ensure User 1 is correct and try again";
                    ButtonEnabled = true;
                    return;
                }
            }

            foreach (var userGames in ownedGames[" games "].Children)
            {
                user1Games.Add(userGames[" name "].AsString());
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            StatusText = "";
            InvalidText = "Your API key is not valid. Ensure you followed the instructions correctly and try again";
            ButtonEnabled = true;
            return;
        }
        /*try
        {
            KeyValue ownedGames;
            if (user2.Length == 17 && user2.All(char.IsDigit))
            {
                ownedGames = playerService.GetOwnedGames(steamid: Convert.ToUInt64(user2),
                    include_appinfo: true, include_played_free_games: true);
                var gameCount = ownedGames[ "game_count" ].AsString();
                if (string.IsNullOrWhiteSpace(gameCount))
                {
                    StatusText = "";
                    InvalidText = "User 2 is not valid or has no games, ensure User 2 is correct and try again";
                    ButtonEnabled = true;
                    return Task.CompletedTask;
                }
            }

            else
            {
                KeyValue steamId = steamUser.ResolveVanityURL(vanityurl: user2);
                var user2AsString = (steamId[ "steamid" ].AsString());
                if (string.IsNullOrWhiteSpace(user2AsString))
                {
                    StatusText = "";
                    InvalidText = "User 2 is not valid, ensure User 2 is correct and try again";
                    ButtonEnabled = true;
                    return Task.CompletedTask;
                }
                ownedGames = playerService.GetOwnedGames(steamid: Convert.ToUInt64(user2AsString),
                    include_appinfo: true, include_played_free_games: true);
                var gameCount = ownedGames[ "game_count" ].AsString();
                if (string.IsNullOrWhiteSpace(gameCount))
                {
                    StatusText = "";
                    InvalidText = "User 2 has no games, ensure User 2 is correct and try again";
                    ButtonEnabled = true;
                    return Task.CompletedTask;
                }
            }

            foreach (var userGames in ownedGames[" games "].Children)
            {
                user2Games.Add(userGames[" name "].AsString());
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            StatusText = "";
            InvalidText = "Your API key is not valid. Ensure you followed the instructions correctly and try again";
            ButtonEnabled = true;
            return Task.CompletedTask;
        }*/

        StatusText = "Parsing Results...";
        var combinedGames = user1Games.Intersect(user2Games);
        foreach (var combinedGame in combinedGames)
            Games.Add(combinedGame);
        StatusText = "Have Fun!";
        ButtonEnabled = true;
        return;
    }
}