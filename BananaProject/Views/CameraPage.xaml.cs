using BananaProject.ViewModels;

namespace BananaProject.Views;

public partial class CameraPage : ContentPage
{
	

	public CameraPage(CameraViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
