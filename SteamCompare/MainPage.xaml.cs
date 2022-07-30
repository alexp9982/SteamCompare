using SteamCompare.ViewModel;

namespace SteamCompare;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	// private void OnCounterClicked(object sender, EventArgs e)
	// {
	// 	count++;
	//
	// 	if (count == 1)
	// 		CounterBtn.Text = $"Clicked {count} time";
	// 	else
	// 		CounterBtn.Text = $"Clicked {count} times";
	//
	// 	SemanticScreenReader.Announce(CounterBtn.Text);
	// }
}

