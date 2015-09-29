using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Datos;

namespace Fenicia_Web
{
    public partial class Panel_De_Ingreso : System.Web.UI.Page
    {

        Logica_Bloque_Usuario LBU = new Logica_Bloque_Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { // genera el captcha al ingresar a la pagina
                Generar_Captcha();
            }
        }

        #region Iniciar_Session

        public void Guardar_Cookie(string Usuario, string Password, int ID_Usuario) // Metodo para guardar la cookies
        {
            HttpCookie Variable_Cookie = new HttpCookie("Usuario_Recordado"); // coockie definida como Usuario Recordado
            Variable_Cookie.Values.Add("Usuario", Usuario); // dentro de la coockie Usuario Recordado carga el usuario
            Variable_Cookie.Values.Add("Password", Password); // dentro de la coockie Usuario Recordado carga el Password 
            Variable_Cookie.Values.Add("ID_Usuario", ID_Usuario.ToString()); // dentro de la coocke Usuario Recordado carga el ID_Usuario
            Variable_Cookie.Expires = DateTime.Now.AddDays(90); // tiempo de vida de la coockie en la maquina del usuario 90 dias
            Response.Cookies.Add(Variable_Cookie);
        }

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

            Response.Redirect("index.aspx");
        }

        #endregion

        #region Captcha

        public class Dos_Valores_De_Seguridad
        {
            public int Imagen_Captcha { get; set; }
            public string Valor_Captcha { get; set; }
        }

        public Dos_Valores_De_Seguridad Generar_Captcha()
        {
            Dos_Valores_De_Seguridad Datos = new Dos_Valores_De_Seguridad();
            Random r = new Random();
            string[] Valores_De_Seguridad = new string[6] { "1a75K", "6h49L", "dJ56E", "NF74m", "7D26t", "3EM2i" };
            Datos.Imagen_Captcha = r.Next(1, 7);
            ViewState["imagen"] = Datos.Imagen_Captcha;
            Datos.Valor_Captcha = Valores_De_Seguridad[Datos.Imagen_Captcha - 1];
            ViewState["valor"] = Datos.Valor_Captcha;
            Image_Captcha.ImageUrl = "captcha/" + ViewState["imagen"].ToString() + ".png";
            Image_Captcha_Movil.ImageUrl = "captcha/" + ViewState["imagen"].ToString() + ".png";
            return Datos;
        }

        #endregion

        #region Registrarse

        public void Boton_Enviar_Registro_Click(object sender, EventArgs e) // boton de registro de la pc
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

            int Errores_Registrar_Usuario = LBU.Logica_Insertar_Registro(Usuario, Password, RePassword, Captcha,(string) ViewState["valor"], Condiciones, Correo, 2, IP_Address);

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

            Password_Registro_Movil.BorderColor = System.Drawing.Color.Empty;
            RePassword_Registro_Movil.BorderColor = System.Drawing.Color.Empty;
            Captcha_Registro_Movil.BorderColor = System.Drawing.Color.Empty;
            Correo_Registro_Movil.BorderColor = System.Drawing.Color.Empty;
            Usuario_Registro_Movil.BorderColor = System.Drawing.Color.Empty;
        }

        public void Vaciar_Textbox()
        {
            Password_Registro.Text = string.Empty;
            RePassword_Registro.Text = string.Empty;
            Captcha_Registro.Text = string.Empty;
            Correo_Registro.Text = string.Empty;
            Usuario_Registro.Text = string.Empty;

            Password_Registro_Movil.Text = string.Empty;
            RePassword_Registro_Movil.Text = string.Empty;
            Captcha_Registro_Movil.Text = string.Empty;
            Correo_Registro_Movil.Text = string.Empty;
            Usuario_Registro_Movil.Text = string.Empty;

        }

        public void Boton_Registro_Movil_Click(object sender, EventArgs e) // boton de registro del celular
        {
            Errores_Al_Registrar_El_Usuario(Usuario_Registro_Movil.Text, Password_Registro_Movil.Text, RePassword_Registro_Movil.Text, Captcha_Registro_Movil.Text, (string)ViewState["Valor_Captcha"], Condiciones_Registro_Movil.Checked, Correo_Registro_Movil.Text, Request.UserHostAddress.ToString());

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
        
        #endregion

    }

}