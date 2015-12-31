using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Diagnostics;
//using System.Net;

namespace Fenicia_Web
{
    public partial class Mis_Ejercicios : System.Web.UI.Page
    {

        #region Clases

        Logica_Bloque_Mis_Ejercicios LBME = new Logica_Bloque_Mis_Ejercicios();

        #endregion


        #region Page_Load
        protected void Page_Load(object sender, EventArgs e) // falta frenar para que el usuario no pueda entrar desde aca
        {

           


            if (Session["Usuario"] == null) // verifica si termino la session
            {
                Response.Redirect("sefue.aspx"); // me redirige a la pagina                
                Session.Clear(); // limpiar todas las variables de sesion del usuario
                Session.Abandon(); // abandonar las variables de sesion (esto se realiza con el fin de asegurarme que borro la session del usuario                 
            }
            
            Resultado_DataList_Mis_Ejercicios(Convert.ToInt32(Session["Variable_ID_Usuario"]), 0); // datalist para cargar con el ID_Usuario y desde la pagina cero
            Condiciones_Paginacion();
           
            if (Request.Params["__EVENTARGUMENT"] == "metodo1") {
                metodo1();           
            }
            if (Request.Params["__EVENTARGUMENT"] == "metodo2")
            {
                metodo2();
            }
            if (Request.Params["__EVENTARGUMENT"] == "")
            {
               return;
            }
        }

        #endregion


        #region Metodo_Extra_Para_Cambiar_El_Texto_Del_Boton_Del_Datalist_Para_Ejercicio
        public string Etiqueta_Ejercicio(int Valor)
        { // boton ejercicio
            string Boton = "";
            switch (Valor)
            {
                case 1:
                    Boton = "Ver Ejercicio"; // escribir ver ejercicio
                    break;
                case 0:
                    Boton = "Comprar Ejer."; // escribir comprar el ejercicio
                    break;
            }
            return Boton;
        }

        #endregion


        #region Metodo_Extra_Para_Cambiar_El_Testo_Del_Boton_Del_DataList_Para_Explicacion
        public string Etiqueta_Explicacion(int Valor) //etiqueta explicacion del datalist
        {
            string Boton = "";
            switch (Valor)
            {
                case 1:
                    Boton = "Ver Explicación"; // cambiar la explicacion por ver explicacion
                    break;
                case 0:
                    Boton = "Comprar Explic."; // cambiar la explicacion por comprar la explicacion
                    break;
            }
            return Boton;
        }

        #endregion


        #region DataList

        public void Compra_OK()
        {
            string alerta = @"<script type='text/javascript'>    
                           
                            window.location.assign(Mis_Ejercicios.aspx);
                            </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, false);
        }

        public void Sin_Plata()
        {
            string alerta = @"<script type='text/javascript'>    
                            alert('usted no cuenta con crédito suficiente');                              
                            </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, false);
        }

        public void Fallo()
        {
            string alerta = @"<script type='text/javascript'>    
                            alert('en estos momentos no puede comprar el servicio');                            
                            </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, false);
        }

        public void No_Realizado()
        {

            string alerta = @"<script type='text/javascript'>   
                            window.location.reload();
                            </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, false);

        }

        protected void Identificador(object sender, DataListCommandEventArgs e)
        {
            int Identificador = int.Parse(e.CommandName); // identificador para saber que linkbutton presione 
            int Boton_Presionado = int.Parse(e.CommandArgument.ToString()); // identificador para determinar que boton se presiono
            switch (Boton_Presionado)
            {
                case 1:// boton de ejercicio
                    int Valor_Ejercicio = LBME.Logica_Ver_Si_El_Ejercicio_Fue_Comprado_Desde_Mis_Ejercicios(Convert.ToInt32(Session["Variable_ID_Usuario"]), Identificador); //resultado para saber si compro el ejercicio o lo tengo que mostrar
                    if (Valor_Ejercicio == 0) //muestra el ejercicio que ya fue comprado solo necesita mostrarlos pues lo compro en el datalist inicial
                    {                       
                        string Respuesta = LBME.Logica_Buscar_Ubicacion_De_La_Respuesta_De_Los_Ejercicios(Identificador); // busca las ubicaciones para mostrar los videos o ejercicios en la pantalla
                        Resultado_Ejercicio.ImageUrl = "http://www.colegioeba.com/respuesta/" + Respuesta + ".png"; // reescribe el URL de la imagen para ser visto
                        ScriptManager.RegisterStartupScript(this, GetType(), "", "openModal('" + Resultado_Ejercicio.ImageUrl + "')", true);                        
                        return;
                    }
                    if (Valor_Ejercicio == 1) // muestra el ejercicio aun no comprado y lo compra desde mis ejercicios
                    {

                        Session["Identificador_Fuera"] = Identificador;
                        string script = @"<script type='text/javascript'>
                           
                                            var respuesta = confirm('Este servicio tiene un costo desea adquirilo?');
                                                if (respuesta){
                                                    alert ('Gracias por su confianza');
                                                    __doPostBack('','metodo2');}
                                                else{
                                                    alert ('Usted ha cancelado la compra');}

                                        </script>";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);


                    }
                    if (Valor_Ejercicio == -6) // no se conecto a la base de datos
                    {
                        Fallo();
                        return;
                    }
                    break;

                case 2: //boton explicacionesComprar Explic.
                    


                    int Valor_Explicacion = LBME.Logica_Ver_Si_La_Explicacion_Fue_Comprado_Desde_Mis_Ejercicios(Convert.ToInt32(Session["Variable_ID_Usuario"]), Identificador); //resultado para saber si compro la explicacion o la tiene que mostrar
                    if (Valor_Explicacion == 0) // muestra que la explicacion ya fue comprada solo necesita mostrarla 
                    {

                        string Respuesta = LBME.Logica_Buscar_Ubicacion_De_Los_Videos(Identificador);  // obtengo la explicacion de donde esta ubicado el video y lo muestra
                        Resultado_Video.Src = "http://www.youtube.com/embed/" + Respuesta + "?rel=0&showinfo=0" ; // modifica segun la ubicacion el src del iframe para ver el video

                        ScriptManager.RegisterStartupScript(this, GetType(), "", "openModalVideo('" + Resultado_Video.Src + "')", true);
                        
                        return;
                    }
                    if (Valor_Explicacion == 1) // muesta la explicacion no comprada y pregunta si quiere comprarla 
                    {
                        Session["Identificador_Fuera"] = Identificador;
                        string script = @"<script type='text/javascript'>
                           
                                            var respuesta = confirm('Este servicio tiene un costo desea adquirilo?');
                                                if (respuesta){
                                                    alert ('Gracias por su confianza');
                                                    __doPostBack('','metodo1');}
                                                else{
                                                    alert ('Usted ha cancelado la compra');}

                                        </script>";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                                                
                    }
                    if (Valor_Explicacion == -6) // no se conecta a la base de datos
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('no conecto');", true);
                        return;
                    }
                    break;

                case 3: // boton para imprimir el ejercicio
                    int Impresion = LBME.Logica_Comprar_Ejercicio_Para_Imprimir(Convert.ToInt32(Session["Variable_ID_Usuario"]), Identificador, Request.UserHostAddress.ToString(), 2);

                    if (Impresion == 1) // impresion comprada
                    {
                        LBME.Logica_Bonificacion_X_Cantidad(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Request.UserHostAddress.ToString());

                                                
                        Response.Clear();
                        Response.ContentType = "image/png";

                        Response.AppendHeader("Content-Disposition", "attachment; filename=fenicia"+ DateTime.Now +".png"); // con este nombre se descarga


                        Response.TransmitFile("C:\\impresion/" + LBME.Logica_Buscar_Ubicacion_De_La_Respuesta_Del_Ejercicio_Imprimible(Identificador) + ".png");
                        Response.End();


                        // este codigo que esta abajo sirve para imprimir pero tiene el problema que no funciona en el servidor
                        //string txtFileName = "c:impresion/e.doc"; // ubicacion del archivo para imprimir
                        //ProcessStartInfo info = new ProcessStartInfo(txtFileName); // script para imprimir el archivo de resolucion del ejercicio
                        //info.Verb = "Print";
                        //info.CreateNoWindow = true;
                        //info.WindowStyle = ProcessWindowStyle.Hidden;
                        //Process.Start(info);
                        //return;
                    }
                    if (Impresion == 0) // no tengo plata para imprimir
                    {
                        Sin_Plata();
                        return;
                    }
                    if (Impresion == -6) // no se conecto la base de datos
                    {
                        Fallo();
                        return;
                    }
                    break;
            }
        }


        public void metodo2() 
        {
            int Ejercicio = LBME.Logica_Comprar_Ejercicio_Desde_Mis_Ejercicios(Convert.ToInt32(Session["Variable_ID_Usuario"]), (int)Session["Identificador_Fuera"], Request.UserHostAddress.ToString(), 2);

            if (Ejercicio == 1)
            {
                LBME.Logica_Bonificacion_X_Cantidad(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Request.UserHostAddress.ToString());
                Compra_OK();
                Limpiar_Argumento();
                return;
            }
            if (Ejercicio == 0)
            {
                Sin_Plata();
                Limpiar_Argumento();
                return;
            }
            if (Ejercicio == -6)
            {
                Fallo();
                Limpiar_Argumento();
                return;
            }


        }

        public void metodo1() 
        {

            int? Explicacion = LBME.Logica_Comprar_Explicacion_Desde_Mis_Ejercicios(Convert.ToInt32(Session["Variable_ID_Usuario"]),(int)Session["Identificador_Fuera"], Request.UserHostAddress.ToString(), 2); // realiza las compras del ejercicio, el uno es la empresa

            if (Explicacion == 1)
            {
                LBME.Logica_Bonificacion_X_Cantidad(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Request.UserHostAddress.ToString());
                Compra_OK();
                Limpiar_Argumento();
                return;
            }
            if (Explicacion == 0) // no plata
            {
                Sin_Plata();
                Limpiar_Argumento();
                return;
            }
            if (Explicacion == -6) // no se conecto
            {
                Fallo();
                Limpiar_Argumento();
                return;
            }

        }

        public void Limpiar_Argumento()
        {

            string script = @"<script type='text/javascript'>
                           
                            __doPostBack('','');      

                           </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

        }

        public void Resultado_DataList_Mis_Ejercicios(int ID_Usuario, int Pagina)
        {
            DataList_Mis_Ejercicios.DataSource = LBME.Logica_Mostrar_DataList_En_Mis_Ejercicios(ID_Usuario).Skip(Pagina * 8).Take(8); // muestra el datalist de mis ejercicios paginado de a 20 datos
            DataList_Mis_Ejercicios.DataBind();
        }
        #endregion


        #region Paginacion_Del_DataList

        public void Condiciones_Paginacion()
        {
            ViewState["Pagina_Mis_Ejercicios"] = 0;// arranca de la pagina cero
            Centros_Paginados.Visible = false; // contenedor de los paginados siguiente y anterior centrales
            Siguiente_Primero.Visible = true; // siguiente primero arranca true
            Anterior_Ultimo.Visible = false; // anterior ultimo es false
            ViewState["Cantidad_De_Datos_Mis_Ejercicios"] = LBME.Logica_Paginado_Mis_Ejercicios(Convert.ToInt32(Session["Variable_ID_Usuario"]));//cantidad de datos al buscar en mis ejercicios

            int tucho = (int)ViewState["Cantidad_De_Datos_Mis_Ejercicios"];
            ViewState["Cantidad_De_Paginas_Mis_Ejercicios"] = (int)ViewState["Cantidad_De_Datos_Mis_Ejercicios"] / 8;//cantidad de paginas que se generan empezando por el cero
            ViewState["Resto_Mis_Ejercicios"] = (int)ViewState["Cantidad_De_Datos_Mis_Ejercicios"] % 8;// cantidad de ejercicios que faltan para completar una hoja
            if ((int)ViewState["Resto_Mis_Ejercicios"] == 0)// si el resto es exacto necesito una hoja menos porque se arranca de la hoja cero
            {
                ViewState["Cantidad_De_Paginas_Mis_Ejercicios"] = (int)ViewState["Cantidad_De_Paginas_Mis_Ejercicios"] - 1;// resto una hoja
            }
            if ((int)ViewState["Cantidad_De_Datos_Mis_Ejercicios"] <= 8)// si cuento con menos de 20 datos no muestra siguiente primero
            {
                Siguiente_Primero.Visible = false;
            }

        }

        protected void Siguiente_Click(object sender, EventArgs e)
        {
            ViewState["Pagina_Mis_Ejercicios"] = (int)ViewState["Pagina_Mis_Ejercicios"] + 1;// se suma una hoja
            if ((int)ViewState["Pagina_Mis_Ejercicios"] == (int)ViewState["Cantidad_De_Paginas_Mis_Ejercicios"])// se fija si estoy en la ultima hoja
            {
                Resultado_DataList_Mis_Ejercicios(Convert.ToInt32(Session["Variable_ID_Usuario"]), (int)ViewState["Pagina_Mis_Ejercicios"]);// llama al datalist
                Centros_Paginados.Visible = false; // como es la ultima pagina la paginacion centrada es falsa
                Extremos_Paginados.Visible = true; // como es la ultima pagina la paginacion externa es verdadera
                Siguiente_Primero.Visible = false; // siguiente primero es falso pues estoy en la ultima hoja
                Anterior_Ultimo.Visible = true; // anterior ultimo verdadero pues estoy en la ultima hoja
            }
            else // si no estoy en la ultima hoja
            {
                Resultado_DataList_Mis_Ejercicios(Convert.ToInt32(Session["Variable_ID_Usuario"]), (int)ViewState["Pagina_Mis_Ejercicios"]);// llama al datalist
                Centros_Paginados.Visible = true; // solo muestra los paginados centrales de siguiente y anterior
                Extremos_Paginados.Visible = false; // no muestra los paginados externos de siguiente y anterior porque no estoy ni en la primera ni en la ultima hoja
            }
        }

        protected void Anterior_Click(object sender, EventArgs e)
        {
            ViewState["Pagina_Mis_Ejercicios"] = (int)ViewState["Pagina_Mis_Ejercicios"] - 1;// se resta una hoja
            if ((int)ViewState["Pagina_Mis_Ejercicios"] == 0)// estoy en la primera hoja
            {
                Resultado_DataList_Mis_Ejercicios(Convert.ToInt32(Session["Variable_ID_Usuario"]), (int)ViewState["Pagina_Mis_Ejercicios"]); // llama al datalist               
                Centros_Paginados.Visible = false; // como es la ultima pagina la paginacion centrada es falsa
                Extremos_Paginados.Visible = true; // como es la ultima pagina la paginacion externa es verdadera
                Siguiente_Primero.Visible = true;// siguiente primero es falso pues estoy en la ultima hoja
                Anterior_Ultimo.Visible = false;// anterior ultimo verdadero pues estoy en la ultima hoja
            }
            else // si no estoy en la primera pagina
            {
                Resultado_DataList_Mis_Ejercicios(Convert.ToInt32(Session["Variable_ID_Usuario"]), (int)ViewState["Pagina_Mis_Ejercicios"]); // llama al datalist
                Centros_Paginados.Visible = true; // aparece pues no estoy ni en la primera ni en la ultima hoja 
                Extremos_Paginados.Visible = false; // no muestra los paginados externos de siguiente y anterior porque no estoy en la primera pagina
            }
        }

        #endregion

    }

}