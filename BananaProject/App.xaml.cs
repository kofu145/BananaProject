using BananaProject.ViewModels;
using BananaProject.Views;

namespace BananaProject;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new EntryPage(new EntryViewModel());
	}
}

