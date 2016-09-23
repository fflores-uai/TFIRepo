using TFI.CORE.Entities;
using TFI.CORE.Mappers;

namespace TFI.CORE.Managers
{
    public class UsuarioManager : IManager
    {
        private readonly UsuarioMapper _mapper;

        public UsuarioManager()
        {
            _mapper = new UsuarioMapper();
        }

        public bool Create(Usuario usuario)
        {
            return _mapper.Create(usuario);
        }

        public bool Delete(int ID)
        {
            return true;
        }
    }
}