using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace Fenicia_Web
{
    public partial class Mis_Explicaciones : System.Web.UI.Page
    {
        
        #region Clases

        Logica_Bloque_Mis_Explicaciones LBME = new Logica_Bloque_Mis_Explicaciones();

        #endregion


        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)// falta frenar para que el usuario no pueda entrar desde aca
        {
            Resultado_DataList_Mis_Explicaciones(Convert.ToInt32(Session["Variable_ID_Usuario"]), 0);// datalist para cargar con el ID_Usuario y desde la pagina cero
            Condiciones_Paginacion();
            if (Session["Usuario"] == null) // verifica si termino la session
            {
                Response.Redirect("sefue.aspx"); // me redirige a la pagina                
                Session.Clear(); // limpiar todas las variables de sesion del usuario
                Session.Abandon(); // abandonar las variables de sesion (esto se realiza con el fin de asegurarme que borro la session del usuario                 
            }     
        }

        #endregion


        #region DataList
        protected void Identificador(object sender, DataListCommandEventArgs e)
        {
            int Identificador = int.Parse(e.CommandName); // identificador para saber que linkbutton presione 
            string Respuesta = LBME.Logica_Buscar_Ubicacion_De_Los_Videos(Identificador);// obtengo la explicacion de donde esta ubicado el video y lo muestra
            Resultado_Video.Src = "http://www.youtube.com/embed/" + Respuesta + "?rel=0&showinfo=0";
            ScriptManager.RegisterStartupScript(this, GetType(), "", "openModalVideo('" + Resultado_Video.Src + "')", true);

            return;
            
        }

        public void Resultado_DataList_Mis_Explicaciones(int ID_Usuario, int Pagina)
        {
            DataList_Mis_Explicaciones.DataSource = LBME.Logica_Mostrar_DataList_En_Mis_Explicaciones(ID_Usuario).Skip(Pagina * 8).Take(8);// muestra el datalist de mis ejercicios paginado de a 20 datos
            DataList_Mis_Explicaciones.DataBind();

        }

        #endregion


        #region Paginacion_Del_DataList
        public void Condiciones_Paginacion()
        {
            ViewState["Pagina_Mis_Explicaciones"] = 0;// arranca de la pagina cero
            Centros_Paginados.Visible = false; // contenedor de los paginados siguiente y anterior centrales
            Siguiente_Primero.Visible = true; // siguiente primero arranca true
            Anterior_Ultimo.Visible = false; // anterior ultimo es false
            ViewState["Cantidad_De_Datos_Mis_Explicaciones"] = LBME.Logica_Paginado_Mis_Explicaciones(Convert.ToInt32(Session["Variable_ID_Usuario"]));//cantidad de datos al buscar en mis explicaciones
            ViewState["Cantidad_De_Paginas_Mis_Explicaciones"] = (int)ViewState["Cantidad_De_Datos_Mis_Explicaciones"] / 8;//cantidad de paginas que se generan empezando por el cero
            ViewState["Resto_Mis_Explicaciones"] = (int)ViewState["Cantidad_De_Datos_Mis_Explicaciones"] % 8;// cantidad de ejercicios que faltan para completar una hoja
            if ((int)ViewState["Resto_Mis_Explicaciones"] == 0)// si el resto es exacto necesito una hoja menos porque se arranca de la hoja cero
            {
                ViewState["Cantidad_De_Paginas_Mis_Explicaciones"] = (int)ViewState["Cantidad_De_Paginas_Mis_Explicaciones"] - 1;// resto una hoja
            }
            if ((int)ViewState["Cantidad_De_Datos_Mis_Explicaciones"] <= 8)// si cuento con menos de 20 datos no muestra siguiente primero
            {
                Siguiente_Primero.Visible = false;
            }
        }

        protected void Siguiente_Click(object sender, EventArgs e)
        {
            ViewState["Pagina_Mis_Explicaciones"] = (int)ViewState["Pagina_Mis_Explicaciones"] + 1;// se suma una hoja
            if ((int)ViewState["Pagina_Mis_Explicaciones"] == (int)ViewState["Cantidad_De_Paginas_Mis_Explicaciones"])// se fija si estoy en la ultima hoja
            {
                Resultado_DataList_Mis_Explicaciones(Convert.ToInt32(Session["Variable_ID_Usuario"]), (int)ViewState["Pagina_Mis_Explicaciones"]);// llama al datalist
                Centros_Paginados.Visible = false; // como es la ultima pagina la paginacion centrada es falsa
                Extremos_Paginados.Visible = true; // como es la ultima pagina la paginacion externa es verdadera
                Siguiente_Primero.Visible = false; // siguiente primero es falso pues estoy en la ultima hoja
                Anterior_Ultimo.Visible = true; // anterior ultimo verdadero pues estoy en la ultima hoja
            }
            else // si no estoy en la ultima hoja
            {
                Resultado_DataList_Mis_Explicaciones(Convert.ToInt32(Session["Variable_ID_Usuario"]), (int)ViewState["Pagina_Mis_Explicaciones"]);// llama al datalist
                Centros_Paginados.Visible = true; // solo muestra los paginados centrales de siguiente y anterior
                Extremos_Paginados.Visible = false; // no muestra los paginados externos de siguiente y anterior porque no estoy ni en la primera ni en la ultima hoja
            }
        }

        protected void Anterior_Click(object sender, EventArgs e)
        {
            ViewState["Pagina_Mis_Explicaciones"] = (int)ViewState["Pagina_Mis_Explicaciones"] - 1; // se resta una hoja
            if ((int)ViewState["Pagina_Mis_Explicaciones"] == 0) // estoy en la primera pagina
            {
                Resultado_DataList_Mis_Explicaciones(Convert.ToInt32(Session["Variable_ID_Usuario"]), (int)ViewState["Pagina_Mis_Explicaciones"]); //llama al datalist
                Centros_Paginados.Visible = false; // como es la ultima pagina la paginacion centrada es falsa
                Extremos_Paginados.Visible = true; // como es la ultima pagina la paginacion externa es verdadera
                Siguiente_Primero.Visible = true;// siguiente primero es falso pues estoy en la ultima hoja
                Anterior_Ultimo.Visible = false;// anterior ultimo verdadero pues estoy en la ultima hoja
            }
            else // si no estoy en la primera pagina
            {
                Resultado_DataList_Mis_Explicaciones(Convert.ToInt32(Session["Variable_ID_Usuario"]), (int)ViewState["Pagina_Mis_Explicaciones"]); // llama al datalist
                Centros_Paginados.Visible = true; // aparece pues no estoy ni en la primera ni en la ultima hoja 
                Extremos_Paginados.Visible = false; // no muestra los paginados externos de siguiente y anterior porque no estoy en la primera pagina
            }
        }
        #endregion
    }
}