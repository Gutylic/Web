using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Profesor_On_Line
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Consultas;

        public int Metodo_Permitir_Uso_Del_Profesor_On_Line(int ID_Usuario, int ID_Empresa)
        {
            return db.Permitir_Uso_Del_Profesor_On_Line(ID_Usuario, ID_Empresa);
        }

        public int Metodo_Comprar_Mi_Ejercicio_Personalizado(int ID_Usuario, string IP_Address, int ID_Empresa, string Archivo_Adjunto, string Archivo_Ficha, string Archivo_Enunciado)
        {
            return db.Comprar_Mi_Ejercicio_Personalizado(ID_Usuario, IP_Address, ID_Empresa, Archivo_Adjunto, Archivo_Ficha, Archivo_Enunciado);
        }

        public int? Metodo_Armar_El_Nombre_Del_Archivo_Numero_De_Consultas()
        {
            db.Armar_El_Nombre_Del_Archivo_Numero_De_Consultas(ref Consultas);
            return Consultas;
        }

        public int Metodo_Bonificacion_X_Cantidad(int ID_Usuario, int ID_Empresa, string IP_Address)
        {
            return db.Bonificacion_X_Cantidad(ID_Usuario, ID_Empresa, IP_Address);
        }



    }
}
