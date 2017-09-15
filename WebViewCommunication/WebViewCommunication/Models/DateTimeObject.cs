using System;

namespace WebViewCommunication.Models
{
    public class DateTimeObject
    {
        public static string GetDate()
        {
            return DateTime.Now.ToString("d");
        }

        public static string GetTime()
        {
            return DateTime.Now.ToString("t");
        }
    }
}
