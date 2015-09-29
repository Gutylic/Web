using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Usuario
    {

        DataClassesDataContext db = new DataClassesDataContext();
        string Usuario;
        string Password;
        string Correo;
        int? ID_Usuario;

        public int Metodo_Registrar_Usuario(string Usuario, string Password, string Correo, int ID_Empresa, string IP_Address)
        {
            return db.Registrar_Usuario(Usuario, Password, Correo, ID_Empresa, IP_Address);        
        }

        public int Metodo_Bonificacion_X_Registrarse(string Usuario, int ID_Empresa, string IP_Address)
        {
            return db.Bonificacion_X_Registrarse(Usuario, ID_Empresa, IP_Address);
        }

        public int Metodo_Activar_Usuario(string Usuario, int ID_Empresa)
        {
            return db.Activar_Usuario(Usuario, ID_Empresa);
        }

        public class Dos_Datos_String_Para_Reenviar_La_Activacion // clase extra utilizada para que alguna clase me devuelva dos valores
        {
            public string Correo { get; set; }
            public string Password { get; set; }
        }

        public Dos_Datos_String_Para_Reenviar_La_Activacion Metodo_Reenviar_Activacion_Al_Usuario(string Usuario, int ID_Empresa)
        {
            Dos_Datos_String_Para_Reenviar_La_Activacion Datos = new Dos_Datos_String_Para_Reenviar_La_Activacion();
            db.Reenviar_Activacion_Al_Usuario(Usuario, ID_Empresa, ref Correo, ref Password);
            Datos.Correo = Correo;
            Datos.Password = Password;
            return Datos;
        }

        public class Dos_Datos_String_Para_Recuperar_La_Contrasena // clase extra utilizada para que alguna clase me devuelva dos valores
        {
            public string Usuario { get; set; }
            public string Password { get; set; }
        }

        public Dos_Datos_String_Para_Recuperar_La_Contrasena Metodo_Recuperar_Contrasena(string Correo, int ID_Empresa)
        {
            Dos_Datos_String_Para_Recuperar_La_Contrasena Datos = new Dos_Datos_String_Para_Recuperar_La_Contrasena();
            db.Recuperar_Contrasena(Correo, ID_Empresa, ref Usuario, ref Password);
            Datos.Usuario = Usuario;
            Datos.Password = Password;
            return Datos;
        }

        public int? Metodo_Loguear_Usuario(string Usuario, string Password, int ID_Empresa)
        {
            db.Loguear_Usuario(Usuario, Password, ID_Empresa, ref ID_Usuario);
            return ID_Usuario;        
        }
               
    }
}
