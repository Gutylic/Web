using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Datos;
using Logica;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace Fenicia_Web
{
    public partial class index : System.Web.UI.Page
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
                if (Session["Variable_ID_Usuario"] == null) // error en la comprobacion de usuario y contraseña
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

            int Validez_De_La_Oferta = LBU.Logica_Bonificacion_X_Registrarse(Usuario_Registro.Text, 2, Request.UserHostAddress.ToString());

            if (Validez_De_La_Oferta != -6)
            {
                string OK = @"<script type='text/javascript'>   
                                   alert('su usuario ya fué registrado con exito, en momentos recibirá en su correo electrónico un email con su activacion a la pagina');
                                   $(function () {                                       
                                        $('#Registro').modal('hide');   
                                   });
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", OK, false);
                Bordes_Textbox();
                Vaciar_Textbox();
                Boton_Enviar_Registro.Enabled = true;
                return;
            }
            else
            {
                string alerta_10 = @"<script type='text/javascript'>  
                                        alert('su registro no pudo ser completado satisfactoriamente, intentelo más tarde');
                                      </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta_10, false);
                return;

            }

        }

        public void Errores_Al_Registrar_El_Usuario(string Usuario, string Password, string RePassword, string Captcha, string Imagen_Del_Captcha, bool Condiciones, string Correo, string IP_Address)
        {

            int Errores_Registrar_Usuario = LBU.Logica_Insertar_Registro(Usuario, Password, RePassword, Captcha, Imagen_Del_Captcha, Condiciones, Correo, 2, IP_Address);

            if (Errores_Registrar_Usuario == -6)
            {
                string alerta_10 = @"<script type='text/javascript'>  
                                        alert('su registro no pudo ser completado satisfactoriamente, intentelo más tarde');
                                      </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta_10, false);
                return;
            }
            if (Errores_Registrar_Usuario == 0)
            {
                string alerta_1 = @"<script type='text/javascript'>  
                                        alert('su usuario no puede ser registrado, en este momento');  
                                      </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta_1, false);
                Bordes_Textbox();
                Usuario_Registro.BorderColor = System.Drawing.Color.Red;
                Boton_Enviar_Registro.Enabled = true;
                return;
            }
            if (Errores_Registrar_Usuario == -1)
            {
                string alerta_1 = @"<script type='text/javascript'>  
                                        alert('su usuario no puede ser registrado, pruebe con otro');  
                                      </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta_1, false);
                Bordes_Textbox();
                Usuario_Registro.BorderColor = System.Drawing.Color.Red;
                Boton_Enviar_Registro.Enabled = true;
                return;
            }
            if (Errores_Registrar_Usuario == -2)
            {
                string alerta_9 = @"<script type='text/javascript'> 
                                        alert('el correo electrónico por usted designado ya se encuentra registrado, modifiquelo y confirme nuevamente las contraseñas');                                        
                                      </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta_9, false);
                Bordes_Textbox();
                Password_Registro.BorderColor = System.Drawing.Color.Red;
                RePassword_Registro.BorderColor = System.Drawing.Color.Red;
                Correo_Registro.BorderColor = System.Drawing.Color.Red;
                Boton_Enviar_Registro.Enabled = true;
                return;
            }
            if (Errores_Registrar_Usuario == -10)
            {
                string alerta_1 = @"<script type='text/javascript'>  
                                        alert('su usuario no puede ser registrado, si esta vacio el casillero o tiene más de 10 caracteres');  
                                      </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta_1, false);
                Bordes_Textbox();
                Usuario_Registro.BorderColor = System.Drawing.Color.Red;
                Boton_Enviar_Registro.Enabled = true;
                return;
            }
            if (Errores_Registrar_Usuario == -11)
            {
                string alerta_1 = @"<script type='text/javascript'>  
                                        alert('su usuario no tiene el formato permitido anule espacios y quite algunos caracteres');  
                                      </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta_1, false);
                Bordes_Textbox();
                Usuario_Registro.BorderColor = System.Drawing.Color.Red;
                Boton_Enviar_Registro.Enabled = true;
                return;
            }
            if (Errores_Registrar_Usuario == -12)
            {
                string error_caracteres = @"<script type='text/javascript'>  
                                        alert('el tipo de correo ingresado no es válido'); 
                                        </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", error_caracteres, false);
                Bordes_Textbox();
                Correo_Registro.BorderColor = System.Drawing.Color.Red;
                Boton_Enviar_Registro.Enabled = true;
                return;
            }
            if (Errores_Registrar_Usuario == -13)
            {
                string alerta_2 = @"<script type='text/javascript'>  
                                        alert('su contraseña no cumple con los requisitos requeridos');  
                                      </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta_2, false);
                Bordes_Textbox();
                Password_Registro.BorderColor = System.Drawing.Color.Red;
                RePassword_Registro.BorderColor = System.Drawing.Color.Red;
                Boton_Enviar_Registro.Enabled = true;
                return;
            }
            if (Errores_Registrar_Usuario == -14)
            {
                string alerta_3 = @"<script type='text/javascript'>
                                        alert('sus contraseñas no son iguales'); 
                                      </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta_3, false);
                Bordes_Textbox();
                Password_Registro.BorderColor = System.Drawing.Color.Red;
                RePassword_Registro.BorderColor = System.Drawing.Color.Red;
                Boton_Enviar_Registro.Enabled = true;
                return;
            }
            if (Errores_Registrar_Usuario == -15)
            {
                string alerta_4 = @"<script type='text/javascript'>    
                                        alert('el casillero del correo electrónico no puede quedar vacio');
                                      </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta_4, false);
                Bordes_Textbox();
                Correo_Registro.BorderColor = System.Drawing.Color.Red;
                Password_Registro.BorderColor = System.Drawing.Color.Red;
                RePassword_Registro.BorderColor = System.Drawing.Color.Red;
                Boton_Enviar_Registro.Enabled = true;
                return;
            }
            if (Errores_Registrar_Usuario == -16)
            {
                string alerta_5 = @"<script type='text/javascript'>    
                                        alert('No escribio ninguna imagen, escriba la misma y vuelva a registrarse');
                                      </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta_5, false);
                Bordes_Textbox();
                Captcha_Registro.BorderColor = System.Drawing.Color.Red;
                Password_Registro.BorderColor = System.Drawing.Color.Red;
                RePassword_Registro.BorderColor = System.Drawing.Color.Red;
                Boton_Enviar_Registro.Enabled = true;
                return;
            }
            if (Errores_Registrar_Usuario == -17)
            {
                string alerta_6 = @"<script type='text/javascript'>    
                                        alert('no escribio la imagen correctamente, por favor hagalo nuevamente e ingrese las contraseñas');                                        
                                      </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta_6, false);
                Generar_Captcha();
                Captcha_Registro.Text = string.Empty;
                Bordes_Textbox();
                Captcha_Registro.BorderColor = System.Drawing.Color.Red;
                Password_Registro.BorderColor = System.Drawing.Color.Red;
                RePassword_Registro.BorderColor = System.Drawing.Color.Red;
                Boton_Enviar_Registro.Enabled = true;
                return;
            }
            if (Errores_Registrar_Usuario == -18)
            {
                string alerta_7 = @"<script type='text/javascript'>   
                                        alert('no acepto las condiciones de la pagina, acepte marcando la casilla correspondiente');                                        
                                      </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta_7, false);
                Bordes_Textbox();
                Password_Registro.BorderColor = System.Drawing.Color.Red;
                RePassword_Registro.BorderColor = System.Drawing.Color.Red;
                Boton_Enviar_Registro.Enabled = true;
                return;
            }


        }

        public void Bordes_Textbox()
        {
            Password_Registro.BorderColor = System.Drawing.Color.Empty;
            RePassword_Registro.BorderColor = System.Drawing.Color.Empty;
            Captcha_Registro.BorderColor = System.Drawing.Color.Empty;
            Correo_Registro.BorderColor = System.Drawing.Color.Empty;
            Usuario_Registro.BorderColor = System.Drawing.Color.Empty;
        }

        public void Vaciar_Textbox()
        {
            Password_Registro.Text = string.Empty;
            RePassword_Registro.Text = string.Empty;
            Captcha_Registro.Text = string.Empty;
            Correo_Registro.Text = string.Empty;
            Usuario_Registro.Text = string.Empty;
        }


        public void Boton_Registrese_Click(object sender, EventArgs e)
        {
            Generar_Captcha();
            Bordes_Textbox();
            Vaciar_Textbox();
        }

        public void Errores_Al_Reenviar_Activacion(string Usuario)
        {
            int Errores_Reenvio_Usuario = LBU.Logica_Reenvio_Activacion(Usuario, 2);

            if (Errores_Reenvio_Usuario == -6)
            {
                string FALLO = @"<script type='text/javascript'>    
                                   alert('intente más tarde la conexión'); 
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", FALLO, false);
                Bordes_Textbox();
                Usuario_Registro.BorderColor = System.Drawing.Color.Red;
                Vaciar_Textbox();
                return;
            }
            if (Errores_Reenvio_Usuario == 0)
            {
                string FALLO = @"<script type='text/javascript'>    
                                   alert('ingrese un usuario registrado'); 
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", FALLO, false);
                Bordes_Textbox();
                Usuario_Registro.BorderColor = System.Drawing.Color.Red;
                Vaciar_Textbox();
                return;
            }
            if (Errores_Reenvio_Usuario == 1)
            {
                string OK = @"<script type='text/javascript'>  
                                   alert('le reenviamos a su correo electrónico nuevamente su codigo de activación');
                                   $(function () {                                       
                                        $('#Registro').modal('hide');    
                                   });
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", OK, false);
                Bordes_Textbox();
                Vaciar_Textbox();
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
            //System.Threading.Thread.Sleep(5999);
            Identificar_Al_Loguear_El_Usuario(Usuario_Inicio.Text.ToLower(), Password_Inicio.Text);
        }

        public void Identificar_Al_Loguear_El_Usuario(string Usuario, string Password)
        {
            int? Identificador_Del_Usuario = LBU.Logica_Loguear_Usuario(Usuario, Password, 2);

            if (Identificador_Del_Usuario == null)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('los datos ingresados no son validos, ingrese nuevamente los mismos');", true);
                Usuario_Inicio.BorderColor = System.Drawing.Color.Red;
                Password_Inicio.BorderColor = System.Drawing.Color.Red;
                return;
            }
            else
            {

                Session["Usuario"] = Usuario_Inicio.Text; // cargo el usuario y lo guardo en el servidor (se usa mas adelante en otros procedimientos)
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
            DataList_De_Resultados.DataSource = LBB.Logica_Mostrar_DataList_De_Productos_En_El_Buscador_Inicial(Ano, Profesor, Colegio, Materia, Tema).Skip(Pagina * 20).Take(20); // paginado cada 20 hojas
            DataList_De_Resultados.DataBind();
        }

        protected void Logos_Asociados(object sender, DataListItemEventArgs e) // posisiona los logitos al costado de las respuestas del datalist
        {

            Tabla_De_Ejercicios Logo_De_La_Lista = new Tabla_De_Ejercicios();
            Logo_De_La_Lista = (Tabla_De_Ejercicios)e.Item.DataItem;

            System.Web.UI.WebControls.Image Logo = new System.Web.UI.WebControls.Image(); // genero una variable del tipo imagen para cambiar al vuelo la misma
            Logo = (System.Web.UI.WebControls.Image)e.Item.FindControl("Imagen_Logos"); // la imagen se cambiara donde se encuentre el ID = Imagen_Logos

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
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "openModal_NoLogueado()", true);
                return;
            }
            Session["ID_Ejercicio"] = e.CommandName; // capturo en la variable de session el Identificador del ejercicio a mostrar al clickear encima del linkButton
            string Enunciado = "http://www.colegioeba.com/enunciado/Enunciado" + e.CommandName + ".png"; // carga el enunciado
            switch (LBDI.Logica_Determinar_Si_Es_Ejercicio_O_Video_Y_Pone_Uno_O_Dos_Botones(int.Parse(e.CommandName)))  // si se trata de un ejercicio o explicacion se necesitan dos botones, si se trata de un video o un pack solo un boton
            {
                case 1: // habilita el panel para mostrar dos botones
                    ScriptManager.RegisterStartupScript(UpdatePanel_Resultados_Del_Datalist, GetType(), "", "openModal('" + Enunciado + ", 1')", true);
                    break;                   
                case 2: // habilita el panel para mostrar dos botones
                   ScriptManager.RegisterStartupScript(UpdatePanel_Resultados_Del_Datalist, GetType(), "", "openModal('" + Enunciado + ", 1')", true);
                   break;
                case 3: // habilita el panel para mostrar un boton
                    ScriptManager.RegisterStartupScript(UpdatePanel_Resultados_Del_Datalist, GetType(), "", "openModal('" + Enunciado + ", 2')", true);
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
                    Resultado_DataList_Busqueda((string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Profesor"], (string)ViewState["Etiqueta_Tema"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (int)ViewState["Pagina"]);// datalist de busqueda
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
                    Resultado_DataList_Busqueda((string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Profesor"], (string)ViewState["Etiqueta_Tema"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (int)ViewState["Pagina"]);// datalist de busqueda

                }
                Centros_Paginados.Visible = true; // estoy en las paginas del centro
                Extremos_Paginados.Visible = false;// no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        #endregion

      
        #region Compra_De_Productos_DataList_Inicial

        

        protected void Boton_Registrarse_Popup_Click(object sender, EventArgs e)
        {
            Response.Redirect("Panel_De_Ingreso.aspx");
        }

        protected void Boton_Inicio_Popup_Click(object sender, EventArgs e)
        {
            Response.Redirect("Panel_De_Ingreso.aspx");
        }

       

        
        protected void Boton_Compra_Ejercicio_Click(object sender, EventArgs e)
        {
            Caduco_Session();// metodo para verificar si caduco la session  

            int? Valor = LBDI.Logica_Comprar_Ejercicio_Desde_DataList_Inicial(Convert.ToInt32(Session["Variable_ID_Usuario"]), int.Parse((string)Session["ID_Ejercicio"]), Request.UserHostAddress.ToString(), 2); // resultado de la compra del producto el 1 representa la empresa observar que tambien tengo el valor del IP        
            switch (Valor)
            {
                case 0: // ya compraste el ejercicio evita que lo recompres
                    string alerta = @"<script type='text/javascript'>    
                                    alert('usted ya adquirio este ejercicio');  
                                    </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, false);
                    break;
                case 1: // el ejercicio fue comprado sin problemas
                    string alerta1 = @"<script type='text/javascript'>    
                                        alert('gracias por comprar nuestros servicios');  
                                        $(function () {                                       
                                            $('#Ejercicio').modal('hide');    
                                        });
                                        </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta1, false);
                    break;
                case 2: // no tengo plata para comprar el ejercicio
                    string alerta2 = @"<script type='text/javascript'>    
                                    alert('usted no cuenta con crédito suficiente');                                    
                                    </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta2, false);
                    break;
                default: // no se conectro a la base de datos
                    string alerta3 = @"<script type='text/javascript'>    
                                    alert('en estos momentos no puede comprar el servicio');  
                                    </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta3, false);
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
                    string alerta = @"<script type='text/javascript'>    
                                            alert('usted ya adquirio esta explicación');  
                                            </script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, false);
                    break;
                case 1: // el ejercicio fue comprado sin problemas
                     string alerta2 = @"<script type='text/javascript'>    
                                        alert('gracias por comprar nuestros servicios');  
                                        $(function () {                                       
                                            $('#Ejercicio').modal('hide');    
                                        });
                                        </script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta2, false);
                    break;
                case 2: // no tengo plata para comprar el ejercicio
                    string alerta3 = @"<script type='text/javascript'>    
                                    alert('usted no cuenta con crédito suficiente');                                    
                                    </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta3, false);
                    break;
                default: // no se conectro a la base de datos
                    string alerta4 = @"<script type='text/javascript'>    
                                    alert('en estos momentos no puede comprar el servicio');  
                                    </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta4, false);
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
                     string alerta = @"<script type='text/javascript'>    
                                    alert('usted ya adquirio este vídeo');  
                                    </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, false);
                    break;
                case 1: // el ejercicio fue comprado sin problemas
                     string alerta1 = @"<script type='text/javascript'>    
                                        alert('gracias por comprar nuestros servicios');  
                                        $(function () {                                       
                                            $('#Ejercicio').modal('hide');    
                                        });
                                        </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta1, false);
                    break;
                case 2: // no tengo plata para comprar el ejercicio
                    string alerta2 = @"<script type='text/javascript'>    
                                    alert('usted no cuenta con crédito suficiente');                                    
                                    </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta2, false);
                    break;
                default: // no se conectro a la base de datos
                    string alerta3 = @"<script type='text/javascript'>    
                                    alert('en estos momentos no puede comprar el servicio');  
                                    </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta3, false);
                    break;
            }

            LBDI.Logica_Bonificacion_X_Cantidad(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Request.UserHostAddress.ToString());

        }

        #endregion


        #region Busqueda

        protected void Boton_Buscar_Seleccion_Click(object sender, EventArgs e)
        {
            int Valor = LBB.Logica_Errores_En_La_Busqueda(Buscar_x_Profesor.Text, Buscar_x_Ano.Text, Buscar_x_Colegio.Text, Buscar_x_Materia.Text, Buscar_x_Tema.Text); // determina el comportamiento al realizar la busqueda
            if (Valor == 0) // no cargue nada en todos los textbox del panel de busqueda
            {
                string alerta = @"<script type='text/javascript'>    
                                  alert('usted no ha escrito en ningún casillero, obtendra todos los resultados de nuestra base de datos más de 15.000 ejercicios');       
                                    $(function () {                                       
                                        $('#Busqueda').modal('hide');    
                                    });
                                </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, false);
                Condiciones_Paginacion(true); // lo trabaja como si fuera la primera vez que abro la pagina al datalist
                Resultado_DataList_Inicial(0);
                return;
            }
            ViewState["Etiqueta_Profesor"] = LBB.Logica_Buscar_Profesor(Buscar_x_Profesor.Text); // cargo en una variable de usuario el profesor
            ViewState["Etiqueta_Ano"] = LBB.Logica_Buscar_Ano(Buscar_x_Ano.Text); // cargo en una variable de usuario el año
            ViewState["Etiqueta_Tema"] = LBB.Logica_Buscar_Tema(Buscar_x_Tema.Text); // cargo en una variable de usuario el tema
            ViewState["Etiqueta_Colegio"] = LBB.Logica_Buscar_Colegio(Buscar_x_Colegio.Text); // cargo en una variable de usuario el colegio
            ViewState["Etiqueta_Materia"] = LBB.Logica_Buscar_Materia(Buscar_x_Materia.Text); // cargo en una variable de usuario la materia

            string alerta1 = @"<script type='text/javascript'>  
                                   $(function () {                                       
                                        $('#Busqueda').modal('hide');    
                                   });
                                </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta1, false);

            Buscar_x_Profesor.Text = string.Empty;
            Buscar_x_Colegio.Text = string.Empty;
            Buscar_x_Ano.Text = string.Empty;
            Buscar_x_Materia.Text = string.Empty;
            Buscar_x_Tema.Text = string.Empty;

            // esto es para analizar: puedo borrar los datos en el servidor pero no borrar los textbox hasta que vuelva a abrir este panel de esa manera no usaria los viewstate

            
            Condiciones_Paginacion(false); // condiciones para el paginado adaptado al momento de la busqueda por eso es fales
            Resultado_DataList_Busqueda((string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Profesor"], (string)ViewState["Etiqueta_Tema"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], 0); // muestra las respuestas en el datalist de busqueda desde la pagina cero        
        }

        #endregion


        #region Comentario_De_Usuarios

        public void Bordes_Textbox_Comentario()
        {
            Nombre_Contacto.BorderColor = System.Drawing.Color.Empty;
            Correo_Contacto.BorderColor = System.Drawing.Color.Empty;
            Comentario_Contacto.BorderColor = System.Drawing.Color.Empty;
        }

        public void Vaciar_Textbox_Comentario()
        {
            Nombre_Contacto.Text = string.Empty;
            Correo_Contacto.Text = string.Empty;
            Comentario_Contacto.Text = string.Empty;
        }

        protected void Boton_Contacto_Click(object sender, EventArgs e)
        {
            
            int Valor = LBC.Logica_Contacto_De_Usuario(Nombre_Contacto.Text, Correo_Contacto.Text, Comentario_Contacto.Text, 2); // envio del comentario resultado de la interaccion, el uno es la empresa
            switch (Valor)
            {
                case 0: // no envia por nombre vacio
                   string error_vacio1 = @"<script type='text/javascript'> 
                                        alert('debe escribir un nombre');                                        
                                        </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", error_vacio1, false);
                Bordes_Textbox_Comentario();
                Nombre_Contacto.BorderColor = System.Drawing.Color.Red;
                Boton_Contacto.Enabled = true;
                    break;
                case -1: // no tienen forma de correo
                    string error_caracteres = @"<script type='text/javascript'>    
                                            alert('el tipo de correo ingresado no es válido');                                  
                                            </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", error_caracteres, false);
                Bordes_Textbox_Comentario();
                Correo_Contacto.BorderColor = System.Drawing.Color.Red;
                Boton_Contacto.Enabled = true;
                    break;
                case -2: // comentario corto
                    string error_vacio = @"<script type='text/javascript'>  
                                        alert('no puede enviar un comentario vacio');                                        
                                        </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", error_vacio, false);
                    Bordes_Textbox_Comentario();
                    Comentario_Contacto.BorderColor = System.Drawing.Color.Red;
                    Boton_Contacto.Enabled = true;
                    break;
                case -6: // no conecto con la base de datos
                    string error_vacio3 = @"<script type='text/javascript'>  
                                        alert('en estos momentos no puede enviar al ecomentario intente mas tarde');                                        
                                        </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", error_vacio3, false);
                    Bordes_Textbox_Comentario();
                    Comentario_Contacto.BorderColor = System.Drawing.Color.Red;
                    Boton_Contacto.Enabled = true;
                    break;
                case 1: // se envio el comentario
                    string alerta = @"<script type='text/javascript'> 
                              alert('su mensaje fue enviado satisfactoriamente');  
                              </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, false);

            Bordes_Textbox_Comentario();
            Vaciar_Textbox_Comentario();
            Boton_Contacto.Enabled = true;
                    break;
            }
        }

        #endregion


        #region Panel_De_Control

        protected void Panel_De_Control_Click(object sender, EventArgs e)
        {
            Caduco_Session(); // metodo para verificar si caduco la session  
            Usuario_Panel_Control.Text = (string)Session["Usuario"]; // carga el usuario
            List<Mostrar_El_Panel_De_Control_Del_UsuarioResult> Datos = LBPDC.Logica_Mostrar_El_Panel_De_Control_Del_Usuario(Convert.ToInt32(Session["Variable_ID_Usuario"])); // creo una variable de panel de control para que me traiga los datos del usuario           
            Contrasena_Panel_Control.Text = Datos[0].Password; // contraseña
            Correo_Panel_Control.Text = Datos[0].Correo; // correo
            Skype_Panel_Control.Text = Datos[0].Usuario_De_Skype; // Skype
            Celular_Panel_Control.Text = Datos[0].Numero_De_Celular; // celular
            Modelo_Panel_Control.Text = Datos[0].Modelo_De_Celular; // modelo
            ScriptManager.RegisterStartupScript(Perfil_Del_Usuario, GetType(), "", "openModal_panelControl()", true);
        }

        protected void Boton_Actualizar_Datos_Click(object sender, EventArgs e) // boton para actualizar el panel de control
        {
            Caduco_Session(); // metodo para verificar si caduco la session                  
            int? Valor = LBPDC.Logica_Metodo_Actualizar_El_Panel_De_Control(Convert.ToInt32(Session["Variable_ID_Usuario"]), Contrasena_Panel_Control.Text, Correo_Panel_Control.Text, Celular_Panel_Control.Text, Skype_Panel_Control.Text, 2, Modelo_Panel_Control.Text); // muestra la respuesta al actualizar con nuevos datos el panel de control, la empresa es 1
            switch (Valor)
            {
                case 1: // actualizacion correcta

                    Guardar_Cookie((string)Session["Usuario"], Contrasena_Panel_Control.Text, (int)Session["Variable_ID_Usuario"]);

                    string OK = @"<script type='text/javascript'>    
                                   alert('datos actualizados'); 
                                   $(function () {                                       
                                        $('#Panel_De_Control').modal('hide');   
                                   });
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", OK, false);
                    break;
                case 0: // correo ya registrado
                    string FALLO1 = @"<script type='text/javascript'>    
                                   alert('el correo ya esta registrado'); 
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", FALLO1, false);
                    break;
                case -6: // no se conexto a la base de datos
                    string FALLO8 = @"<script type='text/javascript'>    
                                   alert('la actualizacion de sus datos no pudieron realizarse intentelo mas tarde'); 
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", FALLO8, false);
                    break;
                case -1:// no tiene forma de correo
                    string FALLO5 = @"<script type='text/javascript'>    
                                   alert('El correo ingresado no tiene forma de correo electronico'); 
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", FALLO5, false);
                    break;
                case -2:// error por la cantidad de datos del passsword 
                     string FALLO = @"<script type='text/javascript'>    
                                   alert('la contraseña debe tener mas de 6 caracteres'); 
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", FALLO, false);
                    break;
                case -3:// error de correo vacio
                    string FALLO2 = @"<script type='text/javascript'>    
                                   alert('la contraseña no debe estar vacia'); 
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", FALLO2, false);
                    break;
            }
        }


        #endregion


        #region Panel_De_Movimientos
        protected void Panel_De_Movimientos_Click(object sender, EventArgs e)
        {
            
            Usuario_Mis_Movimientos.Text = "Usuario: " + (string)Session["Usuario"]; // carga el usuario
            Credito_Usuario_Mis_Movimientos.Text = "Crédito $ " + (LBPDM.Logica_Obtener_El_Credito_Del_Usuario(Convert.ToInt32(Session["Variable_ID_Usuario"]))).ToString(); // carga el credito del usuario en este momento
            DataList_Mis_Movimientos.DataSource = LBPDM.Logica_Mostrar_Los_Movimientos_Realizados_X_El_Usuario(Convert.ToInt32(Session["Variable_ID_Usuario"])).Take(15); // carga en un datalist los ultimos 15 movimientos
            DataList_Mis_Movimientos.DataBind();
            ScriptManager.RegisterStartupScript(Panel_De_Consulta_De_Movimientos, GetType(), "", "openModal_panelConsulta()", true);
        }

        #endregion


        #region Panel_De_Carga_De_Credito

        protected void Panel_De_Credito_Click(object sender, EventArgs e)
        {
            Caduco_Session();// metodo para verificar si caduco la session    
            Response.Redirect("Carga_Credito.aspx"); //abre el panel para cargar por tarjeta o por prestamo sos 
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
            //Caduco_Session(); // metodo para verificar si caduco la session    
            if (Usuario_Logueado.Text == string.Empty) // no esta logueado no deja ingresar al profesor
            {
                ScriptManager.RegisterStartupScript(UpdatePanel_Resultados_Del_Datalist, GetType(), "", "openModal_NoLogueado()", true);
                return;
            }

            if (LBPOL.Logica_Permitir_Uso_Del_Profesor_On_Line(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2) == 1) // si esta logueado pero averigua si puede realizar esta consulta por la plata que tenga el uno representa a la empresa
            {
                Response.Redirect("Profesor_OnLine_Selector.aspx"); // puede realizar la consulta
            }
            else // no puede usar el profesor por falta de plata
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no tiene crédito para realizar la consulta');", true);
                return;
            }
        }

        #endregion

    }
}