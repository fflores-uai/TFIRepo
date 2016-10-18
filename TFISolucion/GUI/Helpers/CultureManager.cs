using System;
using System.Web;

namespace TFI.GUI.Helpers
{
    public static class CultureManager
    {
        private const string KEY = "language";
        private static readonly HttpContext Ctx { get { return HttpContext.Current; } set { } }

        public static string CookieCulture
        {
            get { return Ctx.Request.Cookies[KEY] == null ? (string)null : Ctx.Request.Cookies[KEY].Value; }
            set { Ctx.Request.Cookies.Add(new HttpCookie(KEY, value) { Expires = DateTime.Now.AddMonths(1) }); }
        }

        public static void SetLanguage(string language = null)
        {
            var lang = language != null ? language : "ES";
            Ctx.Session["culture"] = lang;
        }
    }
}