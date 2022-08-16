using CommunityToolkit.WinUI.Notifications;
using SteamCompare.Classes;

namespace SteamCompare.WinUI;

public class NotificationService : INotificationService
{
    public void ShowNotification(string title, string body)
    {
        if (OperatingSystem.IsWindowsVersionAtLeast(10, 0 ,18362, 0))
            new ToastContentBuilder()
                .AddToastActivationInfo(null, ToastActivationType.Foreground)
                .AddText(title, hintStyle: AdaptiveTextStyle.Header)
                .AddText(body, hintStyle: AdaptiveTextStyle.Body)
                .Show();
    }
}
