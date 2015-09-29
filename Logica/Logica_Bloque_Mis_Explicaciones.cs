using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Mis_Explicaciones
    {
        Bloque_Mis_Explicaciones BME = new Bloque_Mis_Explicaciones();

        public List<Mostrar_DataList_En_Mis_ExplicacionesResult> Logica_Mostrar_DataList_En_Mis_Explicaciones(int ID_Usuario)
        {
            return BME.Metodo_Mostrar_DataList_En_Mis_Explicaciones(ID_Usuario).ToList();
        }

        public int? Logica_Paginado_Mis_Explicaciones(int ID_Usuario)
        {
            return BME.Metodo_Paginado_Mis_Explicaciones(ID_Usuario);
            
        }

        public string Logica_Buscar_Ubicacion_De_Los_Videos(int ID_Ejercicio)
        {
            return BME.Metodo_Buscar_Ubicacion_De_Los_Videos(ID_Ejercicio);
            
        }

        public int Logica_Bonificacion_X_Cantidad(int ID_Usuario, int ID_Empresa, string IP_Address)
        {
            return BME.Metodo_Bonificacion_X_Cantidad(ID_Usuario, ID_Empresa, IP_Address);
        }


    }
}
  