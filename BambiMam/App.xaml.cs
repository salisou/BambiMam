using BambiMam.Services;
using BambiMam.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BambiMam
{
    public partial class App : Application
    {

        private static SqliteHelper db;

        public static SqliteHelper Database
        {
            get
            {
                if (db == null)
                {
                    db = new SqliteHelper(Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData),
                        "dbo_Registri1.db3"));
                }

                return db;

            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
