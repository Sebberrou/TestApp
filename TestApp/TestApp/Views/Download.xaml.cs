using Plugin.DownloadManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.DownloadManager.Abstractions;
namespace TestApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Download : ContentPage
	{
        string url;
        string DevicePath;
        IDownloadManager downloadManager;
		public Download ()
		{
			InitializeComponent ();
            CrossDownloadManager.Current.CollectionChanged += (sender, e) =>
                System.Diagnostics.Debug.WriteLine(
                    "[DownloadManager] " + e.Action +
                    " -> New items: " + (e.NewItems?.Count ?? 0) +
                    " at " + e.NewStartingIndex +
                    " || Old items: " + (e.OldItems?.Count ?? 0) +
                    " at " + e.OldStartingIndex
                );
            DevicePath = DependencyService.Get<IStorage>().GetPath();
            CrossDownloadManager.Current.PathNameForDownloadedFile = new Func<IDownloadFile, string>(file =>
            {
                string fileName =  new Uri(file.Url).AbsoluteUri.Split('/').Last();
                string path = System.IO.Path.Combine(DevicePath,"myApp", fileName);
                System.Diagnostics.Debug.WriteLine("Path: "+ path);
                return path;
            });
        }
        public void OnDownloadClicked(object sender, EventArgs e)
        {
            url = Url.Text;
            downloadManager = CrossDownloadManager.Current;
            
            var file = downloadManager.CreateDownloadFile(url);
            
            file.PropertyChanged += File_PropertyChanged;
            downloadManager.Start(file);
            //downloadManager.PathNameForDownloadedFile = getFilePath;
        }


        private void File_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.PropertyName);
            var file = sender as IDownloadFile;
            System.Diagnostics.Debug.WriteLine(file.Status);
            System.Diagnostics.Debug.WriteLine((file.TotalBytesWritten / file.TotalBytesExpected) * 100 + "%");
            System.Diagnostics.Debug.WriteLine(file.Url);            
            System.Diagnostics.Debug.WriteLine("============ End Property Changed =================");
        }
    }
}