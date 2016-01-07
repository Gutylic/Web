<%@ Page Language="C#" AutoEventWireup="true" Culture="en-US" UICulture="de" CodeBehind="index.aspx.cs" Inherits="Fenicia_Web.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>Fenicia ¡es aprobar!</title>

    <meta name="viewport" content="width=device-width, initial-scale=1"/>
         
<!-- Jquery -->
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="js/jquery-2.1.1.min.js"></script>
   
<!-- js Bootstrap 3 -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <%--<script src="js/bootstrap.min.js"></script>--%>

<!-- CSS correspondiente a Bootstrap 3 -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />

<!-- CSS con los estilos-->
    <link href="css/encabezado.css" rel="stylesheet" type="text/css"/> <%--encabezado--%>
    <link href="css/pizarra_carrusel.css" rel="stylesheet" type="text/css"/> <%-- pizarra y carrousel--%>
    <link href="css/amarillo_profesores.css" rel="stylesheet" type="text/css"/><%--panel amarillo con los profesores --%>
   






    <link href="css/logueo.css" rel="stylesheet" type="text/css" /> <%-- logueo del usuario --%> 
    <link href="css/logueado.css" rel="stylesheet" type="text/css" /> <%-- panel de logueado --%>  
       



    <link href="css/profesor_online.css" rel="stylesheet" type="text/css" /><%-- profesor-online --%>
    
    <link href="css/buscar.css" rel="stylesheet" type="text/css" /><%--boton de buscar --%>
    
    <link href="css/listado.css" rel="stylesheet" type="text/css" /><%-- resultado datalist --%>
    
    <link href="css/paginado.css" rel="stylesheet" type="text/css"/><%-- paginado datalist --%>
    
    <link href="css/publicidad.css" rel="stylesheet" type="text/css" /><%-- publicidad --%>
    
    <link href="css/quehacemos.css" rel="stylesheet" type="text/css"/><%-- que hacemos --%>
    <link href="css/precios.css" rel="stylesheet" type="text/css"/><%-- precios --%>
    
    
    <link href="css/contacto.css" rel="stylesheet" type="text/css"/><%-- contacto --%>
    <link href="css/pie.css" rel="stylesheet" type="text/css"/><%-- pie --%>
    <link href="css/progreso.css" rel="stylesheet" type="text/css"/><%-- imagenes de progreso --%>
    <link href="css/panel_datalist.css" rel="stylesheet" type="text/css"/><%-- panel no logueado --%>
    <link href="css/registro.css" rel="stylesheet" type="text/css"/><%-- panel de registro --%> 
    <link href="css/panel_de_busqueda.css" rel="stylesheet" type="text/css"/> <%-- panel de busqueda --%>   
     
    <link href="css/panel_de_control.css" rel="stylesheet" type="text/css" />
    <link href="css/consulta_de_saldo.css" rel="stylesheet" />
  
    <link href="css/panel_del_datalist_logueado.css" rel="stylesheet" />
   
<!-- JS script de la pagina-->
    <script src="js/actividad.js" type="text/javascript"></script>
    
<!-- Srcript para llamar al iframe que contiene el enunciado de los ejercicios-->    
    <script type="text/javascript">

        function openModal(variable) {

            var valor = variable.split(','); // separo la variable en dos (iframe,botones)

            $('#Ejercicio').modal('show');
            $('#Enunciados').attr("src", valor[0]);

            if (valor[1] == 2) {
                $("#Boton_Video").css("display", "block");
                $("#Botones_Ejercicio").css("display", "none");
            }
            else {
                $("#Boton_Video").css("display", "none");
                $("#Botones_Ejercicio").css("display", "block");
            }

        };

        function openModal_NoLogueado() {
            $('#NoLogueado').modal('show');
        };

        function openModal_panelControl() {
            $('#Panel_De_Control_De_Usuarios').modal('show');
        };

        function openModal_panelConsulta() {
            $('#Panel_De_Consulta').modal('show');
        };

        function Aceptar_Compra() {

            var seleccion = confirm("¿Está seguro de realizar la compra? la misma tiene un costo");

            if (!seleccion) {
                alert("NO acepto la compra del producto");
                location.reload(true);
            }

            return seleccion;

        }

    </script>

<link rel="shortcut icon" type="image/png" href="favicon.icon" />
<link rel="apple-touch-icon" href="img/touch-icon.png"/>

    
</head>

<body>

    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div itemscope itemtype="http://www.data-vocabulary.org/Product">

            
<%-- **************** Aca comienza la cabecera de la pagina ****************************--%>
    
        <header id="main-header"> <%-- estilos del encabezado en encabezado --%> 
            <div class="container">
                <div class="row">
                    <div class="col-xs-10 col-sm-3">
                        <h1 class="logo_fenicia"><a href="#" class="scroll-top"><span itemprop="brand">Fenicia</span><span class="es_aprobar">¡es aprobar!</span></a></h1>                        
                    </div>		
                    <div class="col-xs-2 col-sm-9">
                        <ul class="nav nav-pills hidden-xs" id="main-menu" >
				            <li><a href="#" data-id="profesores" class="scroll-link opcion_profesores scroll"><span class="profesores" itemprop="category" >Profesores Particulares</span><span class="linea_inferior_encabezado"> ahora estamos en linea</span></a></li>
                            <li><a href="#" data-id="que_hacemos" class="scroll-link scroll">¿Que hacemos?</a></li>
                            <li><a href="#" data-id="contactenos" class="scroll-link scroll">Contactenos</a></li>
			               <%-- <li><a href="#" class="icono_movil scroll"><span class="glyphicon glyphicon-phone linea_inferior_encabezado"></span>Version Movil</a></li>--%>
			            </ul>
                        <a href="#" id="mobile-menu-button" title="menú movil" class="btn btn-xs visible-xs "><span class="glyphicon glyphicon-align-justify"></span></a>
                    </div>            
                </div>
            </div>     
            <div class="visible-xs">        
                <ul id="mobile-main-menu" >
				    <li><a href="#" data-id="profesor_movil" class="scroll-link scroll-movil" >Profesores Particulares<span> ahora estamos en linea</span></a></li>
                    <li><a href="#" data-id="que_hacemos_movil" class="scroll-link scroll-movil" >¿Que hacemos?</a></li>
                    <li><a href="#" data-id="contactenos_movil" class="scroll-link scroll-movil" >Contactenos</a></li>
			    </ul>
            </div>
        </header>        <%-- fin del estilo del encabezado --%> 


<%-- **************** Pizarra con carrousel ********************************************--%>


        <section id="top">     
               
            <article class="fondo_pizarra">                
                <div class="container">	                
                    <div class="row ">		                
                        <div class="col-xs-12 centrado_carrousel">			                
                            <div class="carousel slide hidden-xs" id="carousel-930919">				                
				                <div class="carousel-inner">
					                <div class="item active">
						                <img alt="" src="images/fondo-carrusel.png" />
						                <div class="carousel-caption posicion_carrusel">
							                <h2 class="titulos_carrusel">
								                Profesores particulares a toda hora, para enseñarte
							                </h2>
							            </div>
					                </div>
					                <div class="item">
						                <img alt="" src="images/fondo-carrusel.png" />
						                <div class="carousel-caption posicion_carrusel">
							                <h2 class="titulos_carrusel">
								                Registrate y consulta tus dudas las 24 horas
							                </h2>
						                </div>
					                </div>
					                <div class="item">
						                <img alt="" src="images/fondo-carrusel.png" />
						                <div class="carousel-caption posicion_carrusel">
							                <h2 class="titulos_carrusel">
								                Resolvemos y explicamos solo lo que vos nos pedis... 
							                </h2>							               
                                        </div>
					                </div>
                                    <div class="item">
						                <img alt="" src="images/fondo-carrusel.png" />
						                <div class="carousel-caption posicion_carrusel">
							                <h2 class="titulos_carrusel">
								                Todas las respuestas y explicaciones al instante
							                </h2>							                
						                </div>
					                </div>
					                <div class="item">
						                <img alt="" src="images/fondo-carrusel.png" />
						                <div class="carousel-caption posicion_carrusel">
							                <h2 class="titulos_carrusel">
								                "Nosotros nos adaptmos a tus necesidades y no vos a nosotros"
							                </h2>
						                </div>
					                </div>
					                <div class="item">
						                <img alt="" src="images/fondo-carrusel.png" />
						                <div class="carousel-caption posicion_carrusel">
							                <h2 class="titulos_carrusel">
								                Vos determiná donde, cuando y cuanto te explicamos	
							                </h2>							                
						                </div>
					                </div>				              
                                </div>                                 
                                <a class="left carousel-control" href="#carousel-930919" data-slide="prev">
                                    <span class="glyphicon glyphicon-chevron-left"></span>
                                </a>                                                                
                                <a class="right carousel-control" href="#carousel-930919" data-slide="next">
                                    <span class="glyphicon glyphicon-chevron-right"></span>
                                </a>
			                </div>
		                </div>	                
                    </div>
                    <div class="visible-xs">                     
				        <div class="col-xs-12 carrusel_movil">
                            <div>
                                <p>
                                    Profesores Particulares las 24 horas<br /> en tu celular o en tu PC
                                </p>
                                <p class="subcarrusel_movil">
                                    consultanos tus dudas y nosostros te la respondemos con videos o resolviendote los ejercicios. <br />"Nosotros nos adaptamos a vos y no vos a nosotros"
                                </p>
                            </div>                      			        
                        </div>              
                    </div> 
                          
                </div>  
            </article>          <%-- fin del carrusel --%>
  

<%-- **************** pagina de color amarillo *****************************************--%>      
        

            <article class="fondo_amarillo">          
                <div class="container">                    
                    <div class="row">                        
                        <div class="hidden-xs">                        
                            <div class="col-sm-2">                            
                                <div class="fondo_profesor">    
                                    <h3 class="en_linea">En linea</h3>
                                    <div class="centrados_datos_del_profesor">
                                        <img src="images/profesor_1.png" alt="Ricardo Ramirez" class="img-circle foto_profesor"/>
                                        <h4 class="materia"><span itemprop="name">Matemática</span></h4>
                                        <h5>Ricardo Ramirez</h5>
                                        <h6>Consultalo sobre:</h6>
                                        <ul class="lista_de_materias" >
                                            <li>Álgebra</li>
                                            <li>Estadística</li>
                                            <li>Análisis Matemático</li>
                                            <li>Geometría</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>                         
                            <div class="col-sm-2">
                                <div class="fondo_profesor">
                                    <h3 class="en_linea">En linea</h3>
                                    <div class="centrados_datos_del_profesor">
                                        <img alt="Ramón Fonseca" src="images/profesor_2.png" class="img-circle foto_profesor" />
                                        <h4 class="materia">Física</h4>
                                        <h5>Ramón Fonseca</h5>
                                        <h6>Consultalo sobre:</h6>
                                        <ul class="lista_de_materias" >
                                            <li>Fisicoquímica</li>
                                            <li>Biofísica</li>
                                            <li><span itemprop="name">Química</span></li>
                                            <li>Merceología</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>                        
                            <div class="col-sm-2">
                                <div class="fondo_profesor">
                                    <h3 class="en_linea">En linea</h3>
                                    <div class="centrados_datos_del_profesor">
                                        <img src="images/profesor_3.png" alt="Daniela Suarez" class="img-circle foto_profesor" />
                                        <h4 class="materia">Bíologia</h4>
                                        <h5>Daniela Suarez</h5>
                                        <h6>Consultalo sobre:</h6>
                                        <ul class="lista_de_materias" >
                                            <li>Biología Celular</li>
                                            <li>Ciencias Naturales</li>
                                            <li>Bioquímica</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>                        
                            <div class="col-sm-2">
                                <div class="fondo_profesor">
                                    <h3 class="en_linea">En linea</h3>
                                    <div class="centrados_datos_del_profesor">
                                        <img src="images/profesor_2.png" alt="Ramón Fonseca" class="img-circle foto_profesor" />
                                        <h4 class="materia">Química</h4>
                                        <h5>Ramón Fonseca</h5>
                                        <h6>Consultalo sobre:</h6>
                                        <ul class="lista_de_materias" >
                                            <li>Fisicoquímica</li>
                                            <li>Biofísica</li>
                                            <li><span itemprop="name">Física</span></li>
                                            <li>Merceología</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>                        
                            <div class="col-sm-2">
                                <div class="fondo_profesor">
                                    <h3 class="en_linea">En linea</h3>
                                    <div class="centrados_datos_del_profesor">
                                        <img src="images/profesor_4.png" alt="Ivana Rodriguez" class="img-circle foto_profesor"  />
                                        <h4 class="materia">Computación</h4>
                                        <h5>Ivana Rodriguez</h5>
                                        <h6>Consultalo sobre:</h6>
                                        <ul class="lista_de_materias" >
                                            <li>Base de Datos</li>
                                            <li>Programación</li>
                                            <li>Lógica</li>
                                            <li>Office y mas..</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>                        
                            <div class="col-sm-2">
                                <div class="fondo_profesor">
                                    <h3 class="en_linea">En linea</h3>
                                    <div class="centrados_datos_del_profesor">
                                        <img src="images/profesor_3.png" alt="Daniela Suarez" class="img-circle foto_profesor" />
                                        <h4 class="materia_celular">Bíologia Celular</h4>
                                        <h5>Daniela Suarez</h5>
                                        <h6 class="consultalo">Consultalo sobre:</h6>
                                        <ul class="lista_de_materias" >
                                            <li>Biología</li>
                                            <li>Ciencias Naturales</li>
                                            <li>Bioquímica</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>                    
                    </div> 
                    <div class="row">
                        <div class="visible-xs">
                            <div class="col-xs-12 ">
                                <div class="fondo_profesor fondo_profesor_movil">
                                    <p class="parrafo_de_servicios_movil">En línea las siguientes materias:</p>
                                    <ul class="lista_materias_movil">
                                        <li>Matemática</li>
                                        <li>Física</li>
                                        <li>Química</li>
                                        <li>Biología</li>
                                        <li>Computación</li>
                                        <li>y otras materias más...</li>
                                    </ul>                        
                                </div>
                            </div>
                        </div>
                    </div>
               </div>
                
                <div class="container ">                    
                    <div class="hidden-xs">                    
                        <div class="row">                        
                            <div class="col-sm-4">
                                <div class="columna_amarilla">
                                    <p class="parrafo_de_servicios">En nuestra pagina web hay gran cantidad de ejercicios resueltos para ser consultados... <br /><br /><br /><br /> </p>
                                    <a href="#profesores" class="ir" >Ir a resolver ejercicios
                                        <span class="glyphicon glyphicon-arrow-right"></span>
                                    </a>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="columna_amarilla">
                                    <p class="parrafo_de_servicios">Envienos sus trabajos prácticos que seran resueltos rapidamente, y le seran enviado a su celular o PC <br /><br /><br /><br /></p>
                                    <a href="#profesores" class="ir" >Preguntele a nuestros docentes
                                        <span class="glyphicon glyphicon-arrow-right"></span>
                                    </a>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="columna_amarilla">
                                    <p class="parrafo_de_servicios">Puede pedirnos que le realizemos la tarea de la clase o que le expliquemos algún tema... <br /><br /><br /><br /></p>
                                    <a href="#profesores" class="ir" >Ir a las explicaciones en videos
                                        <span class="glyphicon glyphicon-arrow-right"></span>
                                    </a>
                                </div>
                            </div>                                            
                        </div>
                    
                    </div>                    
                    <div class="visible-xs">                        
                        <div class="col-xs-12 columna_amarilla_movil">
                            <p class="parrafo_movil">* Si estudiando se te presentan dudas, no importa la hora consultános...<br />
                                * Si tenes que entregar la tarea para el colegio o la uniersidad, consultános...<br />
                                * Faltaste a clases y necesita que te expliquen lo aprendido, consultános...</p>
                            <a href="#profesor_movil" data-id="profesores" class="ir_movil">Ir a resolver ejercicios 
                                <span class="glyphicon glyphicon-arrow-right"></span>
                            </a>
                        </div>
                    </div>               
                </div>
                <div id="profesores"></div><%-- llamada del encabezado a profesores --%>  
            </article>  <%-- fin de pizarra amarilla --%>                   
        </section>        
        <hr />

<%-- **************** pagina del profesor particular ***********************************--%>    

        <section>
            <article>
                <div class="container">
                    <div class="row">
                        

<%-- ************************* parte para loguearse ***********************************--%>                            
                           
                        <div class="col-xs-12 col-sm-4 col-sm-push-8">
                            <asp:Panel ID="Panel_De_Logueo" runat="server" DefaultButton="Boton_Iniciar_Session">
                                <asp:UpdatePanel ID="Panel_Asociado_A_Inicio_De_Session" runat="server" UpdateMode="Conditional">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="Boton_Iniciar_Session" />
                                    </Triggers>
                                    <ContentTemplate>


<%-- panel antes del loguearse --%>

                                        <div runat="server" id="Panel_Inicial" > 
                                            <div class="panel-info sector_logueo">
                                                <div class="panel-heading titulo_panel_logueo">
                                                    <h3 class="panel_title ingrese_como_usuario">Ingrese como usuario</h3>  
                                                </div>  
                                                                               
                                                <div class="panel-body">    
                                                    <h6 class="usuario_inicio">Usuario</h6>
                                                    <asp:TextBox ID="Usuario_Inicio" CssClass="form-control caja_de_texto js_session_1" MaxLength="10" runat="server" ></asp:TextBox>
                                                    <h6 class="password_inicio">Contraseña</h6>
                                                    <asp:TextBox ID="Password_Inicio" CssClass="form-control caja_de_texto js_session_2" MaxLength="10" runat="server" onKeyPress="mayuscula_activado(event)" TextMode="Password"></asp:TextBox>      
                                                    <div class="row">                                        
                                                        <div class="col-xs-12">
                                                            <a href="Olvido_Contrasena.aspx" target="_blank" class="olvido_contrasena">¿Olvido su contraseña?</a>
                                                        </div>                                   
                                                    </div>
                                                    <div class="row">                                       
                                                        <div class="col-xs-9 col-sm-6">
                                                            <asp:CheckBox ID="Mantener_Session" runat="server"/> 
                                                            <h6 class="recordarme">Recordarme</h6>                               
                                                        </div>                                                        
                                                        <div class="col-xs-3 col-sm-6">
                                                            <asp:UpdatePanel ID="Progreso_Boton_Iniciar_Session" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Button ID="Boton_Iniciar_Session" runat="server" CssClass="btn btn-primary boton_iniciar_session" Text="Iniciar Sesión" OnClientClick="return validar_logueo()" OnClick="Boton_Iniciar_Session_Click"/>
                                                              </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>                                                     
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-xs-12 ">                                            
                                                            <div class="registrese">  
                                                                <hr class="linea_de_separacion_boton_registrese"/>
                                                                <asp:Button data-toggle="modal" href="#Registro" OnclientClick="limpiar_registro()" class="btn btn-success boton_registrese" ID="Boton_Registrese" OnClick="Boton_Registrese_Click" runat="server" Text="Regístrese como usuario" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>                                            
                                        </div>
                                        <div runat="server" id="Panel_Logueado" visible="false" >
                                            <div class="panel-info sector_logueo">
                                                <div class="panel-heading titulo_panel_logueo" >
                                                    <table class="encabezado">
                                                        <tr>
                                                            <td><asp:Label ID="Usuario_Logueado" runat="server" ></asp:Label></td>
                                                            <td><asp:LinkButton ID="Cerrar_Sesion" runat="server" OnClientClick="session_expirada()" OnClick="Cerrar_Sesion_Click">X</asp:LinkButton></td>
                                                        </tr>
                                                    </table>   
                                                </div>


<%-- panel de logueado --%>
                                                
                                                <div class="panel-body padding_mayor hidden-xs">   
                                                    
                                                    <div class="row panel_pedagogico">
                                                        <div class="col-xs-2">
                                                            <span class="glyphicon glyphicon-folder-open"></span>
                                                        </div>
                                                        <div class="col-xs-10">
                                                            <h1 class="titulo_panel_pedagogico">Paneles Pedagogicos</h1>
                                                        </div>                                                    
                                                    </div>

                                                    <div class="row renglon_1" >
                                                        <div class="col-xs-2">
                                                            <asp:LinkButton runat="server" CssClass="glyphicon glyphicon-pencil icono_celeste_claro" OnClick="Mis_Ejercicios_Click" ToolTip="Presione para ver sus ejercicios"></asp:LinkButton>
                                                        </div>
                                                        <div class="col-xs-8 ubicacion_nombre">
                                                            <asp:LinkButton ID="Mis_Ejercicios" runat="server" ToolTip="Presione para ver sus ejercicios" OnClick="Mis_Ejercicios_Click"> Mis ejercicios</asp:LinkButton>
                                                        </div>    
                                                        <div class="col-xs-1 celeste_claro">
                                                            
                                                        </div>
                                                    </div>
                                                    
                                                    <div class="row renglon_2" >
                                                        <div class="col-xs-2">
                                                            <asp:LinkButton runat="server" CssClass="glyphicon glyphicon-file icono_celeste_oscuro" OnClick="Mis_Explicaciones_Click" ToolTip="Presione para ver sus vídeos"></asp:LinkButton>
                                                            
                                                        </div>
                                                        <div class="col-xs-8 ubicacion_nombre">
                                                            <asp:LinkButton ID="Mis_Explicaciones" runat="server" OnClick="Mis_Explicaciones_Click" ToolTip="Presione para ver sus vídeos"> Mis explicaciones</asp:LinkButton>
                                                        </div>    
                                                        <div class="col-xs-1 celeste_oscuro">
                                                            
                                                        </div>
                                                    </div>
                                                            
                                                    <div class="row panel_pedagogico">
                                                        <div class="col-xs-2">
                                                            <span class="glyphicon glyphicon-folder-open"></span>
                                                        </div>
                                                        <div class="col-xs-10">
                                                            <h1 class="titulo_panel_pedagogico">Paneles Administrativos</h1>
                                                        </div>                                                    
                                                    </div>

                                                    <div class="row renglon_3" >
                                                        <div class="col-xs-2">
                                                            <asp:LinkButton OnClick="Panel_De_Control_Click" runat="server" CssClass="glyphicon glyphicon-user icono_rojo_claro" ToolTip="Presione para sus datos"></asp:LinkButton>
                                                            
                                                        </div>
                                                        <div class="col-xs-8 ubicacion_nombre">
                                                            <asp:LinkButton OnClick="Panel_De_Control_Click" runat="server" ID="Panel_De_Control" ToolTip="Presione para ver sus datos"> Mis datos</asp:LinkButton></td>
                                                        </div>    
                                                        <div class="col-xs-1 rojo_claro">
                                                            
                                                        </div>
                                                    </div>
                                                    
                                                    <div class="row renglon_4" >
                                                        <div class="col-xs-2">
                                                            <asp:LinkButton runat="server" CssClass="glyphicon glyphicon-list-alt icono_rojo_medio" OnClick="Panel_De_Movimientos_Click" ToolTip="Presione para consultar su saldo"></asp:LinkButton>
                                                        </div>
                                                        <div class="col-xs-8 ubicacion_nombre">
                                                            <asp:LinkButton ID="Panel_De_Movimiento" OnClick="Panel_De_Movimientos_Click" runat="server" ToolTip="Presione para consultar su saldo"> Mi Saldo</asp:LinkButton>
                                                        </div>    
                                                        <div class="col-xs-1 rojo_medio">
                                                            
                                                        </div>
                                                    </div> 
                                                    
                                                    <div class="row renglon_5" >
                                                        <div class="col-xs-2">
                                                            <asp:LinkButton runat="server" CssClass="glyphicon glyphicon-usd icono_rojo_oscuro" ToolTip="Presione para cargar crédito" OnClick="Panel_De_Credito_Click"></asp:LinkButton>
                                                        </div>
                                                        <div class="col-xs-8 ubicacion_nombre">
                                                            <asp:LinkButton ID="Panel_De_Credito" runat="server" ToolTip="Presione para cargar crédito" OnClick="Panel_De_Credito_Click">Carga de Crédito</asp:LinkButton>
                                                        </div>    
                                                        <div class="col-xs-1 rojo_oscuro">
                                                            
                                                        </div>
                                                    </div>  
                                                   
                                             
                                                </div>
<%-- parte movil --%>
                                                <div class="panel-body padding_mayor visible-xs" >
                                                    <table class="contenido_tablas_logueado_movil" style="width:100%" >
                                                        <tr>
                                                           
                                                                <div class=" col-xs-10 ejercicios_movil">

                                                                    <asp:LinkButton ID="Lapiz_Movil" runat="server" CssClass="glyphicon glyphicon-pencil icono_celeste_oscuro_xs" ToolTip="Presione para ver sus ejercicios" OnClick="Mis_Ejercicios_Click"></asp:LinkButton>                                                            
                                                                    <asp:LinkButton ID="Ejercicios_Movil" runat="server" ToolTip="Presione para ver sus ejercicios" OnClick="Mis_Ejercicios_Click"> Mis ejercicios</asp:LinkButton>

                                                                </div>
                                                                <div class=" col-xs-2">

                                                                    <div class="celeste_claro_xs"></div>

                                                                </div>
                                                                
                                                                
                                                            
                                                        </tr>
                                                        <tr>
                                                            
                                                                <div class=" col-xs-10 ejercicios_movil">

                                                                    <asp:LinkButton ID="Hojita_Movil" runat="server" CssClass="glyphicon glyphicon-file icono_celeste_oscuro_xs" OnClick="Mis_Explicaciones_Click" ToolTip="Presione para ver sus vídeos"></asp:LinkButton>                                                           
                                                                    <asp:LinkButton ID="Explicaciones_Movil" runat="server" OnClick="Mis_Explicaciones_Click" ToolTip="Presione para ver sus vídeos"> Mis explicaciones</asp:LinkButton>
                                                                
                                                                </div>
                                                                <div class=" col-xs-2">

                                                                    <div class="celeste_oscuro_xs"></div>

                                                                </div>

                                                        </tr>
                                                        <tr>

                                                            <div class=" col-xs-10 ejercicios_movil">

                                                                <asp:LinkButton OnClick="Panel_De_Control_Click" runat="server" ID="Perfil_Movil" CssClass="glyphicon glyphicon-user icono_rojo_claro_xs" ToolTip="Presione para sus datos"></asp:LinkButton>
                                                                <asp:LinkButton OnClick="Panel_De_Control_Click" runat="server" ID="Datos_Movil" ToolTip="Presione para ver sus datos"> Mis datos</asp:LinkButton>
                                                                                                                                
                                                            </div>
                                                            <div class=" col-xs-2">

                                                                    <div class="rojo_claro_xs"></div>

                                                            </div>

                                                        </tr>
                                                        <tr>

                                                            <div class=" col-xs-10 ejercicios_movil">

                                                                <asp:LinkButton OnClick="Panel_De_Movimientos_Click" runat="server" ID="Agendita_Movil" CssClass="glyphicon glyphicon-list-alt icono_rojo_medio_xs" ToolTip="Presione para sus datos"></asp:LinkButton>
                                                                <asp:LinkButton OnClick="Panel_De_Movimientos_Click" runat="server" ID="Mi_Saldo_Movil" ToolTip="Presione para ver sus datos"> Mi saldo</asp:LinkButton>
                                                                                                                                
                                                            </div>
                                                            <div class=" col-xs-2">

                                                                <div class="rojo_medio_xs"></div>

                                                            </div>

                                                        </tr>
                                                        <tr>

                                                            <div class=" col-xs-10 ejercicios_movil">
                                                                
                                                                <asp:LinkButton ID="Dinero_Movil" runat="server" CssClass="glyphicon glyphicon-usd icono_rojo_oscuro_xs" ToolTip="Presione para cargar crédito" OnClick="Panel_De_Credito_Click"></asp:LinkButton>
                                                                <asp:LinkButton ID="Credito_Movil" runat="server" ToolTip="Presione para cargar crédito" OnClick="Panel_De_Credito_Click">Carga de crédito</asp:LinkButton>                                                                
                                                                                                                                
                                                            </div>
                                                            <div class=" col-xs-2">

                                                                <div class="rojo_oscuro_xs"></div>

                                                            </div>

                                                        </tr>

                                                        
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                             </asp:Panel>             
                        </div>  <%-- final del logueado--%>


<%-- ************************* profesor on line ***************************************--%> 
                        
                        <div class="col-sm-4 hidden-xs">
                            <div class="thumbnail fondo_pizarra">
                                <asp:UpdatePanel ID="UpdatePanel_Profesor_On_Line" runat="server">  
                                    <ContentTemplate>
                                        <asp:ImageButton ID="Imagen_Pizarra"  class="imagen_pizarra"  ToolTip="Profesor Particular" ImageUrl="~/images/pizarra.png" runat="server" OnClick="Boton_Profesor_On_Line_Click" style="outline:none"/> 
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>  
                        </div> 
                        
                          
<%-- parte movil --%>
                        <div id="profesor_movil"></div>                       
                        <div class="col-xs-12 visible-xs"> 
                            <asp:UpdatePanel ID="UpdatePanel_Profesor_On_Line_Movil" runat="server"> 
                                <ContentTemplate>
                                    <div class="thumbnail fondo_pizarra_movil">
                                        <asp:ImageButton ID="Imagen_Pizarra_Movil" Height="100%" Width="263px" class="imagen_pizarra_movil" runat="server" ImageUrl="~/images/pizarra_movil.png" OnClick="Boton_Profesor_On_Line_Click" />
                                    </div> 
                                </ContentTemplate>
                            </asp:UpdatePanel>                                               
                        </div>


<%-- ************************* Busqueda y Resultados***************************************--%> 

                         
<%-- ************ Busqueda *********** --%>

                        <div class="col-xs-12 col-sm-4 col-sm-pull-8"> 
                            <div class="buscar_en_datalist_inicial" >   
                                <a data-toggle="modal" href="#Busqueda" class="btn btn-primary boton_busqueda">Presione aquí para buscar</a>
                            </div>                            
                        </div>
                    </div>
                </div>


<%--************Resultado de la busqueda ******--%>                
                                                  
                <div class="container">                  
                    <div class="row">                       
                        <div class="col-xs-12 col-sm-4">
                            <div class="listado_datalist">
                                <asp:Image ID="Imagen_Ayuda" runat="server" ImageUrl="~/images/logo_ayuda.gif" />
                                <asp:Image ID="Imagen_Importante" runat="server" ImageUrl="~/images/logo_importante.gif" />
                                <h3 class="como_usar_el_sistema">¿Como usar el sistema?</h3>
                            </div>
                            <div class="panel panel-info datalist_inicial_de_ejercicios">
                                <div class="panel-heading titulo_datalist_De_ejercicios">
                                    <h3 class="panel-title explicaciones_en_videos_y_ejercicios">Explicaciones en vídeos y ejercicios</h3>
                                </div>  
                                <div class="panel-body"> 
                                    <asp:UpdatePanel ID="UpdatePanel_Resultados_Del_Datalist" runat="server">  
                                        <ContentTemplate>          
                                            <asp:DataList ID="DataList_De_Resultados" runat="server" OnItemDataBound="Logos_Asociados" OnItemCommand="Identificador">
                                                <ItemTemplate>
                                                    <table class="tabla_datalist">
                                                        <tr>
                                                            <td class="columna_1_datalist_inicial" >
                                                                <asp:Image ID="Imagen_Logos" CssClass="logo" runat="server" />
                                                            </td>
                                                            <td class="columna_2_datalist_inicial">
                                                                <asp:LinkButton runat="server" ToolTip="presione para mirar" CssClass="link_datalist" ID="Titulos_De_Productos" CommandName='<%# Eval ("ID_Ejercicio") %>'> <%# Eval ("Titulo") %> </asp:LinkButton>
                                                            </td>
                                                        </tr> 
                                                    </table>
                                                </ItemTemplate> 
                                            </asp:DataList>


<%--************Paginado ******--%>   


 <%--**** paginacion central de siguiente y anterior que esta en las paginas del medio **--%>

                                            <div id="Centros_Paginados" runat="server" visible="false">   
                                                <asp:LinkButton ID="Anterior" ForeColor="DimGray" runat="server" OnClick="Anterior_Click" style="text-decoration:none; "><< Anterior &nbsp</asp:LinkButton>
                                                <asp:LinkButton ID="Siguiente" ForeColor="DimGray" runat="server" OnClick="Siguiente_Click" style="text-decoration:none; " >&nbsp Siguiente >></asp:LinkButton>
                                            </div> 
                                       </ContentTemplate>
                                    </asp:UpdatePanel>                                     
                                </div>
                            </div>                        
                        </div>
              

<%--*************************************Publicidad 1 y 2 ********************************--%>                                                                                                     
                        <div class="hidden-xs">                        
                            <div class="col-sm-4">
                                 <img class="publicidad1" src="images/publicidad_1.png" alt="publicidad 1" />
                            </div>                        
                            <div class="col-sm-4">
                                <img class="publicidad2" src="images/publicidad_2.png" alt="publicidad 2" />
                            </div>
                        </div>
                    </div>
                </div>

                <div id="que_hacemos"></div>

                
<%--*************************************Publicidad 3 *********** ***********************--%>  
                
                <div class="container hidden-xs">
                    <div class="row">
                        <div class="col-xs-8 col-xs-offset-4">
                            <img class="publicidad3" src="images/publicidad_3.png" alt="publicidad 3" /> 
                        </div>
                    </div>
                </div>  


<%-- paginacion de los extremos correspondiente a siguiente y anterior en la primera y ultima pagina --%>

                <div class="container">
                    <div class="row">
                        <div class="col-xs-12 col-sm-4">
                            <asp:UpdatePanel ID="UpdatePanel_Botones_Externos_Datalist" runat="server">
                                <ContentTemplate>
                                    <div id="Extremos_Paginados" runat="server">
                                        <asp:LinkButton ID="Anterior_Ultimo" Visible="false" ForeColor="DimGray" runat="server" OnClick="Anterior_Click"><< Anterior &nbsp</asp:LinkButton>
                                        <asp:LinkButton ID="Siguiente_Primero" ForeColor="DimGray" runat="server" OnClick="Siguiente_Click">&nbsp Siguiente >></asp:LinkButton> 
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <hr/>            
            </article>      
        </section> 

<%-- *********************************** que hacemos ***********************************--%>    

        <section>
            <article>
                <div class="container">
                    <div class ="hidden-xs">                        
                        <div class="row">                        
                            <div class="col-xs-4"> 
                                <div class="cuadro_rosa_primero"> 
                                    <h4 class="titulo_rosa">¿Debes entregar un trabajo práctico?</h4>                                    
                                    <h4 class="cuadro_azul_primero">Nosotros hacemos el trabajo por vos</h4>
                                </div>
                            </div>
                            <div class="col-xs-4"> 
                                <div class="cuadro_rosa_segundo"> 
                                    <h4 class="titulo_rosa">¿Tenes pequeñas dudas en algunos ejercicios y temas de teoría?</h4>
                                    <h4 class="cuadro_azul_segundo" >Nosotros te enseñamos solo lo que vos necesitas</h4>
                                </div>
                            </div>                                                   
                            <div class="col-xs-4"> 
                                <div class="fondo_gris">
                                    <h4 class="parrafo_principal_de_servicios">Somos un sistema de profesores particulares, que atendemos las 24 horas del día,<span itemprop="description">preparamos estudiantes</span> en matemática, física, química, biología y computación</h4>
                                </div>
                            </div>                        
                        </div>                          
                        <div class="row">                        
                            <div class="col-xs-4">                             
                                <div class="cuadro_rosa_tercero"> 
                                     <h4 class="titulo_rosa">¿Estas estudiando para un examen?</h4>                                     
                                     <h4 class="cuadro_azul_tercero">Nosotros te preparamos</h4>
                                </div>
                            </div>
                            <div class="col-xs-4"> 
                                <div class="cuadro_rosa_cuarto"> 
                                    <h4 class="titulo_rosa">¿Estudias en las noche y no conseguís un docente?</h4>
                                    <h4 class="cuadro_azul_cuarto">Nosotros te explicamos a la hora que quieras</h4>
                                </div>
                            </div>

                            <div class="col-xs-4">
                                <div class="fondo_oscuro">
                                    <h5 class="parrafo_fondo_oscuro" >Envianos los enunciados de tus ejercicio por foto o por medio de nuestro editor <br />lo resolvemos al instante y te lo enviamos a tu PC y si deseas a tu celular, no cobramos ningún cargo extra por el envio al teléfono</h5>
                                </div>
                            </div>                                            
                        </div>
                       
                        <div class="row">                        
                            <div class="col-xs-1">
                                <div class="icono_que_hacemos">
                                    <img src="images/icono_quehacemos.png" />
                                </div>
                            </div>                            
                            <div class="col-xs-11">
                                <h2 class="titulo_nosotros">Nosotros nos adaptamos a tus necesicidades y no vos a nosotros</h2>
                            </div>                         
                        </div>
                    </div>
                </div>
                             
                <div class="visible-xs">                        
                   <div class="fondo_gris">                            
                        <div class="container">                                
                            <div class="row">                            
                                <div class="col-xs-12">
                                    <h4 class="titulo_principal">Nosotros estamos para <span id="que_hacemos_movil"> </span>adaptarnos a tus necesidades y no vos a nosotros"</h4><br /> 
                                    <h4 class="subtitulo_principal"> Somos un sistema de profesores particulares, que atendemos las 24 horas del día. Envianos una foto del enunciado del ejercicio y te damos la respuesta al celular.</h4>
                                </div>
                            </div>
                        </div>
                   </div>
                </div>                                
            </article>


<%-- ******************************* precios ***************************************--%>

            
            <article class="fondo_precio">
                <div class="container">
                    <div class="hidden-xs">                   
                         <div class="row">
                             <div class="col-xs-4">
                                 <div class="precio_1">
                                    <img src="images/oferta_1.png" alt="Precios de cada ejercicio" class="img-circle circulos_precio"/>
                                </div> 
                            </div> 
                        </div> 
                        <div class="row">
                            <div class="col-xs-4">                                
                                <div class="precio_2y3" >
                                    <img src="images/oferta_2.png" alt="Precios de cada explicaciones" class="img-circle circulos_precio"/>
                                    <img src="images/oferta_3.png" alt="Precios por paquetes" class="img-circle circulos_precio"/>
                                </div>
                            </div>
                        </div> 
                        <div class="row">  
                            <div class="col-xs-4"> 
                                 <div class="precio_4" >
                                    <img src="images/oferta_4.png" alt="Promociones" class="img-circle circulos_precio"/>
                                </div>
                            </div> 
                            <div class="col-xs-4">
                                <div class="panel panel-warning sistema_de_pago" >
                                    <div class="panel-heading titulo_sistema_de_pago">SISTEMAS DE PAGO</div>
                                    <div class="panel-body">
                                        <ul class="lista_sistema_de_pago">
                                            <li>Si vive en la República Argentina use RapiPago o Pago Facíl.</li>
                                            <li>Puede pagar por medio de una transferéncia bancária<span><br/> (necesita enviar el comprobante de depósito)</span></li>
                                            <li>Puede abonar con Mercado Pago en diferentes paises</li>
                                            <li>Puede cargar crédito en todo el mundo por Paypal</li>
                                            <li>Cree su propia factura digital de carga de saldo y pague con todas las tarjetas de crédito o banca computarizada</li>
                                        </ul>
                                    </div>
                                    <div class="panel-footer pie_sistema_de_pago" >(*) el crédito no tiene fecha de <span>vencimiento</span>, algunos médios de pago puede tardar 72 horas en debitarse en su cuenta</div>
                                </div>
                            </div>

                            <div class="col-xs-4">
                                <div class="panel panel-warning otros_medios" >
                                    <div class="panel-heading titulo_otros_medios">OTROS MÉDIOS</div>
                                    <div class="panel-body">
                                        <ul class="lista_otros_medios">
                                            <li>Compre en el Kiosco o Libreria una tarjeta precarga &#8220;Xelados&#8221; de $5; $10; $20; $50 y $100.<span><br />(Ingrese los códigos de su tarjeta e inmediatamente recibita el crédito)</span></li>
                                        </ul>
                                    </div>
                                    <div class="panel-footer pie_otros_medios" >Si se queda sin crédito puede pedir un "credito SOS" que sera debitado de su próxima carga sin costos extras </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="visible-xs">                    
                        <div class="col-xs-12">
                            <div class="panel panel-warning sistema_de_pago_movil">
                                <div class="panel-heading titulo_sistema_de_pago_movil">SISTEMAS DE PAGO</div>
                                <div class="panel-body">
                                    <ul class="lista_sistema_de_pago_movil">
                                        <li>Si vive en la República Argentina use RapiPago o Pago Facíl.</li>
                                        <li>Puede pagar por medio de una transferéncia bancária<span><br/> (necesita enviar el comprobante de depósito)</span></li>
                                        <li>Puede abonar con Mercado Pago en diferentes paises</li>
                                        <li>Puede cargar crédito en todo el mundo por Paypal</li>
                                        <li>Cree su propia factura digital de carga de saldo para abonar con todas las tarjetas de crédito</li>
                                    </ul>
                                </div>
                                <div class="panel-footer pie_sistema_de_pago_movil">(*) el crédito no tiene fecha de <span>vencimiento</span>, algunos médios de pago puede tardar 72 horas en debitarse en su cuenta</div>
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <div class="panel panel-warning otros_medios_movil">
                                <div class="panel-heading titulo_otros_medios_movil">OTROS MÉDIOS</div>
                                <div class="panel-body">
                                    <ul class="lista_otros_medios_movil">
                                        <li>Compre en el Kiosco o Libreria una tarjeta precarga &#8220;Xelados&#8221; de $5; $10; $20; $50 y $100.<span class="aclaracion_1"><br />(Ingrese los códigos de su tarjeta e inmediatamente recibita el crédito)</span></li>
                                    </ul>
                                </div>
                                <div class="panel-footer pie_otros_medios_movil">Si se queda sin crédito puede pedir un &#8220;credito SOS&#8217; que sera debitado de su próxima carga sin costos extras </div>
                            </div>
                        </div>    
                    </div>
                </div>                
            </article>
        </section>
        <hr />

<%-- ********************************* contactenos ************************************--%>
            
        <section id="contactenos" >                        
            <div class="container">                    
                <div class="row">                        
                    <div class="icono_correo">                            
                        <span class="glyphicon-envelope" ></span>
                        <div id="contactenos_movil"></div>
                    </div>                
                </div>                    
                <div class="row">                        
                    <div class="col-xs-12 ">
                        <h1 class="titulo_correo">Contactese con nosotros, estamos para ayudarlo</h1>
                    </div>                               
                </div>                    
                <div class="row">
                    <div class="col-xs-12">
                        <div class="contenido_contactenos">        
                            <asp:Panel ID="Panel_De_Comentarios" runat="server" DefaultButton="Boton_Contacto">                 
                                <asp:UpdatePanel ID="Progreso_Boton_Enviar_Contacto" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="Nombre" CssClass="etiquetas_form" runat="server" Text="Nombre" ></asp:Label>
                                        <asp:TextBox ID="Nombre_Contacto" MaxLength="30" CssClass="js_contacto_1 form-control textbox_rellenar" runat="server" placeholder="escriba su nombre"></asp:TextBox>
                                        <asp:Label ID="Correo" CssClass="etiquetas_form" runat="server" Text="Correo Electronico"></asp:Label>
                                        <asp:TextBox ID="Correo_Contacto" MaxLength="30" type="email" CssClass="js_contacto_2 form-control textbox_rellenar" runat="server" placeholder="escriba su correo electrónico"></asp:TextBox>
                                        <asp:Label ID="Mensaje" CssClass="etiquetas_form" runat="server" Text="Mensaje" ></asp:Label>
                                        <asp:TextBox ID="Comentario_Contacto" class="js_contacto_3 form-control textbox_rellenar_comentario" runat="server" TextMode="MultiLine" Rows="8" placeholder="escribir un comentario"></asp:TextBox>                                
                                        <asp:Button ID="Boton_Contacto" runat="server" CssClass="btn btn-warning btn-lg boton_mensaje" Text="Envienos sus comentarios" OnClientClick="return validar_comentario();" OnClick="Boton_Contacto_Click" />     
                                    </ContentTemplate>
                                </asp:UpdatePanel> 
                           </asp:Panel>                      
                        </div>                    
                    </div>                    
                </div>
            </div> 
        </section>
        <hr />

<%-- ********************************* Pie de Pagina *********************************--%>

        <footer>        
             <div class="container">              
                <div class="row">                
                    <div class="col-xs-7">
                        <div class="ubicacion_pie" >
                            <h6 class="main-footer pie_ley">Xelados Tecnology S.A. © 2015 - <a data-toggle="modal" href="#Terminos">Términos y Condiciones</a> - <a data-toggle="modal" href="#Politica">Políticas de Privacidad</a></h6>
                        </div>
                    </div>
                    
                    <div class="col-xs-5">
                        <div class="ubicacion_pie">
                            <h6 class="main-webmaster pie_web">WebMaster Martina Ivana Romero</h6>
                        </div>
                    </div>
                </div>
            </div>        
        </footer>        


<%-- ******************************** paneles de progreso ****************************--%>


<%-- boton de inicio progreso --%>

        <asp:UpdateProgress ID="Progreso_Boton_Logueo" runat="server" AssociatedUpdatePanelID="Progreso_Boton_Iniciar_Session" >
            <ProgressTemplate>                                
                <div style="background:url(images/fondo_proceso.png); width: 100%; z-index: 59; top: 0px; left: 0px; position: fixed; height: 100%;">
                    <div class="container">
                        <div class="row">
                            <div class="col-sm-4 col-sm-offset-4 hidden-xs" style="background-color:ghostwhite; border:solid 2px #428BCA; width:340px;height:140px;margin-top:300px;text-align:center">                
                                <img src="images/ajax-loader.gif" style="margin-top:40px; margin-bottom:20px" />
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


<%-- boton de contacto progreso --%>

        <asp:UpdateProgress ID="Progreso_Boton_Contacto" runat="server" AssociatedUpdatePanelID="Progreso_Boton_Enviar_Contacto" >
            <ProgressTemplate>                                
                <div style="background:url(images/fondo_proceso.png); width: 100%; z-index: 59; top: 0px; left: 0px; position: fixed; height: 100%;">
                    <div class="container">
                        <div class="row">
                            <div class="col-sm-4 col-sm-offset-4 hidden-xs" style="background-color:ghostwhite; border:solid 2px #428BCA; width:340px;height:140px;margin-top:300px;text-align:center">                
                                <img src="images/ajax-loader.gif" style="margin-top:40px; margin-bottom:20px" />
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


<%-- ************************* paneles modales del datalist **** ***********************************--%> 


<%-- panel ejercicios del datalist logueado --%>
        
        <div class="modal fade" id="Ejercicio" >            
            <div class="modal-dialog">      
                <div class="modal-content panel_contenedor ">
                    <div class="modal-header cabezera_datalist">
                        <button type="button" class="close cerrar_datalist" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title explicaciones_y_videos">Explicaciones y Videos</h4>
                    </div>
                    <div class="modal-body">
                        <asp:Image ID="Enunciados" ImageUrl="http" Width="100%" runat="server" />                        
                        <div class="row " id="Botones_Ejercicio" runat="server">
                            <div class="col-xs-4 solucion hidden-xs">
                                <asp:UpdatePanel ID="Panel_De_Botones_Para_Ejercicios" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="Boton_Compra_Ejercicio" OnClientClick="return Aceptar_Compra();" runat="server" Text="Quiero la solución" CssClass="btn btn-success" OnClick="Boton_Compra_Ejercicio_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-xs-6 solucion visible-xs ">
                                <asp:UpdatePanel ID="Panel_De_Botones_Para_Ejercios_Movil" runat="server" style="text-align:center">
                                    <ContentTemplate>
                                        <asp:Button ID="Boton_Compra_Ejercicio_Movil" OnClientClick="return Aceptar_Compra();" runat="server" Text="Quiero la solución" CssClass="btn btn-success" OnClick="Boton_Compra_Ejercicio_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>                            
                            <div class="col-xs-4 explicacion col-sm-offset-4 hidden-xs">
                                <asp:UpdatePanel ID="Panel_De_Botones_Para_Explicaciones" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="Boton_Compra_Explicacion" OnClientClick="return Aceptar_Compra();" runat="server" Text="Quiero la explicación" OnClick="Boton_Compra_Explicacion_Click" ToolTip="puede tener una demora de 24 horas" CssClass="btn btn-default" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-xs-6 explicacion col-sm-offset-4 visible-xs">
                                <asp:UpdatePanel ID="Panel_De_Botones_Para_Explicaciones_Movil" runat="server" style="text-align:center">
                                    <ContentTemplate>
                                        <asp:Button ID="Boton_Compra_Explicacion_Movil" OnClientClick="return Aceptar_Compra();" runat="server" Text="Quiero la explicación" OnClick="Boton_Compra_Explicacion_Click" ToolTip="puede tener una demora de 24 horas" CssClass="btn btn-default" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" id="Boton_Video" runat="server" >
                            <div class="col-xs-12">
                                <asp:UpdatePanel ID="Panel_De_Boton_Para_Video" runat="server" style="text-align:center">
                                    <ContentTemplate>
                                        <asp:Button ID="Boton_Compra_Video" OnClientClick="return Aceptar_Compra();" runat="server" OnClick="Boton_Compra_Video_Click" Text="Quiero comprar el vídeo?" CssClass="btn btn-success" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>                                                        
                        </div>  
                    </div>                    
                </div>      
            </div>
        

<%-- boton de ejercicios y videos progreso --%>
                             
            <asp:UpdateProgress ID="Progreso_Botones" runat="server">
                <ProgressTemplate>                                
                    <div style="background:url(images/fondo_proceso.png); width: 100%; z-index: 959; top: 0px; left: 0px; position: fixed; height: 100%;">
                        <div class="container">
                            <div class="row">
                                <div class="col-sm-4 col-sm-offset-4 hidden-xs" style="background-color:ghostwhite; border:solid 2px #428BCA; width:340px;height:140px;margin-top:300px;text-align:center">                
                                    <img src="images/ajax-loader.gif" style="margin-top:40px; margin-bottom:20px" />
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
        </div>  

                  
<%-- panel ejercicio del datalist no logueado --%>
        
        <div class="modal fade" id="NoLogueado"   >            
            <div class="modal-dialog">                
                <div class="modal-content " style="height: 0px;border-bottom-width: 0px;border-right-width: 0px;border-top-width: 0px;border-left-width: 0px;">
                    <div class="modal-body fondo_panel_NoLogueado" style="margin-top:180px;">
                        <h3 class="mensaje_error_NoLogueado">Para acceder a estas opciones debe encontrarse registrado</h3> 
                        <hr style="margin-top:0px;"/>                         
                        <table class="botonera_NoLogueado">
                            <tr>
                                <td class="ubicacion_NoLogueado">
                                    <asp:Button ID="Boton_Inicio_Popup" OnClick="Boton_Inicio_Popup_Click" runat="server" Text="Ya eres usuario?" CssClass="btn btn-default botones_popup"  />
                                </td >
                                <td class="ubicacion_NoLogueado">
                                    <asp:Button ID="Boton_Registrarse_Popup" OnClick="Boton_Registrarse_Popup_Click" runat="server" Text="Registrate ahora" CssClass="btn btn-success botones_popup" />
                                </td>                                
                            </tr>                            
                        </table>                       
                    </div>                    
                </div>                
            </div>
        </div>  <%-- final panel ejercicio del datalist --%>

            
<%-- panel ejercicio del Consulta --%>
        
        <div class="modal fade" id="Panel_De_Consulta">            
            <div class="modal-dialog modal-lg">     
                <asp:UpdatePanel ID="Panel_De_Consulta_De_Movimientos" runat="server"> 
                    <ContentTemplate>
                        <div class="modal-content"> 
                            <div class="modal-header recuadro">
                                <div class="row">
                                    <div class="col-xs-10 usuario_mis_movimientos">
                                        <asp:Label ID="Usuario_Mis_Movimientos" runat="server" Text="Label"></asp:Label>
                                    </div>
                                    
                                    <div class="col-xs-2 cerrar_usuario_mis_movimientos">
                                       <button type="button" class="close cerrar_datalist" data-dismiss="modal" aria-hidden="true">×</button>
                                    </div>
                                    
                                </div>
                                <div class="row">
                                    <div class="col-xs-12 credito_usuario_mis_movimientos">
                                        <asp:Label ID="Credito_Usuario_Mis_Movimientos" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </div> 
                            </div>
                                <div  class="modal-body cuerpo">
                                    <div class="row">
                                        <div class="col-xs-2 titulo_fecha_del_movimiento" >
                                            <h1 class="titulo_para_panel_de_movimiento">Fecha</h1>
                                        </div>
                                        <div class="col-xs-6 titulo_descripcion_de_movimiento">
                                            <h1 class="titulo_para_panel_movimiento">Tipo de Movimiento</h1>
                                        </div>
                                        <div class="col-xs-2 titulo_plata_debe_movimiento">
                                            <h1 class ="titulo_para_panel_movimiento">Debe</h1>
                                        </div>
                                        <div class="col-xs-2 titulo_plata_haber_movimiento">
                                            <h1 class="titulo_para_panel_movimiento">Haber</h1>
                                        </div>
                                    </div>
                                    <asp:DataList ID="DataList_Mis_Movimientos" Width="100%" runat="server">
                                        <ItemTemplate>
                                            <div class="row">
                                                <div class="col-xs-2 fecha_de_movimiento"><%# Eval ("Fecha_Del_Movimiento","{0:d}") %></div>
                                                <div class="col-xs-6 descripcion"><%# Eval ("Descripcion_De_Movimiento") %></div>
                                                <div class="col-xs-2 plata_debe"><%# Eval ("Plata_Debe","{0:c2}") %></div>
                                                <div class="col-xs-2 plata_haber"><%# Eval ("Plata_Haber","{0:c2}") %></div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>       
        </div>


<%-- ************************* paneles de buqueda**** ***********************************--%> 


<%-- panel de busqueda --%>
        
        <div class="modal fade" id="Busqueda">            
            <div class="modal-dialog">
                <asp:UpdatePanel ID="Panel_De_Busqueda_En_DataList" runat="server">                        
                    <ContentTemplate>
                        <div class="modal-content ">
                           <div class="modal-header busqueda_cabezera">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h4 class="modal-title buscar_ejercicios_y_explicaciones">Buscar ejercicios y explicaciones</h4>
                            </div>
                            <div class="modal-body busqueda_cuerpo">
                                  <div class="form-group formulario_de_busqueda">
                                  <asp:Label runat="server" CssClass="sub_etiqueta">Complete los casilleros para una mejor búsqueda </asp:Label> 
                                </div>          
                                <div class="form-group formulario_busqueda">               
                                    <label class="etiqueta_busqueda etiqueta">Tema</label>
                                    <asp:TextBox TextMode="SingleLine" maxlength="60" ID="Buscar_x_Tema" class="form-control textbox_busqueda" runat="server"></asp:TextBox>
                                    <label class="etiqueta_inferior_0">ejemplo: <span class="etiqueta_inferior_1">regla de tres simple</span><br /><span class="etiqueta_inferior_2">trabajo práctico de matemática números enteros</span></label>
                                </div>
                                <div class="form-group formulario_busqueda">               
                                    <label class="etiqueta_busqueda etiqueta">Materia</label>
                                    <asp:TextBox TextMode="SingleLine" maxlength="60" ID="Buscar_x_Materia" class="form-control textbox_busqueda" runat="server"></asp:TextBox>
                                    <label class="etiqueta_inferior_0">ejemplo: <span class="etiqueta_inferior_1">química</span><br /><span class="etiqueta_inferior_2">física</span></label>
                                </div>
                                <div class="form-group formulario_busqueda">
                                    <label class="etiqueta_registro etiqueta">Colegio</label>
                                    <asp:TextBox TextMode="SingleLine" maxlength="30" ID="Buscar_x_Colegio" class="form-control textbox_busqueda" runat="server"></asp:TextBox>
                                    <label class="etiqueta_inferior_0">ejemplo: <span class="etiqueta_inferior_1">Universidad de Buenos Aires</span><br /><span class="etiqueta_inferior_2">UBA</span></label>
                                </div>
                                <div class="form-group formulario_busqueda">
                                    <label class="etiqueta_registro etiqueta">Año en Curso</label>
                                    <asp:TextBox TextMode="SingleLine" maxlength="20" ID="Buscar_x_Ano" class="form-control textbox_busqueda" runat="server"></asp:TextBox> 
                                    <label class="etiqueta_inferior_0">ejemplo: <span class="etiqueta_inferior_1">primer año</span><br /><span class="etiqueta_inferior_2">primero</span></label>                   
                                </div>
                                <div class="form-group formulario_busqueda">
                                    <label class="etiqueta_registro etiqueta">Profesor o Catedra</label>
                                    <asp:TextBox TextMode="SingleLine" maxlength="30" ID="Buscar_x_Profesor"  class="form-control textbox_busqueda" runat="server"></asp:TextBox>     
                                    <label class="etiqueta_inferior_0">ejemplo: <span class="etiqueta_inferior_1">Gutierrez</span><br /><span class="etiqueta_inferior_2">Fernando Quiroz</span></label>
                                </div>                                
                            </div>                    
                            <div class="modal-footer pie_busqueda">
                                <asp:UpdatePanel ID="Boton_De_Busqueda_En_El_DataList" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="Boton_Buscar_Seleccion" OnClick="Boton_Buscar_Seleccion_Click" runat="server" CssClass="btn btn-primary btn-lg boton_busqueda" Text="Realizar la Búsqueda"/>  
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>                    
                        </div>               
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>  
            
            
<%-- boton de busqueda progreso --%>
                             
            <asp:UpdateProgress ID="Progreso_Boton_Busqueda" runat="server" AssociatedUpdatePanelID="Boton_De_Busqueda_En_El_DataList" >
                <ProgressTemplate>                                
                    <div style="background:url(images/fondo_proceso.png); width: 100%; z-index: 959; top: 0px; left: 0px; position: fixed; height: 100%;">
                        <div class="container">
                            <div class="row">
                                <div class="col-sm-4 col-sm-offset-4 hidden-xs" style="background-color:ghostwhite; border:solid 2px #428BCA; width:340px;height:140px;margin-top:300px;text-align:center">                
                                    <img src="images/ajax-loader.gif" style="margin-top:40px; margin-bottom:20px" />
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
        </div>  <%-- final panel de busqueda --%>                      

<%-- ************************* panel de registro completo**** ***********************************--%> 

        <div class="modal fade" id="Registro">
            <script src="js/registro.js" type="text/javascript"></script>
            <div class="modal-dialog">
                <asp:UpdatePanel ID="Panel_De_Registro" runat="server">                        
                    <ContentTemplate>
                        <div class="modal-content ">
                            <div class="modal-header registro_cabezera">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h4 class="modal-title titulo_formularios">Formulario de registración</h4>
                            </div>
                            <div class="modal-body cuerpo_del_formulario">
                                <div class="form-group formulario_registro">
                                    <asp:UpdatePanel ID="Progreso_Reenvio" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="Reenviar_Activacion" OnClick="Reenviar_Activacion_Click" CausesValidation="false" runat="server" OnClientClick="javascript:return Reenviar_Mail();">¿Te registraste y no llego el e-mail de confirmación?</asp:LinkButton>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>          
                                <div class="form-group formulario_registro">               
                                    <label class="etiqueta_registro">Nombre de Usuario</label>
                                    <asp:TextBox placeholder="cree un usuario" TextMode="SingleLine" maxlength="10" ID="Usuario_Registro" class="registro_1 form-control textbox_registro" onKeyPress="return pohibido_blanco(event)" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group formulario_registro">
                                    <label class="etiqueta_registro">Contraseña deseada</label>
                                    <asp:TextBox placeholder="escriba una contraseña de más de 5 caracteres" TextMode="Password" maxlength="10" ID="Password_Registro" onKeyPress="mayuscula_activado(event)"  class="registro_2 form-control textbox_registro" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group formulario_registro">
                                    <label class="etiqueta_registro">Confirme contraseña</label>
                                    <asp:TextBox placeholder="repita la contraseña" TextMode="Password" maxlength="10" ID="RePassword_Registro"  class="registro_3 form-control textbox_registro" runat="server"></asp:TextBox>                            
                                </div>
                                <div class="form-group formulario_registro">
                                    <label class="etiqueta_registro">Correo electrónico</label>
                                    <asp:TextBox placeholder="ingrese un correo electrónico" TextMode="Email" maxlength="30" ID="Correo_Registro"  class="registro_4 form-control textbox_registro" runat="server"></asp:TextBox>                            
                                </div>
                                <div style="text-align:center">        
                                    <asp:Image ID="Imagen_Captcha" runat="server"/>                                                                      
                                </div>
                                <div class="form-group formulario_registro">
                                    <label class="etiqueta_registro">Ingrese el código de la imagen</label>
                                    <asp:TextBox TextMode="SingleLine" class="registro_5 form-control textbox_registro" ID="Captcha_Registro" runat="server" placeholder="ingrese la imágen"></asp:TextBox>
                                </div>
                                <div class="checkbox checkbox-celular">
                                    <label class="etiqueta_acepta_condiciones" >
                                        <asp:CheckBox ID="Condiciones_Registro" runat="server" />
                                        <a href="www.xelados.net" runat="server" id="condiciones_terminos">Acepto términos y condiciones</a>
                                    </label>
                                </div>
                            </div>                    
                            <div class="modal-footer pie_registro">
                                <asp:UpdatePanel ID="Panel_De_Envio_Del_Registro" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="Boton_Enviar_Registro" runat="server" CssClass="btn btn-primary btn-lg boton_registro" Text="Registrarse como usuario" OnClick="Boton_Enviar_Registro_Click" OnClientClick="return validar_registro()"/>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>                       
                        </div>                  
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div> 

<%-- boton de registro progreso --%>
                             
            <asp:UpdateProgress ID="Boton_Registro_Progreso" runat="server" AssociatedUpdatePanelID="Panel_De_Registro" >
                <ProgressTemplate>                                
                    <div style="background:url(images/fondo_proceso.png); width: 100%; z-index: 959; top: 0px; left: 0px; position: fixed; height: 100%;">
                        <div class="container">
                            <div class="row">
                                <div class="col-sm-4 col-sm-offset-4 hidden-xs" style="background-color:ghostwhite; border:solid 2px #428BCA; width:340px;height:140px;margin-top:300px;text-align:center">                
                                    <img src="images/ajax-loader.gif" style="margin-top:40px; margin-bottom:20px" />
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


<%-- boton de reenvio de registro progreso --%>
                             
            <asp:UpdateProgress ID="Boton_Reenvio_Progreso" runat="server" AssociatedUpdatePanelID="Progreso_Reenvio" >
                <ProgressTemplate>                                
                    <div style="background:url(images/fondo_proceso.png); width: 100%; z-index: 959; top: 0px; left: 0px; position: fixed; height: 100%;">
                        <div class="container">
                            <div class="row">
                                <div class="col-sm-4 col-sm-offset-4 hidden-xs" style="background-color:ghostwhite; border:solid 2px #428BCA; width:340px;height:140px;margin-top:300px;text-align:center">                
                                    <img src="images/ajax-loader.gif" style="margin-top:40px; margin-bottom:20px" />
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
        </div>  <%-- final del registro --%>    

        
<%-- ************************* panel de control**** ***********************************--%> 


<%-- panel de Control --%>
        
        <div class="modal fade" id="Panel_De_Control_De_Usuarios">            
            <div class="modal-dialog">
                <asp:UpdatePanel ID="Perfil_Del_Usuario" runat="server">                        
                    <ContentTemplate>
                        <div class="modal-content ">
                            <div class="modal-header busqueda_cabezera">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h4 class="modal-title titulo_formulario">Panel de Control</h4>
                            </div>
                            <div class="modal-body">                                          
                                <div class="form-group formulario_panel_de_control">                                     
                                    <asp:Label ID="Etiqueta_Usuario_Panel_Contenido" runat="server" Text="Usuario: "></asp:Label>
                                    <asp:Label ID="Usuario_Panel_Control" runat="server" ></asp:Label> 
                                </div>
                                <div class="form-group formulario_panel_de_control">
                                    <asp:Label ID="Etiqueta_Contrasena_Panel" runat="server" Text="Contraseña:"></asp:Label>               
                                    <asp:TextBox ID="Contrasena_Panel_Control" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group formulario_panel_de_control">
                                    <asp:Label ID="Etiqueta_Correo_Panel" runat="server" Text="Correo:"></asp:Label>
                                    <asp:TextBox ID="Correo_Panel_Control" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group formulario_panel_de_control">
                                    <asp:Label ID="Etiqueta_Skype_Panel" runat="server" Text="Skype:"></asp:Label>
                                    <asp:TextBox ID="Skype_Panel_Control" CssClass="form-control" runat="server"></asp:TextBox> 
                                </div>
                                <div class="form-group formulario_panel_de_control">
                                     <asp:Label ID="Etiqueta_Celular_Panel" runat="server" Text="Tel. Móvil:"></asp:Label>
                                    <asp:TextBox ID="Celular_Panel_Control" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group formulario_panel_de_control">
                                    <asp:Label ID="Etiqueta_Modelo_Panel" runat="server" Text="Modelo Movil:"></asp:Label>
                                    <asp:TextBox ID="Modelo_Panel_Control" CssClass="form-control"  runat="server"></asp:TextBox>
                                </div>                    
                            </div>                    
                            <div class="modal-footer pie_panel_de_control">
                                <asp:UpdatePanel ID="Panel_Boton_Actualizar_Datos" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="Boton_Actualizar_Datos" OnClick="Boton_Actualizar_Datos_Click"  runat="server" CssClass="btn btn-primary btn-lg boton_busqueda" Text="Actualizar Datos"/>  
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>                       
                        </div>               
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>  
        
            
<%-- boton de actualizacion de datos en progreso --%>
                             
           <asp:UpdateProgress ID="Actualizar_Panel_Progreso" runat="server" AssociatedUpdatePanelID="Panel_Boton_Actualizar_Datos" >
                <ProgressTemplate>                                
                    <div style="background:url(images/fondo_proceso.png); width: 100%; z-index: 959; top: 0px; left: 0px; position: fixed; height: 100%;">
                        <div class="container">
                            <div class="row">
                                <div class="col-sm-4 col-sm-offset-4 hidden-xs" style="background-color:ghostwhite; border:solid 2px #428BCA; width:340px;height:140px;margin-top:300px;text-align:center">                
                                    <img src="images/ajax-loader.gif" style="margin-top:40px; margin-bottom:20px" />
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
            </asp:UpdateProgress>    <%-- final panel de control --%> 
       </div>  
     

    </div> <%-- final del div relacionado con los microdatos --%>   

    </form>

</body>

</html>
