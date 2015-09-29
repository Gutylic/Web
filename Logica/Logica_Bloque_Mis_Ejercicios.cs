using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Mis_Ejercicios
    {

        Bloque_Mis_Ejercicios BME = new Bloque_Mis_Ejercicios(); 

        public List<Mostrar_DataList_En_Mis_EjerciciosResult> Logica_Mostrar_DataList_En_Mis_Ejercicios(int ID_Usuario)
        {
            return BME.Metodo_Mostrar_DataList_En_Mis_Ejercicios(ID_Usuario).ToList();
        }

        public int? Logica_Paginado_Mis_Ejercicios(int ID_Usuario)
        {
            return BME.Metodo_Paginado_Mis_Ejercicios(ID_Usuario);
            
        }

        public string Logica_Buscar_Ubicacion_De_La_Respuesta_De_Los_Ejercicios(int ID_Ejercicio)
        {
            return BME.Metodo_Buscar_Ubicacion_De_La_Respuesta_De_Los_Ejercicios(ID_Ejercicio);
            
        }

        public string Logica_Buscar_Ubicacion_De_La_Respuesta_Del_Ejercicio_Imprimible(int ID_Ejercicio)
        {
            return BME.Metodo_Buscar_Ubicacion_De_La_Respuesta_Del_Ejercicio_Imprimible(ID_Ejercicio);
          
        }

        public string Logica_Buscar_Ubicacion_De_Los_Videos(int ID_Ejercicio)
        {
            return BME.Metodo_Buscar_Ubicacion_De_Los_Videos(ID_Ejercicio);
            
        }

        public int Logica_Comprar_Ejercicio_Desde_Mis_Ejercicios(int ID_Usuario, int ID_Ejercicio, string IP_Address, int ID_Empresa)
        {
            return BME.Metodo_Comprar_Ejercicio_Desde_Mis_Ejercicios(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);
        }

        public int Logica_Comprar_Explicacion_Desde_Mis_Ejercicios(int ID_Usuario, int ID_Ejercicio, string IP_Address, int ID_Empresa)
        {
            return BME.Metodo_Comprar_Explicacion_Desde_Mis_Ejercicios(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);
        }

        public int Logica_Comprar_Ejercicio_Para_Imprimir(int ID_Usuario, int ID_Ejercicio, string IP_Address, int ID_Empresa)
        {
            return BME.Metodo_Comprar_Ejercicio_Para_Imprimir(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);

        }

        public int Logica_Ver_Si_El_Ejercicio_Fue_Comprado_Desde_Mis_Ejercicios(int ID_Usuario, int ID_Ejercicio)
        {
            return BME.Metodo_Ver_Si_El_Ejercicio_Fue_Comprado_Desde_Mis_Ejercicios(ID_Usuario, ID_Ejercicio);
        }

        public int Logica_Ver_Si_La_Explicacion_Fue_Comprado_Desde_Mis_Ejercicios(int ID_Usuario, int ID_Ejercicio)
        {
            return BME.Metodo_Ver_Si_La_Explicacion_Fue_Comprado_Desde_Mis_Ejercicios(ID_Usuario, ID_Ejercicio);
        }

        public int Logica_Bonificacion_X_Cantidad(int ID_Usuario, int ID_Empresa, string IP_Address)
        {
            return BME.Metodo_Bonificacion_X_Cantidad(ID_Usuario, ID_Empresa, IP_Address);
        }

    }
}
