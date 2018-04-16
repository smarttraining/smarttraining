using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace smarttraining
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Search : ContentPage
	{
		public Search(string SV)
		{
			InitializeComponent();
			var events = Event.GetSearchEvents(SV);
			foreach (var even in events)
			{

				var button = new Button
				{
					HeightRequest = 200,
					Image = even.E_pic,
					Text = Convert.ToString(even.E_id)

				};
				
				button.Clicked += async (s, e) =>
				{
					await Navigation.PushAsync(new EventPage(Int32.Parse(button.Text)), false);
				};
			}


		}

		private void InitializeComponent()
		{
			throw new NotImplementedException();
		}

		async void Go_EventPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new EventPage(), false);
		}

		async void Go_MainPage(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new MainPage(), false);

		}

		//async void Go_EventPage(object sender, EventArgs e)
		//{

		//    Detail = new NavigationPage(new EventPage());
		//    IsPresented = false;

		//}
	}
}