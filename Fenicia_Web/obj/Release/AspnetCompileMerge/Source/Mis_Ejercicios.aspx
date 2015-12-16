<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mis_Ejercicios.aspx.cs" Inherits="Fenicia_Web.Mis_Ejercicios" %>

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
    <link href="css/panel_mis_ejecicios.css" rel="stylesheet" type="text/css" />
    <link href="shadowbox.css" rel="stylesheet" />
    <script src="shadowbox.js"></script>
    
    <script>
        function openModal(variable) {
           
            $('#Ejercicio').modal('show');
            $('#Resultado_Ejercicio').attr("src", variable);   

        };

        function openModalVideo(variable) {

            $('#Film').modal('show');

            $('#Resultado_Video').attr("src", variable);
            
        };

        
        $(document).ready(function () {
           
            $('#Film').on('hidden.bs.modal', function (e) {
                $('#Film iframe').attr("src", $('#Film iframe').attr("src"));
            });
        });



    </script>
</head>


<%--<body oncontextmenu='return false' onkeydown='return false' style="background: url(../images/fondo_inicial.png) #0b333f no-repeat center center fixed;"	>--%>
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


<%-- **************** Pizarra ********************************************--%>
        
            <section >   
                <div class="container">      
                    <div class="panel panel-success"> 
                        <div class="panel-heading">Mis Ejercicios</div>
                        <div class="panel-body cuerpo_ejercicios"> 
                                               
                            <div class="row ">                                                    
                                <asp:UpdatePanel ID="UpdatePanel_DataList" runat="server">
                                    <ContentTemplate>
                                        <asp:DataList ID="DataList_Mis_Ejercicios" runat="server" OnItemCommand="Identificador">
                                            <ItemTemplate>
                                           
                                                <div class="row ">   
                                                    <div class="col-xs-8 col-sm-5 etiqueta_titulo">
                                                        <asp:Label ID="Etiqueta_Titulo" runat="server" Text='<%# Eval("Titulo") %>'></asp:Label>
                                                    </div>
                                                    <div class="col-xs-2 col-sm-1 etiqueta_duracion">
                                                        <asp:Label ID="Etiqueta_Duracion" runat="server" Text='<%# string.Concat(Eval("Dias_Que_Restan_Para_Usar_El_Producto")," día(s)")%>'></asp:Label>
                                                    </div>
                                                    <div class="col-sm-2 boton_1 hidden-xs" >              
                                                        <asp:LinkButton runat="server" OnClientClick="return Aceptar_Compra();" CssClass="btn btn-success ejercicios " CommandName='<%# Eval("ID_Ejercicio")%>' CommandArgument="1"> <%# this.Etiqueta_Ejercicio(Convert.ToInt32(Eval("Ejercicio")))%> </asp:LinkButton>
                                                    </div>   
                                                    <div class="col-sm-2 boton_2 hidden-xs" >
                                                        <asp:LinkButton runat="server" OnClientClick="return Aceptar_Compra();" CssClass="btn btn-warning explicaciones" CommandName='<%# Eval("ID_Ejercicio")%>' CommandArgument="2"> <%# this.Etiqueta_Explicacion(Convert.ToInt32(Eval("Explicacion")))%> </asp:LinkButton>
                                                    </div>   
                                                    <div class="col-sm-2 boton_3 hidden-xs" >
                                                        <asp:LinkButton runat="server" OnClientClick="return Aceptar_Compra();" CssClass="btn btn-default impresiones" CommandName='<%# Eval("ID_Ejercicio")%>' CommandArgument="3"> Imprimir </asp:LinkButton>
                                                    </div>                                                   
                                                </div>
                                            
                                                <div class="row botonera visible-xs">  
                                                    <div class="col-xs-4 boton_1">              
                                                        <asp:LinkButton runat="server" OnClientClick="return Aceptar_Compra();" CssClass="btn btn-success linkButton_ejercicios" CommandName='<%# Eval("ID_Ejercicio")%>' CommandArgument="1"> <%# this.Etiqueta_Ejercicio(Convert.ToInt32(Eval("Ejercicio")))%> </asp:LinkButton>
                                                    </div>   
                                                    <div class="col-xs-4 boton_2">
                                                        <asp:LinkButton runat="server" OnClientClick="return Aceptar_Compra();" CssClass="btn btn-warning linkButton_explicacion" CommandName='<%# Eval("ID_Ejercicio")%>' CommandArgument="2"> <%# this.Etiqueta_Explicacion(Convert.ToInt32(Eval("Explicacion")))%> </asp:LinkButton>
                                                    </div>   
                                                    <div class="col-xs-4 boton_3">
                                                        <asp:LinkButton runat="server" OnClientClick="return Aceptar_Compra();" CssClass="btn btn-default linkButton_impresiones" CommandName='<%# Eval("ID_Ejercicio")%>' CommandArgument="3"> Imprimir </asp:LinkButton>
                                                    </div>
                                                </div>

                                        </ItemTemplate>
                                        </asp:DataList>
                            
                                        <div id="Centros_Paginados" class="paginado" runat="server" visible="false">

                                            <asp:LinkButton ID="Anterior" ForeColor="DimGray" style="text-decoration:none;" OnClick="Anterior_Click" runat="server"><< Anterior &nbsp</asp:LinkButton>
                                            <asp:LinkButton ID="Siguiente" ForeColor="DimGray" OnClick="Siguiente_Click" style="text-decoration:none;" runat="server">&nbsp Siguiente >></asp:LinkButton>

                                        </div>
                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                                               
                        </div>
                 
                <%-- paginacion de los extremos correspondiente a siguiente y anterior en la primera y ultima pagina --%>

                        <div class="container">
                            <div class="row paginado">
                                <div class="col-xs-12 col-sm-4" style="width:96%">
                                    <asp:UpdatePanel ID="UpdatePanel_Botones_Externos_Datalist" runat="server">
                                        <ContentTemplate>
                                            <div id="Extremos_Paginados" runat="server">
                                                <asp:LinkButton ID="Anterior_Ultimo"  Visible="false" ForeColor="DimGray"  runat="server" OnClick="Anterior_Click"><< Anterior &nbsp</asp:LinkButton>
                                                <asp:LinkButton ID="Siguiente_Primero" ForeColor="DimGray" runat="server"  OnClick="Siguiente_Click">&nbsp Siguiente >></asp:LinkButton> 
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </section>
        
<%-- ********************************* Pie de Pagina *********************************--%>

            <footer>        
                <div class="container" style="height:50px">              
                    <div class="row" style="margin-top:30px">                
                        <div class="col-xs-7">
                            <div class="ubicacion_pie" >
                                <h6 class="main-footer pie_ley ">Xelados Tecnology S.A. © 2015 - <a data-toggle="modal" class="pie" href="#Terminos">Términos y Condiciones</a> - <a data-toggle="modal" class="pie" href="#Politica">Políticas de Privacidad</a></h6>
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
        
<%-- ************************* paneles de buqueda**** ***********************************--%> 


<%-- panel de busqueda --%>
        
            <div class="modal fade" id="Ejercicio">            
                <div class="modal-dialog">
                    <div class="modal-content ">
                        <div class="modal-body" >
                            <asp:Image ID="Resultado_Ejercicio" ImageUrl="http" Width="100%" runat="server" />           
                        </div>                    
                    </div>               
                </div>  
            </div>
            
<%-- boton de busqueda progreso --%>

<%-- ************************* paneles de buqueda**** ***********************************--%> 


<%-- panel de busqueda --%>
        
        <div class="modal fade" id="Film">            
            <div class="modal-dialog">
               <div class="modal-content ">
                    <div class="modal-body">
                        <iframe src="https" width="100%" height="360px" id="Resultado_Video" frameborder="0" allowfullscreen runat="server"></iframe>
                    </div>

               </div>               
                    
            </div>  
        </div>
            
<%-- boton de busqueda progreso --%>
    </form>
</body>
</html>
