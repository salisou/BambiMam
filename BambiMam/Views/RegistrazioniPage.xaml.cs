using BambiMam.Models;
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
    public partial class RegistrazioniPage : ContentPage
    {
        public RegistrazioniPage()
        {
            InitializeComponent();
            Title = "Pannolini";
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                MyCollectionView.ItemsSource = await App.Database.SelectRegistrazioni();
            }
            catch
            {
                 
            }
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddRegistrazini());
        }

        private void MainPage_Clicked(object sender, EventArgs e)
        {

        }

        private async void SwiperItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var reg = item.CommandParameter as Registrazioni;
            if (reg != null)
            {
                await Navigation.PushAsync(new AddRegistrazini(reg));
            }
        }

        private async void SwiperItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var reg = item.CommandParameter as Registrazioni;
            var result = await DisplayAlert("Attenzione!", $"Voi veramente cancellare? {reg.Pipi} {reg.Colori_Cacca} {reg.Data_Inserimento} {reg.Ore}", "Si", "No");

            if (result)
            {
                await App.Database.DeleteRegistrazioni(reg);
                MyCollectionView.ItemsSource = await App.Database.SelectRegistrazioni();
            }
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            MyCollectionView.ItemsSource = await App.Database.RicercaNellaLista(e.NewTextValue);
        }
    }
}