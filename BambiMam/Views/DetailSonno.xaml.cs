using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BambiMam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailSonno : ContentPage
    {
        public DetailSonno()
        {
            InitializeComponent();
            Title = "Sonno";
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddSonno());
        }
    }
}