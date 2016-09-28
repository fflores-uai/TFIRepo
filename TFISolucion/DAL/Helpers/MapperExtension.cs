using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace TFI.DAL.Helpers.Extensions
{
    public static class MapperExtension
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

        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();

            foreach (var prop in properties)
            {
                if (prop.PropertyType.IsPrimitive
                    || typeof(String).IsAssignableFrom(prop.PropertyType)
                    || typeof(DateTime).IsAssignableFrom(prop.PropertyType))
                {
                    prop.SetValue(item, row[prop.Name], null);
                }
            }
            return item;
        }
    }
}