using BananaProject.Views;

namespace BananaProject;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(MessageBoard), typeof(MessageBoard));
	}
}

