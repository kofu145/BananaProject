using BananaProject.ViewModels;
using System.Globalization;

namespace BananaProject.Views;

public partial class EventPage : ContentPage
{
	public EventPage(EventViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

		string[] facts = new string[]
		{
			"Dogs sweat through their footpads to keep cold",
			"Dogs have completely unique nose prints",
			"Cats have 32 muscles in each ear",
            "Cats have over one hundred vocal sounds (dogs have ten!)",
			"Fleas can jump 350 times its body length",
			"Starfish do not have a brain",
			"Slugs have 4 noses",
			"Polar bear skin is black, not white",
			"Hummingbirds are the only birds that can fly backwards",
			"Ostrich's have eyes bigger than their brain",
			"Dragonflies can see in all directions at the same time",
            "You can tell the age of a whale by looking at the wax plug in its ear"
        };


        // Get the current date and time
        DateTime currentDate = DateTime.Now;
        Calendar calendar = CultureInfo.CurrentCulture.Calendar;
        int weekOfYear = calendar.GetMonth(currentDate);

		factOfTheWeekBox.Text = facts[weekOfYear - 1];
	}
}