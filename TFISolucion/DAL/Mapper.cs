using System.Collections.Generic;
using System.Linq;
using TFI.DAL.Helpers;
using TFI.DAL.Helpers.Extensions;

namespace TFI.DAL.Mapper
{
    public class Mapper<TSource> where TSource : new()
    {
        private string Entity;
        private IConnection conection;

        public Mapper(string Name)
        {
            conection = new SQLServer();
            this.Entity = Name;
        }

        public bool Add(TSource source)
        {
            return conection.Write(Procedure(Action.Create),
                                   source.ToHashtable());
        }

        public bool Update(TSource source)
        {
            return conection.Write(Procedure(Action.Update),
                                   source.ToHashtable());
        }

        public TSource Find(int ID)
        {
            //var datatable = conection.Read(Procedure(Action.Find),
            //                      ID.ToHashtable("ID"));

            //var result = datatable.ToList<TSource>();

            return conection.Read(Procedure(Action.Find),
                                  ID.ToHashtable("ID"))
                                  .ToList<TSource>()
                                  .FirstOrDefault();
        }

        public List<TSource> FindAll()
        {
            return conection.Read(Procedure(Action.FindAll), null)
                            .ToList<TSource>();
        }

        public List<TSource> FindByNetworkId()
        {
            return conection.Read(Procedure(Action.FindByNetworkID), null)
                            .ToList<TSource>();
        }

        public string Procedure(string action)
        {
            return string.Format("{0}_{1}", Entity, action);
        }
    }
}