using SteamCompare.ViewModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SteamCompare;

public partial class KeyPage : ContentPage
{
    public KeyPage(KeyPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        ContinueButton.IsEnabled = false;
    }

    public void OnText1Changed(object sender, TextChangedEventArgs e)
    {
        var newText = e.NewTextValue;
        if (!string.IsNullOrWhiteSpace(newText))
        {
            ContinueButton.IsEnabled = true;
        }
        else
            ContinueButton.IsEnabled = false;
    }

    async void GoToURL(object sender, EventArgs args)
    {
        UrlButton.IsEnabled = false;
        var answer = await DisplayAlert("Confirm", "Are you sure you want to open 'https://steamcommunity.com/dev/apikey' in your browser?", "Yes", "No");
        if (answer)
        {
            var url = "https://steamcommunity.com/dev/apikey";
            try
            {
                if (OperatingSystem.IsWindows())
                    Process.Start(url);
                else if (OperatingSystem.IsMacCatalyst())
                    await Browser.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
                else if (OperatingSystem.IsIOS() && (OperatingSystem.IsIOSVersionAtLeast(10)))
                    //await Launcher.OpenAsync(url);
                    await Browser.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
                else if (OperatingSystem.IsAndroid())
                    await Browser.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (OperatingSystem.IsWindows())
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (OperatingSystem.IsIOS())
                {
                    await Launcher.OpenAsync(url);
                }
                else if (OperatingSystem.IsMacCatalyst())
                {
                    Process.Start("open", url);
                }
                else
                {
                    await DisplayAlert("Alert", "Unable to open webpage, please create an issue on GitHub", "OK");
                }
            }
            UrlButton.IsEnabled = true;
            return;
        }
        else
        {
            UrlButton.IsEnabled = true;
            return;
        }
    }
}