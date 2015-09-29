<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pagina_Enunciados.aspx.cs" Inherits="Fenicia_Web.Pagina_Enunciados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>Fenicia ¡es aprobar!</title>

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
    <link href="css/encabezado.css" rel="stylesheet" type="text/css" />
<%--encabezado--%>

    <link href="css/cabecera_credito.css" rel="stylesheet" type="text/css" />
<%-- cabecera del panel de credito--%>
   
    <link href="css/pizarra_carrusel.css" rel="stylesheet" type="text/css" />
<%-- pizarra y carrousel--%>
    
    <link href="css/pie.css" rel="stylesheet" type="text/css" />
<%-- pie --%>

    <link href="css/progreso.css" rel="stylesheet" type="text/css" />

<%-- imagenes de progreso --%>
    <link href="css/profesor_online.css" rel="stylesheet" type="text/css"/>

<%-- imagenes de progreso --%>
    <link href="css/paginas_respuestas.css" rel="stylesheet" type="text/css"/>

    <script>

        function Aceptar_Compra() {

            var seleccion = confirm("¿Está seguro de realizar la compra? la misma tiene un costo");

            if (!seleccion) {
                alert("NO acepto la compra del producto");
                location.reload(true);
            }

            return seleccion;

        }

    </script>

</head>

<body style="background: url(../images/fondo_inicial.png) #0b333f no-repeat center center fixed;">

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
     
 <%-- **************** Pizarra con ejercicios ********************************************--%>      
        
            <section>
                <div class ="container">
                    <div class="panel panel-default">
                        <div class="panel-heading">Comprar mi pregunta</div>
                        <div class="panel-body">
                            <div class="col-xs-6" style="text-align:center">
                                <asp:Button ID="Boton_Resolver_Mi_Ejercicio" ToolTip="quiere el ejercicio resuelto" CssClass="btn btn-danger" runat="server" Text="Resolverlo" OnClick="Boton_Resolver_Mi_Ejercicio_Click" OnClientClick="Aceptar_Compra()" />
                            </div>
                            <div class="col-xs-6" style="text-align:center">
                                <asp:Button ID="Boton_Explicar_Mi_Ejercicio" ToolTip="quiere el ejercicio explicado" runat="server" CssClass="btn btn-danger" Text="Explicarlo" OnClick="Boton_Explicar_Mi_Ejercicio_Click" OnClientClick="Aceptar_Compra()"/>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="col-xs-12" style="text-align:center">
                                <asp:Button ID="Buscar_Por_Ficha" runat="server" ToolTip="busque ejercicios similares por tema, colegio, profesor, año, curso" Text="Ejercicios iguales por tema/colegio/profesor" CssClass="btn btn-primary" OnClick="Buscar_Por_Ficha_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div class="panel panel-success">
                        <div class="panel-heading">Ejercicios similares por enunciado</div>
                        <div class="panel-body">
                            <asp:UpdatePanel ID="UpdatePanel_DataList" runat="server">
                                <ContentTemplate>
                                    <asp:DataList ID="Resultado_DataList_Enunciado" CssClass="datalist_resultado" runat="server" OnItemCommand="Identificador">
                                        <ItemTemplate>
                                        
                                            <asp:Image style="width:50%; margin-bottom:5px" ID="Imagen_Enunciado" ImageUrl='<%#"http://www.colegioeba.com/enunciado/Enunciado"+ Eval("ID_Ejercicio") + ".png"%>' runat="server" />
                                            <%--<asp:Image style="width:21.25%; margin-bottom:5px" ID="Imagen_Ficha" ImageUrl='<%#"http://www.colegioeba.com/ficha/Ficha"+ Eval("ID_Ejercicio") + ".png"%>' runat="server" />--%>
                                        
                                            <asp:Button style="width:23%" ID="Boton_Comprar_Ejercicio" OnClientClick="Aceptar_Compra()" ToolTip="quiere el ejercicio resuelto" CssClass="btn btn-success botones" CommandArgument="1" runat="server" CommandName='<%# Eval ("ID_Ejercicio") %>' Text="Ejercicio" />
                                            <asp:Button style="width:23%" ID="Boton_Comprar_Explicacion" OnClientClick="Aceptar_Compra()" ToolTip="quiere el ejercicio explicado" CssClass="btn btn-success botones explicacion"  CommandArgument="2" runat="server" CommandName='<%# Eval ("ID_Ejercicio") %>' Text="Explicación" />
                                                                            
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <div id="Centros_Paginados" class="paginado" runat="server" visible="false">

                                        <asp:LinkButton ID="Anterior" ForeColor="DimGray" style="text-decoration:none;" OnClick="Anterior_Click" runat="server"><< Anterior &nbsp</asp:LinkButton>
                                        <asp:LinkButton ID="Siguiente" ForeColor="DimGray" OnClick="Siguiente_Click" style="text-decoration:none;" runat="server">&nbsp Siguiente >></asp:LinkButton>

                                    </div>                        
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="row paginado">
                            <div class="col-xs-12 col-sm-4" style="width:100%">
                                <asp:UpdatePanel ID="UpdatePanel_Botones_Externos_Datalist" runat="server">
                                    <ContentTemplate>
                                        <div id="Extremos_Paginados" runat="server">
                                            <asp:LinkButton ID="Anterior_Ultimo"  Visible="false" ForeColor="DimGray" style="text-decoration:none;"  runat="server" OnClick="Anterior_Click"><< Anterior &nbsp</asp:LinkButton>
                                            <asp:LinkButton ID="Siguiente_Primero" ForeColor="DimGray" runat="server" style="text-decoration:none;" OnClick="Siguiente_Click">&nbsp Siguiente >></asp:LinkButton> 
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

<%-- paginacion de los extremos correspondiente a siguiente y anterior en la primera y ultima pagina --%>

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
       

    </form>
</body>
</html>
