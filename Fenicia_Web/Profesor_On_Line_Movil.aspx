<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesor_On_Line_Movil.aspx.cs" Inherits="Fenicia_Web.Profesor_On_Line_Movil" %>

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
<%--<script src="js/bootstrap.min.js"></script>--%>

<!-- CSS correspondiente a Bootstrap 3 -->
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />
<%--<link href="css/bootstrap.min.css" rel="stylesheet" />--%>

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


    <script>

        

        function Aceptar_Compra() {

            var seleccion = confirm("¿Está seguro de realizar la compra? la misma tiene un costo");

            if (!seleccion) {
                alert("NO acepto la compra del producto");
                location.reload(true);
            }

            return seleccion;

        }

        function openModal() {
           
            $('#Ficha').modal('show');


        };

    </script>


<link rel="shortcut icon" type="image/png" href="favicon.icon" />
<link rel="apple-touch-icon" href="img/touch-icon.png"/>


</head>

<body style="background: url(../images/fondo_inicial.png) #0b333f no-repeat center center fixed;">

    <form id="form1" runat="server">

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

        <section>        
            <article>   
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="panel panel-success panel_total"> 
                                <div class="panel-heading encabezado_panel">Mi Profesor Particular</div>
                                <div class="panel-body">            
                                    <div class="row">	
                                        <div class ="col-xs-12 profesor"></div>
                                    </div>
                                    <div class="row ">	
                                        
                                        <div class ="col-xs-12 editor_total_movil" >
                                            <asp:TextBox class="editor_movil" TextMode="MultiLine" placeholder="Envie una foto del ejercicio o escriba el enunciado" style="font-size:12px; font-weight:normal; margin-top:0px" ID="Ingreso_De_Ejercicio" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">	
                                        <div class ="col-xs-12 botonera">

                                            <asp:FileUpload ID="Subir_Adjunto" CssClass="btn btn-default" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class ="col-xs-12 aclaracion" >
                                            <asp:Label ID="Aclaracion_Adjunto" runat="server" > Adjunte una foto de alguna parte del ejercicio que no pudo escribir con nuestro editor o si desea tome una foto del ejercicio y envielo, también puede enviar un archivo de texto con el ejercicio</asp:Label>
                                        </div>
                                    </div>	
                                    <div class="row">
                                        <div class ="col-xs-12 " style="text-align:center" >
                                            <asp:Button type="button" class="btn btn-success boton_resolver" runat="server" onclick="Boton_Abrir_Ficha_Click" Text="Resolver mi ejercicio" />
                                        </div>
                                    </div>  
                                </div>
                            </div>
<%-- paginacion de los extremos correspondiente a siguiente y anterior en la primera y ultima pagina --%>

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

<%-- ************************* paneles de buqueda**** ***********************************--%>


<%-- panel de busqueda --%>
        
    <div class="modal fade busqueda" id="Ficha">            
        <div class="modal-dialog">
            <div class="modal-content ">
                <div class="modal-header busqueda_cabezera">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title titulo_formulario">Buscar ejercicios y explicaciones</h4>
                </div>
                <div class="modal-body">
                        <div class="form-group formulario_presentacion">
                        <asp:Label runat="server" CssClass="sub_etiqueta">Complete los casilleros para una mejor búsqueda </asp:Label> 
                    </div>          
                    <div class="form-group formulario_busqueda primer_item">               
                        <label class="etiqueta_busqueda etiqueta">Tema</label>
                        <asp:TextBox TextMode="SingleLine" maxlength="60" ID="Buscar_x_Tema" class="form-control textbox_busqueda" runat="server"></asp:TextBox>
                        <label class="etiqueta_inferior">ejemplo: <span class="etiqueta_inferior_1">trabajo práctico de matemática números enteros</span><br /><span class="etiqueta_inferior_2">regla de tres simple</span></label>
                    </div>
                    <div class="form-group formulario_busqueda">               
                        <label class="etiqueta_busqueda etiqueta">Materia</label>
                        <asp:TextBox TextMode="SingleLine" maxlength="60" ID="Buscar_x_Materia" class="form-control textbox_busqueda" runat="server"></asp:TextBox>
                        <label class="etiqueta_inferior">ejemplo: <span class="etiqueta_inferior_1">química</span><br /><span class="etiqueta_inferior_2">física</span></label>
                    </div>
                    <div class="form-group formulario_busqueda">
                        <label class="etiqueta_registro etiqueta">Colegio</label>
                        <asp:TextBox TextMode="SingleLine" maxlength="30" ID="Buscar_x_Colegio" class="form-control textbox_busqueda" runat="server"></asp:TextBox>
                        <label class="etiqueta_inferior">ejemplo: <span class="etiqueta_inferior_1">Universidad de Buenos Aires</span><br /><span class="etiqueta_inferior_2">UBA</span></label>
                    </div>
                    <div class="form-group formulario_busqueda">
                        <label class="etiqueta_registro etiqueta">Año en Curso</label>
                        <asp:TextBox TextMode="SingleLine" maxlength="20" ID="Buscar_x_Ano"  class="form-control textbox_busqueda" runat="server"></asp:TextBox> 
                        <label class="etiqueta_inferior">ejemplo: <span class="etiqueta_inferior_1">primer año</span><br /><span class="etiqueta_inferior_2">primero</span></label>                   
                    </div>
                    <div class="form-group formulario_busqueda">
                        <label class="etiqueta_registro etiqueta">Profesor o Catedra</label>
                        <asp:TextBox TextMode="SingleLine" maxlength="30" ID="Buscar_x_Profesor"  class="form-control textbox_busqueda" runat="server"></asp:TextBox>     
                        <label class="etiqueta_inferior">ejemplo: <span class="etiqueta_inferior_1">Gutierrez</span><br /><span class="etiqueta_inferior_2">Fernando Quiroz</span></label>
                    </div>                                
                </div>                    
                <div class="modal-footer pie_busqueda" style="text-align:center">
                    
                    <asp:Button ID="Boton_Enviar_Ejercicio" runat="server" CssClass="btn btn-primary btn-lg boton_busqueda" Text="Realizar la Búsqueda" OnClick="Boton_Enviar_Ejercicio_Click"/> 
                                           
                </div>                    
            </div>               
                   
        </div>  
    


            
    </div>
    </form>
</body>
</html>


