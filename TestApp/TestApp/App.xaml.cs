using System;

using TestApp.Views;
using Xamarin.Forms;

namespace TestApp
{
	public partial class App : Application
	{

		public App ()
		{
			InitializeComponent();
            System.Diagnostics.Debug.WriteLine(Current.Properties.Count);
            if (Current.Properties.ContainsKey("Theme"))
                StartMainPage();
            else
                MainPage = new ThemeSelectPage();
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
            Current.SavePropertiesAsync();
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
        public void StartMainPage()
        {
            //MainPage = new MainPage();
            MainPage = new Settings();
        }
	}
    public enum Theme
    {
        Meca,
        Horse
    }
}
