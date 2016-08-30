using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace WebtechProject
{
    /// <summary>
    /// Entry of the application
    /// </summary>
    public partial class App : Application
    {
        static SensorDataDatabase database;
        /// <summary>
        /// The database object where all data will be stored
        /// </summary>
        public static SensorDataDatabase Database
        {
            get
            {
                database = database ?? new SensorDataDatabase();
                return database;
            }
        }

        /// <summary>
        /// Creating the first page for the application
        /// </summary>
        public App()
        {
            MainPage = new NavigationPage(new WebtechProject.MainHub());
        }

        /// <summary>
        /// Gets called on app start
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        /// <summary>
        /// Gets called on app sleep
        /// </summary>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// Gets called on app resume
        /// </summary>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
