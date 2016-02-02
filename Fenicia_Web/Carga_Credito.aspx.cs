using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;
using System.Diagnostics;
using mercadopago;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Fenicia_Web
{
    public partial class Carga_Credito : System.Web.UI.Page
    {

        Logica_Bloque_Carga_De_Credito LBCDC = new Logica_Bloque_Carga_De_Credito(); 

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] == null) // si la variable de session esta vacia se vuelve al origen
            {
                Response.Redirect("index.aspx");

            }

        }

        
        protected void Boton_Prestamo_SOS_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5999);
           
            int? Valor = LBCDC.Logica_Pedido_Prestamo_SOS(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Request.UserHostAddress.ToString()); // resultado del prestamo SOS, el uno es la empresa
            switch (Valor)
            {
                case 1: // presto la plata
                    string OK = @"<script type='text/javascript'>    
                                   alert('su carga ya fue acreditada, gracias por usar nuestros servicios'); 
                                   window.location.href= 'index.aspx'; 
                                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", OK, false);
                    break;
                case 0: // ya pidio un prestamo
                    string Fallo = @"<script type='text/javascript'>    
                                   alert('Usted ya ha pedido su prestamo SOS'); 
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", Fallo, false);
                    break;
                case -6: // no se conecto a la base de datos
                    string Fallo1 = @"<script type='text/javascript'>    
                                   alert('En estos momentos no podemos procesar su pedido intentelo mas tarde'); 
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", Fallo1, false);
                    break;
            }

        }

        protected void Boton_Tarjeta_Prepago_Click(object sender, EventArgs e)
        {
            decimal? Premio_1;  // variable preparada para saber si tiene premio la recarga
            decimal? Premio_2;  // variable preparada para saber si tiene premio la carga
            decimal? Plata = LBCDC.Logica_Obtener_Credito_De_La_Tarjeta(int.Parse(Codigo_De_La_Tarjeta.Text), 2); //determina si la tarjeta es valida y ademas me da el valor de la tarjeta
            if (Plata == null) // plata cero es que la tajeta se vencio o no existe
            {
                string FALLO = @"<script type='text/javascript'>    
                                   alert('esta tarjeta ya fue cargada con anterioridad, cargue una nueva'); 
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", FALLO, false);
            }

            Premio_1 = LBCDC.Logica_Cargar_Premio_En_La_Proxima_Recarga(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Plata, Request.UserHostAddress.ToString()); // carga para la proxima recarga el premio

            Premio_2 = LBCDC.Logica_Bonificacion_X_Carga(Convert.ToInt32(Session["Variable_ID_Usuario"]), 2, Request.UserHostAddress.ToString(), Plata); // bonificacion en la carga

            int Valor = LBCDC.Logica_Cargar_Credito_Usuarios(Convert.ToInt32(Session["Variable_ID_Usuario"]), Plata, 2, Request.UserHostAddress.ToString(), Premio_1, Premio_2); // resultado del codigo de la tarjeta un uno es la empresa y el otro uno es la descripcion del movimiento

            switch (Valor)
            {
                case 1: // cargo la tarjeta y ya se debito                    
                    string OK = @"<script type='text/javascript'>    
                                   alert('su carga ya fue acreditada, gracias por usar nuestros servicios'); 
                                   window.location.href= 'index.aspx'; 
                                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", OK, false);
                    break;
                case -6: // no se conecto a la base de datos
                    string FALLO = @"<script type='text/javascript'>    
                                   alert('su tarjeta no se pudo cargar, comuniquese con nuestros operadores'); 
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", FALLO, false);
                    break;
            }


        }

            


        protected void Boton_Mercado_Pago_Click(object sender, EventArgs e)
        {

            decimal Valor_Carga = LBCDC.Mercado_Pago(TextBox_Mercado_Pago.Text, TextBox_Mercado_Pago_Movil.Text); // analisis de donde pidio la carga pc o movil

            if (Valor_Carga == -9) // fallo los botones en javascript
            {
                return;
            }

            MP mp = new MP("7071654091217780", "F4SUQfv2CA4YUvPj0VsFROGywMkcYvyC");

            Hashtable preference = mp.createPreference("{\"items\":[{\"title\":\"clases\",\"quantity\":1,\"currency_id\":\"ARS\",\"unit_price\":" + Valor_Carga + "}],\"external_reference\":\"" + (string)Session["User"] + "\"}");
            
            String accessToken = mp.getAccessToken();
            
            Response.Redirect((((Hashtable) preference["response"])["sandbox_init_point"]).ToString());

        }


        protected void Boton_Cuenta_Digital_Click(object sender, EventArgs e)
        {

            decimal Valor_Carga = LBCDC.Cuenta_Digital(TextBox_Cuenta_Digital.Text, TextBox_Cuenta_Digital_Movil.Text, TextBox_PagoFacil.Text, TextBox_PagoFacil_Movil.Text); // averigua donde pidio la carga si de movil o pc o si es de pago facil o de cuenta digital

            if (Valor_Carga == -9) // fallo el analisis del boton capturado en javascript
            {
                return;
            }

            if (Valor_Carga > 5) // carga menos plata que la permitida
            {

                Response.Redirect("https://www.cuentadigital.com/api.php?id=596733&codigo=" + (string)Session["User"] + "&precio=" + Valor_Carga + "&venc=7&concepto=Credito&moneda=ARS&site=");

            }
            else
            {

                string script = @"<script type='text/javascript'>
                              alert('Debe realizar facturas de mas de (cinco pesos) $5');
                              </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                return;
            }


        }


        protected void Boton_Paypal_Factura_Click(object sender, EventArgs e)
        {


            decimal Valor_Carga = LBCDC.PayPal(TextBox_PayPal.Text, TextBox_PayPal_Movil.Text); // analisis de donde pidio la plata si desde el celular o la pc

            if (Valor_Carga == -9) // si falla el javascript del boton
            {
                return;
            }


            if (Valor_Carga > 5) // evita que se cargue menos de 5 pesos
            {

                Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business=Correodelosprofesores@gmail.com&item_name=Carga_de_Credito&amount=" + Valor_Carga + "&no_shipping=1&item_number=" + (string)Session["User"]);


            }
            else
            {

                string script = @"<script type='text/javascript'>
                              alert('Debe realizar facturas de mas de (cinco pesos) $5');
                              </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                return;

            }
            
        }
        
    }

}