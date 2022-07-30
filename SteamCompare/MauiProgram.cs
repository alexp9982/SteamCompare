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

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainPageViewModel>();

		builder.Services.AddSingleton<ComparePage>();
		builder.Services.AddSingleton<ComparePageViewModel>();

		builder.Services.AddTransient<ListPage>();
		builder.Services.AddTransient<ListPageViewModel>();

		return builder.Build();
	}
}
