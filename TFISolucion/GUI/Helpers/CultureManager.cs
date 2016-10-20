using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using TFI.CORE.Managers;

namespace TFI.GUI.Helpers
{
    public static class CultureManager
    {
        private const string KEY = "lang";
        private static HttpContext Context { get { return HttpContext.Current; } set { } }

        private static IDictionary<string, string> DIC;

        // Opcional
        public static string CookieCulture
        {
            get { return Context.Request.Cookies[KEY] == null ? (string)null : Context.Request.Cookies[KEY].Value; }
            set { Context.Request.Cookies.Add(new HttpCookie(KEY, value) { Expires = DateTime.Now.AddMonths(1) }); }
        }

        /// <summary>
        /// Cambia el valor de lenguage de la pagina, lo guarda en session y ademas cambia el Culture.
        /// </summary>
        /// <param name="language"></param>
        public static void UpdateCulture(string language = null)
        {
            //Usando cookie de session:
            var lang = language != null ? language : "es";
            Context.Session[KEY] = lang.ToLower();

            //En caso de usar .resx
            CultureInfo culture = new CultureInfo(lang);
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
        }

        public static string Translate(this string value)
        {
            DIC = LenguageManager.GetDiccionario(KEY);

            return value;
        }
    }
}