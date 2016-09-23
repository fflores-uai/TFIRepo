using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFI.CORE.Entities;
using TFI.CORE.Mappers;

namespace TFI.CORE.Managers
{
    public class UsuarioManager
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
    }
}
