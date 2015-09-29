using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Comentarios
    {

        Bloque_Comentarios BC = new Bloque_Comentarios();
        //public int Logica_Comentarios_De_Los_Usuarios(string Nombre, string Correo, string Comentario, int ID_Empresa)
        //{
        //     Logica_Contacto_De_Usuario(Nombre, Correo, Comentario, ID_Empresa);
        //}

        public int Logica_Error_Al_Ingresar_Un_Comentario_Por_El_Usuario(string Nombre, string Correo, string Comentario) // metodo de captado de errores en el comentario
        {
            if (Nombre == string.Empty)
            {
                return 0; // error por nombre vacio      
            }
            if (Correo.IndexOf("@", 0) == -1 || Correo.IndexOf(".", 0) == -1)// no tiene forma de correo
            {
                return -1; // no tiene forma de correo
            }
            if (Comentario.Length <= 5)
            {
                return -2; // error por la cantidad de palabras en el comentario          
            }
            return 1;
        }

        public int Logica_Contacto_De_Usuario(string Nombre, string Correo, string Comentario, int Empresa)
        {
            int Valor = Logica_Error_Al_Ingresar_Un_Comentario_Por_El_Usuario(Nombre, Correo, Comentario); // tipos de error al ingresar un comentario
            if (Valor != 1)
            {
                return Valor;
            }
            return BC.Metodo_Comentarios_De_Los_Usuarios(Nombre, Correo, Comentario, Empresa); // si no hay error devuelve lo que diga la base de datos
        }
    }
}
