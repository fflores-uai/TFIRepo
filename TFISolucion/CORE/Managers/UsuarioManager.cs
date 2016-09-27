using TFI.CORE.Entities;
using TFI.CORE.Mappers;

namespace TFI.CORE.Managers
{
    public class UsuarioManager
    {
        private readonly Mapper<Usuario> _mapper;

        public UsuarioManager()
        {
            _mapper = new Mapper<Usuario>("Usuario");
        }

        public bool Create(Usuario usuario)
        {
            return _mapper.Create(usuario);
        }

        public Usuario Find(int id)
        {
            return _mapper.Find(id);
        }
    }
}