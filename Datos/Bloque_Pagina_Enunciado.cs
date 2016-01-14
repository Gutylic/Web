using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Pagina_Enunciado
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;
        int? Consultas;
   

        public List<Tabla_MATH_De_Ejercicios> Metodo_Mostrar_DataList_De_Productos_Sumilares_X_Enunciado(string Enunciado_1, string Enunciado_2)
        {
            return db.Mostrar_DataList_De_Productos_Similares_X_Enunciado(Enunciado_1, Enunciado_2).ToList();
        }

        public int? Metodo_Paginado_DataList_Enunciado(string Enunciado_1, string Enunciado_2)
        {
            db.Paginado_DataList_Enunciado(Enunciado_1,Enunciado_2, ref Cantidad);
            return Cantidad;
        }

        public int Metodo_Bonificacion_X_Cantidad(int ID_Usuario, int ID_Empresa, string IP_Address)
        {
            return db.Bonificacion_X_Cantidad(ID_Usuario, ID_Empresa, IP_Address);
        }

        public int Metodo_Comprar_Ejercicio_Desde_Pagina_Enunciado(int ID_Usuario, int ID_Ejercicio, string IP_Address, int ID_Empresa)
        {
            return db.Comprar_Ejercicio_Desde_Pagina_Enunciado(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);

        }

        public int Metodo_Comprar_Explicacion_Desde_Pagina_Enunciado(int ID_Usuario, int ID_Ejercicio, string IP_Address, int ID_Empresa)
        {
            return db.Comprar_Explicacion_Desde_Pagina_Enunciado(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);

        }

        public int Metodo_Comprar_Mi_Ejercicio_Personalizado_Desde_Enunciado(int ID_Usuario, string IP_Address, int ID_Empresa, bool Adjunto, string Archivo, string Nombre_Adjunto, bool Ejercicio_Personalizado, string Enunciado)
        {
            return db.Comprar_Mi_Ejercicio_Personalizado_Desde_Enunciado(ID_Usuario, IP_Address, ID_Empresa, Adjunto, Archivo,Nombre_Adjunto, Ejercicio_Personalizado,Enunciado );
        }

        public int Metodo_Comprar_Mi_Explicacion_Personalizada_Desde_Enunciado(int ID_Usuario, string IP_Address, int ID_Empresa, bool Adjunto, string Archivo, string Nombre_Adjunto, bool Explicacion_Personalizada, string Enunciado)
        {
            return db.Comprar_Mi_Explicacion_Personalizada_Desde_Enunciado(ID_Usuario, IP_Address, ID_Empresa, Adjunto, Archivo,Nombre_Adjunto, Explicacion_Personalizada,Enunciado);
        }

        public int? Metodo_Armar_El_Nombre_Del_Archivo_Numero_De_Consultas()
        {
            db.Armar_El_Nombre_Del_Archivo_Numero_De_Consultas(ref Consultas);
            return Consultas;
        }

       

    }
}

