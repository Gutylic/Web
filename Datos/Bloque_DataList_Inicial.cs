using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_DataList_Inicial
    {
        
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;
        int? Resultado;
        
        public List<Tabla_De_Ejercicios> Metodo_Mostrar_DataList_Del_Inicio()
        {
            return db.Mostrar_DataList_Del_Inicio().ToList();
        }

        public int? Metodo_Paginado_DataList_Del_Inicio()
        {
            db.Paginado_DataList_Del_Inicio(ref Cantidad);
            return Cantidad;
        }

        public int? Metodo_Determinar_Si_Es_Ejercicio_O_Video_Y_Pone_Uno_O_Dos_Botones(int ID_Ejercicio)
        {
            db.Determinar_Si_Es_Ejercicio_O_Video_Y_Pone_Uno_O_Dos_Botones(ID_Ejercicio, ref Resultado);
            return Resultado;
        }

        public int Metodo_Bonificacion_X_Cantidad(int ID_Usuario, int ID_Empresa, string IP_Address)
        {
            return db.Bonificacion_X_Cantidad(ID_Usuario, ID_Empresa, IP_Address);
        }

        public int Metodo_Comprar_Ejercicio_Desde_DataList_Inicial(int ID_Usuario, int ID_Ejercicio, string IP_Address, int ID_Empresa)
        {
            return db.Comprar_Ejercicio_Desde_DataList_Inicial(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);
        }

        public int Metodo_Comprar_Explicacion_Desde_DataList_Inicial(int ID_Usuario,int ID_Ejercicio,string IP_Address,int ID_Empresa)
        {
            return db.Comprar_Explicacion_Desde_DataList_Inicial(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);
        
        }

        public int Metodo_Comprar_Video_Desde_El_DataList_Inicial(int ID_Usuario, int ID_Ejercicio, string IP_Address, int ID_Empresa)
        {
            return db.Comprar_Video_Desde_El_DataList_Inicial(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);

        }

    }
}
