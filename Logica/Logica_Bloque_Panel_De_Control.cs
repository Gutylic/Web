using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Panel_De_Control
    {

        Bloque_Panel_De_Control BPDC = new Bloque_Panel_De_Control();

        public List<Mostrar_El_Panel_De_Control_Del_UsuarioResult> Logica_Mostrar_El_Panel_De_Control_Del_Usuario(int ID_Usuario)
        {
            return BPDC.Metodo_Mostrar_El_Panel_De_Control_Del_Usuario(ID_Usuario);        
        }

        public int Logica_Metodo_Actualizar_El_Panel_De_Control(int ID_Usuario, string Password, string Correo, string Numero_De_Celular, string Usuario_De_Skype, int ID_Empresa, string Modelo_De_Celular)
        {
            int Error = Logica_Posibles_Errores_Al_Intentar_Actualizar_Datos_Por_Parte_Del_Usuario(Password, Correo); // posibles errores en el password con menos datos o un correo ya registrado
            if (Error != 1)
            {
                return Error;
            }
            if (Numero_De_Celular == string.Empty) { Numero_De_Celular = null; }
            if  (Usuario_De_Skype == string.Empty) { Usuario_De_Skype = null; }
            if (Modelo_De_Celular == string.Empty) { Modelo_De_Celular = null; }
            return BPDC.Metodo_Actualizar_El_Panel_De_Control(ID_Usuario, Password, Correo, Numero_De_Celular, Usuario_De_Skype, ID_Empresa, Modelo_De_Celular);
        }

        public int Logica_Posibles_Errores_Al_Intentar_Actualizar_Datos_Por_Parte_Del_Usuario(string Password, string Correo) // metodo de errores en la actualizacion del panel de control
        {
            if (Correo.IndexOf("@", 0) == -1 || Correo.IndexOf(".", 0) == -1)// no tiene forma de correo
            {
                return -1; // no tiene forma de correo
            }
            if (Password.Length <= 5)
            {
                return -2; // error por la cantidad de datos del password           
            }
            if (Correo == string.Empty)
            {
                return -3; // error correo vacio
            }
            return 1; // todo OK
        }

    }
}
