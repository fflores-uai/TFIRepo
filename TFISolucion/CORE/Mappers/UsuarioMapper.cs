using TFI.CORE.Entities;
using TFI.CORE.Helpers.Extensions;
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
}