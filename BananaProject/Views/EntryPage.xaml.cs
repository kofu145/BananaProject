using BananaProject.ViewModels;

namespace BananaProject.Views;

public partial class EntryPage : ContentPage
{
	public EntryPage(EntryViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		//Shell.SetTabBarIsVisible(Application.Current.MainPage, false);
		

    }
}