using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Settings : ContentPage
	{
        SettingsViewModel viewModel;

        public Settings ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new SettingsViewModel();

        }

        private void OnCompleted(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnCompleted");
        }
    }
}