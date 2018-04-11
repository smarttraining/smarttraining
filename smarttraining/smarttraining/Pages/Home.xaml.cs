using smarttraining;    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace smarttraining
{

    public partial class Home : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public DataTemplate ItemTemplate { get; }
    

        private Label _previousLabel;
    public Home ()
		{	
             
			InitializeComponent ();

            /*  NavigationPage.SetHasNavigationBar(this, false);*/ // This removes Navigation Bar

            Image1.Source = User.profile.U_Photo; 

            menuList = new List<MasterPageItem>();

            var page1 = new MasterPageItem() { Title = "Мои события", Icon = "mycalendar.png", TargetType = typeof(MyEvents) };
            var page2 = new MasterPageItem() { Title = "Мой профиль", Icon = "user.png", TargetType = typeof(MyProfile) };
            var page3 = new MasterPageItem() { Title = "События", Icon = "calendar.png", TargetType = typeof(Events) };
            var page4 = new MasterPageItem() { Title = "Настройки", Icon = "settings.png", TargetType = typeof(Setting) };
            var page5 = new MasterPageItem() { Title = "О программе", Icon = "aboutprogram.png", TargetType = typeof(About) };
			var page6 = new MasterPageItem() { Title = "Войти", Icon = "login.png", TargetType = typeof(MainPage) };
			var page8 = new MasterPageItem() { Title = "Выйти", Icon = "logout.png", TargetType = typeof(MainPage)};
			var page9 = new MasterPageItem() { Title = "Lala", Icon = "logout.png", TargetType = typeof(MapPage) };


			menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
			menuList.Add(page5);
			menuList.Add(page9);
			if (User.profile.U_Key == "")
			{
				menuList.Add(page6);
			}
			else
			{
				menuList.Add(page8);
			}



			// Setting our list to be ItemSource for ListView in MainPage.xaml
			navigationDrawerList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Events)));

			

            //if (User.profile.U_Key == "")
            //{
            //    page6.Title = "Войти";
            //    page6.Icon = "login.png";
            //}
            //else
            //{
            //    page6.Title = "Выйти";
            //    page6.Icon = "logout.png";
            //}
            Detail = new NavigationPage(new Events())
            {
                // Green bar color
                //BarBackgroundColor = Color.FromHex("#67B437")
            };
            if (User.profile.U_Name != "")
            {
                NameFn.Text = User.profile.U_Name;
            }
            if (User.profile.U_Patname != "")
            {
                NamePn.Text = User.profile.U_Patname;
            }
            if (User.profile.U_Surname != "")
            {
                NameSn.Text = User.profile.U_Surname;
            }
            if (User.profile.U_Photo != "")
            {
                Image1.Source = "https://xamarin.com/content/images/pages/forms/example-app.png";
            }
        }
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            //item.BackgroundColor = Color.Pink;
            Type page = item.TargetType;

        

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }

        private async void OnLabelClicked(object s, EventArgs e)
        {
            if (_previousLabel != null)
            {
                _previousLabel.BackgroundColor = Color.Transparent;
            }

           
        }




        async void Go_MainPage(object sender, EventArgs e)
        {
            if (User.profile.U_Key != "") User.profile = new Profile();
            //await Navigation.PushModalAsync(new MainPage(), false);
            Detail = new NavigationPage(new MainPage());
            IsPresented = false;
            //await Navigation.PushModalAsync(new MainPage());
            // await Navigation.PushModalAsync(new MainPage(), false);
        }

        //async void Go_Events(object sender, EventArgs e)
        //{
        //	Detail = new NavigationPage(new Events());
        //	IsPresented = false;

        //}
        //async void Go_Settings(object sender, EventArgs e)
        //{
        //	Detail = new NavigationPage(new Setting());
        //	IsPresented = false;

        //}

        //      async void Go_About(object sender, EventArgs e)
        //      {

        //          Detail = new NavigationPage(new About());
        //          IsPresented = false;

        //      }

        //      async void Go_MyEvents(object sender, EventArgs e)
        //      {

        //	Detail = new NavigationPage(new MyEvents());
        //	IsPresented = false;

        //}
        //async void Go_MyFavorites(object sender, EventArgs e)
        //{

        //	Detail = new NavigationPage(new MyFavorites());
        //	IsPresented = false;

        //}
        //async void Go_MyMaterials(object sender, EventArgs e)
        //{

        //	Detail = new NavigationPage(new MyMaterials());
        //	IsPresented = false;

        //}
        //async void Go_MyProfile(object sender, EventArgs e)
        //{

        //	Detail = new NavigationPage(new MyProfile());
        //	IsPresented = false;

        //}
        //async void Go_MyCategories(object sender, EventArgs e)
        //{

        //	Detail = new NavigationPage(new MyCategories());
        //	IsPresented = false;

        //}

    }


}