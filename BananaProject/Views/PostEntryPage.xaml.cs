using BananaProject.ViewModels;

namespace BananaProject.Views;

public partial class PostEntryPage : ContentPage
{
	public PostEntryPage(PostEntryViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}