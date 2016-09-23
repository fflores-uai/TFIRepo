using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFI.CORE.Helpers.Extensions
{
    public static class HastableExtension
    {
        public static Hashtable ToHashtable(this Object o)
        {
            var paramenters = new Hashtable();

            var properties = o.GetType().GetProperties();

            foreach (var p in properties)
            {
                if (!p.PropertyType.IsClass
                    || typeof(String).IsAssignableFrom(p.PropertyType)
                    || typeof(DateTime).IsAssignableFrom(p.PropertyType))
                {
                    paramenters.Add(string.Format("@{0}", p.Name), p.GetValue(o));
                }
                //TODO: Agregar LazyLoading
                // deberia rellamar para generar el los paramentros, tambien ya sabeindo el nombre del StoreProcedure 
            }

            return paramenters;
        }
    }
}
