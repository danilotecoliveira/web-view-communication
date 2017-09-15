using Android.OS;
using Android.App;
using Android.Webkit;

namespace WebViewCommunication.Droid
{
    [Activity(Label = "", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Black.NoTitleBar")]
    public class MainActivity : Activity
	{
        WebView webView;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            webView = new WebView(this);
            SetContentView(webView);

            webView.Settings.JavaScriptEnabled = true;
            webView.AddJavascriptInterface(new JSCommunicator(this, webView), "CSharp");
            webView.LoadUrl("file:///android_asset/index.html");
        }
	}
}


