using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace Fenicia_Web
{
    public partial class Pagina_Fichas : System.Web.UI.Page
    {
        #region Clases

        Logica_Bloque_Pagina_Ficha LBPF = new Logica_Bloque_Pagina_Ficha();

        #endregion


        #region Variables

        public void Cargar_Variables_De_URL(string Usuario, string Maestro, string Ano, string Tema, string Colegio, string Materia, string Enunciado1, string Enunciado2, bool Boton_Ejercicio, bool Boton_Explicacion)
        {
            Session["Usuario"] = Usuario; // recupera desde el URL el Usuario
            ViewState["Etiqueta_Maestro"] = LBPF.Logica_Buscar_Profesor(Maestro); // recupera desde el URL el Maestro y lo convierto en etiqueta de busqueda para ficha
            ViewState["Etiqueta_Ano"] = LBPF.Logica_Buscar_Ano(Ano); // recupera desde el URL el Ano y lo convierto en etiqueta de busqueda para ficha
            ViewState["Etiqueta_Tema"] = LBPF.Logica_Buscar_Tema(Tema); // recupera desde el URL el Tema y lo convierto en etiqueta de busqueda para ficha
            ViewState["Etiqueta_Colegio"] = LBPF.Logica_Buscar_Colegio(Colegio); // recupera desde el URL el Colegio y lo convierto en etiqueta de busqueda para ficha
            ViewState["Etiqueta_Materia"] = LBPF.Logica_Buscar_Materia(Materia); // recupera desde el URL el Materia y lo convierto en etiqueta de busqueda para ficha
            ViewState["Enunciado_1"] = Enunciado1; // recupera desde el URL el Enunciado1
            ViewState["Enunciado_2"] = Enunciado2; // recupera desde el URL el Enunciado2        
            Session["Boton_Ejercicio"] = Boton_Ejercicio;
            Session["Boton_Explicacion"] = Boton_Explicacion;
        }

        #endregion


        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // la primera vez que carga
            {
                Cargar_Variables_De_URL(Request.QueryString["Usuario"], Request.QueryString["Maestro"], Request.QueryString["Ano"], Request.QueryString["Tema"], Request.QueryString["Colegio"], Request.QueryString["Materia"], Request.QueryString["Enunciado1"], Request.QueryString["Enunciado2"],Convert.ToBoolean(Request.QueryString["Boton_Ejercicio"]),Convert.ToBoolean(Request.QueryString["Boton_Explicacion"])); // carga las variables de la URL   

                Listado_De_Parecidos((string)ViewState["Etiqueta_Maestro"], (string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (string)ViewState["Etiqueta_Tema"], 0);// Llama al datalist de enunciados parecidos, desde la pagina cero

                Condiciones_Paginacion(); // datos para armado de la paginacion del datalist
                if (ViewState["Enunciado_1"] == null)
                {
                    Buscar_Por_Enunciado.Enabled = false; // anula el boton de buscar por enunciado
                }

            }

            if ((bool)Session["Boton_Ejercicio"])
            {
                Boton_Resolver_Mi_Ejercicio.Enabled = true;
            }
            else
            {
                Boton_Resolver_Mi_Ejercicio.Enabled = false;
            }

            if ((bool)Session["Boton_Explicacion"])
            {
                Boton_Explicar_Mi_Ejercicio.Enabled = true;
            }
            else
            {
                Boton_Explicar_Mi_Ejercicio.Enabled = false;
            }


            if (Session["Usuario"] == null) // verifica si termino la session
            {

                Response.Redirect("sefue.aspx"); // me redirige a la pagina                
                Session.Clear(); // limpiar todas las variables de sesion del usuario
                Session.Abandon(); // abandonar las variables de sesion (esto se realiza con el fin de asegurarme que borro la session del usuario                 

            }

        }
        #endregion


        #region Data_List
        public void Listado_De_Parecidos(string Maestro, string Ano, string Colegio, string Materia, string Tema, int Pagina)
        {
            Resultado_DataList_Ficha.DataSource = LBPF.Logica_Mostrar_DataList_De_Productos_Sumilares_X_Ficha(Maestro, Ano, Colegio, Materia, Tema).Skip(Pagina * 5).Take(5); //datalist que contiene las fichas
            Resultado_DataList_Ficha.DataBind();

        }

        public void Identificador(object sender, DataListCommandEventArgs e)
        {
            int Identificador = int.Parse(e.CommandName); // identifica el ID correspondiente al ejercicio
            int Boton_Presionado = int.Parse(e.CommandArgument.ToString()); // identifica si presione el boton de resolver el ejercicio o el de explicar
            switch (Boton_Presionado)
            {
                case 1: // compro la resolucion del ejercicio

                    int Ejercicio = LBPF.Logica_Comprar_Ejercicio_Desde_Pagina_Ficha(Convert.ToInt32(Session["Variable_ID_Usuario"]), Identificador, Request.UserHostAddress.ToString(), 2);

                    if (Ejercicio == -1) // el ejercicio ya fue comprado
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('usted ya compro este ejercicio');", true);
                        return;
                    }
                    if (Ejercicio == 1) // compro el ejercicio todo OK
                    {
                        LBPF.Logica_Bonificacion_X_Cantidad(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Request.UserHostAddress.ToString());
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('su compra fué satisfactoria, la respuesta del ejercicio esta en su carpeta de mis ejercicios');", true);
                        return;
                    }
                    if (Ejercicio == 0) // no compro el ejercicio por no tener plata
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('usted no cuenta con suficiente crédito para realizar la consulta, pida un préstamo SOS en su panel de crédito');", true);
                        return;
                    } // no se conecto a la base de datos
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('en estos momentos no podemos atender su consulta');", true);
                    break;

                case 2: // compro la explicacion del ejercicio                   

                    int Explicacion = LBPF.Logica_Comprar_Explicacion_Desde_Pagina_Ficha(Convert.ToInt32(Session["Variable_ID_Usuario"]), Identificador, Request.UserHostAddress.ToString(), 2);

                    if (Explicacion == -1) // ya lo compre
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('usted ya compro esta explicacion');", true);
                        return;
                    }
                    if (Explicacion == 1) // comprado ok
                    {
                        LBPF.Logica_Bonificacion_X_Cantidad(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Request.UserHostAddress.ToString());
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('su compra fué satisfactoria, la explicacion del ejercicio podrá encontrarla en su panel de mis ejercicios');", true);
                        return;
                    }
                    if (Explicacion == 0) // no tiene plata
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('usted no cuenta con suficiente crédito para realizar la consulta, pida un préstamo SOS en su panel de control');", true);
                        return;
                    }
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('en estos momentos no podemos atender su consulta');", true);
                    break;
            }
        }

        #endregion


        #region Paginacion_Del_DataList
        public void Condiciones_Paginacion()
        {
            ViewState["Pagina_Ficha"] = 0; // arranca de la pagina cero
            Centros_Paginados.Visible = false; // contenedor de los paginados siguiente y anterior centrales
            Siguiente_Primero.Visible = true; // siguiente primero arranca true
            Anterior_Ultimo.Visible = false; // anterior ultimo es false
            ViewState["Cantidad_De_Datos_Ficha"] = LBPF.Logica_Paginado_DataList_Ficha((string)ViewState["Etiqueta_Maestro"], (string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (string)ViewState["Etiqueta_Tema"]); //cantidad de datos al buscar por enunciados
            ViewState["Cantidad_De_Paginas_Ficha"] = (int)ViewState["Cantidad_De_Datos_Ficha"] / 5;//cantidad de paginas que se generan empezando por el cero
            ViewState["Resto_Ficha"] = (int)ViewState["Cantidad_De_Datos_Ficha"] % 5;// cantidad de ejercicios que faltan para completar una hoja
            if ((int)ViewState["Resto_Ficha"] == 0)// si el resto es exacto necesito una hoja menos porque se arranca de la hoja cero
            {
                ViewState["Cantidad_De_Paginas_Ficha"] = (int)ViewState["Cantidad_De_Paginas_Ficha"] - 1;// resto una hoja
            }
            if ((int)ViewState["Cantidad_De_Datos_Ficha"] <= 5)// si cuento con menos de 10 datos no muestra siguiente primero
            {
                Siguiente_Primero.Visible = false;
            }

        }

        protected void Siguiente_Click(object sender, EventArgs e)
        {
            ViewState["Pagina_Ficha"] = (int)ViewState["Pagina_Ficha"] + 1;// se suma una hoja
            if ((int)ViewState["Pagina_Ficha"] == (int)ViewState["Cantidad_De_Paginas_Ficha"])// se fija si estoy en la ultima hoja
            {
                Listado_De_Parecidos((string)ViewState["Etiqueta_Maestro"], (string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (string)ViewState["Etiqueta_Tema"], (int)ViewState["Pagina_Ficha"]);// llama al datalist
                Centros_Paginados.Visible = false; // como es la ultima pagina la paginacion centrada es falsa
                Extremos_Paginados.Visible = true; // como es la ultima pagina la paginacion externa es verdadera
                Siguiente_Primero.Visible = false; // siguiente primero es falso pues estoy en la ultima hoja
                Anterior_Ultimo.Visible = true; // anterior ultimo verdadero pues estoy en la ultima hoja
            }
            else // si no estoy en la ultima hoja
            {
                Listado_De_Parecidos((string)ViewState["Etiqueta_Maestro"], (string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (string)ViewState["Etiqueta_Tema"], (int)ViewState["Pagina_Ficha"]);//llama al datalist
                Centros_Paginados.Visible = true; // solo muestra los paginados centrales de siguiente y anterior
                Extremos_Paginados.Visible = false; // no muestra los paginados externos de siguiente y anterior porque no estoy ni en la primera ni en la ultima hoja
            }
        }

        protected void Anterior_Click(object sender, EventArgs e)
        {
            ViewState["Pagina_Ficha"] = (int)ViewState["Pagina_Ficha"] - 1; // se resta una hoja
            if ((int)ViewState["Pagina_Ficha"] == 0) // estoy en la primera hoja
            {
                Listado_De_Parecidos((string)ViewState["Etiqueta_Maestro"], (string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (string)ViewState["Etiqueta_Tema"], (int)ViewState["Pagina_Ficha"]); // llama al datalist
                Centros_Paginados.Visible = false; // como es la ultima pagina la paginacion centrada es falsa
                Extremos_Paginados.Visible = true; // como es la ultima pagina la paginacion externa es verdadera
                Siguiente_Primero.Visible = true;// siguiente primero es falso pues estoy en la ultima hoja
                Anterior_Ultimo.Visible = false;// anterior ultimo verdadero pues estoy en la ultima hoja
            }
            else // si no estoy en la primera pagina
            {
                Listado_De_Parecidos((string)ViewState["Etiqueta_Maestro"], (string)ViewState["Etiqueta_Ano"], (string)ViewState["Etiqueta_Colegio"], (string)ViewState["Etiqueta_Materia"], (string)ViewState["Etiqueta_Tema"], (int)ViewState["Pagina_Ficha"]); // llama al datalist
                Centros_Paginados.Visible = true; // aparece pues no estoy ni en la primera ni en la ultima hoja 
                Extremos_Paginados.Visible = false; // no muestra los paginados externos de siguiente y anterior porque no estoy en la primera pagina
            }
        }

        #endregion


        #region Comprar_Mi_Ejercicio
        
        protected void Boton_Resolver_Mi_Ejercicio_Click(object sender, EventArgs e)
        {
            if(Boton_Resolver_Mi_Ejercicio.Enabled == false)
            {
                return;
            }

            int Ejercicio;

            if (Session["Nombre_Enunciado"] == null)
            {
                Ejercicio = LBPF.Logica_Comprar_Mi_Ejercicio_Personalizado_Desde_Ficha(Convert.ToInt32(Session["Variable_ID_Usuario"]), Request.UserHostAddress.ToString(), 2, (bool)Session["Subio_Adjunto"], LBPF.Logica_Armado_Del_Nombre_Del_Archivo((string)Session["Usuario"]), (string)Session["Nombre_Adjunto"], Boton_Explicar_Mi_Ejercicio.Enabled,null);
            }
            else
            {
                Ejercicio = LBPF.Logica_Comprar_Mi_Ejercicio_Personalizado_Desde_Ficha(Convert.ToInt32(Session["Variable_ID_Usuario"]), Request.UserHostAddress.ToString(), 2, (bool)Session["Subio_Adjunto"], LBPF.Logica_Armado_Del_Nombre_Del_Archivo((string)Session["Usuario"]), (string)Session["Nombre_Adjunto"], Boton_Explicar_Mi_Ejercicio.Enabled,"1");
            }
            
            
            if (Ejercicio == 1) //compro el ejercicio
            {
                LBPF.Logica_Bonificacion_X_Cantidad(Convert.ToInt32(Session["Variable_ID_Usuario"]), 1, Request.UserHostAddress.ToString());
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('gracias por la compra, a la brevedad recibira la explicación detallada del ejercicio resuelto en su panel de mis ejercicios');", true);
                Boton_Resolver_Mi_Ejercicio.Enabled = false; // comprar el ejercicio y desabilitar el boton de compra   
                Session["Boton_Ejercicio"] = false;
                return;
            }           
            if (Ejercicio == 0) // no tengo plata
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('usted no cuenta con el crédito suficiente para realizar esta consulta, pida un crédito SOS desde su panel de crédito');", true);
                return;
            }
            if (Ejercicio == -6)// no funciona la base de datos
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('en estos momentos no podemos atender su consulta, realicela más tarde por favor');", true);
                return;
            }
            
        }


        protected void Boton_Explicar_Mi_Ejercicio_Click(object sender, EventArgs e)
        {
            if (Boton_Explicar_Mi_Ejercicio.Enabled == false)
            {
                return;
            }
            int Explicacion;

            if (Session["Nombre_Enunciado"] == null)
            {
                Explicacion = LBPF.Logica_Comprar_Mi_Explicacion_Personalizada_Desde_Ficha(Convert.ToInt32(Session["Variable_ID_Usuario"]), Request.UserHostAddress.ToString(), 2, (bool)Session["Subio_Adjunto"], LBPF.Logica_Armado_Del_Nombre_Del_Archivo((string)Session["Usuario"]), (string)Session["Nombre_Adjunto"], Boton_Resolver_Mi_Ejercicio.Enabled, null);
            }
            else
            {
                Explicacion = LBPF.Logica_Comprar_Mi_Explicacion_Personalizada_Desde_Ficha(Convert.ToInt32(Session["Variable_ID_Usuario"]), Request.UserHostAddress.ToString(), 2, (bool)Session["Subio_Adjunto"], LBPF.Logica_Armado_Del_Nombre_Del_Archivo((string)Session["Usuario"]), (string)Session["Nombre_Adjunto"], Boton_Resolver_Mi_Ejercicio.Enabled, "1");
            }



           
            
            if (Explicacion == 1) //compro el ejercicio
            {
                LBPF.Logica_Bonificacion_X_Cantidad(Convert.ToInt32(Session["Variable_ID_Usuario"]), 1, Request.UserHostAddress.ToString());
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('gracias por la compra, a la brevedad recibira la explicación detallada del ejercicio resuelto en su panel de mis ejercicios');", true);
                Boton_Explicar_Mi_Ejercicio.Enabled = false; // comprar el ejercicio y desabilitar el boton de compra     
                Session["Boton_Explicacion"] = false;
                return;
            }           
            if (Explicacion == 0) // no tengo plata
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('usted no cuenta con el crédito suficiente para realizar esta consulta, pida un crédito SOS desde su panel de crédito');", true);
                return;
            }
            if (Explicacion == -6)// no funciona la base de datos
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('en estos momentos no podemos atender su consulta, realicela más tarde por favor');", true);
                return;
            }
        }

        #endregion


        #region Boton_Enunciado

        protected void Buscar_Por_Enunciado_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pagina_Enunciados.aspx" + (string)Session["Contenido"] + "&Boton_Ejercicio=" + Convert.ToBoolean(Session["Boton_Ejercicio"]) + "&Boton_Explicacion=" + Convert.ToBoolean(Session["Boton_Explicacion"]));
        }

        #endregion
    }
}