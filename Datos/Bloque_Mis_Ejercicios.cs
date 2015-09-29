using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Mis_Ejercicios
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? Resultado;
        string Ubicacion;

        public List<Mostrar_DataList_En_Mis_EjerciciosResult> Metodo_Mostrar_DataList_En_Mis_Ejercicios(int ID_Usuario)
        {
            return db.Mostrar_DataList_En_Mis_Ejercicios(ID_Usuario).ToList();
        }

        public int? Metodo_Paginado_Mis_Ejercicios(int ID_Usuario)
        {
            db.Paginado_Mis_Ejercicios(ID_Usuario, ref Resultado);
            return Resultado;
        }

        public string Metodo_Buscar_Ubicacion_De_La_Respuesta_De_Los_Ejercicios(int ID_Ejercicio)
        {
            db.Buscar_Ubicacion_De_La_Respuesta_De_Los_Ejercicios(ID_Ejercicio, ref Ubicacion);
            return Ubicacion;
        }

        public string Metodo_Buscar_Ubicacion_De_La_Respuesta_Del_Ejercicio_Imprimible(int ID_Ejercicio)
        {
            db.Buscar_Ubicacion_De_La_Respuesta_Del_Ejercicio_Imprimible(ID_Ejercicio, ref Ubicacion);
            return Ubicacion;
        }

        public string Metodo_Buscar_Ubicacion_De_Los_Videos(int ID_Ejercicio)
        {
            db.Buscar_Ubicacion_De_Los_Videos(ID_Ejercicio, ref Ubicacion);
            return Ubicacion;
        }

        public int Metodo_Comprar_Ejercicio_Desde_Mis_Ejercicios(int ID_Usuario, int ID_Ejercicio, string  IP_Address, int ID_Empresa)
        {
            return db.Comprar_Ejercicio_Desde_Mis_Ejercicios(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);
        }

        public int Metodo_Comprar_Explicacion_Desde_Mis_Ejercicios(int ID_Usuario, int ID_Ejercicio, string IP_Address, int ID_Empresa)
        {
            return db.Comprar_Explicacion_Desde_Mis_Ejercicios(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);
        }

        public int Metodo_Comprar_Ejercicio_Para_Imprimir(int ID_Usuario, int ID_Ejercicio, string IP_Address, int ID_Empresa )
        {
            return db.Comprar_Ejercicio_Para_Imprimir(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);
        
        }

        public int Metodo_Ver_Si_El_Ejercicio_Fue_Comprado_Desde_Mis_Ejercicios(int ID_Usuario, int ID_Ejercicio)
        {
            return db.Ver_Si_El_Ejercicio_Fue_Comprado_Desde_Mis_Ejercicios(ID_Usuario, ID_Ejercicio);
        }

        public int Metodo_Ver_Si_La_Explicacion_Fue_Comprado_Desde_Mis_Ejercicios(int ID_Usuario, int ID_Ejercicio)
        {
            return db.Ver_Si_La_Explicacion_Fue_Comprado_Desde_Mis_Ejercicios(ID_Usuario, ID_Ejercicio);
        }

        public int Metodo_Bonificacion_X_Cantidad(int ID_Usuario, int ID_Empresa, string IP_Address)
        {
            return db.Bonificacion_X_Cantidad(ID_Usuario, ID_Empresa, IP_Address);
        }
            
    }
}
