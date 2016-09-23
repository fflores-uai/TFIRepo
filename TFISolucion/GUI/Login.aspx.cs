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
                NetworkID = txtUser.Text,
                Clave = txtPassword.Text
            };

            _manager.Create(user);
        }
    }
}