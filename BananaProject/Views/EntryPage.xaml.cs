using BananaProject.ViewModels;

namespace BananaProject.Views;

public partial class EntryPage : ContentPage
{
	public EntryPage(EntryViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
        //Shell.SetTabBarIsVisible(Application.Current.MainPage, false);
        userNameInput.TextChanged += UserNameInput_TextChanged;
    }

    private void UserNameInput_TextChanged(object sender, TextChangedEventArgs e)
    {
        Entry eSender = (Entry)sender;
        string input = eSender.Text;
        if (input.Length == 0)
        {
            signInButton.BackgroundColor = Color.FromRgb(100, 100, 100);
            newAccountButton.BackgroundColor = Color.FromRgb(100, 100, 100);
        } else
        {
            signInButton.BackgroundColor = Color.FromRgb(38, 127, 0);
            newAccountButton.BackgroundColor = Color.FromRgb(38, 127, 0);
        }
    }
}