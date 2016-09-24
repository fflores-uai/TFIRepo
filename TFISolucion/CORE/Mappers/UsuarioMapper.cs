using System.Collections.Generic;
using System.Linq;
using TFI.CORE.Entities;
using TFI.CORE.Helpers;
using TFI.CORE.Helpers.Extensions;
using TFI.DAL;

namespace TFI.CORE.Mappers
{
    public class UsuarioMapper
    {
        private const string ENTITY = "Usuario";
        private IConnection conection;

        public UsuarioMapper()
        {
            conection = new SQLServer();
        }

        public bool Create(Usuario usuario)
        {
            return conection.Write(Procedure(Action.Create),
                                   usuario.ToHashtable());
        }

        public bool Update(Usuario usuario)
        {
            return conection.Write(Procedure(Action.Update),
                                   usuario.ToHashtable());
        }

        public Usuario Find(int ID)
        {
            return conection.Read(Procedure(Action.Find),
                                  ID.ToHashtable("ID"))
                            .ToList<Usuario>()
                            .First();
        }

        public List<Usuario> FindAll()
        {
            return conection.Read(Procedure(Action.FindAll), null)
                            .ToList<Usuario>();
        }


        public string Procedure(string action)
        {
            return string.Format("{0}_{1}", ENTITY, action);
        }
    }
}