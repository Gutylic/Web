using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Mis_Explicaciones
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Resultado;
        string Ubicacion;

        public List<Mostrar_DataList_En_Mis_ExplicacionesResult> Metodo_Mostrar_DataList_En_Mis_Explicaciones(int ID_Usuario)
        {
            return db.Mostrar_DataList_En_Mis_Explicaciones(ID_Usuario).ToList();
        }

        public int? Metodo_Paginado_Mis_Explicaciones(int ID_Usuario)
        {
            db.Paginado_Mis_Explicaciones(ID_Usuario, ref Resultado);
            return Resultado;
        }
                
        public string Metodo_Buscar_Ubicacion_De_Los_Videos(int ID_Ejercicio)
        {
            db.Buscar_Ubicacion_De_Los_Videos(ID_Ejercicio, ref Ubicacion);
            return Ubicacion;
        }
       
        public int Metodo_Bonificacion_X_Cantidad(int ID_Usuario, int ID_Empresa, string IP_Address)
        {
            return db.Bonificacion_X_Cantidad(ID_Usuario, ID_Empresa, IP_Address);
        }

    }
}
