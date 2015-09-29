using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_DataList_Inicial
    {

        Bloque_DataList_Inicial BDI = new Bloque_DataList_Inicial();
        public List<Tabla_De_Ejercicios> Logica_Mostrar_DataList_Del_Inicio()
        {
            return BDI.Metodo_Mostrar_DataList_Del_Inicio().ToList();
        }

        public int? Logica_Paginado_DataList_Del_Inicio()
        {
            return BDI.Metodo_Paginado_DataList_Del_Inicio();            
        }

        public int? Logica_Determinar_Si_Es_Ejercicio_O_Video_Y_Pone_Uno_O_Dos_Botones(int ID_Ejercicio)
        {
            return BDI.Metodo_Determinar_Si_Es_Ejercicio_O_Video_Y_Pone_Uno_O_Dos_Botones(ID_Ejercicio);          
        }

        public int Logica_Bonificacion_X_Cantidad(int ID_Usuario, int ID_Empresa, string IP_Address)
        {
            return BDI.Metodo_Bonificacion_X_Cantidad(ID_Usuario, ID_Empresa, IP_Address);
        }

        public int Logica_Comprar_Ejercicio_Desde_DataList_Inicial(int ID_Usuario, int ID_Ejercicio, string IP_Address, int ID_Empresa)
        {
            return BDI.Metodo_Comprar_Ejercicio_Desde_DataList_Inicial(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);            
        }

        public int Logica_Comprar_Explicacion_Desde_DataList_Inicial(int ID_Usuario, int ID_Ejercicio, string IP_Address, int ID_Empresa)
        {
            return BDI.Metodo_Comprar_Explicacion_Desde_DataList_Inicial(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);

        }
        
        public int Logica_Comprar_Video_Desde_El_DataList_Inicial(int ID_Usuario, int ID_Ejercicio, string IP_Address, int ID_Empresa)
        {
            return BDI.Metodo_Comprar_Video_Desde_El_DataList_Inicial(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);

        }

    }
}
