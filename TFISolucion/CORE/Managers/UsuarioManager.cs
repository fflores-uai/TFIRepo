using TFI.CORE.Entities;
using TFI.DAL.Mapper;

namespace TFI.CORE.Managers
{
    public class UsuarioManager
    {
        private const string ENTITY = "Usuario";
        private readonly Mapper<Usuario> Db;

        public UsuarioManager()
        {
            Db = new Mapper<Usuario>(ENTITY);
        }

        public bool Create(Usuario usuario)
        {
            return Db.Add(usuario);
        }

        public Usuario Find(int id)
        {
            return Db.Find(id);
        }
    }
}