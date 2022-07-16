using SignaturesApp.Controller;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_2
{
    public partial class App : Application
    {

        static DBconexion database;

        public static DBconexion BaseDatos
        {
            get
            {
                if (database == null)
                {
                    database = new DBconexion(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM02Ejercicio2.2.db3"));
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
