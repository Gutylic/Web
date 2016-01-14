using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Datos;
using System.IO;

namespace Fenicia_Web
{
    public partial class Profesor_On_Line : System.Web.UI.Page
    {
        #region Clases
        
        Logica_Bloque_Profesor_On_Line LBPOL = new Logica_Bloque_Profesor_On_Line();
        
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null) // verifica si termino la session
            {
                Response.Redirect("sefue.aspx"); // me redirige a la pagina                
                Session.Clear(); // limpiar todas las variables de sesion del usuario
                Session.Abandon(); // abandonar las variables de sesion (esto se realiza con el fin de asegurarme que borro la session del usuario   
            }
            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {
                ViewState["Enunciado_Movil"] = null;
            }


        }


        #region Boton_Abrir_Ficha
        protected void Boton_Abrir_Ficha_Click(object sender, EventArgs e)
        {
            if (Ingreso_De_Ejercicio.Text == string.Empty && Contenido_Wiris.Value == "<math xmlns=\"http://www.w3.org/1998/Math/MathML\"/>" && !Subir_Adjunto.HasFiles ) // vacio el enunciado y el adjunto
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('No ha enviado ningún ejercicio');", true);
                Session["Nombre_Adjunto"]=null;
                Session["Nombre_Enunciado"]=null;
                return; // retorna a la pagina y no hace nada
                
            }


            if (Ingreso_De_Ejercicio.Text == string.Empty && Contenido_Wiris.Value == "<math xmlns=\"http://www.w3.org/1998/Math/MathML\"/>" && Subir_Adjunto.HasFiles) //vacio el enunciado pero con adjunto
            {
                Session["Subio_Adjunto"] = true;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Usted no ha escrito ningún enunciado');", true);
                Session["Nombre_Adjunto"] = "C:\\archivo/" + LBPOL.Logica_Armado_Del_Nombre_Del_Archivo((string)Session["Usuario"]) + "_adj." + Subir_Adjunto.PostedFile.FileName.Split('.')[1];
                Subir_Adjunto.PostedFile.SaveAs((string)Session["Nombre_Adjunto"]); // carga el adjunto   
                Session["Nombre_Enunciado"] = null;
                
                string codigo = @"<script type='text/javascript'>   
                            openModal();
                            </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", codigo, false);
                return;

            }


            if ((Ingreso_De_Ejercicio.Text != string.Empty || Contenido_Wiris.Value != "<math xmlns=\"http://www.w3.org/1998/Math/MathML\"/>") && !Subir_Adjunto.HasFiles) // tiene enunciado y no tiene adjunto
            {
                if (Contenido_Wiris.Value != "<math xmlns=\"http://www.w3.org/1998/Math/MathML\"/>")
                { 
                  
                    Session["Subio_Adjunto"] = false;
                    string Enunciado = LBPOL.Logica_Cargar_Enunciado(Contenido_Wiris.Value,(string)Session["Usuario"]); // carga el enunciado 
                    ViewState["Enunciado_1"] = LBPOL.Logica_Enunciados_Al_25(Enunciado).Valor_1; // toma una similitud inicial del 25% del enunciado para comprara
                    ViewState["Enunciado_2"] = LBPOL.Logica_Enunciados_Al_25(Enunciado).Valor_2; // toma una similitud intermedia del 25% del enunciado para comparar
                    Session["Nombre_Adjunto"] = null;
                    Session["Nombre_Enunciado"] = 1;
                    string codigo = @"<script type='text/javascript'>    
                            alert('usted envió el ejercicio sin archivo adjunto');  
                            openModal();
                            </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", codigo, false);
                    return;
                }

                if (Ingreso_De_Ejercicio.Text != string.Empty)
                {                    
                    Session["Subio_Adjunto"] = false;
                    string Enunciado = LBPOL.Logica_Cargar_Enunciado(Contenido_Wiris.Value, (string)Session["Usuario"]); // carga enunciado
                    Session["Nombre_Adjunto"] = "C:\\archivo/" + LBPOL.Logica_Armado_Del_Nombre_Del_Archivo((string)Session["Usuario"]) + "_adj." + Subir_Adjunto.PostedFile.FileName.Split('.')[1];
                    Subir_Adjunto.PostedFile.SaveAs((string)Session["Nombre_Adjunto"]); // carga el adjunto   
                   
                    Session["Nombre_Enunciado"] = 1;
                  
                    ViewState["Enunciado_1"] = LBPOL.Logica_Enunciados_Al_25(Enunciado).Valor_1; // toma una similitud inicial del 25% del enunciado para comprara
                    ViewState["Enunciado_2"] = LBPOL.Logica_Enunciados_Al_25(Enunciado).Valor_2; // toma una similitud intermedia del 25% del enunciado para comparar
                    string codigo = @"<script type='text/javascript'>                               
                            openModal();
                            </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", codigo, false);
                    return;
                }
            }
            
            if ((Ingreso_De_Ejercicio.Text != string.Empty || Contenido_Wiris.Value != "<math xmlns=\"http://www.w3.org/1998/Math/MathML\"/>") && Subir_Adjunto.HasFiles) // carga enunciado y adjunto
            {
                if (Contenido_Wiris.Value != "<math xmlns=\"http://www.w3.org/1998/Math/MathML\"/>")
                {
                    Session["Subio_Adjunto"] = true;
                    string Enunciado = LBPOL.Logica_Cargar_Enunciado(Contenido_Wiris.Value, (string)Session["Usuario"]); // carga enunciado
                    Session["Nombre_Adjunto"] = "C:\\archivo/" + LBPOL.Logica_Armado_Del_Nombre_Del_Archivo((string)Session["Usuario"]) + "_adj." + Subir_Adjunto.PostedFile.FileName.Split('.')[1];
                    Subir_Adjunto.PostedFile.SaveAs((string)Session["Nombre_Adjunto"]); // carga el adjunto   
                    
                    Session["Nombre_Enunciado"] = 1;
                    ViewState["Enunciado_1"] = LBPOL.Logica_Enunciados_Al_25(Enunciado).Valor_1; // toma una similitud inicial del 25% del enunciado para comprara
                    ViewState["Enunciado_2"] = LBPOL.Logica_Enunciados_Al_25(Enunciado).Valor_2; // toma una similitud intermedia del 25% del enunciado para comparar
                    string codigo = @"<script type='text/javascript'>                               
                            openModal();
                            </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", codigo, false);
                    return;
                }
                if (Ingreso_De_Ejercicio.Text != string.Empty)
                {
                    Session["Subio_Adjunto"] = true;
                    string Enunciado = LBPOL.Logica_Cargar_Enunciado(Contenido_Wiris.Value, (string)Session["Usuario"]); // carga enunciado
                    Session["Nombre_Adjunto"] = "C:\\archivo/" + LBPOL.Logica_Armado_Del_Nombre_Del_Archivo((string)Session["Usuario"]) + "_adj." + Subir_Adjunto.PostedFile.FileName.Split('.')[1];
                    Subir_Adjunto.PostedFile.SaveAs((string)Session["Nombre_Adjunto"]); // carga el adjunto   

               
                    Session["Nombre_Enunciado"] = 1;

                    ViewState["Enunciado_1"] = LBPOL.Logica_Enunciados_Al_25(Enunciado).Valor_1; // toma una similitud inicial del 25% del enunciado para comprara
                    ViewState["Enunciado_2"] = LBPOL.Logica_Enunciados_Al_25(Enunciado).Valor_2; // toma una similitud intermedia del 25% del enunciado para comparar
                    string codigo = @"<script type='text/javascript'>                               
                            openModal();
                            </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", codigo, false);
                    return;
                }
            }            
        }

        #endregion


        #region Enviar_Ejercicio_Para_Resolver
        protected void Boton_Enviar_Ejercicio_Click(object sender, EventArgs e)
        {
            Session["Contenido"] = "?Tema=" + Buscar_x_Tema.Text + "&Materia=" + Buscar_x_Materia.Text + "&Maestro=" + Buscar_x_Profesor.Text + "&Colegio=" + Buscar_x_Colegio.Text + "&Ano=" + Buscar_x_Ano.Text + "&Usuario=" + (string)Session["Usuario"] + "&Enunciado1=" + (string)ViewState["Enunciado_1"] + "&Enunciado2=" + (string)ViewState["Enunciado_2"]; // creo una variable de session con  el contenido de la URL para enviar las variables
            
            if (Buscar_x_Tema.Text == string.Empty && Buscar_x_Materia.Text == string.Empty && Buscar_x_Profesor.Text == string.Empty && Buscar_x_Colegio.Text == string.Empty && Buscar_x_Ano.Text == string.Empty) // mira si no hay ficha
            {
                LBPOL.Logica_Cargar_Ficha(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, (string)Session["Usuario"]);

                if (ViewState["Enunciado_1"] == null) // me mando un adjunto y hay que resolverlo
                {
                    int Ejercicio = LBPOL.Logica_Comprar_Mi_Ejercicio_Personalizado(Convert.ToInt32(Session["Variable_ID_Usuario"]), Request.UserHostAddress.ToString(), 2, (string)Session["Nombre_Adjunto"], LBPOL.Logica_Armado_Del_Nombre_Del_Archivo((string)Session["Usuario"]), null);

                    LBPOL.Logica_Bonificacion_X_Cantidad(Convert.ToInt32(Session["Variable_ID_Usuario"]), 1, Request.UserHostAddress.ToString()); // ejecuta un procedimiento para cargar credito y ademas acentarlo en los movimientos

                   
                    if (Ejercicio == 1) // tengo plata compro
                    {
                        Compra_OK_Con_Ficha();
                        return;
                    }
                    if (Ejercicio == 0) // no tengo plata no compro
                    {
                        Sin_Plata();
                        return;
                    }
                    if (Ejercicio == -6) // no se conecto a la base
                    {
                        Fallo();
                         return;
                    }
                    
                }
                else //sin ficha con enunciado 
                {
                   
                    if (ViewState["Enunciado_Movil"] == null) // enunciado movil vacio
                    {                        
                        Response.Redirect("Pagina_Enunciados.aspx?Enunciado1=" + (string)ViewState["Enunciado_1"] + "&Enunciado2=" + (string)ViewState["Enunciado_2"] + "&Usuario=" + (string)Session["Usuario"] + "&Boton_Ejercicio=true&Boton_Explicacion=true"); // me envia a la pagina de enunciados similares y bloquea el boton de buscar por ficha
                    }
                    else
                    {
                        Compra_OK_Con_Ficha();
                        return;
                    }                    
                }            
            }
                
            else //con ficha 
            {
                
                LBPOL.Logica_Cargar_Ficha(Buscar_x_Tema.Text, Buscar_x_Materia.Text, Buscar_x_Profesor.Text, Buscar_x_Colegio.Text, Buscar_x_Ano.Text, (string)Session["Usuario"]); //carga la ficha en el disco C:
                if (ViewState["Enunciado_1"] == null) // con ficha sin enunciado
                {
                    Response.Redirect("Pagina_Fichas.aspx?Tema=" + Buscar_x_Tema.Text + "&Materia=" + Buscar_x_Materia.Text + "&Maestro=" + Buscar_x_Profesor.Text + "&Colegio=" + Buscar_x_Colegio.Text + "&Ano=" + Buscar_x_Ano.Text + "&Usuario=" + (string)Session["Usuario"] + "&Boton_Ejercicio=true&Boton_Explicacion=true"); // busca por ficha y bloquea el boton de buscar por enunciado
                }
                else // con ficha con enunciado 
                {
                    if (ViewState["Enunciado_Movil"] == null) // enunciado movil vacio
                    {
                        Response.Redirect("Pagina_Fichas.aspx" + (string)Session["Contenido"] + "&Boton_Ejercicio=true&Boton_Explicacion=true"); // llama a la pagina de buscar por ficha y permite buscar por enundiado
                    }
                    else // enunciado movil lleno
                    {
                        Response.Redirect("Pagina_Fichas.aspx?Tema=" + Buscar_x_Tema.Text + "&Materia=" + Buscar_x_Materia.Text + "&Maestro=" + Buscar_x_Profesor.Text + "&Colegio=" + Buscar_x_Colegio.Text + "&Ano=" + Buscar_x_Ano.Text + "&Usuario=" + (string)Session["Usuario"] + "&Boton_Ejercicio=true&Boton_Explicacion=true"); // busca por ficha y bloquea el boton de buscar por enunciado
                    }   
                }
            }
        }


        public void Compra_OK_Con_Ficha()
        {
            string alerta = @"<script type='text/javascript'>    
                            alert('gracias por comprar nuestros servicios');  
                            
                            </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, false);
            //window.location='Pagina_Fichas.aspx';
        }

        public void Compra_OK_Sin_Ficha()
        {
            string alerta = @"<script type='text/javascript'>    
                            alert('gracias por comprar nuestros servicios');                             
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
        #endregion
    }
}