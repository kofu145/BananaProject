using BananaProject.ViewModels;

namespace BananaProject.Views;

public partial class MessageBoard : ContentPage
{

	public MessageBoard(MessageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
