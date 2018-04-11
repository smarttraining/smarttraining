using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace smarttraining
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Events : ContentPage
	{
		public Events ()
		{
			InitializeComponent ();
            var events = Event.GetAllEvents();
			
			SearchBar searchBar = new SearchBar
            {
                Placeholder = "Enter search term"
            };

            Grid GridSearch = new Grid
            {
                BackgroundColor = Color.FromHex("#F5F5F5"),
                RowDefinitions =
                        {
                            new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                        },
                ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                    }
            };


            GridSearch.Children.Add(searchBar, 0, 0);
            eventslo.Children.Add(GridSearch);

            foreach (var even in events)
            {
				var webClient = new WebClient();

                Grid GridEvent = new Grid
                {   
                    RowSpacing = 0,
                    ColumnSpacing = 0,

                    RowDefinitions =
                        {
                            new RowDefinition { Height = 50 },
                            new RowDefinition { Height = 150 },
                            new RowDefinition { Height = 130 }
                        },
                    ColumnDefinitions =
                        {
                            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                        }
                };
                Grid GridEvent2 = new Grid
                {
                    RowSpacing = 0,
                    ColumnSpacing = 0,

                    RowDefinitions =
                        {
                            new RowDefinition { Height = 130 }
                        },
                    ColumnDefinitions =
                        {
                            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                        }
                };
                Grid GridEvent3 = new Grid
                {
                    RowSpacing = 0,
                    ColumnSpacing = 0,

                    RowDefinitions =
                        {
                            new RowDefinition { Height = 40 },
                            new RowDefinition { Height = 30 },
                            new RowDefinition { Height = 30 },
                            new RowDefinition { Height = 30 }
                        },
                    ColumnDefinitions =
                        {
                            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }  
                        }
                };






                // Тут все работает 
                var ButID = even.E_id;
                
                var ImgEvent = new Image { HeightRequest = 150, Source = even.E_pic, Margin = new Thickness(8, 0, 8, 0), Aspect = Aspect.AspectFill };
                var labelEvent = new Label { Text = Convert.ToString(even.E_Name), HeightRequest = 50, BackgroundColor = Color.FromHex("#96BFD3"), TextColor = Color.FromHex("#111"), Margin = new Thickness(8, 10, 8, 0), HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };
                var labelEventCost = new Label { Text = Convert.ToString(even.E_Price), HeightRequest = 130, BackgroundColor = Color.FromHex("#BDD7E4"), TextColor = Color.FromHex("#111"), Margin = new Thickness(0, 0, 8, 10), HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, FontSize = 20 };
                var labelEventTime = new Label { Text = Convert.ToString(even.E_Price), HeightRequest = 40, BackgroundColor = Color.FromHex("#BDD7E4"), TextColor = Color.FromHex("#111"), Margin = new Thickness(8, 0, 0, 0), HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, FontSize = 18 };
                var labelEventDate = new Label { Text = Convert.ToString(even.E_Date), HeightRequest = 20, BackgroundColor = Color.FromHex("#BDD7E4"), TextColor = Color.FromHex("#111"), Margin = new Thickness(8, 0, 0, 0), HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, FontSize = 16 };
                var labelEventMonth = new Label{ Text = Convert.ToString(even.E_Price), HeightRequest = 20, BackgroundColor = Color.FromHex("#BDD7E4"), TextColor = Color.FromHex("#111"), Margin = new Thickness(8, 0, 0, 0), HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, FontSize = 16 };
                var labelEventYear = new Label { Text = Convert.ToString(even.E_Price), HeightRequest = 20, BackgroundColor = Color.FromHex("#BDD7E4"), TextColor = Color.FromHex("#111"), Margin = new Thickness(8, 0, 0, 10), HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, FontSize = 16 };
               
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += async (s, e) =>
                {
                    await Navigation.PushAsync(new EventPage(Int32.Parse(ButID.ToString())), false);  
                };

                ImgEvent.GestureRecognizers.Add(tapGestureRecognizer);
                labelEvent.GestureRecognizers.Add(tapGestureRecognizer);
                labelEventCost.GestureRecognizers.Add(tapGestureRecognizer);
                labelEventTime.GestureRecognizers.Add(tapGestureRecognizer);
                labelEventDate.GestureRecognizers.Add(tapGestureRecognizer);
                labelEventMonth.GestureRecognizers.Add(tapGestureRecognizer);
                labelEventYear.GestureRecognizers.Add(tapGestureRecognizer);

                GridEvent.Children.Add(ImgEvent, 0, 1);
                GridEvent.Children.Add(labelEvent, 0, 0);
                GridEvent.Children.Add(GridEvent2, 0, 2);

                GridEvent2.Children.Add(GridEvent3, 0, 0);
                GridEvent2.Children.Add(labelEventCost, 1, 0);
                         
                GridEvent3.Children.Add(labelEventTime, 0, 0);
                GridEvent3.Children.Add(labelEventDate, 0, 1);
                GridEvent3.Children.Add(labelEventMonth, 0, 2);
                GridEvent3.Children.Add(labelEventYear, 0, 3);

                eventslo.Children.Add(GridEvent);
               
                // До сюда



                // var ButID = even.E_id;
                // var ImgEvent = new Image { HeightRequest = 50, Margin = new Thickness(5, 10, 5, 0), Aspect = Aspect.AspectFill };
                // var labelEvent = new Button { Text = Convert.ToString(even.E_Name), HeightRequest = 150, BackgroundColor = Color.FromHex("#CCCDC5"), Margin = new Thickness(5, 0, 5, 10) };
                // labelEvent.Image = "event.jpg";

                //var tapGestureRecognizer = new TapGestureRecognizer();
                // tapGestureRecognizer.Tapped += async (s, e) =>
                // {
                //     await Navigation.PushAsync(new EventPage(Int32.Parse(ButID.ToString())), false);  //Амир нужен, чтоб работает ли иил нет
                // };

                // ImgEvent.GestureRecognizers.Add(tapGestureRecognizer);
                // labelEvent.GestureRecognizers.Add(tapGestureRecognizer);

                // eventslo.Children.Add(ImgEvent);
                // eventslo.Children.Add(labelEvent);
















                //btn1.Clicked += async (s, e) =>
                //{
                //    await Navigation.PushAsync(new EventPage(Int32.Parse(ButID.ToString())), false);
                //};




                // var grid = new Grid();

                //grid.RowDefinitions.Add(new RowDefinition { Height = 250 });       
                //grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                //var btn = new Button { Text = "Top Left", BackgroundColor = Color.Blue,  HeightRequest = 250 };

                //grid.Children.Add(btn, 0, 0);

                //eventslo.Children.Add(grid);







                //            var ButID = even.E_id;
                //var button = new Button
                //            {
                //                HeightRequest = 250,
                //                Image = even.E_pic,
                //                Text = Convert.ToString(even.E_Name)

                //            };


                //            eventslo.Children.Add(button);
                //            button.Clicked += async (s, e) =>
                //            {
                //                await Navigation.PushAsync(new EventPage(Int32.Parse(ButID.ToString())), false);
                //            };
            }


        }

        async void Go_EventPage(object sender, EventArgs e) {
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