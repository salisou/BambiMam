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
    public partial class AddSonno : ContentPage
    {

        private Entry objEntrySelected;
        public AddSonno()
        {
            InitializeComponent();
        }

        private void SearchQryFind(object sender, EventArgs e)
        {

        }

        private void EntryFocused(object sender, FocusEventArgs e)
        {

        }

        private void EntryUnFocused(object sender, FocusEventArgs e)
        {

        }


        private void DatePickerXaml_DateChanged(object sender, DateChangedEventArgs e)
        {
            //inserisce la nuova data cambiata nel testo della entry sulla quale è stabilito il focus
            objEntrySelected.Text = e.NewDate.ToString("d");
        }

        private void btnSalvaRegistrazione_Clicked(object sender, EventArgs e)
        {

        }
    }
}