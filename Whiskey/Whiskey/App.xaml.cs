using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Whiskey.View;
using Xamarin.Forms;

namespace Whiskey
{
    public partial class App : Application
    {
        /// <summary>
        /// Consider this method as public static void main, which launches the app. 
        /// MainPage property in this class, sets the starting page of app. 
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new Home();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
