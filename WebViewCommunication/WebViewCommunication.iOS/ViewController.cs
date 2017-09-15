using Foundation;
using System;
using System.IO;
using UIKit;
using WebKit;

namespace WebViewCommunication.iOS
{
	public partial class ViewController : UIViewController, IWKScriptMessageHandler
    {
        WKWebView webview_real;

        public ViewController(IntPtr handle) : base(handle) { }

        public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
        {
            var func = message.Body.ToString();
            var result = string.Empty;

            if (func == "ShowDate")
                result = DateTimeObject.GetDate();

            if (func == "ShowTime")
                result = DateTimeObject.GetTime();

            Callback(result);
        }





        private void Callback(string result)
        {
            webview_real.EvaluateJavaScript($"Callback('{result}')", null);
        }





        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            AppDomainInitializer();
        }





        public void AppDomainInitializer()
        {
            var userController = new WKUserContentController();
            userController.AddScriptMessageHandler(this, "readr");

            var config = new WKWebViewConfiguration
            {
                UserContentController = userController
            };

            webview_real = new WKWebView(View.Frame, config);
            View.AddSubview(webview_real);

            string localHtmlUrl = Path.Combine(NSBundle.MainBundle.BundlePath, "Content/index.html");
            webview_real.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));
        }

    }
}
}

