using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace smarttraining
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Email.Completed += (s, e) => {
                Password.Focus();
            };


            //Image1.Aspect = Aspect.AspectFill; 
        }

        async void Go_login(object sender, EventArgs e)
        {
            //if(!Email.Text.Equals("") && !Password.Text.Equals(""))
            //{
            var loginKey = User.Login(Email.Text, Password.Text);
            if (!loginKey.Contains("Error"))
            {
                await Navigation.PushModalAsync(new Home(), false);
                //loginPg
            }
            else
            {
                await Navigation.PushModalAsync(new Events());
            }
            //}    
            // sdt
        }

        async void Go_reg(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Registration());
        }
     
    

}
}
