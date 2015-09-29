using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Panel_De_Movimientos
    {

        DataClassesDataContext db = new DataClassesDataContext();
        decimal? Credito_De_Usuario;

        public List<Mostrar_Los_Movimientos_Realizados_X_El_UsuarioResult> Metodo_Mostrar_Los_Movimientos_Realizados_X_El_Usuario(int ID_Usuario)
        {
            return db.Mostrar_Los_Movimientos_Realizados_X_El_Usuario(ID_Usuario).ToList();
        }

        public decimal? Metodo_Obtener_El_Credito_Del_Usuario(int ID_Usuario)
        { 
            db.Obtener_El_Credito_Del_Usuario(ID_Usuario, ref Credito_De_Usuario);
            return Credito_De_Usuario;
        }
    }
}
