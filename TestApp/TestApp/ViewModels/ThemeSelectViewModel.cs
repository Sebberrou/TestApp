using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace TestApp.ViewModels
{
    public class ThemeSelectViewModel : BaseViewModel
    {
        public ThemeSelectViewModel()
        {
            Title = "About";

            ThemeSelectCommand = new Command((parameter) =>
            {
                System.Diagnostics.Debug.WriteLine("hello");
                Application.Current.Properties["Theme"] = true;
                Application.Current.MainPage = new Views.MainPage();
                Task.Run(async () =>
                {
                    await Application.Current.SavePropertiesAsync();
                });
            });
        }

        public ICommand ThemeSelectCommand { get; }
    }
}