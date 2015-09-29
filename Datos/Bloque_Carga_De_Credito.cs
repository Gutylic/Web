using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Carga_De_Credito
    {

        DataClassesDataContext db = new DataClassesDataContext();
        decimal? Premio_X_Carga;
        decimal? Credito_De_La_Tarjeta;
        decimal? Premio_Proxima_Recarga;

        public decimal? Metodo_Bonificacion_X_Carga(int ID_Usuario, int ID_Empresa, string IP_Address, decimal? Plata)
        {
            db.Bonificacion_X_Carga(ID_Usuario, ID_Empresa, IP_Address, Plata, ref Premio_X_Carga);
            return Premio_X_Carga;
        }

        public decimal? Metodo_Cargar_Premio_En_La_Proxima_Recarga(int ID_Usuario, int ID_Empresa, decimal? Plata, string IP_Address)
        { 
            db.Cargar_Premio_En_La_Proxima_Recarga(ID_Usuario,ID_Empresa,Plata,IP_Address, ref Premio_Proxima_Recarga);
            return Premio_Proxima_Recarga;
        }


        public decimal? Metodo_Obtener_Credito_De_La_Tarjeta(int Codigo, int ID_Empresa)
        {
            db.Obtener_Credito_De_La_Tarjeta(Codigo, ID_Empresa, ref Credito_De_La_Tarjeta);
            return Credito_De_La_Tarjeta;
        }

        public int Metodo_Pedido_Prestamo_SOS(int ID_Usuario, int ID_Empresa, string IP_Address)
        {
            return db.Pedido_Prestamo_SOS(ID_Usuario, ID_Empresa, IP_Address);        
        }

        public int Metodo_Cargar_Credito_Usuarios(int ID_Usuario, decimal? Plata, int ID_Descripcion, string IP_Address, decimal? Premio_1, decimal? Premio_2)
        {
            return db.Cargar_Credito_Usuarios(ID_Usuario, Plata, ID_Descripcion, IP_Address, Premio_1, Premio_2);
        }
    }
}
