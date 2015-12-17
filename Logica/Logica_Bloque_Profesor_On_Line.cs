using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Profesor_On_Line
    {
        Bloque_Profesor_On_Line BPOL = new Bloque_Profesor_On_Line();

        public int Logica_Permitir_Uso_Del_Profesor_On_Line(int ID_Usuario, int ID_Empresa)
        {
            return BPOL.Metodo_Permitir_Uso_Del_Profesor_On_Line(ID_Usuario, ID_Empresa);
        }

        public int Logica_Comprar_Mi_Ejercicio_Personalizado(int ID_Usuario, string IP_Address, int ID_Empresa, string Archivo_Adjunto, string Archivo_Ficha, string Archivo_Enunciado)
        {
            return BPOL.Metodo_Comprar_Mi_Ejercicio_Personalizado(ID_Usuario, IP_Address, ID_Empresa, Archivo_Adjunto, Archivo_Ficha, Archivo_Enunciado);
        }

        public int? Logica_Armar_El_Nombre_Del_Archivo_Numero_De_Consultas()
        {
            return BPOL.Metodo_Armar_El_Nombre_Del_Archivo_Numero_De_Consultas();
        }

        public string Logica_Armado_Del_Nombre_Del_Archivo(string Usuario) 
        {
            return Usuario + "╝" + Logica_Armar_El_Nombre_Del_Archivo_Numero_De_Consultas().ToString();
        }

        public string Logica_Correccion_Profesor(string Enunciado)
        {
            string Linea = "";
            // quitare todos los caracteres que genera wiris para que el codigo quede limpio y sin espacio
            string[] Terminos_Borrados = new string[] { "<msubsup>", "<mmultiscripts>", "<presubsup>", "</presubsup>", "<mprescripts/>", "<none/>", "</mmultiscripts>", "</msubsup>", "<mo largeop=\"true\">", "<mrow/>", "<munder>", "</munder>", "<munderover>", "</munderover>", "<mover>", "</mover>", "<menclose notation=\"updiagonalstrike\">", "</menclose>", "<mfenced open=\"|\" close=\"|\">", "</mfenced>", "<mi mathvariant=\"normal\">", "<mfrac>", "</mfrac>", "<msup>", "</msup>", "<msub>", "</msub>", "<mrow>", "</mrow>", "<msqrt>", "</msqrt>", "<mroot>", "</mroot>", "<mi>", "</mi>", "<mn>", "</mn>", "<mo>", "</mo>", "<mspace linebreak=\"newline\"/>", "&#8201;", "</math>", "<math xmlns=\"http://www.w3.org/1998/Math/MathML\">", "<maction actiontype=\"argument\">", "</maction>", "<mstyle displaystyle=\"true\">", "</mstyle>", "<mfenced open=\"||\" close=\"||\">", "<menclose notation=\"circle\">", "<menclose notation=\"actuarial\">", "<menclose notation=\"roundedbox\">", "<menclose notation=\"roundedbox\"/>", "<menclose notation=\"top\">", "<menclose notation=\"left\">", "<menclose notation=\"box\"/>", "<menclose notation=\"right\">", "<menclose notation=\"bottom\"/>", "<mfenced open=\"&#8970;\" close=\"&#8971;\">", "<mfenced open=\"&lt;\" close=\"&#62;\" separators=\"|\">", "<mfenced open=\"&#8968;\" close=\"&#8969;\">", "<menclose notation=\"top\"/>", "<menclose notation=\"left\"/>", "<menclose notation=\"right\"/>", "<menclose notation=\"circle\"/>", "<menclose notation=\"actuarial\"/>", "<menclose notation=\"bottom\">", "<menclose notation=\"box\">", "<menclose notation=\"downdiagonalstrike\">", "<menclose notation=\"downdiagonalstrike updiagonalstrike\">", "<menclose notation=\"horizontalstrike\">", "<menclose notation=\"verticalstrike\">", "<menclose>", "<menclose notation=\"verticalstrike horizontalstrike\">", "<menclose notation=\"horizontalstrike\">", "<menclose notation=\"downdiagonalstrike\"/>", "<menclose notation=\"downdiagonalstrike updiagonalstrike\"/>", "<menclose notation=\"verticalstrike\"/>", "<menclose>", "<menclose notation=\"verticalstrike horizontalstrike\"/>", "<menclose/>", "<mtable>", "<mtr>", "<mtd/>", "</mtr>", "</mtable>", "<mtd>", "</mtd>", "<mfenced open=\"[\" close=\"]\">", "<mfenced>", "<mfenced open=\"[\" close=\"]\">", "<mfenced open=\"[\" close=\"]\">", "<mfenced open=\"{\" close=\"\">", "<mtable columnalign=\"left\">", "<mfenced open=\"\" close=\"}\">", 
              "&#172;","&#175;","&#176;","&#177;","&#183;","&#960;","&#729;","&#168;","&#945;","&#946;","&#947;","&#948;","&#949;","&#950;","&#951;","&#952;","&#977;","&#953;","&#954;","&#955;","&#956;","&#957;","&#958;","&#959;","&#982;","&#961;","&#962;","&#963;","&#964;","&#965;","&#966;","&#981;","&#967;","&#968;","&#969;","&#913;","&#914;","&#915;","&#916;","&#917;","&#918;","&#919;","&#920;","&#921;","&#922;","&#923;","&#924;","&#925;","&#926;","&#927;","&#928;","&#929;","&#931;","&#932;","&#933;","&#934;","&#935;","&#936;","&#937;","&#8597;","&#8592;", "&#8593;","&#8595;","&#8596;","&#8594;","&#8598;", "&#8599;","&#8600;","&#8601;","&#8618;","&#8629;","&#8657;","&#8645;","&#8659;","&#8617;","&#8661;","&#8636;","&#8637;","&#8646;","&#8651;","&#8652;","&#8640;","&#8644;","&#8641;","&#8656;","&#8658;","&#8660;","&#8612;","&#8614;","&#8704;","&#8706;", "&#8707;" ,"&#8708;","&#8709;","&#8710;","&#8711;", "&#8712;","&#8715;","&#8721;","&#8719;","&#8713;", "&#8716;","&#8728;", "&#8726;", "&#8723;","&#8729;","&#8733;","&#8734;","&#8736;","&#8737;","&#8738;","&#8741;","&#8742;","&#8743;", "&#8744;","&#8745;","&#8746;","&#8756;","&#8757;","&#8769;","&#8773;","&#8776;", "&#8747;","&#8750;","&#8748;","&#8751;","&#8749;","&#8752;","&#8801;", "&#8804;","&#8805;", "&#8810;", "&#8826;","&#8834;","&#8835;", "&#8838;", "&#8839;","&#8847;" ,"&#8848;", "&#8849;", "&#8850;","&#8851;","&#8852;","&#8853;","&#8855;","&#8857;", "&#8859;", "&#8861;","&#8869;","&#8882;", "&#8883;","&#8900;","&#9633;","&#9649;","&#9651;","&#9675;","&#9180;","&#9181;","&#9183;","&#9182;","&#10808;","&#10888;","&#10529;","&#10530;","&#10606;","&#10602;","&#10607;","&#10605;"};
            string[] Enunciado_Limpio = Enunciado.Split(Terminos_Borrados, StringSplitOptions.RemoveEmptyEntries);
            foreach (string Caracter in Enunciado_Limpio) // genero una variable nueva ya corregida si los caracteres raros de wiris
            {
                Linea = Linea + Caracter;
            }
            // pongo todos los terminos en minusculas y saco los acentos
            Linea = Linea.ToLower();
            Linea = Linea.Replace("&#x000a0;", "");
            Linea = Linea.Replace("<mo></mo>", "");
            Linea = Linea.Replace("&#225;", "a");
            Linea = Linea.Replace("&#233;", "e");
            Linea = Linea.Replace("&#237;", "i");
            Linea = Linea.Replace("&#243;", "o");
            Linea = Linea.Replace("&#250;", "u");
            Linea = Linea.Replace("&#160;", " ");
            Linea = Linea.Replace("&#193;", "a");
            Linea = Linea.Replace("&#201;", "e");
            Linea = Linea.Replace("&#205;", "i");
            Linea = Linea.Replace("&#211;", "o");
            Linea = Linea.Replace("&#218;", "u");
            Linea = Linea.Replace("&#209;", "n");
            Linea = Linea.Replace("Á;", "a");
            Linea = Linea.Replace("É", "e");
            Linea = Linea.Replace("Í", "i");
            Linea = Linea.Replace("Ó", "o");
            Linea = Linea.Replace("Ú", "u");
            Linea = Linea.Replace("ñ", "n");
            Linea = Linea.Replace("Ñ", "n");
            Linea = Linea.Replace("º", "");

            Linea = Linea.Trim(); // elimino los espacios delante y detras de la variable creada
            return Linea; // variable final limpia de wiris

        }

        public void Logica_Cargar_Enunciado_Movil(string Enunciado, string Usuario)
        {
            string Archivo = Usuario + "╝" + Logica_Armar_El_Nombre_Del_Archivo_Numero_De_Consultas().ToString(); // arma el nombre
            
            StreamWriter Editor_Corregido = File.CreateText(("C:\\archivo/") + Archivo + "_clean.txt"); // carga el archivo corregido del enunciado en c:
            string Contenido = Enunciado.ToLower();// pasa a todo el enunciado de wiris a minusculas
            Editor_Corregido.Write(Contenido);
            Editor_Corregido.Flush();
            Editor_Corregido.Close();
            StreamWriter Editor = File.CreateText(("C:\\archivo/") + Archivo + "_math.txt"); // carga el archivo natural del enunciado en c:
            Contenido = Enunciado; 
            Editor.Write(Contenido);
            Editor.Flush();
            Editor.Close();
        }


        public string Logica_Cargar_Enunciado(string Enunciado, string Usuario) // carga dos archivos en c: correspondiente a los enunciados
        {
            string Archivo = Usuario + "╝" + Logica_Armar_El_Nombre_Del_Archivo_Numero_De_Consultas().ToString(); // arma el nombre
            string Enunciado_Corregido = Logica_Correccion_Profesor(Enunciado); // corrigiendo el enunciado
            StreamWriter Editor_Corregido = File.CreateText(("C:\\archivo/") + Archivo + "_clean.txt"); // carga el archivo corregido del enunciado en c:
            string Contenido = Enunciado_Corregido;
            Editor_Corregido.Write(Contenido);
            Editor_Corregido.Flush();
            Editor_Corregido.Close();
            StreamWriter Editor = File.CreateText(("C:\\archivo/") + Archivo + "_math.txt"); // carga el archivo natural del enunciado en c:
            Contenido = Enunciado.ToLower(); // pasa a todo el enunciado de wiris a minusculas
            Editor.Write(Contenido);
            Editor.Flush();
            Editor.Close();
            return Enunciado_Corregido; // devuelve el enunciado corregido para luego separarlo en cuatro percentiles del 25%
        }


        public void Logica_Cargar_Ficha(string Tema, string Materia, string Profesor, string Colegio, string Ano, string Usuario) // crea la ficha
        {
            string Archivo = Usuario + "╝" + Logica_Armar_El_Nombre_Del_Archivo_Numero_De_Consultas().ToString(); // pone todos los datos en minusculas
            Tema = Tema.ToLower();
            Materia = Materia.ToLower();
            Profesor = Profesor.ToLower();
            Colegio = Colegio.ToLower();
            Ano = Ano.ToLower();// genera un archivo ficha con los datos separados por el chirimbolo
            StreamWriter Ficha = File.CreateText(("C:\\archivo/") + Archivo + "_ficha.txt");// escribe dentri del archivo
            Ficha.Write("Tema: ╝");
            Ficha.Write(Tema + " ╝// ");
            Ficha.Write("Materia: ╝");
            Ficha.Write(Materia + " ╝// ");
            Ficha.Write("Profesor: ╝");
            Ficha.Write(Profesor + " ╝// ");
            Ficha.Write("Colegio: ╝");
            Ficha.Write(Colegio + " ╝// ");
            Ficha.Write("Ano: ╝");
            Ficha.Write(Ano);
            Ficha.Flush();
            Ficha.Close();
        }

        public class Dos_Datos_String_Para_Buscar_Por_Enunciado // clase extra utilizada para que alguna clase me devuelva dos valores
        {
            public string Valor_1 { get; set; }
            public string Valor_2 { get; set; }
        }

        public Dos_Datos_String_Para_Buscar_Por_Enunciado Logica_Enunciados_Al_25(string Enunciado)
        {
            Dos_Datos_String_Para_Buscar_Por_Enunciado Datos = new Dos_Datos_String_Para_Buscar_Por_Enunciado();
            //decimal Cantidad = Enunciado.Split(' ').Length; // cuento la cantidad de espacios en blanco para determinar la cantidad de palabras que tiene el enunciado
            string[] Palabras = Enunciado.Split(' ');
            int Cantidad_De_Palabras = Palabras.Length;
            int Porcentaje = Cantidad_De_Palabras / 4;
            int Resto = Cantidad_De_Palabras % 4;
            int Palabras_Exactas;
            int Palabras_Erroneas;

            if (Cantidad_De_Palabras == 1)
            {
                Datos.Valor_1 = "\"" + Palabras[0].Trim() + "\"";  // Variable 1
                Datos.Valor_2 = "\"" + Palabras[0].Trim() + "\"";  // Variable 2          
                return Datos;
            }
            if (Cantidad_De_Palabras == 2)
            {
                Datos.Valor_1 = "\"" + Palabras[0].Trim() + "\"";  // Variable 1
                Datos.Valor_2 = "\"" + Palabras[1].Trim() + "\"";  // Variable 2          
                return Datos;
            }
            if (Cantidad_De_Palabras == 3)
            {
                Datos.Valor_1 = "\"" + Palabras[0].Trim() + "\"";  // Variable 1
                Datos.Valor_2 = "\"" + Palabras[2].Trim() + "\"";  // Variable 2          
                return Datos;
            }


            if (Resto != 0)
            {
                Palabras_Exactas = Porcentaje + 1;

            }
            else
            {
                Palabras_Exactas = Porcentaje;
            }

            if (Resto == 1 || Resto == 2)
            {
                Palabras_Erroneas = Porcentaje;
            }
            else
            {
                Palabras_Erroneas = Porcentaje + 1;
            }

            string[] Palabras_Armadas = new string[Palabras_Exactas];
            string[] Palabra = new string[2]; 
         
            for (int i = 0; i < Palabras_Exactas; i++) 
            {
                Palabra[0] =  Palabra[0] + " " + Palabras[i] ;
            
            }

            for (int i = (Palabras_Exactas + Palabras_Erroneas); i < (2 * Palabras_Exactas + Palabras_Erroneas); i++)
            {
                Palabra[1] = Palabra[1] + " " + Palabras[i];

            }

            Datos.Valor_1 = "\"" +  Palabra[0].Trim() + "\"";  // Variable 1
            Datos.Valor_2 = "\"" + Palabra[1].Trim() + "\"";  // Variable 2          
            return Datos;
        }

        public int Logica_Bonificacion_X_Cantidad(int ID_Usuario, int ID_Empresa, string IP_Address)
        {
            return BPOL.Metodo_Bonificacion_X_Cantidad(ID_Usuario, ID_Empresa, IP_Address);
        }

    }

}
