using System;
using TFI.CORE.Entities;
using TFI.CORE.Managers;

namespace TFI.GUI
{
    public partial class Login : System.Web.UI.Page
    {
        private UsuarioManager _manager;

        protected void Page_Load(object sender, EventArgs e)
        {
            _manager = new UsuarioManager();

            //Autoidioma
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var user = new Usuario()
            {
                Apellido = GenerateRandom(10),
                Nombre = GenerateRandom(10),
                Email = GenerateRandomMail(),
                Dni = GenerateRandom(),
                CondicionFiscalID = (int)CondicionFiscal.Options.ConsumidorFinal,
                UsuarioTipoID = (int)UsuarioTipo.Options.Cliente,
                NetworkID = txtUser.Text,
                Clave = txtPassword.Text
            };

            //_manager.Create(user);

            var u = _manager.Find(2);
        }

        private string GenerateRandom(int length)
        {
            return Guid.NewGuid().ToString().Substring(0, length);
        }

        private string GenerateRandomMail()
        {
            return string.Format("{0}@{1}.com", GenerateRandom(10), GenerateRandom(5));
        }

        private string GenerateRandom()
        {
            return new Random().Next(0, 99999999).ToString();
        }
        
    }
}