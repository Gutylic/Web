using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Panel_De_Control
    {

        DataClassesDataContext db = new DataClassesDataContext();

        public List<Mostrar_El_Panel_De_Control_Del_UsuarioResult> Metodo_Mostrar_El_Panel_De_Control_Del_Usuario(int ID_Usuario)
        {
            return db.Mostrar_El_Panel_De_Control_Del_Usuario(ID_Usuario).ToList();
        }

        public int Metodo_Actualizar_El_Panel_De_Control(int ID_Usuario, string Password, string Correo, string Numero_De_Celular, string Usuario_De_Skype, int ID_Empresa, string Modelo_De_Celular)
        {
            return  db.Actualizar_El_Panel_De_Control(ID_Usuario, Password, Correo, Numero_De_Celular, Usuario_De_Skype, ID_Empresa, Modelo_De_Celular);   
        }


    }
}
