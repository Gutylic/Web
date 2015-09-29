using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Comentarios
    {

        DataClassesDataContext db = new DataClassesDataContext();

        public int Metodo_Comentarios_De_Los_Usuarios(string Nombre, string Correo, string Comentario, int ID_Empresa)
        {
            return db.Comentarios_De_Los_Usuarios(Nombre, ID_Empresa, Correo, Comentario);
        }

    }
}
