using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace Fenicia_Web
{
    public partial class Activacion_De_Cuenta : System.Web.UI.Page
    {

        Logica_Bloque_Usuario LBU = new Logica_Bloque_Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Usuario = Request.QueryString["ID_Nombre"]; // captura la llamada del mail            
            LBU.Logica_Activar_Usuario(Usuario, 2);
        }

        protected void Boton_De_Activacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}