using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace Logica
{
    public class Logica_Aviso_De_Compra
    {

        public void Logica_Aviso(string Usuario)
        {
           Usuario = Usuario.ToLower();
           MailMessage Email = new MailMessage();
           Email.From = new MailAddress("Correodelosprofesores@gmail.com"); // otro cambio si modifico el correo
           Email.To.Add("ConsultaOK@outlook.com");
           Email.Subject = "Realizaron una Consulta";
           Email.Body = "El usuario: " + Usuario + " ha realizado una consulta a las:" + DateTime.Now ;
           Email.IsBodyHtml = true;

           SmtpClient smtp = new SmtpClient("smtp.gmail.com");
           smtp.Port = 587;
           smtp.Credentials = new NetworkCredential("Correodelosprofesores@gmail.com", "qsoiqzuliwweyeog"); // otro cambio si modifico el correo

           try
           {
                smtp.Send(Email);
                                            
           }
           catch (Exception)
           {
                                         
           }

        }
                


    }
}
