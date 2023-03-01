using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BambiMam.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public string Name;
        public MainPage()
        {
            InitializeComponent();

            MyMemu = GetMenus();

            this.BindingContext = this;

            

        }


        public List<Models.Menu> MyMemu { get; set; }

        private List<Models.Menu> GetMenus()
        {
            //MyMemu.Add(new Models.Menu { Name = "Home", Icon = "home.png" });
            //MyMemu.Add(new Models.Menu { Name = "Pannolini", Icon = "reveiller.png" });
            //MyMemu.Add(new Models.Menu { Name = "Sonno", Icon = "Someille.png" });
            //MyMemu.Add(new Models.Menu { Name = "Alattamento", Icon = "Alattamento_1.png" });
            //MyMemu.Add(new Models.Menu { Name = "Svezzamento", Icon = "Baby.png" });

            return new List<Models.Menu>()
            {
                new Models.Menu{ Name = "Home", Icon = "home.png" },
                new Models.Menu{ Name = "Pannolini", Icon = "reveiller.png"},
                new Models.Menu{ Name = "Sonno", Icon = "Someille.png"},
                new Models.Menu{ Name = "Alattamento", Icon = "Alattamento_1.png"},
                new Models.Menu{ Name = "Svezzamento", Icon = "Baby.png"}
            };
        }

        private void openSwip(object sender, EventArgs e)
        {
        }

        private void CloseSwiep(object sender, EventArgs e)
        {

        }


        private async void Pannolini_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrazioniPage());
        }

        private async void Sonno_Tapped1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailSonno());
        }

        private async void Alattamento_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailAlattamento());
           
        }

        private async void Svezzamento_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailSvezzamento());
           
        }

    }
}