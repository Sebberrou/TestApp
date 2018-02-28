using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ThemeSelectPage : ContentPage
	{
		public ThemeSelectPage()
		{
			InitializeComponent ();
		}
        void Theme_Clicked(object sender, TappedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Parameter,"Click event ");
        }
    }
}