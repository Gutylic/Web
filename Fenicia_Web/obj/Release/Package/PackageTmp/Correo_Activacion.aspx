<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Correo_Activacion.aspx.cs" Inherits="Fenicia_Web.Correo_Activacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>Recuperación de Contraseña</title>

    <!-- Jquery -->
    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
   
    <!-- js Bootstrap 3 -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    
    <!-- CSS correspondiente a Bootstrap 3 -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />
    
    <!-- CSS con los estilos-->
    <link rel="stylesheet" href="css/correo_activo.css" type="text/css" />


<link rel="shortcut icon" type="image/png" href="favicon.icon" />
<link rel="apple-touch-icon" href="img/touch-icon.png"/>


</head>

<body>
    
    <form id="form1" runat="server">    


<%-- ------------------------------------cabecera---------------------------------------- --%>


        <header id="main-header">
            <div class="container">
                <div class="row">
                    <div class="col-xs-10 col-sm-3">
                        <h1>Fenicia<span>¡es aprobar!</span></h1>
                    </div>		
                </div>
            </div>     
        </header>


<%-- ------------------------------------cuerpo---------------------------------------- --%>


        <section>
            <div class="container">        
                <div class="row">
                    <div class="col-xs-12">                    
                        <div class="contenido_del_mensaje_de_activacion">Estimado cliente ante todo muchas gracias por depositarnos su confianza, usted ha recibido este mensaje porque se ha registrado en el&nbsp; sitio&nbsp; web de Fenicia,&nbsp; a&nbsp; continuación le&nbsp; detallamos su&nbsp; nombre de&nbsp; usuario y contraseña con los cuales puedes acceder al sistema y utilizar todos nuestros servicios.&nbsp; </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">                    
                        <div class="titulo_usuario_activacion">■ Nombre de Usuario:</div>
                    </div>
                    <div class="col-xs-6">                    
                        <div class="usuario_activacion">NICKUSUARIO</div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">                    
                        <div class="titulo_contrasena_activacion">■ Contraseña:</div>
                    </div>
                    <div class="col-xs-6">                    
                        <div class="contrasena_activacion">CONTRASENA</div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">                    
                        <div class="mensaje_link_de_activacion">Para activar su cuenta debe ingresar al siguiente link (o en su defecto corte y pegue esta dirección en su explorador de internet)</br></div>
                    </div>
                    <div class="col-xs-12">                    
                        <div class="contenido_de_la_activacion">                            
                            <a href="http://www.unprofesorya.com/Activacion_de_Cuenta.aspx?ID_Nombre=NICKUSUARIO">http://www.unrofesorya.com/Activacion_de_Cuenta.aspx?ID_Nombre=NICKUSUARIO</a>
                        </div>
                    </div>
                </div>                
            </div>
        </section>


<%-- ------------------------------------Pie ---------------------------------------- --%>        
       

        <footer>                     
            <div class="container">                
                <div class="row">                
                    <div class="col-xs-12">
                        <div class="ubicacion_pie" >
                            <h6 class="main-footer pie_pagina">Xelados Tecnology S.A. © 2015 - WebMaster Martina Ivana Romero</h6>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
                

    </form>

</body>

</html>



