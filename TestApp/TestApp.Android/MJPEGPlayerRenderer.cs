using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using System.ComponentModel;

using TestApp;

[assembly: ExportRenderer(typeof(MJPEGPlayer), typeof(TestApp.Droid.MJPEGPlayerRenderer))]
namespace TestApp.Droid
{
    public class MJPEGPlayerRenderer : ViewRenderer<MJPEGPlayer, Android.Webkit.WebView>
    {
        const string JavaScriptFunction = "function invokeCSharpAction(data){jsBridge.invokeAction(data);}";
        Context _context;
        string url;
        bool isPlaying = false;

        MJPEGPlayerRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<MJPEGPlayer> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var webview = new Android.Webkit.WebView(_context);

                webview.Settings.JavaScriptEnabled = true;
                webview.VerticalScrollBarEnabled = false;
                SetNativeControl(webview);
            }
            if (e.OldElement != null)
            {
                Control.RemoveJavascriptInterface("jsBridge");
                var player = e.OldElement as MJPEGPlayer;
                player.Cleanup();
            }
            if (e.NewElement != null)
            {
                //Control.AddJavascriptInterface(new JSBridge(this), "jsBridge");

                Control.LoadUrl("file:///android_asset/Content/MJPEGPlayer.html");
                url = e.NewElement.Url;
                //Control.EvaluateJavascript(String.Format("play({0})", e.NewElement.Url) );
                InjectJS(JavaScriptFunction);
                e.NewElement.PlayRequested += OnPlayRequested;
                e.NewElement.PauseRequested += OnPauseRequested;
                e.NewElement.StopRequested += OnStopRequested;
            }
        }

        void InjectJS(string script)
        {
            if (Control != null)
            {
                Control.LoadUrl(string.Format("javascript: {0}", script));
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            // reload the page when shown
            var element = (MJPEGPlayer)sender;

            if (e.PropertyName == "IsVisible")
            {
                if (element.IsVisible == true)
                {
                    OnPlayRequested(this, EventArgs.Empty);
                }
                else
                {
                    OnPauseRequested(this, EventArgs.Empty);
                }
            }
            if (e.PropertyName == "Url")
            {
                url = element.Url;
                if (isPlaying)
                    OnPlayRequested(this, EventArgs.Empty);
            }
        }
        private void OnPlayRequested(object sender, EventArgs e)
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
            {
                Control.EvaluateJavascript(String.Format("play({0});", url), null);
            }
            else
            {
                Control.LoadUrl(String.Format("javascript:play({0});", url));
            }
            isPlaying = true;
        }
        private void OnPauseRequested(object sender, EventArgs e)
        {
            if (!isPlaying)
            {
                return;
            }
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
            {
                Control.EvaluateJavascript("pause();", null);
            }
            else
            {
                Control.LoadUrl("javascript:pause();");
            }
            isPlaying = false;
        }
        private void OnStopRequested(object sender, EventArgs e)
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
            {
                Control.EvaluateJavascript("stop();", null);
            }
            else
            {
                Control.LoadUrl("javascript:stop();");
            }
            isPlaying = false;
        }
        protected void Snapshot()
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
            {
                Control.EvaluateJavascript("snapshot();", null);
            }
            else
            {
                Control.LoadUrl("javascript:snapshot();");
            }
        }

    }
}