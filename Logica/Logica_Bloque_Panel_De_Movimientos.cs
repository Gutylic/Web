using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Panel_De_Movimientos
    {
        Bloque_Panel_De_Movimientos BPDM = new Bloque_Panel_De_Movimientos();

        public List<Mostrar_Los_Movimientos_Realizados_X_El_UsuarioResult> Logica_Mostrar_Los_Movimientos_Realizados_X_El_Usuario(int ID_Usuario)
        {
            return BPDM.Metodo_Mostrar_Los_Movimientos_Realizados_X_El_Usuario(ID_Usuario);

        }

        public decimal? Logica_Obtener_El_Credito_Del_Usuario(int ID_Usuario)
        {
            return BPDM.Metodo_Obtener_El_Credito_Del_Usuario(ID_Usuario);

        }

    }
}
