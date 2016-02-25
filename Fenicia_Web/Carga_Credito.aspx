<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carga_Credito.aspx.cs" Inherits="Fenicia_Web.Carga_Credito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

<title>Fenicia ¡es aprobar!</title>

<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
         
<!-- Jquery -->
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="js/jquery-2.1.1.min.js"></script>
   
<!-- js Bootstrap 3 -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

<!-- CSS correspondiente a Bootstrap 3 -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />

<!-- CSS con los estilos-->
    <link href="css/encabezado.css" rel="stylesheet" type="text/css"/> <%--encabezado--%>
    <link href="css/cabecera_credito.css" rel="stylesheet" type="text/css"/> <%-- cabecera del panel de credito--%>
    <link href="css/cargar_credito_pagofacil.css" rel="stylesheet" type="text/css"/> <%--pagofacil --%>
    <link href="css/cargar_credito_prepago.css" rel="stylesheet" type="text/css"/><%--tarjeta --%>
    <link href="css/cargar_credito_cuenta.css" rel="stylesheet" type="text/css"/><%--cuenta digital --%>
    <link href="css/cargar_mercado_pago.css" rel="stylesheet" type="text/css"/><%--mercado pago --%>
    <link href="css/cargar_paypal.css" rel="stylesheet" type="text/css"/><%--paypal --%>
    <link href="css/cargar_prestamo.css" rel="stylesheet" type="text/css"/><%--prestamo --%>
    <link href="css/cargar_transferencia.css" rel="stylesheet" type="text/css"/><%--transferencia --%>
    <link href="css/pizarra_carrusel.css" rel="stylesheet" type="text/css"/> <%-- pizarra y carrousel--%>
    <link href="css/amarillo_profesores.css" rel="stylesheet" type="text/css"/><%--panel amarillo con los profesores --%>   
    <link href="css/pie.css" rel="stylesheet" type="text/css"/><%-- pie --%>
    <link href="css/progreso.css" rel="stylesheet" type="text/css"/><%-- imagenes de progreso --%>
    
<!-- js programadores de la pagina -->    

    <script src="js/credito.js"></script>

    <script >

        $(document).ready(function () { /* efecto hover sobre la botonera */

            $("#Boton_Pago").hover(
               function () {
                   $('#<%=Boton_Pago.ClientID%>').attr("src", "images/pago_in.png");
               },
                 function () {
                     $('#<%=Boton_Pago.ClientID%>').attr("src", "images/pago_out.png");
                 }
            );
            $("#Boton_Prepago").hover(
                 function () {
                     $('#<%=Boton_Prepago.ClientID%>').attr("src", "images/prepago_in.png");
                 },
                 function () {
                     $('#<%=Boton_Prepago.ClientID%>').attr("src", "images/prepago_out.png");
                 }
            );
            $("#Boton_Mercado").hover(
                function () {
                    $('#<%=Boton_Mercado.ClientID%>').attr("src", "images/mercado_in.png");
                },
                function () {
                    $('#<%=Boton_Mercado.ClientID%>').attr("src", "images/mercado_out.png");
                }
            );
            $("#Boton_Cuenta").hover(
                function () {
                    $('#<%=Boton_Cuenta.ClientID%>').attr("src", "images/cuenta_in.png");
                },
                function () {
                    $('#<%=Boton_Cuenta.ClientID%>').attr("src", "images/cuenta_out.png");
                }
            );
            $("#Boton_Paypal").hover(
                function () {
                    $('#<%=Boton_Paypal.ClientID%>').attr("src", "images/paypal_in.png");
                },
                function () {
                    $('#<%=Boton_Paypal.ClientID%>').attr("src", "images/paypal_out.png");
                }
            );
            $("#Boton_Transferencia").hover(
                function () {
                    $('#<%=Boton_Transferencia.ClientID%>').attr("src", "images/transferencia_in.png");
                },
                function () {
                    $('#<%=Boton_Transferencia.ClientID%>').attr("src", "images/transferencia_out.png");
                }
            );
            $("#Boton_Prestamo").hover(
                function () {
                    $('#<%=Boton_Prestamo.ClientID%>').attr("src", "images/prestamo_in.png");
                },
                function () {
                    $('#<%=Boton_Prestamo.ClientID%>').attr("src", "images/prestamo_out.png");
                }
            );
            $("#Boton_Pago_Movil").hover(
                function () {
                    $('#<%=Boton_Pago_Movil.ClientID%>').attr("src", "images/pago_in_movil.png");
                },
                function () {
                    $('#<%=Boton_Pago_Movil.ClientID%>').attr("src", "images/pago_out_movil.png");
                }
            );
            $("#Boton_Prepago_Movil").hover(
                function () {
                    $('#<%=Boton_Prepago_Movil.ClientID%>').attr("src", "images/prepago_in_movil.png");
                },
                function () {
                    $('#<%=Boton_Prepago_Movil.ClientID%>').attr("src", "images/prepago_out_movil.png");
                }
            );
            $("#Boton_Mercado_Movil").hover(
                function () {
                    $('#<%=Boton_Mercado_Movil.ClientID%>').attr("src", "images/mercado_in_movil.png");
                },
                function () {
                    $('#<%=Boton_Mercado_Movil.ClientID%>').attr("src", "images/mercado_out_movil.png");
                }
            );
            $("#Boton_Cuenta_Movil").hover(
                function () {
                    $('#<%=Boton_Cuenta_Movil.ClientID%>').attr("src", "images/cuenta_in_movil.png");
                },
                function () {
                    $('#<%=Boton_Cuenta_Movil.ClientID%>').attr("src", "images/cuenta_out_movil.png");
                }
            );
            $("#Boton_Paypal_Movil").hover(
                function () {
                    $('#<%=Boton_Paypal_Movil.ClientID%>').attr("src", "images/paypal_in_movil.png");
                },
                function () {
                    $('#<%=Boton_Paypal_Movil.ClientID%>').attr("src", "images/paypal_out_movil.png");
                }
            );
            $("#Boton_Transferencia_Movil").hover(
                function () {
                    $('#<%=Boton_Transferencia_Movil.ClientID%>').attr("src", "images/transferencia_in_movil.png");
                },
                function () {
                    $('#<%=Boton_Transferencia_Movil.ClientID%>').attr("src", "images/transferencia_out_movil.png");
                }
            );
            $("#Boton_Prestamo_Movil").hover(
                function () {
                    $('#<%=Boton_Prestamo_Movil.ClientID%>').attr("src", "images/prestamo_in_movil.png");
                },
                function () {
                    $('#<%=Boton_Prestamo_Movil.ClientID%>').attr("src", "images/prestamo_out_movil.png");
                }
            );
        });


</script>

<link rel="shortcut icon" type="image/png" href="favicon.icon" />
<link rel="apple-touch-icon" href="img/touch-icon.png"/>


</head>


<body>
    
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            
            
<%-- **************** Aca comienza la cabecera de la pagina ****************************--%>
                
        <header id="main-header"> <%-- estilos del encabezado en encabezado --%> 
            <div class="container">
                <div class="row">
                    <div class="col-xs-10 col-sm-3">
                        <h1 class="logo_fenicia"><a href="#" class="scroll-top" title="volver tipos de carga"><span>Fenicia</span><span class="es_aprobar">¡es aprobar!</span></a></h1>  
                    </div>	  
                     <div class="col-xs-2 col-sm-9">
                        <ul class="nav nav-pills hidden-xs" id="main-menu" >
			                <li><a href="index.aspx" class="icono_movil scroll"><span class="glyphicon glyphicon-home linea_inferior_encabezado"></span>Volver a página principal</a></li>
			            </ul>  
                        <a href="index.aspx" id="mobile-menu-button" title="volver a inicio" class="btn btn-xs visible-xs ">
                            <span class="glyphicon glyphicon-home linea-hs"></span>
                        </a>                       
                    </div>                        
                </div>
            </div>         
        </header>  <%--fin del estilo del encabezado --%> 


<%-- **************** Pizarra con botones de pago ********************************************--%>


        <section id="top">        
            <article class="fondo_pizarra">                     
                <div class="container">	                
                    <div class="row hidden-xs">		                
                        <div class="col-sm-12 superior">	
                            <asp:ImageButton data-id="pfrp" ID="Boton_Pago" ToolTip="Pagofacil - rapipago" CssClass="scroll-link" ImageUrl="~/images/pago_out.png" runat="server" />
                            <asp:ImageButton data-id="tp" ID="Boton_Prepago" ImageUrl="~/images/prepago_out.png" CssClass="scroll-link" runat="server" ToolTip="Prepago"  />
                            <asp:ImageButton data-id="mp" ID="Boton_Mercado" ImageUrl="~/images/mercado_out.png" CssClass="scroll-link" runat="server" ToolTip="MercadoPago" />
                            <asp:ImageButton data-id="cd" ID="Boton_Cuenta" ImageUrl="~/images/cuenta_out.png" CssClass="scroll-link" runat="server" ToolTip="CuentaDigital" />
		                </div>	  
                        <div class="col-sm-12 inferior">			                
                            <asp:ImageButton data-id="pp" ID="Boton_Paypal" ImageUrl="~/images/paypal_out.png" CssClass="scroll-link" runat="server" ToolTip="PayPal"  />
                            <asp:ImageButton data-id="psos" ID="Boton_Prestamo" ImageUrl="~/images/prestamo_out.png" CssClass="scroll-link" runat="server" ToolTip="Prestamo SOS"  />
                            <asp:ImageButton data-id="tb" ID="Boton_Transferencia" ImageUrl="~/images/transferencia_out.png" CssClass="scroll-link" runat="server" ToolTip="Transferencia Bancaria"  /> 
		                </div>	       
                    </div>
                    <div class="row visible-xs">
                        <div class="col-xs-12 ">   
                            <asp:ImageButton ID="Boton_Prepago_Movil" data-id="tpm" ImageUrl="~/images/prepago_out_movil.png" CssClass="scroll-link" runat="server" />
                            <asp:ImageButton ID="Boton_Pago_Movil" data-id="pfrpm" ImageUrl="~/images/pago_out_movil.png" CssClass="scroll-link" runat="server" />
                        </div> 
                        <div class="col-xs-12 ">   
                            <asp:ImageButton ID="Boton_Mercado_Movil" data-id="mpm" ImageUrl="~/images/mercado_out_movil.png" CssClass="scroll-link" runat="server" />
                            <asp:ImageButton ID="Boton_Cuenta_Movil" data-id="cdm" ImageUrl="~/images/cuenta_out_movil.png" CssClass="scroll-link" runat="server" />
                        </div>   
                        <div class="col-xs-12 ">   
                            <asp:ImageButton ID="Boton_Paypal_Movil" data-id="ppm" ImageUrl="~/images/paypal_out_movil.png" CssClass="scroll-link" runat="server" />
                            <asp:ImageButton ID="Boton_Transferencia_Movil" data-id="tbm" ImageUrl="~/images/transferencia_out_movil.png" CssClass="scroll-link" runat="server" />
                        </div>
                        <div class="col-xs-12 ">   
                            <asp:ImageButton ID="Boton_Prestamo_Movil" data-id="psosm" ImageUrl="~/images/prestamo_out_movil.png" CssClass="scroll-link" runat="server" />
                        </div>  
                    </div> 
                </div> 
            </article>  
        </section>


<%-- **************** pago rapipago *****************************************--%>      
        
        <section>
            <article class="fondo_amarillo hidden-xs"> <%-- contiene las pantallas grandes--%>
                <div class="container" > 
                    <div class="row"> 
                        <div class="col-xs-6 col-xs-offset-3" >
                            <div id="pfrp"></div>
                            <div class="tarjeta_blanca">
                                <div class="row">
                                    <div class="col-xs-4">
                                        <img class="logo_rapipago" src="images/logo_rapipago_pagofacil.png"  />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-6 col-xs-offset-3 contenedor_info">
                                        <p class="aclaracion_tarjeta">escriba la cantidad que desea cargar</p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-6 col-xs-offset-3 contenedor_total">
                                        <div class="row">
                                            <div class="col-xs-1 contenedor_pesos">
                                            <p class="pesos">$</p>
                                            </div>
                                            <div class="col-xs-10 contenedor_textbox">
                                                <asp:TextBox CssClass="pago_facil" ID="TextBox_PagoFacil" onkeypress="ValidNum()" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-6 col-xs-offset-3 contenedor_boton">
                                        <asp:UpdatePanel ID="UpdatePanel_Pago" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="Boton_Factura_PagoFacil" OnClientClick="return validar_textbox_pagofacil()" class="btn boton_pagofacil" runat="server" ToolTip="presione el botón" OnClick="Boton_Mercado_Pago_Click" Text="Generar Factura" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>   
                                    </div>
                                </div>
                            </div>
                        </div>              
                    </div>  
                </div>                
            </article>
            <div id="pfrpm"></div>
            <article class="fondo_amarillo_movil visible-xs"> <%-- contiene la pantalla chica--%>
                <div class="container">
                    <div class="row">
                        <div class="tarjeta_blanca_movil">
                            <div class="col-xs-12 contenedor_logo_movil">                                
                                <img class="logo_rapipago_movil" src="images/logo_rapipago_pagofacil.png"  />
                            </div>
                            <div class="col-xs-12 contenedor_pesos_movil">
                                <div class="col-xs-1 pesos_movil">$</div>
                                <div class="col-xs-10  contenedor_textbox_movil">
                                    <asp:TextBox ID="TextBox_PagoFacil_Movil" onkeypress="ValidNum()" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xs-12 contenedor_boton_movil">
                                <asp:UpdatePanel ID="UpdatePanel_Cuenta_Movil" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="Boton_Pagofacil_Movil" OnClientClick="return validar_textbox_pagofacil_movil()" OnClick="Boton_Mercado_Pago_Click" CssClass="btn btn-default" runat="server" Text="Generar Factura" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>                                
                            </div>
                        </div>
                    </div>
                </div>
            </article>  
        </section>            
  

<%-- *********************************** tarjeta xelados ***********************************--%>    

        <section>
            <article class= "hidden-xs"> <%-- contiene las pantallas grandes--%>
                <div class="container fondo_blanco " > 
                    <div class="row">                        
                        <div class="col-sm-6 col-sm-offset-3 "> 
                            <div id="tp"></div>                          
                            <div class="tarjeta_amarilla_prepago">
                                <div class="row">
                                    <div class="col-xs-3 logo_prepago">
                                        <img src="images/logo_prepago.png" />
                                    </div>                                      
                                    <div class="col-xs-4 col-xs-offset-5 logo_precio">$ 99,99</div>
                                </div>
                                <div class="row">                                      
                                    <div class="col-xs-6 col-xs-offset-3 codigo_tarjeta">Ingrese el código de su tarjeta</div>  
                                </div>
                                <div class="row">
                                    <div class="col-xs-6 col-xs-offset-3 contenedor_codigo">
                                        <asp:TextBox ID="Codigo_De_La_Tarjeta" onkeypress="ValidNum()" CssClass="textbox_prepago" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row pie_de_pagina_azul">
                                    <div class="col-xs-12 fondo_azul_prepago">
                                        <div class="row ">
                                            <div class="col-xs-6 col-xs-offset-3">
                                                <asp:UpdatePanel ID="UpdatePanel_Boton_Tarjeta" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="Boton_Tarjeta_Prepago" CssClass="btn boton-prepago" runat="server" Text="Ingrese su código" OnClientClick="return validar_textbox_tarjeta()" OnClick="Boton_Tarjeta_Prepago_Click"/>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>    
                                            </div>
                                            <div class="col-xs-3 logo_fenicia_prepago">
                                                <span class="fenicia_prepago">Fenicia</span>
                                            </div>
                                        </div>
                                        <div class="row ">
                                            <div class="col-xs-3 col-xs-offset-9 contenido_aprobar">
                                                <span class="aprobar_prepago">¡es aprobar!</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>                 
                    </div>
                </div>            
            </article>
            <div id="tpm"></div>
            <article class="visible-xs"> <%-- contiene la pantalla chica--%>
                <div class="container fondo_blanco_movil">
                    <div class="row">
                        <div class="tarjeta_amarilla_movil">
                            <div class="col-xs-12 contenedor_logo_movil">                                
                                <img class="logo_prepago_movil" src="images/logo_prepago.png"  />
                            </div>
                            <div class="col-xs-12 contenedor_pesos_movil">
                                <div class="col-xs-1 pesos_movil">Nº</div>
                                <div class="col-xs-10  contenedor_textbox_movil">
                                    <asp:TextBox ID="TextBox_Prepago_Movil" onkeypress="ValidNum()" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xs-12 contenedor_boton_movil">
                                <asp:UpdatePanel ID="UpdatePanel_Boton_Tarjeta_Movil" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="Boton_Tarjeta_Prepago_Movil" OnClientClick="return validar_textbox_prepago_movil()" OnClick="Boton_Tarjeta_Prepago_Click" CssClass="btn btn-default" runat="server" Text="Ingresar Código" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </article>
        </section>


<%-- **************** cuenta digital *****************************************--%>      
        
        <section>
            <article class="fondo_amarillo hidden-xs"> <%-- contiene las pantallas grandes--%>         
                <div class="container">                    
                    <div class="row">                        
                        <div class="col-xs-6 col-xs-offset-3" >
                            <div id="cd"></div>
                            <div class="tarjeta_blanca">
                                <div class="row" >
                                    <div class="col-xs-8 col-xs-push-4 pago1" >
                                       <img src="images/pago1.png" class="logo_pago"/>
                                    </div>
                                    <div class="col-xs-4 col-xs-pull-8 cuenta-dgital" >
                                        <img src="images/logo_cuenta_digital.png" class="logo_cuenta" />
                                    </div>
                                </div>
                                <div class="row"> 
                                    <div class="col-xs-8 col-xs-offset-4 pago2">
                                        <img src="images/pago2.png" class="logo_pago"/>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-6 col-xs-offset-6 pago3">
                                        <img src="images/pago3.png" class="logo_pago"/>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-6 col-xs-offset-6 pago4" >
                                        <img src="images/pago4.png" class="logo_pago"/>
                                    </div>
                                </div>
                            </div>                  
                            <div class="row">
                                <div class="col-xs-6 col-xs-offset-2 info_cuenta" >escriba la cantidad que desea cargar</div>
                            </div>
                            <div class="row">
                                <div class="col-xs-6 col-xs-offset-2 contenedor_total_cuenta">
                                    <div class="row">
                                        <div class="col-xs-1 contenedor_pesos_cuenta">
                                            <p class="pesos">$</p>
                                        </div>
                                        <div class="col-xs-10 contenedor_textbox_cuenta">
                                            <asp:TextBox CssClass="cuenta_digital" ID="TextBox_Cuenta_Digital" onkeypress="ValidNum()" runat="server"></asp:TextBox>
                                         </div>
                                    </div>
                                </div>
                            </div>  
                            <div class="row">
                                <div class="col-xs-6 col-xs-offset-3 boton_cuenta" >
                                    <asp:UpdatePanel ID="UpdatePanel_Cuenta_Digital" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="Boton_CuentaDigital" runat="server" OnClientClick="return validar_textbox_cuenta_digital()" OnClick="Boton_Cuenta_Digital_Click" CssClass="btn" Text="Generar factura" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>                                    
                                </div>
                            </div>                          
                        </div>
                    </div>
                </div>   
            </article>  
            <div id="cdm"></div>
            <article class="fondo_amarillo_movil visible-xs"> <%-- contiene la pantalla chica--%>
                <div class="container">
                    <div class="row">
                        <div class="tarjeta_blanca_movil">
                            <div class="col-xs-12 contenedor_logo_movil">                                
                                <img class="logo_cuenta_digital_movil" src="images/logo_cuenta_digital.png"  />
                            </div>
                            <div class="col-xs-12 contenedor_pesos_movil">
                                <div class="col-xs-1 pesos_movil">$</div>
                                <div class="col-xs-10  contenedor_textbox_movil">
                                    <asp:TextBox ID="TextBox_Cuenta_Digital_Movil" onkeypress="ValidNum()" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xs-12 contenedor_boton_movil">
                                <asp:UpdatePanel ID="UpdatePanel_Cuenta_Digital_Movil" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="Boton_Cuenta_Digital" OnClientClick="return validar_textbox_cuenta_digital_movil()" OnClick="Boton_Cuenta_Digital_Click" CssClass="btn btn-default" runat="server" Text="Generar Factura" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>                                
                            </div>
                        </div>
                    </div>
                </div>
            </article>  
        </section>   
         

<%-- *********************************** mercado pago ***********************************--%> 
           
        <section>
            <article class="hidden-xs">
                <div class="container fondo_blanco" >
                    <div class="row">                        
                        <div class="col-sm-6 col-sm-offset-3 ">
                            <div id="mp"></div>                          
                            <div class="tarjeta_amarilla">
                                <div class="row">
                                    <div class="col-xs-4">
                                        <img class="logo_mercado_pago" src="images/logo_mercado_pago.png"  />
                                    </div>
                                </div>
                                <div class="row contenido_total_mercado">
                                    <div class="col-xs-6 col-xs-offset-3 contenedor_info">
                                        <p class="aclaracion_tarjeta">escriba la cantidad que desea cargar</p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-6 col-xs-offset-3 contenedor_total">
                                        <div class="row">
                                            <div class="col-xs-1 contenedor_pesos">
                                            <p class="pesos">$</p>
                                            </div>
                                            <div class="col-xs-10 contenedor_textbox">
                                                <asp:TextBox CssClass="mercado_pago" ID="TextBox_Mercado_Pago" onkeypress="ValidNum()" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-6 col-xs-offset-3 contenedor_boton_mercado">
                                        <asp:UpdatePanel ID="UpdatePanel_TextBox_MP" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="Boton_Mercado_Pago" OnClientClick="return validar_textbox_mercado_pago()" OnClick="Boton_Mercado_Pago_Click" class="btn boton_mercado_pago" runat="server" ToolTip="presione el botón" Text="Generar Factura" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>                                        
                                    </div>
                                </div>
                            </div>
                        </div>          
                    </div>                       
                </div>                     
            </article>
            <div id="mpm"></div>
            <article class="visible-xs"> <%-- contiene la pantalla chica--%>
                <div class="container fondo_blanco_movil">
                    <div class="row">
                        <div class="tarjeta_amarilla_movil">
                            <div class="col-xs-12 contenedor_logo_movil">
                                
                                <img class="logo_mercado_pago_movil" src="images/logo_mercado_pago.png"  />
                            </div>
                            <div class="col-xs-12 contenedor_pesos_movil">
                                <div class="col-xs-1 pesos_movil">$</div>
                                <div class="col-xs-10  contenedor_textbox_movil">
                                    <asp:TextBox ID="TextBox_Mercado_Pago_Movil" onkeypress="ValidNum()" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xs-12 contenedor_boton_movil">
                                <asp:UpdatePanel ID="UpdatePanel_TextBox_MPM" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="Boton_Mercadopago_Movil" OnClientClick="return validar_textbox_mercado_pago_movil()" OnClick="Boton_Mercado_Pago_Click" CssClass="btn btn-default" runat="server" Text="Generar Factura" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>                                
                            </div>
                        </div>
                    </div>
                </div>
            </article>
        </section>


<%-- **************** paypal *****************************************--%>      
        
        <section>
            <article class="fondo_amarillo hidden-xs">          
                <div class="container">                    
                    <div class="row">                        
                        <div class="hidden-xs">                        
                            <div class="col-sm-6 col-sm-offset-3 ">                                   
                                <div id="pp"></div> 
                                <div class="tarjeta_blanca">
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <img class="logo_paypal" src="images/logo_paypal.png"  />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-6 col-xs-offset-3 contenedor_info">
                                            <p class="aclaracion_tarjeta">escriba la cantidad que desea cargar</p>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-6 col-xs-offset-3 contenedor_total">
                                            <div class="row">
                                                <div class="col-xs-1 contenedor_pesos">
                                                <p class="dolares">U$D</p>
                                                </div>
                                                <div class="col-xs-10 contenedor_textbox">
                                                    <asp:TextBox ID="TextBox_PayPal" onkeypress="ValidNum()" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-6 col-xs-offset-3 contenedor_boton">
                                            <asp:UpdatePanel ID="UpdatePanel_PayPal" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="Boton_Paypal_Factura" OnClientClick="return validar_textbox_paypal()" OnClick="Boton_Paypal_Factura_Click" class="btn boton_pagofacil" runat="server" ToolTip="presione el botón" Text="Ir a PayPal" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>                                            
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-10 col-xs-offset-1 contenedor_volver">
                                            <p class="volver">Usted sera enviado a la web de PayPal para pagar</p>
                                        </div>
                                    </div>
                                </div>
                            </div>  
                        </div>                    
                    </div>      
                </div>
            </article>   
            <div id="ppm"></div> 
            <article class="fondo_amarillo_movil visible-xs"> <%-- contiene la pantalla chica--%>
                <div class="container">
                    <div class="row">
                        <div class="tarjeta_blanca_movil">
                            <div class="col-xs-12 contenedor_logo_movil">                                
                                <img class="logo_paypal_movil" src="images/logo_paypal.png"  />
                            </div>
                            <div class="col-xs-12 contenedor_dolar_movil">
                                <div class="col-xs-1 dolar_movil">U$D</div>
                                <div class="col-xs-10  contenedor_textbox_movil">
                                    <asp:TextBox ID="TextBox_PayPal_Movil" onkeypress="ValidNum()" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xs-12 contenedor_boton_movil">
                                <asp:UpdatePanel ID="UpdatePanel_PayPal_Movil" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="Boton_Pay_Pal_Movil" OnClientClick="return validar_textbox_paypal_movil()" OnClick="Boton_Paypal_Factura_Click" CssClass="btn btn-default" runat="server" Text="Ir a PayPal" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </article>          
        </section>   
        
         
<%-- *********************************** prestamo ***********************************--%>    

        <section>
            <article class ="hidden-xs"><%-- contiene las pantallas grandes--%>
                <div class="container fondo_blanco" >                                         
                    <div class="row">                        
                        <div class="col-sm-6 col-sm-offset-3 ">   
                            <div id="psos"></div>                         
                            <div class="tarjeta_amarilla">
                                <div class="row">
                                    <div class="col-xs-4">
                                        <img class="logo_prestamo" src="images/logo_prestamo.png"  />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-10 col-xs-offset-1 parrafos">
                                        <p class="primer_parrafo">¿Te quedaste sin crédito?</p>
                                        <p class="segundo_parrafo"> te prestamos y en tu próxima recarga nos devolves el importe sin ningún cargo extra</p> 
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-6 col-xs-offset-3 contenedor_boton">
                                        <asp:UpdatePanel ID="UpdatePanel_PrestamoSOS" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="Boton_Prestamo_SOS" OnClick="Boton_Prestamo_SOS_Click" class="btn" runat="server" ToolTip="presione el botón" Text="Pida su prestamo SOS" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>         
                    </div>  
                </div>                                    
            </article>
            <div id="psosm"></div>
            <article class="visible-xs"> <%-- contiene la pantalla chica--%>
                <div class="container fondo_blanco_movil">
                    <div class="row">
                        <div class="tarjeta_amarilla_movil">
                            <div class="col-xs-12 contenedor_logo_movil">                                
                                <img class="logo_prestamo_movil" src="images/logo_prestamo.png"  />
                            </div>
                            <div class="col-xs-12 contenedor_parrafos_movil">
                                <p class="primer_parrafo_movil">Pedí tu préstamo SOS</p>
                                <p class="segundo_parrafo_movil"> ... lo devolves en tu próxima recarga</p>
                            </div>
                            <div class="col-xs-12 contenedor_boton_movil">
                                <asp:UpdatePanel ID="UpdatePanel_Prestamo_SOS" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="Boton_Prestamo_SOS_Movil" CssClass="btn btn-default" runat="server" OnClick="Boton_Prestamo_SOS_Click" Text="Pedir Préstamo SOS" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </article>
        </section>


<%-- **************** transferencia *****************************************--%>      
        
        <section>
            <article class="fondo_amarillo hidden-xs">  <%-- contiene las pantallas grandes--%>  
                <div class="container">                    
                    <div class="row">     
                        <div class="col-sm-6 col-sm-offset-3 ">     
                            <div id="tb"></div>                       
                            <div class="tarjeta_blanca">
                                <div class="row">
                                    <div class="col-sm-6 logo_banco">
                                        <img class="logo_transferencia" src="images/logo_transferencia.png"  />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-10 contenido_envio">
                                        <p class="envio">Requiere envio del comprobante</p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-10 contenido_datos">
                                        <p class="dato_1">Nombre: Fenicia S.A.</p>
                                        <p class="dato_2">CBU, número: 012234543234567864</p>
                                        <p class="dato_3">Caja de Ahorro en pesos</p>
                                        <p class="dato_4">Banco Citibank número: 52066554412</p>
                                        <p class="dato_5">CUIT: 27-32234678-9</p>
                                    </div>
                                </div>
                            </div>
                        </div>  
                    </div>                    
               </div>
            </article> 
            <div id="tbm"></div>
            <article class="fondo_amarillo_movil visible-xs"> <%-- contiene la pantalla chica--%>
                <div class="container">
                    <div class="row">
                        <div class="tarjeta_blanca_movil">
                            <div class="col-xs-12 contenedor_logo_movil">
                                
                                <img class="logo_transferencia_movil" src="images/logo_transferencia.png"  />
                            </div>
                            <div class="col-xs-12 contenedor_aviso_movil">
                                <p class="envio_movil">Requiere envio del comprobante</p> 
                            </div>
                            <div class="col-xs-12 contenedor_transferencia_movil">
                                <p class="dato_1_movil">Nombre: Fenicia S.A.</p>
                                <p class="dato_2_movil">CBU, número: 012234543234567864</p>
                                <p class="dato_3_movil">Caja de Ahorro en pesos</p>
                                <p class="dato_4_movil">Banco Citibank número: 52066554412</p>
                                <p class="dato_5_movil">CUIT: 27-32234678-9</p>
                            </div>
                        </div>
                    </div>
                </div>
            </article>                        
        </section>    



<%-- ********************************* Pie de Pagina *********************************--%>

        <footer>        
             <div class="container" style="height:50px">              
                <div class="row" style="margin-top:30px">                
                    <div class="col-xs-7">
                        <div class="ubicacion_pie" >
                            <h6 class="main-footer pie_ley">Xelados Tecnology S.A. © 2015 - <a data-toggle="modal" href="#Terminos">Términos y Condiciones</a> - <a data-toggle="modal" href="#Politica">Políticas de Privacidad</a></h6>
                        </div>
                    </div>
                    
                    <div class="col-xs-5">
                        <div class="ubicacion_pie">
                            <h6 class="main-webmaster pie_web" style="float:right; font-weight:bolder">WebMaster Martina Ivana Romero</h6>
                        </div>
                    </div>
                </div>
            </div>        
        </footer>    


<%-- boton de progreso tarjeta  --%>
                             
            <asp:UpdateProgress ID="Progreso_Tarjeta" runat="server">
                <ProgressTemplate>                                
                    <div style="background:url(images/fondo_proceso.png); width: 100%; z-index: 959; top: 0px; left: 0px; position: fixed; height: 100%;">
                        <div class="container">
                            <div class="row">
                                <div class="col-sm-4 col-sm-offset-4 hidden-xs" style="background-color:ghostwhite; border:solid 2px #428BCA; width:340px;height:140px;margin-top:300px;text-align:center">                
                                    <img src="images/ajax-loader.gif" style="margin-top:40px; margin-bottom:20px; width:50% " />
                                    <p style="margin-bottom:20px; color:#428BCA">Este proceso puede tardar unos minutos... </p>
                                </div>
                                <div class="col-xs-12 visible-xs" style="background:rgb(256,256,256); border:solid 2px #428BCA; width:100%;height:140px;margin-top:300px;text-align:center">                
                                    <img src="images/ajax-loader.gif" style="margin-top:40px; margin-bottom:20px" />
                                    <p style="margin-bottom:20px; color:#428BCA">Este proceso puede tardar unos minutos... </p>
                                </div>
                            </div>
                        </div>    
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
       
<%-- final panel progreso --%>  

<%-- panel ejercicios del datalist logueado --%>
        
        <div class="modal fade" id="Cuenta_Digital" >  
            <div class="modal-dialog">                
                <div class="modal-content ">
                    <div class="modal-body">                   
                        <iframe id="Factura_Cuenta_Digital" src ="http" runat ="server" height="800" width="800" ></iframe>
                    </div>                    
                </div>                    
            </div>
        </div>
            
 <%-- panel ejercicios del datalist logueado --%>
        
        <div class="modal fade" id="Mercado" >            
            <div class="modal-dialog">                
                <div class="modal-content ">
                    <div class="modal-body">                        
                        <iframe id="Factura_Mercado" src ="http" runat ="server" height="420" width="640" ></iframe>
                    </div>                    
                </div>                    
            </div>
        </div>           
    </form>

</body>

</html>