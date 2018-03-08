using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TestApp;
using TestApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(Storage))]
namespace TestApp.Droid
{
    class Storage : IStorage
    {
        public string GetPath()
        {
            string path = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryMovies).AbsolutePath;
            string dcimpath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim).AbsolutePath;
            return dcimpath;
        }
    }
}