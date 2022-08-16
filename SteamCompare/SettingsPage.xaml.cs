using System.Diagnostics;
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
    }

    private void NotificationToggle(object sender, EventArgs e)
    {
        if (!SettingsHolder.NotificationsEnabled)
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
            SettingsHolder.NotificationsEnabled = true;
            NotifyButton.Text = "Disable Notifications";
        }
        else
        {
            Debug.WriteLine("Notifications is {0}", SettingsHolder.NotificationsEnabled);
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
            SettingsHolder.NotificationsEnabled = false;
            NotifyButton.Text = "Enable Notifications";
        }

    }
}