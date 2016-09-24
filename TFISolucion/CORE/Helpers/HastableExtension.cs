using System;
using System.Collections;

namespace TFI.CORE.Helpers.Extensions
{
    public static class HastableExtension
    {
        public static Hashtable ToHashtable(this Object o, string Name = null)
        {
            var paramenters = new Hashtable();

            if (o.GetType().IsPrimitive)
            {
                paramenters.Add(string.Format("@{0}", Name), o);
            }

            if (paramenters.Count == 0)
            {
                var properties = o.GetType().GetProperties();
                foreach (var p in properties)
                {
                    if (!p.PropertyType.IsClass
                        || p.PropertyType.IsPrimitive
                        || typeof(String).IsAssignableFrom(p.PropertyType)
                        || typeof(DateTime).IsAssignableFrom(p.PropertyType)
                        || !typeof(ICollection).IsAssignableFrom(p.PropertyType))
                    {
                        paramenters.Add(string.Format("@{0}", p.Name), p.GetValue(o));
                    }

                    //TODO: Agregar LazyLoading
                }
            }

            return paramenters;
        }
    }
}