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
    public class Logica_Bloque_Usuario
    {

        Bloque_Usuario BU = new Bloque_Usuario();

        public int Logica_Registrar_Usuario(string Usuario, string Password, string Correo, int ID_Empresa, string IP_Address)
        {
            Usuario = Usuario.ToLower();
            return BU.Metodo_Registrar_Usuario(Usuario, Password, Correo, ID_Empresa, IP_Address);
        }
                
        public int Logica_Bonificacion_X_Registrarse(string Usuario, int ID_Empresa, string IP_Address)
        {
            return BU.Metodo_Bonificacion_X_Registrarse(Usuario, ID_Empresa, IP_Address);
        }

        public int Logica_Activar_Usuario(string Usuario, int ID_Empresa)
        {
            return BU.Metodo_Activar_Usuario(Usuario, ID_Empresa);
        }

        public int Logica_Insertar_Registro(string Usuario, string Password_1, string Password_2, string Captcha, string Imagen_Captcha, bool Condiciones, string Correo, int ID_Empresa, string IP_Address)
        {
            Usuario = Usuario.ToLower(); // pasamos el usuario a minusculas
            Correo = Correo.ToLower(); // pasamos el correo a minusculas
            int Error = Logica_Posibles_Errores_Al_Insertar_Registro(Usuario, Password_1, Password_2, Captcha, Imagen_Captcha, Condiciones, Correo); //captura los errores cometidos al ingresar un dato en el panel de registro
            if (Error != 1)
            {
                return Error;
            }
            int? Valor = Logica_Registrar_Usuario(Usuario, Password_1, Correo, ID_Empresa, IP_Address); // preparado para enviar los datos a el correo asi se activa
            switch (Valor)
            {
                case -6:
                    {
                        return -6; // no se conecto a la base de datos
                    }
                case -1:
                    {
                        return -1; // bloqueada la ip                         
                    }
                case -2:
                    {
                        return -2; // error de usuario           
                    }
                case -3:
                    {
                        return -3; // error de correo registrado              
                    }
                case 1: // envia al correo la activacion
                    {
                        MailMessage Email = new MailMessage();
                        Email.From = new MailAddress("xeladostechnology@gmail.com"); // otro cambio si modifico el correo
                        Email.To.Add(Correo);
                        Email.Subject = "Activación de la cuenta";
                        string Body = HttpContent("http://www.unprofesorya.com/Correo_Activacion.aspx"); // recordar que debo cambiarla
                        string Body1 = Body.Replace("NICKUSUARIO", Usuario);
                        string Body2 = Body1.Replace("CONTRASENA", Password_1);
                        Email.Body = Body2;
                        Email.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.Port = 587;
                        smtp.Credentials = new NetworkCredential("xeladostechnology@gmail.com", "qjdkuhvekcwyunpm"); // otro cambio si modifico el correo
                        smtp.EnableSsl = true;
                        try
                        {
                            smtp.Send(Email);
                            return 1; // todo OK                                
                        }
                        catch (Exception)
                        {
                            return -6; // no conectado                            
                        }

                    }
                default:
                    return -6; // no conectado            
            }

        }

        public int Logica_Posibles_Errores_Al_Insertar_Registro(string Usuario, string Password_1, string Password_2, string Captcha, string Imagen_Captcha, bool Condiciones, string Correo) // posibles errores en el registro
        {
            if (Usuario.Length > 10 || Usuario == string.Empty) // usuario vacio o con mas de 10 caracteres
            {
                return -10;
            }
            if (Usuario.IndexOf(" ", 0) != -1) // usuario con un espacio vacio
            {
                return -11;
            }
            if (Correo.IndexOf("@", 0) == -1 || Correo.IndexOf(".", 0) == -1) // no tiene forma de correo
            {
                return -12;
            }
            if (Password_1.Length <= 5) // password con menos de 6 caracteres
            {
                return -13;
            }
            if (Password_1 != Password_2) // password y confirmacion del password diferentes
            {
                return -14;
            }
            if (Correo == string.Empty) // correo vacio
            {
                return -15;
            }
            if (Captcha == string.Empty) // captcha vacio
            {
                return -16;
            }
            if (Captcha != Imagen_Captcha) // verificacion del capcha erroneo
            {
                return -17;
            }
            if (!Condiciones) // no acepto las condiciones
            {
                return -18;
            }
            return 1; // todo OK
        }
                
        public int? Logica_Loguear_Usuario(string Usuario, string Password, int ID_Empresa)
        {
            Usuario = Usuario.ToLower();
            return BU.Metodo_Loguear_Usuario(Usuario, Password, ID_Empresa);     
        }

        public int Logica_Posibles_Errores_Al_Reenviar_Activacion(string Usuario) // metodo de posibles errores
        {
            if (Usuario.Length > 10 || Usuario == string.Empty) // usuario vacio o con mas de diez caracteres
            {
                return -10;
            }
            if (Usuario.IndexOf(" ", 0) != -1) // usuario con un espacio blanco en su interior
            {
                return -11;
            }
            return 1; // Todo OK
        }

        public int Logica_Reenvio_Activacion(string Usuario, int ID_Empresa) // renvia la activacion si no llego
        {
            Usuario = Usuario.ToLower(); //pasamos el usuario a minusculas
            int Error = Logica_Posibles_Errores_Al_Reenviar_Activacion(Usuario); // captura los errores cometidos
            if (Error != 1)
            {
                return Error; // devuelve el error cometido
            }
            if (BU.Metodo_Reenviar_Activacion_Al_Usuario(Usuario, ID_Empresa).Correo == null || BU.Metodo_Reenviar_Activacion_Al_Usuario(Usuario, ID_Empresa).Password == null)// error por no encontrarse el nombre de usuario
            {
                return 0;
            }
            //envia al correo la activacion
            MailMessage Correo = new MailMessage();
            Correo.From = new MailAddress("xeladostechnology@gmail.com"); // otro cambio si modifico el correo
            Correo.To.Add(BU.Metodo_Reenviar_Activacion_Al_Usuario(Usuario, ID_Empresa).Correo);
            Correo.Subject = "Activación de la cuenta";
            string Body = HttpContent("http://www.unprofesoya.com/Correo_Activacion.aspx"); // recordar que debo cambiarla
            string Body1 = Body.Replace("NICKUSUARIO", Usuario);
            string Body2 = Body1.Replace("CONTRASENA", BU.Metodo_Reenviar_Activacion_Al_Usuario(Usuario, ID_Empresa).Password);
            Correo.Body = Body2;
            Correo.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("xeladostechnology@gmail.com", "qjdkuhvekcwyunpm"); // otro cambio si modifico el correo
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(Correo);
                return 1; // todo ok
            }
            catch (Exception)
            {
                return -6; // no se conecto a la base de datos
            }

        }

        public string HttpContent(string URL) // cargar toda la pagina web para enviar por mail
        {
            WebRequest objRequest = HttpWebRequest.Create(URL);
            StreamReader reader = new StreamReader(objRequest.GetResponse().GetResponseStream());
            string Result = reader.ReadToEnd();
            return Result;
        }

        public int Logica_Recuperar_Contrasena(string Email, int ID_Empresa) 
        {
            Email = Email.ToLower(); // lo convierto a minusculas
            if (Email.IndexOf(" ") != -1 || Email.Length < 1)
            {
                return 0; // error de espacios y error de vacio
            }
            if (Email.IndexOf("@", 0) == -1 || Email.IndexOf(".", 0) == -1)// no tiene forma de correo
            {
                return 0; // no tiene forma de correo
            }
            string Usuario = BU.Metodo_Recuperar_Contrasena(Email,ID_Empresa).Usuario;  // obtener usuario
            string Password = BU.Metodo_Recuperar_Contrasena(Email, ID_Empresa).Password; // obtener password
            if (Usuario == null || Password == null)
            {
                return -1; // no conectado o correo no existe
            }
            //envia al correo la contraseña y el usuario
            MailMessage Correo = new MailMessage();
            Correo.From = new MailAddress("xeladostechnology@gmail.com"); // otro cambio si modifico el correo
            Correo.To.Add(Email);
            Correo.Subject = "Aviso de solicitud de recuperación de contraseña";
            string Body = HttpContent("http://www.unprofesorya.com/Correo_Recuperacion.aspx"); // recordar que debo cambiarla
            string Body1 = Body.Replace("NICKUSUARIO", Usuario);
            string Body2 = Body1.Replace("CONTRASENA", Password);
            Correo.Body = Body2;
            Correo.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("xeladostechnology@gmail.com", "qjdkuhvekcwyunpm"); // otro cambio si modifico el correo
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(Correo);
                return 1; // envio correcto
            }
            catch (Exception)
            {
                return -6; // error de envio ;
            }
        
        }
        
    }
}
