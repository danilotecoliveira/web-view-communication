using Java.Interop;
using Android.Webkit;
using Android.Content;
using WebViewCommunication.Models;
using System;

namespace WebViewCommunication.Droid
{
    public class JSCommunicator : Java.Lang.Object
    {
        Context context;
        WebView webView;

        public JSCommunicator(Context context, WebView webView)
        {
            this.context = context;
            this.webView = webView;
        }





        [Export]
        [JavascriptInterface]
        public void Invoke(string func)
        {
            var result = string.Empty;

            if (func == "ShowDate")
                result = DateTimeObject.GetDate();

            if (func == "ShowTime")
                result = DateTimeObject.GetTime();

            Callback(result);
        }





        private void Callback(string result)
        {
            webView.LoadUrl($"javascript:Callback('{result}');");
        }
    }
}