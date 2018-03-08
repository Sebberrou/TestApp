using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using System.IO;
using System.Linq;
using Android.Util;

namespace TestApp.Droid
{
    [Activity(Label = "TestApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            InitDownloadManager();

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        void InitDownloadManager()
        {
            // Define where the files should be stored. MUST be an external storage. (see https://github.com/SimonSimCity/Xamarin-CrossDownloadManager/issues/10)
            // If you skip this, you neither need the permission `WRITE_EXTERNAL_STORAGE`.


            // In case you want to create your own notification :)
            //(CrossDownloadManager.Current as DownloadManagerImplementation).NotificationVisibility = DownloadVisibility.Hidden;

            // Prevents the file from appearing in the android download manager
            (CrossDownloadManager.Current as DownloadManagerImplementation).IsVisibleInDownloadsUi = true;
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
        protected override void OnPause()
        {
            base.OnPause();

        }
    }
}

