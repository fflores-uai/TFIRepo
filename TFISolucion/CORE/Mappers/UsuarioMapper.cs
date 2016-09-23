using System;
using System.Collections;
using TFI.CORE.Entities;
using TFI.DAL;

namespace TFI.CORE.Mappers
{
    public class UsuarioMapper
    {
        private IConnection conection;

        public UsuarioMapper()
        {
            conection = new SQLServer();
        }

        public bool Create(Usuario usuario)
        {
            var data = usuario.ToHashtable();
            return conection.Write("Usuario_Create", data);
        }
    }

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
            }

            return paramenters;
        }
    }
}