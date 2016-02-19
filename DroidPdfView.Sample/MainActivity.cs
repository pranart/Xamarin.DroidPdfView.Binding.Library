using Android.App;
using Android.Widget;
using Android.OS;
using Com.Joanzapata.Pdfview;
using System.Security.Cryptography;
using Com.Joanzapata.Pdfview.Listener;


namespace DroidPdfView.Sample
{
	[Activity (Label = "DroidPdfView.Sample", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity , IOnPageChangeListener
	{
		PDFView PDFView { get; set; }

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			PDFView = FindViewById<PDFView> (Resource.Id.pdfView1);
		}

		protected override void OnStart ()
		{
			base.OnStart ();

			PDFView.FromAsset("sample.pdf")
				.DefaultPage (1)
				.OnPageChange (this)
				.EnableDoubletap (true)
				.Load ();
		}

		void IOnPageChangeListener.OnPageChanged (int p0, int p1)
		{
			System.Diagnostics.Debug.WriteLine ("Change to Page " + p0);
		}
	}
}


