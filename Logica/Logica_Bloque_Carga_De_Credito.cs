using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Carga_De_Credito
    {

        Bloque_Carga_De_Credito BCDC = new Bloque_Carga_De_Credito();

        public decimal? Logica_Bonificacion_X_Carga(int ID_Usuario, int ID_Empresa, string IP_Address, decimal? Plata)
        {
            return BCDC.Metodo_Bonificacion_X_Carga(ID_Usuario, ID_Empresa, IP_Address, Plata);
          
        }

        public decimal? Logica_Obtener_Credito_De_La_Tarjeta(int Codigo, int ID_Empresa)
        {
            return BCDC.Metodo_Obtener_Credito_De_La_Tarjeta(Codigo, ID_Empresa);
           
        }

         public decimal? Logica_Cargar_Premio_En_La_Proxima_Recarga(int ID_Usuario, int ID_Empresa, decimal? Plata, string IP_Address)
        { 
            return BCDC.Metodo_Cargar_Premio_En_La_Proxima_Recarga(ID_Usuario,ID_Empresa,Plata,IP_Address);
           
        }

        public int Logica_Pedido_Prestamo_SOS(int ID_Usuario, int ID_Empresa, string IP_Address)
        {
            return BCDC.Metodo_Pedido_Prestamo_SOS(ID_Usuario, ID_Empresa, IP_Address);

        }

        public int Logica_Cargar_Credito_Usuarios(int ID_Usuario, decimal? Plata, int ID_Descripcion, string IP_Address, decimal? Premio_1, decimal? Premio_2)
        {
            return BCDC.Metodo_Cargar_Credito_Usuarios(ID_Usuario, Plata, ID_Descripcion, IP_Address, Premio_1, Premio_2);
        }
    }
}
