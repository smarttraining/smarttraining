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
	public partial class Registration2 : ContentPage
	{
		public Registration2 (int id, string key)
		{
			InitializeComponent ();
			
		}

        async void Reg2(object sender, EventArgs e)
        {
            
        }
    }
}