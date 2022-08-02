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
            string url = "https://steamcommunity.com/dev/apikey";
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    await DisplayAlert("Alert", "Unable to open webpage", "OK");
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