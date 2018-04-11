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
	public partial class MyEvents : ContentPage
	{
		public MyEvents ()
		{
			InitializeComponent ();
            var events=Event.GetAllEvents();
            foreach (var even in events)
            {

                var button = new Button
                {
                    HeightRequest = 200,
                    Image = even.E_pic,
                    Text = even.E_Name
                };
                eventslo.Children.Add(button);
            }
        }
	}
}