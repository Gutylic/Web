using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;
using Logica;

namespace Fenicia_Web
{
    public partial class Olvido_Contrasena : System.Web.UI.Page
    {

         #region Clases

        Logica_Bloque_Usuario LBU = new Logica_Bloque_Usuario();

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Recuperar_Contraseña

        protected void Boton_Recuperar_Password_Click(object sender, EventArgs e)
        {
            Errores_Al_Recuperar_La_Contrasena(Correo_Enviar_Contrasena.Text);
        }

        public void Errores_Al_Recuperar_La_Contrasena(string Correo)
        {
            int Errores_Recuperar_Contrasena = LBU.Logica_Recuperar_Contrasena(Correo, 2);

            if (Errores_Recuperar_Contrasena == -6)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no se conecto a bd');", true);
                return;
            }
            if (Errores_Recuperar_Contrasena == 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no tiene forma de correo');", true);
                return;
            }
            if (Errores_Recuperar_Contrasena == -1)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('el correo electrónico ingresado no se encuentra registrado en nuestra web');", true);
                return;
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('su usuario y contraseña fueron enviados al correo correspondiente');window.close();", true);
            return;
        }

        #endregion

    }
}


