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
    public partial class AddRegistrazini : ContentPage
    {
        Entry objEntrySelected;


        // Dictionary to get Color from color name.

        public AddRegistrazini()
        {
            InitializeComponent();

            foreach (string Colori in nameToColor.Keys)
            {
                ColoriCacca_Picker.Items.Add(Colori);
            }
        }

        Dictionary<string, Color> nameToColor = new Dictionary<string, Color>
        {
            { "Non ha fatto la cacca", Color.Default }, { "colore della Cacca è Arancione", Color.FromHex("#FFBF00") },
            { "Colore della Cacca è Senape", Color.FromHex("#808000") }, { "Colore della Cacca è Giallo verde", Color.FromHex("#8a9f49") },
        };

        Models.Registrazioni _registrazioni;
        public AddRegistrazini( Models.Registrazioni registrazioni)
        {
            InitializeComponent();
            Title = "Modifica ";

            string strConferma = "Si";
            string strNonConferma = "No";
            _registrazioni = registrazioni;


            if (PipiEntry.IsChecked == true)
            {
                registrazioni.Pipi = strConferma.ToString();
            }
            else if (PipiEntry.IsChecked == false)
            {
                registrazioni.Pipi = strNonConferma.ToString();
            }
            {   
                PipiEntry.IsChecked = true;
            }

            var prova = registrazioni.Colori_Cacca;
            if (prova != null)
            {
                DisplayAlert("Attenzione!", "Non seiste questo campo non esisgte", "ok");
            }
            else
            {
                prova = ColoriCacca_Picker.SelectedIndex.ToString();
            }

            Data_InserimentoEntry.Date = registrazioni.Data_Inserimento;
            Ore.Time =  registrazioni.Ore;
        }

        private async void Save_CLicakd(object sender, EventArgs e)
        {
            
            if ( string.IsNullOrEmpty(Conferma.Text.ToString()) 
                && string.IsNullOrEmpty(ColoriCacca_Picker.SelectedIndex.ToString()) 
                && string.IsNullOrEmpty(Data_InserimentoEntry.Date.Day.ToString("d"))
                && string.IsNullOrEmpty(Ore.Time.ToString("T")))
            {

                await DisplayAlert("Attenzione!", "Hai Dimenricato un campo", "Ok");
            }else if (_registrazioni != null)
            {
                UpdateInserimenti();
            }
            else
            {
                InsertAll();
            }
        }

        private async void UpdateInserimenti()
        {
            _registrazioni.Pipi = Conferma.Text;
            _registrazioni.Colori_Cacca = ColoriCacca_Picker.SelectedIndex.ToString();
            _registrazioni.Data_Inserimento = Data_InserimentoEntry.Date;
            _registrazioni.Ore = Ore.Time ;

            await App.Database.UpdateRegistrazioni(_registrazioni);
            await Navigation.PopAsync();
        }

        private async void InsertAll()
        {
            //DateTime date = Data_InserimentoEntry.Date;
            //var time = Ore.Time;

            //string dataTime = "Data: " + date.ToString("d") + "Ore: "+ time.ToString();

            //Resultato.Text = dataTime;

            await App.Database.CreateRegistrazioni(new Models.Registrazioni
            {
                //N_Pannolini = N_PannoliniEntry.Text,
                Pipi = Conferma.Text,
                Colori_Cacca = ColoriCacca_Picker.SelectedIndex.ToString(),
                Data_Inserimento = Data_InserimentoEntry.Date,
                Ore = Ore.Time,
            });
            await Navigation.PopAsync();
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                Conferma.Text = "Si";
            }
            else
            {
                Conferma.Text = "No";
            }
        }

        //private void DatePickerXaml_DateChanged(object sender, DateChangedEventArgs e)
        //{
        //    objEntrySelected = new Entry();
        //    //inserisce la nuova data cambiata nel testo della entry sulla quale è stabilito il focus
        //    objEntrySelected.Text = e.NewDate.ToString("d");
        //}

    }
}