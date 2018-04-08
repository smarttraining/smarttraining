using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace smarttraining
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPageItem : ContentPage
    {
        public MasterPageItem()
        {
            InitializeComponent();
        }
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }
    }










    //public class MyModel : INotifyPropertyChanged
    //{


    //    private Color _backgroundColor;

    //    public Color BackgroundColor
    //    {
    //        get { return _backgroundColor; }
    //        set
    //        {
    //            _backgroundColor = value;

    //            if (PropertyChanged != null)
    //            {
    //                PropertyChanged(this, new PropertyChangedEventArgs("BackgroundColor"));
    //            }
    //        }
    //    }

    //    public void SetColors(bool isSelected)
    //    {
    //        if (isSelected)
    //        {
    //            BackgroundColor = Color.FromRgb(0.20, 0.20, 1.0);
    //        }
    //        else
    //        {
    //            BackgroundColor = Color.FromRgb(0.95, 0.95, 0.95);
    //        }
    //    }
    //}











}