using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Datos;
using System.Net.Mail;
using System.Net;
using System.IO;

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
            MailMessage Mio = new MailMessage();
            Mio.From = new MailAddress("Correodelosprofesores@gmail.com");
            Mio.To.Add("ActivacionOK@outlook.com");
            Mio.Subject = "Activacion OK";
            Mio.Body = "Se registro pero aun no activo:" + (Request.QueryString["ID_Nombre"]).ToString();
            Mio.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("Correodelosprofesores@gmail.com", "qsoiqzuliwweyeog"); // otro cambio si modifico el correo
            smtp.EnableSsl = true;


            try
            {
                smtp.Send(Mio);
                Response.Redirect("index.aspx");

            }
            catch (Exception)
            {
                Response.Redirect("index.aspx");

            }
            
        }
    }
}