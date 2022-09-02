using System.Diagnostics;
using System.Runtime.InteropServices;
using SteamCompare.Classes;
using SteamCompare.ViewModel;
using ServiceProvider = SteamCompare.Classes.ServiceProvider;

namespace SteamCompare;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(SettingsPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        if (!OperatingSystem.IsMacCatalyst() && !OperatingSystem.IsWindows())
            NotifyButton.IsEnabled = false;
        //BlackButton.IsChecked = true;
    }

    private void NotificationToggle(object sender, EventArgs e)
    {
        if (!DataHolder.NotificationsEnabled)
        {
            try
            {
                ServiceProvider.GetService<INotificationService>()
                    ?.ShowNotification("Notifications Enabled", "Notifications will now appear when getting results.");
            }
            catch (Exception exception)
            {
                ErrorText.Text = "Notifications were unable to be turned on";
                Debug.WriteLine(exception);
                return;
            }
            DataHolder.NotificationsEnabled = true;
            NotifyButton.Text = "Disable Notifications";
        }
        else
        {
            Debug.WriteLine("Notifications is {0}", DataHolder.NotificationsEnabled);
            try
            {
                ServiceProvider.GetService<INotificationService>()
                    ?.ShowNotification("Notifications Disabled", "Notifications will no longer appear when getting results.");
            }
            catch (Exception exception)
            {
                ErrorText.Text = "An error occurred while attempting to send notification, disabling";
                Debug.WriteLine(exception);
                return;
            }
            DataHolder.NotificationsEnabled = false;
            NotifyButton.Text = "Enable Notifications";
        }

    }

    // public void ChangeColor(object sender, CheckedChangedEventArgs e)
    // {
    //     if (RedButton.IsChecked == true)
    //     {
    //         App.Current.Resources["Primary"] = "#aa2e25";
    //         App.Current.Resources["Secondary"] = "#f44336";
    //         App.Current.Resources["Tertiary"] = "#aa2e25";
    //         Debug.WriteLine(App.Current.Resources["Primary"]);
    //     }
    // }
}