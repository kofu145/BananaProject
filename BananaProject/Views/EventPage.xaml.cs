using BananaProject.ViewModels;

namespace BananaProject.Views;

public partial class EventPage : ContentPage
{
	public EventPage(EventViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}