using SteamCompare.ViewModel;
namespace SteamCompare;

public partial class ListPage : ContentPage
{
    public ListPage(ListPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}