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
                Apellido = "LOPEZ",
                Nombre = "JUAN",
                Email = "test@text.com",
                Dni = "33444555",
                CondicionFiscalID = (int)CondicionFiscal.Options.ConsumidorFinal,
                UsuarioTipoID = (int)UsuarioTipo.Options.Cliente,
                NetworkID = txtUser.Text,
                Clave = txtPassword.Text
            };

            _manager.Create(user);

 

        }
    }
}