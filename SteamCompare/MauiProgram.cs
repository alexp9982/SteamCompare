using SteamCompare.Classes;
using SteamCompare.ViewModel;

namespace SteamCompare;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if WINDOWS
        builder.Services.AddSingleton<INotificationService, WinUI.NotificationService>();
#elif MACCATALYST
        builder.Services.AddSingleton<INotificationService, MacCatalyst.NotificationService>();
#endif

        builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainPageViewModel>();

        builder.Services.AddSingleton<SettingsPage>();
        builder.Services.AddSingleton<SettingsPageViewModel>();

        builder.Services.AddSingleton<KeyPage>();
        builder.Services.AddSingleton<KeyPageViewModel>();

        builder.Services.AddSingleton<ComparePage>();
		builder.Services.AddSingleton<ComparePageViewModel>();

		builder.Services.AddTransient<ListPage>();
		builder.Services.AddTransient<ListPageViewModel>();

        SettingsHolder.NotificationsEnabled = false;

		return builder.Build();
	}
}
