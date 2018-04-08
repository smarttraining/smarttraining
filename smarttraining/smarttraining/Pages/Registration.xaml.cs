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
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
        }
       
        async void Reg(object sender, EventArgs e)
        {
			if (Email.Text == null || Email.Text.Equals(""))
			{
				await DisplayAlert("Ошибка", "Email должен быть указан", "ОК");
			}
			else if (Password.Text == null || Password.Text.Equals(""))
			{
				await DisplayAlert("Ошибка", "Password должен быть указан", "ОК");
			}

			else
			{
				if (Password.Text.Length < 3)
				{
				await DisplayAlert("Ошибка", "Пароль слишком короткий", "ОК");
				}
				else if(!Email.Text.Contains("@"))
				{
					await DisplayAlert("Ошибка", "Указанный email неправильный", "ОК");
				}
				else
				{
					if (!Password.Text.Equals(PasswordCheck.Text))
					{
						await DisplayAlert("Ошибка", "Указанный email неправильный", "ОК");
					}
					else
					{
						User.Register(Email.Text, Password.Text);
						User.Login(Email.Text, Password.Text);
						await Navigation.PushModalAsync(new Registration2(User.profile.U_Id, User.profile.U_Key));
					}
				}
			}
        }
    }
}
