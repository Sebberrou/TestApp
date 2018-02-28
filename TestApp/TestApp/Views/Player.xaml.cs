using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MjpegProcessor;
using System.IO;

namespace TestApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Player : ContentPage
	{
        MjpegDecoder mjpeg;
		public Player ()
		{
			InitializeComponent ();
            mjpeg = new MjpegDecoder();
            mjpeg.FrameReady += frame_ready;
            mjpeg.ParseStream(new Uri("http://webcam.st-malo.com/axis-cgi/mjpg/video.cgi?resolution=640x480"));
		}

        private void frame_ready(object sender, FrameReadyEventArgs e)
        {
           
            image.Source = ImageSource.FromStream(() => new MemoryStream(e.FrameBuffer));
            
        }
    }
}