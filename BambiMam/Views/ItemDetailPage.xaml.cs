using BambiMam.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BambiMam.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}