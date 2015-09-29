using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Pagina_Ficha
    {

        Bloque_Pagina_Ficha BPF = new Bloque_Pagina_Ficha();

        public List<Tabla_De_Ejercicios> Logica_Mostrar_DataList_De_Productos_Sumilares_X_Ficha(string Profesor, string Ano, string Colegio, string Materia, string Tema)
        {
            return BPF.Metodo_Mostrar_DataList_De_Productos_Sumilares_X_Ficha(Profesor, Ano, Colegio, Materia, Tema).ToList();
        }

        public int? Logica_Paginado_DataList_Ficha(string Profesor, string Ano, string Colegio, string Materia, string Tema)
        {
            return BPF.Metodo_Paginado_DataList_Ficha(Profesor, Ano, Colegio, Materia, Tema);
           
        }

        public int Logica_Bonificacion_X_Cantidad(int ID_Usuario, int ID_Empresa, string IP_Address)
        {
            return BPF.Metodo_Bonificacion_X_Cantidad(ID_Usuario, ID_Empresa, IP_Address);
        }

        public int Logica_Comprar_Ejercicio_Desde_Pagina_Ficha(int ID_Usuario, int ID_Ejercicio, string IP_Address, int ID_Empresa)
        {
            return BPF.Metodo_Comprar_Ejercicio_Desde_Pagina_Ficha(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);

        }

        public int Logica_Comprar_Explicacion_Desde_Pagina_Ficha(int ID_Usuario, int ID_Ejercicio, string IP_Address, int ID_Empresa)
        {
            return BPF.Metodo_Comprar_Explicacion_Desde_Pagina_Ficha(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);

        }

        public int Logica_Comprar_Mi_Ejercicio_Personalizado_Desde_Ficha(int ID_Usuario, string IP_Address, int ID_Empresa, bool Adjunto, string Archivo,bool Explicacion_Personalizada)
        {
            return BPF.Metodo_Comprar_Mi_Ejercicio_Personalizado_Desde_Ficha(ID_Usuario, IP_Address, ID_Empresa, Adjunto, Archivo, Explicacion_Personalizada);
        }

        public int Logica_Comprar_Mi_Explicacion_Personalizada_Desde_Ficha(int ID_Usuario, string IP_Address, int ID_Empresa, bool Adjunto, string Archivo, bool Ejercicio_Personalizado)
        {
            return BPF.Metodo_Comprar_Mi_Explicacion_Personalizada_Desde_Ficha(ID_Usuario, IP_Address, ID_Empresa, Adjunto, Archivo,Ejercicio_Personalizado);
        }

        public int? Logica_Armar_El_Nombre_Del_Archivo_Numero_De_Consultas()
        {
            return BPF.Metodo_Armar_El_Nombre_Del_Archivo_Numero_De_Consultas();
            
        }

        public string Logica_Armado_Del_Nombre_Del_Archivo(string Usuario)
        {
            return Usuario + "╝" + Logica_Armar_El_Nombre_Del_Archivo_Numero_De_Consultas().ToString();
        }

        public string Logica_De_Correcion_De_Datos_Ingresados_En_La_Busqueda(string Texto) // metodo para corregir la busqueda del cliente
        {
            Texto = Texto.ToLower(); // pasar a minusculas
            Texto = Texto.Replace("\"", " ").Replace(",", " ").Replace("+", " ").Replace("'", " ").Replace("ñ", "n"); // eliminamos cualquier vestigio de comillas, de comas y sumas
            Byte[] tempBytes = Encoding.GetEncoding("ISO-8859-8").GetBytes(Texto); // quitar los acentos las eñes y las dieresis
            Texto = Encoding.UTF8.GetString(tempBytes);
            Texto = Texto.Replace(" ", "");
            Texto = Texto.Replace("  ", " ").Trim(); // linea que corrige el efecto de dos espacios y que quita los espacios al principio y final de la busqueda
            return Texto;

        }

        public int Logica_Errores_En_La_Busqueda(string Profesor, string Ano, string Colegio, string Materia, string Tema) // enviando los datos recogidos en el panel de busqueda me dice si se lleno o esta vacio
        {
            if (Profesor == string.Empty && Ano == string.Empty && Colegio == string.Empty && Materia == string.Empty && Tema == string.Empty) //vacio
            {
                return 0; // todo vacio
            }
            return 1; // lleno
        }

        public string Logica_Buscar_Profesor(string Profesor) // buscar las etiquetas que determinan al profesor
        {
            if (Profesor == null) { Profesor = string.Empty; }
            return BPF.Metodo_Buscar_Profesor(Logica_De_Correcion_De_Datos_Ingresados_En_La_Busqueda(Profesor));
        }

        public string Logica_Buscar_Ano(string Ano) // buscar las etiquetas que determinan al ano
        {
            if (Ano == null) { Ano = string.Empty; }
            return BPF.Metodo_Buscar_Ano(Logica_De_Correcion_De_Datos_Ingresados_En_La_Busqueda(Ano));
        }

        public string Logica_Buscar_Tema(string Tema) // buscar las etiquetas que determinan el tema
        {
            if (Tema == null) { Tema = string.Empty; }
            return BPF.Metodo_Buscar_Tema(Logica_De_Correcion_De_Datos_Ingresados_En_La_Busqueda(Tema));
        }

        public string Logica_Buscar_Colegio(string Colegio) // buscar las etiquetas que determinan el colegio
        {
            if (Colegio == null) { Colegio = string.Empty; }
            return BPF.Metodo_Buscar_Colegio(Logica_De_Correcion_De_Datos_Ingresados_En_La_Busqueda(Colegio));
        }

        public string Logica_Buscar_Materia(string Materia) // buscar las etiquetas que determinan la materia
        {
            if (Materia == null) { Materia = string.Empty; }
            return BPF.Metodo_Buscar_Materia(Logica_De_Correcion_De_Datos_Ingresados_En_La_Busqueda(Materia));
        }

    }
}
