using SteamCompare.ViewModel;

namespace SteamCompare;

public partial class ComparePage : ContentPage
{
	public bool User1Entered = false;
	public bool User2Entered = false;
	public string User1Text;
	public string User2Text;

	public ComparePage(ComparePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	public void OnText1Changed(object sender, TextChangedEventArgs e)
	{
		var newText = e.NewTextValue;
		if (!string.IsNullOrWhiteSpace(newText))
		{
			User1Entered = true;
		}
		else
			User1Entered = false;
		User1Text = newText;
		if (User1Entered && User2Entered)
		{
			CompareButton.IsEnabled = true;
		}
		else
			CompareButton.IsEnabled = false;
	}

	public void OnText2Changed(object sender, TextChangedEventArgs e)
	{
		var newText = e.NewTextValue;
		if (!string.IsNullOrWhiteSpace(newText))
		{
			User2Entered = true;
		}
		else
			User2Entered = false;
		User2Text = newText;
		if (User1Entered && User2Entered)
		{
			CompareButton.IsEnabled=true;
		}
		else
			CompareButton.IsEnabled=false;
	}
}