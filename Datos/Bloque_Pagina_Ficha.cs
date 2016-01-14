using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Pagina_Ficha
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;
        int? Consultas;
        string Etiqueta_Armada;       

        public List<Tabla_De_Ejercicios> Metodo_Mostrar_DataList_De_Productos_Sumilares_X_Ficha(string Profesor, string Ano, string Colegio, string Materia, string Tema)
        { 
            return db.Mostrar_DataList_De_Productos_Similares_X_Ficha(Profesor, Ano,  Colegio,  Materia,  Tema).ToList();
        }

        public int? Metodo_Paginado_DataList_Ficha (string Profesor, string Ano, string Colegio, string Materia, string Tema)
        { 
            db.Paginado_DataList_Ficha(Profesor,Ano,Colegio,Materia,Tema,ref Cantidad);
            return Cantidad;
        }

        public int Metodo_Bonificacion_X_Cantidad(int ID_Usuario, int ID_Empresa, string IP_Address)
        {
            return db.Bonificacion_X_Cantidad(ID_Usuario, ID_Empresa, IP_Address);
        }

        public int Metodo_Comprar_Ejercicio_Desde_Pagina_Ficha(int ID_Usuario, int ID_Ejercicio, string IP_Address, int ID_Empresa)
        {
            return db.Comprar_Ejercicio_Desde_Pagina_Ficha(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);

        }

        public int Metodo_Comprar_Explicacion_Desde_Pagina_Ficha(int ID_Usuario, int ID_Ejercicio, string IP_Address, int ID_Empresa)
        {
            return db.Comprar_Explicacion_Desde_Pagina_Ficha(ID_Usuario, ID_Ejercicio, IP_Address, ID_Empresa);

        }

        public int Metodo_Comprar_Mi_Ejercicio_Personalizado_Desde_Ficha(int ID_Usuario, string IP_Address, int ID_Empresa, bool Adjunto, string Archivo,string Nombre_Adjunto,bool Explicacion_Personalizada,string Existencia_Enunciado)
        {
            return db.Comprar_Mi_Ejercicio_Personalizado_Desde_Ficha(ID_Usuario, IP_Address, ID_Empresa, Adjunto, Archivo,Nombre_Adjunto,Explicacion_Personalizada,Existencia_Enunciado);
        }

        public int Metodo_Comprar_Mi_Explicacion_Personalizada_Desde_Ficha(int ID_Usuario, string IP_Address, int ID_Empresa, bool Adjunto, string Archivo, string Nombre_Adjunto, bool Ejercicio_Personalizado,string Existencia_Enunciado)
        {
            return db.Comprar_Mi_Explicacion_Personalizada_Desde_Ficha(ID_Usuario, IP_Address, ID_Empresa, Adjunto, Archivo,Nombre_Adjunto,Ejercicio_Personalizado,Existencia_Enunciado);
        }

        public int? Metodo_Armar_El_Nombre_Del_Archivo_Numero_De_Consultas()
        {
            db.Armar_El_Nombre_Del_Archivo_Numero_De_Consultas(ref Consultas);
            return Consultas;
        }

        public string Metodo_Buscar_Profesor(string Dato) // vamos a formar la etiqueta de consulta para el profesor
        {
            Etiqueta_Armada = string.Empty;
            if (Dato == string.Empty) // dato llega vacio 
            {
                return "\"p*\"";  // devuelve la cadena string con un comodin especial para constains
            }
            List<Tabla_De_Profesores> Etiqueta_Tabla_Profesor = (db.Buscar_En_Tabla_Profesores(Dato).ToList());  // busca en la tabla profesores y me devuelve una lista              
            try
            {
                foreach (Tabla_De_Profesores s in Etiqueta_Tabla_Profesor) // paso la lista a una variable string
                {
                    Etiqueta_Armada = Etiqueta_Armada + "p" + s.Etiqueta_Profesor + " or "; //separo cada componente de la lista con un or especial para la busqueda constains
                }
                return Etiqueta_Armada + "p0"; // agregar la etiqueta cero que es la etiqueta por defecto
            }
            catch
            {
                return "p0";
            }
        }

        public string Metodo_Buscar_Materia(string Dato) // vamos a formar la etiqueta de consulta para el materia
        {
            Etiqueta_Armada = string.Empty;
            if (Dato == string.Empty) // dato llega vacio
            {
                return "\"m*\"";// devuelve la cadena string con un comodin especial para constains
            }
            List<Tabla_De_Materias> Etiqueta_Tabla_Materia = (db.Buscar_En_Tabla_Materias(Dato).ToList());// busca en la tabla materias y me devuelve una lista    
            try
            {
                foreach (Tabla_De_Materias s in Etiqueta_Tabla_Materia) // paso la lista a una variable string
                {
                    Etiqueta_Armada = Etiqueta_Armada + "m" + s.Etiqueta_Materia + " or ";//separo cada componente de la lista con un or especial para la busqueda constains
                }
                return Etiqueta_Armada + "m0";// agregar la etiqueta cero que es la etiqueta por defecto
            }
            catch
            {
                return "m0";
            }
        }

        public string Metodo_Buscar_Tema(string Dato) // etiqueta la consulta
        {
            Etiqueta_Armada = string.Empty;
            if (Dato == string.Empty) // dato llega vacio
            {
                return "\"t*\"";// devuelve la cadena string con un comodin especial para constains
            }
            List<Tabla_De_Temas> Etiqueta_Tabla_Tema = (db.Buscar_En_Tabla_Temas(Dato).ToList());// busca en la tabla temas y me devuelve una lista                 
            try
            {
                foreach (Tabla_De_Temas s in Etiqueta_Tabla_Tema)  // paso la lista a una variable string 
                {
                    Etiqueta_Armada = Etiqueta_Armada + "t" + s.Etiqueta_Tema + " or ";//separo cada componente de la lista con un or especial para la busqueda constains
                }
                return Etiqueta_Armada + "t0";// agregar la etiqueta cero que es la etiqueta por defecto
            }
            catch
            {
                return "t0";
            }
        }

        public string Metodo_Buscar_Ano(string Dato) // etiqueta la consulta
        {
            Etiqueta_Armada = string.Empty;
            if (Dato == string.Empty) // dato llega vacio
            {
                return "\"a*\"";// devuelve la cadena string con un comodin especial para constains
            }
            List<Tabla_De_Anos> Etiqueta_Tabla_Ano = (db.Buscar_En_Tabla_Anos(Dato).ToList());// busca en la tabla Años y me devuelve una lista  
            try
            {
                foreach (Tabla_De_Anos s in Etiqueta_Tabla_Ano) // paso la lista a una variable string  
                {
                    Etiqueta_Armada = Etiqueta_Armada + "a" + s.Etiqueta_Ano + " or ";//separo cada componente de la lista con un or especial para la busqueda constains
                }
                return Etiqueta_Armada + "a0";// agregar la etiqueta cero que es la etiqueta por defecto
            }
            catch { return "a0"; }
        }

        public string Metodo_Buscar_Colegio(string Dato) // etiqueta la consulta
        {
            Etiqueta_Armada = string.Empty;
            if (Dato == string.Empty) // dato llega vacio
            {
                return "\"c*\"";// devuelve la cadena string con un comodin especial para constains
            }
            List<Tabla_De_Colegios> Etiqueta_Tabla_Colegio = (db.Buscar_En_Tabla_Colegios(Dato).ToList());// busca en la tabla Colegio y me devuelve una lista  
            try
            {
                foreach (Tabla_De_Colegios s in Etiqueta_Tabla_Colegio) // paso la lista a una variable string 
                {
                    Etiqueta_Armada = Etiqueta_Armada + "c" + s.Etiqueta_Colegio + " or ";//separo cada componente de la lista con un or especial para la busqueda constains
                }
                return (Etiqueta_Armada + "c0");// agregar la etiqueta cero que es la etiqueta por defecto
            }
            catch
            { return "c0"; }
        }

       
    }
}
