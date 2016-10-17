using System.Web;
using System.Web.SessionState;

namespace TFI.GUI.Helpers
{
    public static class TranslateHelper
    {
        public static HttpContext ctx;
        public static HttpSessionState Session;

        public static void  SetLanguage(string language = null)
        {
            HttpContext.Current.Session["culture"] = "ES";

            var lang = language != null ? language : "ES";
            Session["culture"] = lang;
           
        }
    }
}