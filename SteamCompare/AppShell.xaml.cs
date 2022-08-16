namespace SteamCompare;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        Routing.RegisterRoute(nameof(KeyPage), typeof(KeyPage));
        Routing.RegisterRoute(nameof(ComparePage), typeof(ComparePage));
		Routing.RegisterRoute(nameof(ListPage), typeof(ListPage));
	}
}
