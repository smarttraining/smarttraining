using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;

namespace App9
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class About : ContentPage
	{
		public string Sea = "";
		public About ()
		{
			InitializeComponent();
			buttonScan.Clicked += Go_Scan;
			var map = new Map(MapSpan.FromCenterAndRadius(new Position(36.8961, 10.1865), Distance.FromKilometers(0.5))){
				IsShowingUser = true,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			var position1 = new Position(36.8961, 10.1865);
			var pin1 = new Pin {
				Type = PinType.Place,
				Position = position1,
				Label = "Somewhere",
				Address = "Smart"
			};
			
		}

		async void Go_Scan(object sender, EventArgs e)
		{

#if __ANDROID__
			// Initialize the scanner first so it can track the current context
			//MobileBarcodeScanner.Initialize(Application);
#endif

			var scanner = new ZXing.Mobile.MobileBarcodeScanner();

			var result = await scanner.Scan();

			if (result != null)
			{
				Materials.AddMaterial(result.Text);
				ScanShow.Text = result.Text;
			}
		}
	
		async void Go_Search(object sender, EventArgs e)
		{
			//await Navigation.PushModalAsync(new Search(Search.Text.ToString()));
		}



	}
}