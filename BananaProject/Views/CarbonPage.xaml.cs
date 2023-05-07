using Android.Icu.Util;
using Javax.Security.Auth;
using System.Globalization;
using Xamarin.Google.Crypto.Tink.Shaded.Protobuf;

namespace BananaProject.Views;

public partial class CarbonPage : ContentPage
{
    int ngasBill = 0;
    int electBill = 0;
    int oilBill = 0;
    int propaneBill = 0;

    double ngasTocarbon;
    double electTocarbon;
    double oilTocarbon;
    double propaneTocarbon;

    public CarbonPage()
	{
		InitializeComponent();

		// get current week as an int
		DateTime current = System.DateTime.Today;
		System.Globalization.Calendar cal = CultureInfo.CurrentCulture.Calendar;
		int curWeek = cal.GetWeekOfYear(current, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

		


		ngas.Completed += (sender, e) =>
		{
            ngasBill = Convert.ToInt32(ngas.Text);
            ngasTocarbon = (ngasBill) * (3071) / 23;
            ngas.Unfocus();
            elect.Focus();
            UpdateResult();
        };

		elect.Completed += (sender, e) =>
		{
            electBill = Convert.ToInt32(elect.Text);
            electTocarbon = (electBill) * 5384 / 44;
            elect.Unfocus();
			oil.Focus();
            UpdateResult();
        };

        oil.Completed += (sender, e) =>
        {
            oilBill = Convert.ToInt32(oil.Text);
            oilTocarbon = (oilBill) * 4848 / 72;
            oil.Unfocus();
            propane.Focus();
            UpdateResult();
        };

        propane.Completed += (sender, e) =>
		{
            propaneBill = Convert.ToInt32(propane.Text);
            propaneTocarbon = (propaneBill) * 2243 / 37;
            propane.Unfocus();
            UpdateResult();
        };


        
    }

    private void CommandEnter(object sender, EventArgs e)
	{
		Entry input = (Entry)sender;
		input.Unfocus();
	}
	private void UpdateResult()
	{
        double totalPoundsOfCarbon = (ngasTocarbon + electTocarbon + oilTocarbon + propaneTocarbon);
        result.Text = totalPoundsOfCarbon.ToString() + " pounds of CO2 every year, or roughly " + (totalPoundsOfCarbon / 48).ToString() + " trees!";
    }
}