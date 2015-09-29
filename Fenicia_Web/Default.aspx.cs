using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Datos;
using Logica;

namespace Fenicia_Web
{
    public partial class Default : System.Web.UI.Page
    {

        #region Clases

        Logica_Bloque_Busqueda LBB = new Logica_Bloque_Busqueda();
        Logica_Bloque_Usuario LBU = new Logica_Bloque_Usuario();
        Logica_Bloque_DataList_Inicial LBDI = new Logica_Bloque_DataList_Inicial();
        Logica_Bloque_Comentarios LBC = new Logica_Bloque_Comentarios();
        Logica_Bloque_Panel_De_Control LBPDC = new Logica_Bloque_Panel_De_Control();
        Logica_Bloque_Panel_De_Movimientos LBPDM = new Logica_Bloque_Panel_De_Movimientos();
        Logica_Bloque_Carga_De_Credito LBCDC = new Logica_Bloque_Carga_De_Credito();
        Logica_Bloque_Profesor_On_Line LBPOL = new Logica_Bloque_Profesor_On_Line();

        #endregion


        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {
                Iniciar_Session(); // ejecutar el page_load  
                Condiciones_Paginacion(true); // armamos el paginado del datalist la primera vez que cargo la pagina, true me dice que determine mi paginado cuando arranco la pagina              
                Resultado_DataList_Inicial(0); // cargamos el datalist y le decimos que comienze por la primera pagina que es 0
            }
        }

        #endregion

        
        #region Abrir_Y_Cerrar_Session

        public void Iniciar_Session()
        {
            if (Request.Cookies["Usuario_Recordado"] != null) // cargar las coockies si es que existen y ya arranca logueado
            {
                Session["Usuario"] = Request.Cookies["Usuario_Recordado"]["Usuario"]; // cargar la coockie como usuario   
                Session["Password"] = Request.Cookies["Usuario_Recordado"]["Password"]; // cargar la coockie como usuario  
                Session["Variable_ID_Usuario"] = LBU.Logica_Loguear_Usuario((string)Session["Usuario"], (string)Session["Password"], 2); // cargar identificador del usuario desde la cookie luego de buscarlo en la base de datos
                if ((int)Session["Variable_ID_Usuario"] == -1) // error en la comprobacion de usuario y contraseña
                {
                    Eliminar_Cookie(); // borra todo vestijio de cookie
                    Panel_Logueado.Visible = false; // panel luego de loguearse
                    Panel_Inicial.Visible = true; // panel antes de loguearse 
                }
                else
                {
                    Panel_Logueado.Visible = true; // panel luego de loguearse
                    Panel_Inicial.Visible = false; // panel antes de loguearse                 
                }
                Usuario_Logueado.Text = "Usuario: " + (string)Session["Usuario"]; // carga el usuario en la etiqueta del panel logueado
            }
            else// si no hay cookies y vengo de otra pagina
            {
                if (Session["Usuario"] != null) // observa si hay una session activa para seguir logueado
                {
                    Panel_Inicial.Visible = false; // panel antes de loguearse
                    Panel_Logueado.Visible = true; // panel luego de loguearse
                    Usuario_Logueado.Text = "Usuario: " + (string)Session["Usuario"]; // carga el usuario en la etiqueta del panel logueado                    
                }
            }
        }

        public void Caduco_Session()
        {
            if (Session["Usuario"] == null) // verifica si termino la session
            {
                Response.Redirect("sefue.aspx"); // me redirige a la pagina
                Usuario_Logueado.Text = string.Empty; // vacia la etiqueta del usuario en el panel de logueado
                Usuario_Inicio.Text = string.Empty; // vacia la etiqueta del usuario en el panel inicial
                Password_Inicio.Text = string.Empty; // vacia la contraseña del usuario en el panel inicial
                Mantener_Session.Checked = false; // descheckea mantener session en el panel inicial
                Session.Clear(); // limpiar todas las variables de sesion del usuario
                Session.Abandon(); // abandonar las variables de sesion (esto se realiza con el fin de asegurarme que borro la session del usuario  
                Eliminar_Cookie(); // cerrar las variables de coockie
            }
        }

        protected void Cerrar_Sesion_Click(object sender, EventArgs e)
        {
            Panel_Inicial.Visible = true; // panel antes de loguearse
            Panel_Logueado.Visible = false; // panel despues de loguearse
            Usuario_Logueado.Text = string.Empty; // vacia la etiqueta del usuario en el panel de logueado
            Usuario_Inicio.Text = string.Empty; // vacia la etiqueta del usuario en el panel inicial
            Password_Inicio.Text = string.Empty; // vacia la contraseña del usuario en el panel inicial
            Mantener_Session.Checked = false; // descheckea mantener session en el panel inicial
            Session.Clear(); // limpiar todas las variables de sesion del usuario
            Session.Abandon(); // abandonar las variables de sesion (esto se realiza con el fin de asegurarme que borro la session del usuario  
            Eliminar_Cookie(); // cerrar las variables de coockie
        }

        #endregion

        
        #region Manejo_De_Session

        public void Guardar_Cookie(string Usuario, string Password, int ID_Usuario) // metodo generado para crear las cookies
        {
            HttpCookie Variable_Cookie = new HttpCookie("Usuario_Recordado"); // coockie definida como Usuario Recordado
            Variable_Cookie.Values.Add("Usuario", Usuario); // dentro de la coockie Usuario Recordado carga el usuario
            Variable_Cookie.Values.Add("Password", Password); // dentro de la coockie Usuario Recordado carga el Password 
            Variable_Cookie.Values.Add("ID_Usuario", ID_Usuario.ToString()); // dentro de la coocke Usuario Recordado carga el ID_Usuario
            Variable_Cookie.Expires = DateTime.Now.AddDays(90); // tiempo de vida de la coockie en la maquina del usuario 90 dias
            Response.Cookies.Add(Variable_Cookie);
        }

        public void Eliminar_Cookie() // metodo para eliminar la coockies
        {
            HttpCookie Variable_Cookie = new HttpCookie("Usuario_Recordado"); // coockie definida como Usuario Recordado
            Variable_Cookie.Expires = DateTime.Now.AddDays(-1d); // eliminamos la coockie diciendo que su vida en la maquina del usuario es hasta ayer 
            Response.Cookies.Add(Variable_Cookie);
        }

        [WebMethod()] // metodod de ajax para no abandonar la session y mantenerse logueado
        public static void Abandonar_Session() // se ejecuta si no esta tildado el checkbox de mantener el usuario, es una llamada desde aspx con javascript
        {
            HttpContext.Current.Session.Remove("Variable_Usuario"); // borro variable de usuario de la coockie
            HttpContext.Current.Session.Remove("Variable_Password"); // borro la contraseña de la coockie
            HttpContext.Current.Session.Remove("Variable_ID_Usuario"); // borro el identificador del usuario de la coockie
        }

        #endregion


        #region Captcha

        public class Dos_Valores_Para_Generar_Captcha // clase generada para que se ejecute el captcha ya que se necesita una imagen y el contenido de la imagen
        {
            public int Imagen_Captcha { get; set; } // las imagenes tienen nombres como 1.png ...

            public string Valor_Captcha { get; set; } // contienen el valor de la imagen
        }

        public Dos_Valores_Para_Generar_Captcha Generar_Captcha() // generar captchas
        {
            Dos_Valores_Para_Generar_Captcha Datos = new Dos_Valores_Para_Generar_Captcha();
            Random r = new Random(); // r es una variable que sirve para trabajar como numero randonico asi toma uno de los 6 captchas generados
            string[] Valores_De_Seguridad = new string[6] { "1a75K", "6h49L", "dJ56E", "NF74m", "7D26t", "3EM2i" }; // valores que hay en la imagen de cada captcha 
            Datos.Imagen_Captcha = r.Next(1, 7); // elige una imagen al azar y el valor de su contenido
            ViewState["Imagen_Captcha"] = Datos.Imagen_Captcha; // trae la imagen
            Datos.Valor_Captcha = Valores_De_Seguridad[Datos.Imagen_Captcha - 1]; // elige el valor de la imagen del captcha
            ViewState["Valor_Captcha"] = Datos.Valor_Captcha; // almacena el contenido de la imagen
            Imagen_Captcha.ImageUrl = "captcha/" + ViewState["Imagen_Captcha"].ToString() + ".png"; // lo muestra en la pagina del cliente
            return Datos;
        }

        #endregion

        
        #region Boton_De_Registro

        protected void Boton_Enviar_Registro_Click(object sender, EventArgs e)
        {

            Errores_Al_Registrar_El_Usuario(Usuario_Registro.Text, Password_Registro.Text, RePassword_Registro.Text, Captcha_Registro.Text, (string)ViewState["Valor_Captcha"], Condiciones_Registro.Checked, Correo_Registro.Text, Request.UserHostAddress.ToString());

            int Validez_De_La_Oferta = LBU.Logica_Bonificacion_X_Registrarse(Usuario_Registro.Text,2,Request.UserHostAddress.ToString());

            switch (Validez_De_La_Oferta)
            {

                case 1:
  
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('reglao por registrarse');", true);
                    break;

                case 0:

                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no regalo');", true);
                    break;

                default:

                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no se conecto a bd');", true);
                    break;

            }

        }

        public void Errores_Al_Registrar_El_Usuario(string Usuario, string Password, string RePassword, string Captcha, string Imagen_Del_Captcha, bool Condiciones, string Correo, string IP_Address)
        {

            int Errores_Registrar_Usuario = LBU.Logica_Insertar_Registro(Usuario, Password, RePassword, Captcha, Imagen_Del_Captcha, Condiciones, Correo, 2, IP_Address);

            if (Errores_Registrar_Usuario == -6)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no se conecto a bd');", true);
                return;
            }
            if (Errores_Registrar_Usuario == 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('ip bloqueada');", true);
                return;
            }
            if (Errores_Registrar_Usuario == -1)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('error usuario registrado');", true);
                return;
            }
            if (Errores_Registrar_Usuario == -2)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('error correo registrado');", true);
                return;
            }
            if (Errores_Registrar_Usuario == -10)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('usuario vacio o con mas de 10 caracteres');", true);
                return;
            }
            if (Errores_Registrar_Usuario == -11)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('usuario con un espacio vacio');", true);
                return;
            }
            if (Errores_Registrar_Usuario == -12)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no tiene forma de correo');", true);
                return;
            }
            if (Errores_Registrar_Usuario == -13)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('password con menos de 6 o mas de 10 caracteres');", true);
                return;
            }
            if (Errores_Registrar_Usuario == -14)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('password y confirmacion distintos');", true);
                return;
            }
            if (Errores_Registrar_Usuario == -15)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('correo vacio');", true);
                return;
            }
            if (Errores_Registrar_Usuario == -16)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('captcha vacio');", true);
                return;
            }
            if (Errores_Registrar_Usuario == -17)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('verificacion erronea del captcha');", true);
                return;
            }
            if (Errores_Registrar_Usuario == -18)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no acepto condiciones');", true);
                return;
            }


        }

        protected void Boton_Registrese_Click(object sender, EventArgs e)
        {
            Panel_De_Registro.Visible = true;
            Generar_Captcha();
        }

        public void Errores_Al_Reenviar_Activacion(string Usuario)
        {
            int Errores_Reenvio_Usuario = LBU.Logica_Reenvio_Activacion(Usuario, 2);

            if (Errores_Reenvio_Usuario == -6)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no se conecto a bd');", true);
                return;
            }
            if (Errores_Reenvio_Usuario == 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no esta en la base de datos');", true);
                return;
            }
            if (Errores_Reenvio_Usuario == 1)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('se envio su activacion de nuevo');", true);
                return;
            }
        }

        protected void Reenviar_Activacion_Click(object sender, EventArgs e)
        {
            Errores_Al_Reenviar_Activacion(Usuario_Registro.Text);
        }

        #endregion

        
        #region Boton_De_Logueo

        protected void Boton_Iniciar_Session_Click(object sender, EventArgs e)
        {
            Identificar_Al_Loguear_El_Usuario(Usuario_Inicio.Text, Password_Inicio.Text);
        }

        public void Identificar_Al_Loguear_El_Usuario(string Usuario, string Password)
        {
            int? Identificador_Del_Usuario = LBU.Logica_Loguear_Usuario(Usuario, Password, 2);

            if (Identificador_Del_Usuario == null)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('verifique el usuario y la contraseña');", true);
                return;
            }

            Session["Usuario"] = Usuario_Inicio.Text.ToLower(); // cargo el usuario y lo guardo en el servidor (se usa mas adelante en otros procedimientos)
            ViewState["Variable_Password"] = Password_Inicio.Text; // cargo la contraseña y la guardo en la maquina del cliente
            Session["Variable_ID_Usuario"] = Identificador_Del_Usuario; // cargo el ID del usuario lo guardo en el servidor (se usa mas adelante en otros procedimientos) si existe es porque ya estoy logueado
            Usuario_Logueado.Text = string.Empty; //es para asegurarse que no estoy logueado porque en algun procedimiento sin estar logueado lo ejecutaba 
            Usuario_Logueado.Text = "Usuario:" + (string)Session["Usuario"]; // carga la etiqueta con el usuario en el panel de de logueado
            Panel_Inicial.Visible = false; // panel antes de loguearse
            Panel_Logueado.Visible = true; // panel despues de loguearse

            if (Mantener_Session.Checked) // esta chequeado el recordarme para saber si queda la session almacenada en el usuario con ajax
            {
                Guardar_Cookie((string)Session["Usuario"], (string)ViewState["Variable_Password"], Convert.ToInt32(Session["Variable_ID_Usuario"])); // mantiene la session activa
            }
            else
            {
                Eliminar_Cookie(); // expirar session activa
            }

        }

        #endregion


        #region DataList

        public void Resultado_DataList_Inicial(int Pagina) // DataList Inicial recibe como parametro la pagina
        {
            ViewState["Momento"] = true; // variable de estado para avisarme que estoy con el resultado del datalist de inicio
            DataList_De_Resultados.DataSource = LBDI.Logica_Mostrar_DataList_Del_Inicio().Skip(Pagina * 20).Take(20); // paginado cada 20 hojas
            DataList_De_Resultados.DataBind();
        }

        public void Resultado_DataList_Busqueda(string Ano, string Profesor, string Tema, string Colegio, string Materia, int Pagina) //DataList de Busqueda recibe como parametros los datos de busqueda y la pagina
        {
            ViewState["Momento"] = false; // varuable de estado para avisarme que estoy con el resultado del datalist de busqueda
            DataList_De_Resultados.DataSource = LBB.Logica_Mostrar_DataList_De_Productos_En_El_Buscador_Inicial(Ano,Profesor, Colegio, Materia, Tema).Skip(Pagina * 20).Take(20); // paginado cada 20 hojas
            DataList_De_Resultados.DataBind();
        }

        protected void Logos_Asociados(object sender, DataListItemEventArgs e) // posisiona los logitos al costado de las respuestas del datalist
        {
           
                Tabla_De_Ejercicios Logo_De_La_Lista = new Tabla_De_Ejercicios();
                Logo_De_La_Lista = (Tabla_De_Ejercicios)e.Item.DataItem;
             
           

            Image Logo = new Image(); // genero una variable del tipo imagen para cambiar al vuelo la misma
            Logo = (Image)e.Item.FindControl("Imagen_Logos"); // la imagen se cambiara donde se encuentre el ID = Imagen_Logos
               
            switch (Logo_De_La_Lista.ID_Tipo_De_Ejercicio) // determino que de todos las columnas de la tabla de ejercicio solo me interesa ID_Tipo_De_Ejercicio
            {
                case 1: // ejercicio
                    Logo.ImageUrl = "imagen/logo_ejercicios.png";
                    Logo.ToolTip = "Ejercicio";
                    break;
                case 2: // explicacion
                    Logo.ImageUrl = "imagen/logo_ejercicios_filmados.png";
                    Logo.ToolTip = "Ejercicio Explicado";
                    break;
                case 3: // video
                    Logo.ImageUrl = "imagen/logo_videos.png";
                    Logo.ToolTip = "Videos";
                    break;
                case 4: // pack de videos
                    Logo.ImageUrl = "imagen/logo_pack_videos.png";
                    Logo.ToolTip = "Conjunto de Videos";
                    break;
            }
            
        }

        protected void Identificador(object sender, DataListCommandEventArgs e) // convierto al datalist en editable 
        {
            if (Usuario_Logueado.Text == string.Empty) // comportamiento del datalist si no estas logueado
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('logueate papu');", true);
                return;
            }
            Session["ID_Ejercicio"] = e.CommandName; // capturo en la variable de session el Identificador del ejercicio a mostrar al clickear encima del linkButton
            Enunciado.ImageUrl = "http://www.colegioeba.com/enunciado/Enunciado" + e.CommandName + ".png"; // carga el enunciado
            switch (LBDI.Logica_Determinar_Si_Es_Ejercicio_O_Video_Y_Pone_Uno_O_Dos_Botones(int.Parse(e.CommandName)))  // si se trata de un ejercicio o explicacion se necesitan dos botones, si se trata de un video o un pack solo un boton
            {
                case 1: // habilita el panel para mostrar dos botones
                    Ejercicios_Y_Explicaciones.Visible = true;
                    Videos.Visible = false;
                    break;
                case 2: // habilita el panel para mostrar dos botones
                    Ejercicios_Y_Explicaciones.Visible = true;
                    Videos.Visible = false;
                    break;
                case 3: // habilita el panel para mostrar un boton
                    Ejercicios_Y_Explicaciones.Visible = false;
                    Videos.Visible = true;
                    break;                
            }
        }

        #endregion


        #region Paginado_Del_DataList

        public void Condiciones_Paginacion(bool Momento) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Centros_Paginados.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Ultimo.Visible = false; // anterior de la ultima pagina
            if (Momento) // cuenta cuantos datos hay en la busqueda segun el momento
            {
            ViewState["Cantidad_De_Datos"] = LBDI.Logica_Paginado_DataList_Del_Inicio(); // momento inicial
            }
            else
            {
                ViewState["Cantidad_De_Datos"] = LBB.Logica_Paginado_DataList_Desde_El_Buscador_Inicial((string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Profesor"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (string)ViewState["Etiqueta_Tema"]); // momento buscado
            }
            ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Datos"] / 20; // cantidad de paginas segun la cantidad de datos            
            ViewState["Resto"] = (int)ViewState["Cantidad_De_Datos"] % 20; // me dice cuantos datos faltan para completar una pagina completa
            if ((int)ViewState["Resto"] == 0) // sin resto hay una cantidad de paginas completas y le debo restar uno para asegurarme que como inicio de cero la ultima pagina no se encuentre vacia
            {
                ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Paginas"] - 1;
            }
            if ((int)ViewState["Cantidad_De_Datos"] <= 20) // para saber si hay menos de 20 datos no aparezca el boton de siguiente
            {
                Siguiente_Primero.Visible = false;
            }
        }

        protected void Siguiente_Click(object sender, EventArgs e)
        {
            ViewState["Pagina"] = (int)ViewState["Pagina"] + 1;// sumo una pagina
            if ((int)ViewState["Pagina"] == (int)ViewState["Cantidad_De_Paginas"]) // mira si la pagina en la que estoy es igual a la pagina final (estoy en la ultima pagina)
            {
                if ((bool)ViewState["Momento"]) // esto es necesario para saber sobre que datalist trabajo, si sobre el inicial al abrir la pagina o sobre uno de busqueda
                {
                    Resultado_DataList_Inicial((int)ViewState["Pagina"]); // datalist inicial
                }
                else
                {
                    Resultado_DataList_Busqueda((string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Profesor"], (string)ViewState["Etiqueta_Tema"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (int)ViewState["Pagina"]); // datalist de busqueda
                }
                Centros_Paginados.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Extremos_Paginados.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo (contiene anterior ultimo y siguiente primero)
                Siguiente_Primero.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Anterior_Ultimo.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
            }
            else // sin no estoy en la ultima pagina
            {
                if ((bool)ViewState["Momento"])// esto es necesario para saber sobre que datalist trabajo, si sobre el inicial al abrir la pagina o sobre uno de busqueda
                {
                    Resultado_DataList_Inicial((int)ViewState["Pagina"]);// datalist inicial
                }
                else
                {
                    Resultado_DataList_Busqueda((string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Profesor"],(string)ViewState["Etiqueta_Tema"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (int)ViewState["Pagina"]);// datalist de busqueda
                }
                Centros_Paginados.Visible = true; // estoy en las paginas del centro
                Extremos_Paginados.Visible = false; // no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        protected void Anterior_Click(object sender, EventArgs e)
        {
            ViewState["Pagina"] = (int)ViewState["Pagina"] - 1; // resto una pagina
            if ((int)ViewState["Pagina"] == 0) // mira si esta en la primera pagina
            {
                if ((bool)ViewState["Momento"])// esto es necesario para saber sobre que datalist trabajo, si sobre el inicial al abrir la pagina o sobre uno de busqueda                
                {
                Resultado_DataList_Inicial((int)ViewState["Pagina"]);// datalist inicial
                }
                else
                {
                    Resultado_DataList_Busqueda((string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Profesor"], (string)ViewState["Etiqueta_Tema"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (int)ViewState["Pagina"]);// datalist de busqueda

                }
                Centros_Paginados.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero 
                Extremos_Paginados.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero (contiene anterior ultimo y siguiente primero)
                Siguiente_Primero.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero
                Anterior_Ultimo.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero
            }
            else// sin no estoy en la primera pagina
            {
                if ((bool)ViewState["Momento"])// esto es necesario para saber sobre que datalist trabajo, si sobre el inicial al abrir la pagina o sobre uno de busqueda
                {
                    Resultado_DataList_Inicial((int)ViewState["Pagina"]);// datalist inicial
                }
                else
                {
                    Resultado_DataList_Busqueda((string)ViewState["Etiqueta_Ano"],(string)ViewState["Etiqueta_Profesor"], (string)ViewState["Etiqueta_Tema"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (int)ViewState["Pagina"]);// datalist de busqueda

                }
                Centros_Paginados.Visible = true; // estoy en las paginas del centro
                Extremos_Paginados.Visible = false;// no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        #endregion


        #region Compra_De_Productos_DataList_Inicial
        protected void Boton_Compra_Ejercicio_Click(object sender, EventArgs e)
        {
            Caduco_Session();// metodo para verificar si caduco la session  
           
            int? Valor = LBDI.Logica_Comprar_Ejercicio_Desde_DataList_Inicial(Convert.ToInt32(Session["Variable_ID_Usuario"]), int.Parse((string)Session["ID_Ejercicio"]), Request.UserHostAddress.ToString(), 2); // resultado de la compra del producto el 1 representa la empresa observar que tambien tengo el valor del IP        
            switch (Valor)
            {
                case 0: // ya compraste el ejercicio evita que lo recompres
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('ya lo compraste');", true);
                    break;
                case 1: // el ejercicio fue comprado sin problemas
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('compro ok');", true);
                    break;
                case 2: // no tengo plata para comprar el ejercicio
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no tenes plata');", true);
                    break;
                default: // no se conectro a la base de datos
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no se conecto');", true);
                    break;
            }

            LBDI.Logica_Bonificacion_X_Cantidad(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Request.UserHostAddress.ToString());

  

        }

        protected void Boton_Compra_Explicacion_Click(object sender, EventArgs e)
        {
            Caduco_Session();// metodo para verificar si caduco la session  

            int? Valor = LBDI.Logica_Comprar_Explicacion_Desde_DataList_Inicial(Convert.ToInt32(Session["Variable_ID_Usuario"]), int.Parse((string)Session["ID_Ejercicio"]), Request.UserHostAddress.ToString(), 2); // resultado de la compra del producto el 1 representa la empresa observar que tambien tengo el valor del IP        
            switch (Valor)
            {
                case 0: // ya compraste el ejercicio evita que lo recompres
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('ya lo compraste');", true);
                    break;
                case 1: // el ejercicio fue comprado sin problemas
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('compro ok');", true);
                    break;
                case 2: // no tengo plata para comprar el ejercicio
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no tenes plata');", true);
                    break;
                default: // no se conectro a la base de datos
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no se conecto');", true);
                    break;
            }

            LBDI.Logica_Bonificacion_X_Cantidad(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Request.UserHostAddress.ToString());

        }

        protected void Boton_Compra_Video_Click(object sender, EventArgs e)
        {

            Caduco_Session();// metodo para verificar si caduco la session  

            int? Valor = LBDI.Logica_Comprar_Video_Desde_El_DataList_Inicial(Convert.ToInt32(Session["Variable_ID_Usuario"]), int.Parse((string)Session["ID_Ejercicio"]), Request.UserHostAddress.ToString(), 2); // resultado de la compra del producto el 1 representa la empresa observar que tambien tengo el valor del IP        
            switch (Valor)
            {
                case 0: // ya compraste el ejercicio evita que lo recompres
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('ya lo compraste');", true);
                    break;
                case 1: // el ejercicio fue comprado sin problemas
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('compro ok');", true);
                    break;
                case 2: // no tengo plata para comprar el ejercicio
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no tenes plata');", true);
                    break;
                default: // no se conectro a la base de datos
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no se conecto');", true);
                    break;
            }

            LBDI.Logica_Bonificacion_X_Cantidad(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Request.UserHostAddress.ToString());

        }

        #endregion


        #region Busqueda

        protected void Boton_Buscar_Click(object sender, EventArgs e)
        {
            Panel_De_Buqueda.Visible = true;
        }

        protected void Boton_Buscar_Seleccion_Click(object sender, EventArgs e)
        {
            int Valor = LBB.Logica_Errores_En_La_Busqueda(Buscar_x_Profesor.Text, Buscar_x_Ano.Text, Buscar_x_Colegio.Text, Buscar_x_Materia.Text, Buscar_x_Tema.Text); // determina el comportamiento al realizar la busqueda
            if (Valor == 0) // no cargue nada en todos los textbox del panel de busqueda
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('muchas respuestas');", true);
                Condiciones_Paginacion(true); // lo trabaja como si fuera la primera vez que abro la pagina al datalist
                Resultado_DataList_Inicial(0);
                return;
            }
            ViewState["Etiqueta_Profesor"] = LBB.Logica_Buscar_Profesor(Buscar_x_Profesor.Text); // cargo en una variable de usuario el profesor
            ViewState["Etiqueta_Ano"] = LBB.Logica_Buscar_Ano(Buscar_x_Ano.Text); // cargo en una variable de usuario el año
            ViewState["Etiqueta_Tema"] = LBB.Logica_Buscar_Tema(Buscar_x_Tema.Text); // cargo en una variable de usuario el tema
            ViewState["Etiqueta_Colegio"] = LBB.Logica_Buscar_Colegio(Buscar_x_Colegio.Text); // cargo en una variable de usuario el colegio
            ViewState["Etiqueta_Materia"] = LBB.Logica_Buscar_Materia(Buscar_x_Materia.Text); // cargo en una variable de usuario la materia
            Condiciones_Paginacion(false); // condiciones para el paginado adaptado al momento de la busqueda por eso es fales
            Resultado_DataList_Busqueda((string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Profesor"],(string)ViewState["Etiqueta_Tema"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], 0); // muestra las respuestas en el datalist de busqueda desde la pagina cero        
        }

        #endregion


        #region Comentario_De_Usuarios

        protected void Boton_Contacto_Click(object sender, EventArgs e)
        {

            int Valor = LBC.Logica_Contacto_De_Usuario(Nombre_Contacto.Text, Correo_Contacto.Text, Comentario_Contacto.Text, 2); // envio del comentario resultado de la interaccion, el uno es la empresa
            switch (Valor)
            { 
                case 0: // no envia por nombre vacio
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('nombre vacio');", true);
                    break;
                case -1: // no tienen forma de correo
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no tiene forma de correo');", true);
                    break;
                case -2: // comentario corto
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('comentario sin sentido');", true);
                    break;
                case -6: // no conecto con la base de datos
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no conecto');", true);
                    break;
                case 1: // se envio el comentario
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('ok');", true);
                    break;
            }
        }
                
        #endregion


        #region Panel_De_Control

        protected void Panel_De_Control_Click(object sender, EventArgs e)
        {
            Caduco_Session(); // metodo para verificar si caduco la session              
            Panel_De_Perfil_Del_Usuario.Visible = true; // abre el panel de control
            Usuario_Panel_Control.Text = (string)Session["Usuario"]; // carga el usuario
            List<Mostrar_El_Panel_De_Control_Del_UsuarioResult> Datos = LBPDC.Logica_Mostrar_El_Panel_De_Control_Del_Usuario(Convert.ToInt32(Session["Variable_ID_Usuario"])); // creo una variable de panel de control para que me traiga los datos del usuario           
            Contrasena_Panel_Control.Text = Datos[0].Password; // contraseña
            Correo_Panel_Control.Text = Datos[0].Correo; // correo
            Skype_Panel_Control.Text = Datos[0].Usuario_De_Skype; // Skype
            Celular_Panel_Control.Text = Datos[0].Numero_De_Celular; // celular
            Modelo_Panel_Control.Text = Datos[0].Modelo_De_Celular; // modelo
        }

        protected void Boton_Actualizar_Datos_Click(object sender, EventArgs e) // boton para actualizar el panel de control
        {
            Caduco_Session(); // metodo para verificar si caduco la session                  
            int? Valor = LBPDC.Logica_Metodo_Actualizar_El_Panel_De_Control(Convert.ToInt32(Session["Variable_ID_Usuario"]), Contrasena_Panel_Control.Text, Correo_Panel_Control.Text, Celular_Panel_Control.Text,Skype_Panel_Control.Text,  2 , Modelo_Panel_Control.Text); // muestra la respuesta al actualizar con nuevos datos el panel de control, la empresa es 1
            switch (Valor)
            {
                case 1: // actualizacion correcta

                    Guardar_Cookie((string)Session["Usuario"], Contrasena_Panel_Control.Text, (int)Session["Variable_ID_Usuario"]);

                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('actualizacion correcta');", true);
                    break;
                case 0: // correo ya registrado
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('el correo ya esta registrado');", true);
                    break;
                case -6: // no se conexto a la base de datos
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no se conecto');", true);
                    break;
                case -1:// no tiene forma de correo
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no formato de correo');", true);
                    break;
                case -2:// error por la cantidad de datos del passsword 
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('error password menos 6 letras');", true);
                    break;
                case -3:// error de correo vacio
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('error correo vacio');", true);
                    break;
            }
        }
        

        #endregion


        #region Panel_De_Movimientos
        protected void Panel_De_Movimientos_Click(object sender, EventArgs e)
        {
            Caduco_Session();// metodo para verificar si caduco la session                 
            Panel_De_Movimientos_De_Los_Usuarios.Visible = true; //abre el panel
            Usuario_Mis_Movimientos.Text = (string)Session["Usuario"]; // carga el usuario
            Credito_Usuario.Text = (LBPDM.Logica_Obtener_El_Credito_Del_Usuario(Convert.ToInt32(Session["Variable_ID_Usuario"]))).ToString(); // carga el credito del usuario en este momento
            DataList_Mis_Movimientos.DataSource = LBPDM.Logica_Mostrar_Los_Movimientos_Realizados_X_El_Usuario(Convert.ToInt32(Session["Variable_ID_Usuario"])).Take(15); // carga en un datalist los ultimos 15 movimientos
            DataList_Mis_Movimientos.DataBind();

        }

        #endregion

        
        #region Panel_De_Carga_De_Credito

        protected void Panel_De_Credito_Click(object sender, EventArgs e)
        {
            Caduco_Session();// metodo para verificar si caduco la session    
            Panel_De_Carga_De_Credito.Visible = true; //abre el panel para cargar por tarjeta o por prestamo sos 
        }

        protected void Boton_Prestamo_Click(object sender, EventArgs e)
        {
            Caduco_Session();// metodo para verificar si caduco la session     
            int? Valor = LBCDC.Logica_Pedido_Prestamo_SOS(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Request.UserHostAddress.ToString()); // resultado del prestamo SOS, el uno es la empresa
            switch (Valor)
            {
                case 1: // presto la plata
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('ok_Prestamo');", true);
                    break;
                case 0: // ya pidio un prestamo
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('ya pidio su prestamo');", true);
                    break;
                case -6: // no se conecto a la base de datos
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no se conecto');", true);
                    break;
            }
        }
        

        protected void Boton_Cargar_Tarjeta_Click(object sender, EventArgs e)
        {
            Caduco_Session();// metodo para verificar si caduco la session     
            decimal? Premio_1;  // variable preparada para saber si tiene premio la recarga
            decimal? Premio_2;  // variable preparada para saber si tiene premio la carga
            decimal? Plata = LBCDC.Logica_Obtener_Credito_De_La_Tarjeta(int.Parse(Codigo_Tarjeta.Text), 2); //determina si la tarjeta es valida y ademas me da el valor de la tarjeta
            if (Plata == null) // plata cero es que la tajeta se vencio o no existe
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('esa tarjeta no existe');", true); // mensaje
                return;
            }

            Premio_1 = LBCDC.Logica_Cargar_Premio_En_La_Proxima_Recarga(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Plata, Request.UserHostAddress.ToString()); // carga para la proxima recarga el premio

            Premio_2 = LBCDC.Logica_Bonificacion_X_Carga(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Request.UserHostAddress.ToString(), Plata); // bonificacion en la carga

            int Valor = LBCDC.Logica_Cargar_Credito_Usuarios(Convert.ToInt32(Session["Variable_ID_Usuario"]), Plata, 2, Request.UserHostAddress.ToString(), Premio_1, Premio_2); // resultado del codigo de la tarjeta un uno es la empresa y el otro uno es la descripcion del movimiento

            switch (Valor)
            {
                case 1: // cargo la tarjeta y ya se debito                    
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('carga ok');", true);
                    break;
                case -6: // no se conecto a la base de datos
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no se conecto');", true);
                    break;
            }
        }
              
        #endregion


        #region Mis_Ejercicios

        protected void Mis_Ejercicios_Click(object sender, EventArgs e)
        {
            Caduco_Session();// metodo para verificar si caduco la session    
            Response.Redirect("Mis_Ejercicios.aspx");
        }

        #endregion


        #region Mis_Explicaciones
        protected void Mis_Explicaciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mis_Explicaciones.aspx");
        }
        #endregion


        #region Profesor_On_Line
        protected void Boton_Profesor_On_Line_Click(object sender, EventArgs e)
        {
            Caduco_Session(); // metodo para verificar si caduco la session    
            if (Usuario_Logueado.Text == string.Empty) // no esta logueado no deja ingresar al profesor
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('logueate papu');", true);
                return;
            }
            
            if (LBPOL.Logica_Permitir_Uso_Del_Profesor_On_Line(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2) == 1) // si esta logueado pero averigua si puede realizar esta consulta por la plata que tenga el uno representa a la empresa
            {
                Response.Redirect("Profesor_On_Line.aspx"); // puede realizar la consulta
            }
            else // no puede usar el profesor por falta de plata
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no tenes plata papu');", true);
                return;
            }
        }

        #endregion

        #region Recuperar_Contraseña
        protected void Olvido_Password_Click(object sender, EventArgs e)
        {
            Response.Redirect("Recuperar_Contrasena.aspx");
        }
        #endregion
    }
}