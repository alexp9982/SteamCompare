namespace SteamCompare;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ComparePage), typeof(ComparePage));
        Routing.RegisterRoute(nameof(ListPage), typeof(ListPage));
    }
}
