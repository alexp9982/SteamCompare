using Steam.Models.SteamCommunity;
using SteamCompare.Classes;
using SteamCompare.ViewModel;
using SteamWebAPI2.Interfaces;

using SteamWebAPI2.Utilities;

using System.Diagnostics;
using ServiceProvider = SteamCompare.Classes.ServiceProvider;

namespace SteamCompare;

public partial class ListPage : ContentPage
{
    public ListPage(ListPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        DataHolder.Games.Clear();
        GamesCollection.ItemsSource = DataHolder.Games;
        ProgressBar.IsVisible = false;
    }

    private async void GetResults(object sender, EventArgs e)
    {
        ResultsButton.IsEnabled = false;
        ProgressBar.IsVisible = true;
        await ProgressBar.ProgressTo(0, 1, Easing.Linear);
        InvalidTextLabel.Text = "";
        StatusTextLabel.Text = "Preparing...";
        DataHolder.Games.Clear();
        GamesCollection.ItemsSource = DataHolder.Games;
        List<string> user1Games = new List<string>();
        List<string> user2Games = new List<string>();
        StatusTextLabel.Text = "Checking API Key...";
#pragma warning disable CS4014 // Because this call is not awaited
        ProgressBar.ProgressTo(0.1, 500, Easing.Linear);
        SteamWebInterfaceFactory webInterfaceFactory;
        try
        {
            webInterfaceFactory = new SteamWebInterfaceFactory(DataHolder.ApiKey);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            StatusTextLabel.Text = "";
            InvalidTextLabel.Text =
                "Your API key is not valid. Ensure you followed the instructions correctly and try again";
            ResultsButton.IsEnabled = true;
            if (!DataHolder.NotificationsEnabled) return;
            try
            {
                ServiceProvider.GetService<INotificationService>()
                    ?.ShowNotification("Results Failed", "Results failed to compile due to an error, view the text next to the Get Results button");
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
            return;
        }

        ProgressBar.ProgressTo(0.25, 500, Easing.Linear);
        StatusTextLabel.Text = "Verifying API key and users...";

        var playerServiceInterface = webInterfaceFactory.CreateSteamWebInterface<PlayerService>(new HttpClient());
        var steamUserInterface = webInterfaceFactory.CreateSteamWebInterface<SteamUser>(new HttpClient());
        ProgressBar.ProgressTo(0.30, 500, Easing.Linear);
        if (DataHolder.User1.Length == 17 && DataHolder.User1.All(char.IsDigit))
        {
            var ownedGames =
                await playerServiceInterface.GetOwnedGamesAsync(Convert.ToUInt64(DataHolder.User1), true, true);
            if (ownedGames.Data.GameCount == 0)
            {
                StatusTextLabel.Text = "";
                InvalidTextLabel.Text = "User 1 is not valid or has no games, ensure User 1 is correct and try again";
                ResultsButton.IsEnabled = true;
                if (!DataHolder.NotificationsEnabled) return;
                try
                {
                    ServiceProvider.GetService<INotificationService>()
                        ?.ShowNotification("Results Failed", "Results failed to compile due to an error, view the text next to the Get Results button");
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                }
                return;
            }

            ProgressBar.ProgressTo(0.6, 500, Easing.Linear);
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
                ProgressBar.ProgressTo(0.45, 500, Easing.Linear);
                ownedGames = await playerServiceInterface.GetOwnedGamesAsync(user1ID.Data, true, true);
            }
            catch (Exception ex)
            {
                StatusTextLabel.Text = "";
                InvalidTextLabel.Text = "User 1 is not valid, ensure User 1 is correct and try again";
                ResultsButton.IsEnabled = true;
                Debug.WriteLine(ex);
                if (!DataHolder.NotificationsEnabled) return;
                try
                {
                    ServiceProvider.GetService<INotificationService>()
                        ?.ShowNotification("Results Failed", "Results failed to compile due to an error, view the text next to the Get Results button");
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                }
                return;
            }

            if (ownedGames.Data.GameCount == 0)
            {
                StatusTextLabel.Text = "";
                InvalidTextLabel.Text = "User 1 has no games, ensure User 1 is correct and try again";
                ResultsButton.IsEnabled = true;
                if (!DataHolder.NotificationsEnabled) return;
                try
                {
                    ServiceProvider.GetService<INotificationService>()
                        ?.ShowNotification("Results Failed", "Results failed to compile due to an error, view the text next to the Get Results button");
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                }
                return;
            }

            ProgressBar.ProgressTo(0.6, 500, Easing.Linear);
            foreach (var ownedGame in ownedGames.Data.OwnedGames)
            {
                user1Games.Add(ownedGame.Name);
            }
        }

        if (DataHolder.User2.Length == 17 && DataHolder.User2.All(char.IsDigit))
        {
            var ownedGames =
                await playerServiceInterface.GetOwnedGamesAsync(Convert.ToUInt64(DataHolder.User2), true, true);
            if (ownedGames.Data.GameCount == 0)
            {
                StatusTextLabel.Text = "";
                InvalidTextLabel.Text = "User 2 is not valid or has no games, ensure User 2 is correct and try again";
                ResultsButton.IsEnabled = true;
                if (!DataHolder.NotificationsEnabled) return;
                try
                {
                    ServiceProvider.GetService<INotificationService>()
                        ?.ShowNotification("Results Failed", "Results failed to compile due to an error, view the text next to the Get Results button");
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                }
                return;
            }

            ProgressBar.ProgressTo(0.9, 500, Easing.Linear);
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
                ProgressBar.ProgressTo(0.75, 500, Easing.Linear);
                ownedGames = await playerServiceInterface.GetOwnedGamesAsync(user2ID.Data, true, true);
            }
            catch (Exception ex)
            {
                StatusTextLabel.Text = "";
                InvalidTextLabel.Text = "User 2 is not valid, ensure User 2 is correct and try again";
                ResultsButton.IsEnabled = true;
                Debug.WriteLine(ex);
                if (!DataHolder.NotificationsEnabled) return;
                try
                {
                    ServiceProvider.GetService<INotificationService>()
                        ?.ShowNotification("Results Failed", "Results failed to compile due to an error, view the text next to the Get Results button");
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                }
                return;
            }

            if (ownedGames.Data.GameCount == 0)
            {
                StatusTextLabel.Text = "";
                InvalidTextLabel.Text = "User 2 has no games, ensure User 2 is correct and try again";
                ResultsButton.IsEnabled = true;
                if (!DataHolder.NotificationsEnabled) return;
                try
                {
                    ServiceProvider.GetService<INotificationService>()
                        ?.ShowNotification("Results Failed", "Results failed to compile due to an error, view the text next to the Get Results button");
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                }
                return;
            }

            ProgressBar.ProgressTo(0.9, 500, Easing.Linear);
            foreach (var ownedGame in ownedGames.Data.OwnedGames)
            {
                user2Games.Add(ownedGame.Name);
            }
        }

        StatusTextLabel.Text = "Parsing Results...";
        var combinedGames = user1Games.Intersect(user2Games);
        foreach (var combinedGame in combinedGames)
            DataHolder.Games.Add(combinedGame);
        GamesCollection.ItemsSource = DataHolder.Games;
        StatusTextLabel.Text = "Have Fun!";
        ResultsButton.IsEnabled = true;
        ProgressBar.ProgressTo(1, 500, Easing.Linear);
        if (!DataHolder.NotificationsEnabled) return;
        try
        {
            ServiceProvider.GetService<INotificationService>()
                ?.ShowNotification("Results Compiled", "Results are complete and available for viewing");
        }
        catch (Exception exception)
        {
            Debug.WriteLine(exception);
        }
#pragma warning restore CS4014
    }
}