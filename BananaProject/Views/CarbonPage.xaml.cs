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

    const double CARBON_EMISSIONS_PER_DOLLAR_NATURAL_GAS = 3071 / 23;
    const double CARBON_EMISSIONS_PER_DOLLAR_ELECTRICITY = 5384 / 44;
    const double CARBON_EMISSIONS_PER_DOLLAR_FUEL_OIL = 4848 / 72;
    const double CARBON_EMISSIONS_PER_DOLLAR_PROPANE = 2243 / 37;


    public CarbonPage()
	{
		InitializeComponent();	


		ngas.Completed += (sender, e) =>
		{
            ngasBill = Convert.ToInt32(ngas.Text);
            ngasTocarbon = (ngasBill) * CARBON_EMISSIONS_PER_DOLLAR_NATURAL_GAS;
            ngas.Unfocus();
            elect.Focus();
            UpdateResult();
        };

		elect.Completed += (sender, e) =>
		{
            electBill = Convert.ToInt32(elect.Text);
            electTocarbon = (electBill) * CARBON_EMISSIONS_PER_DOLLAR_ELECTRICITY;
            elect.Unfocus();
			oil.Focus();
            UpdateResult();
        };

        oil.Completed += (sender, e) =>
        {
            oilBill = Convert.ToInt32(oil.Text);
            oilTocarbon = (oilBill) * CARBON_EMISSIONS_PER_DOLLAR_FUEL_OIL;
            oil.Unfocus();
            propane.Focus();
            UpdateResult();
        };

        propane.Completed += (sender, e) =>
		{
            propaneBill = Convert.ToInt32(propane.Text);
            propaneTocarbon = (propaneBill) * CARBON_EMISSIONS_PER_DOLLAR_PROPANE;
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
        poundsOfCarbon.Text = totalPoundsOfCarbon.ToString();
        treesOfCarbon.Text = ((int)(totalPoundsOfCarbon/48)).ToString();
    }
}