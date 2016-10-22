using System;
using TFI.GUI.Helpers;

namespace TFI.GUI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lblNombre.Value = lblNombre.ID.Translate();
            //lblNombre.Text = lblNombre.Text.Translate();
            CultureManager.UpdateCulture("en");

            lblIngles.InnerText = lblIngles.InnerText.Translate();
            


        }
    }
}