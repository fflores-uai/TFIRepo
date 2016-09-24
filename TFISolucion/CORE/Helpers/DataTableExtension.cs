using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace TFI.CORE.Helpers.Extensions
{
    public static class DataTableExtensions
    {
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