<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Correo_Recuperacion.aspx.cs" Inherits="Fenicia_Web.Correo_Recuperacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>

    <title>Recuperación de Contraseña</title>

     <!-- Jquery -->
    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
   
    <!-- js Bootstrap 3 -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>

    <!-- CSS correspondiente a Bootstrap 3 -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />

    <!-- CSS con los estilos-->
    <link rel="stylesheet" href="css/pagina_contrasena.css" type="text/css" />


<link rel="shortcut icon" type="image/png" href="favicon.icon" />
<link rel="apple-touch-icon" href="img/touch-icon.png"/>


</head>

<body>
    
    <form id="form1" runat="server">  


<%-- ------------------------------------cabecera ---------------------------------------- --%>


        <header id="main-header">
            <div class="container">
                <div class="row">
                    <div class="col-xs-10 col-sm-3">
                        <h1>Fenicia<span>¡es aprobar!</span></h1>
                    </div>		
                </div>
            </div>     
        </header>


<%-- ------------------------------------cuerpo ---------------------------------------- --%>


        <section>
            <div class="container">        
                <div class="row">
                    <div class="col-xs-12">                    
                        <div class="contenido_correo_recuperacion">Estimado cliente usted a solicitado la recuperación de su contraseña y es por ese motivo que se la reenviamos a su correo electronico. Ante cualquier problema no dude en consultarnos por medio del panel de contactos.</div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">                    
                        <div class="titulo_usuario_correo_recuperacion">■ Nombre de Usuario:</div>
                    </div>
                    <div class="col-xs-6">                    
                        <div class="usuario_correo_recuperacion">NICKUSUARIO</div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-6">                    
                        <div class="titulo_contrasena_correo_recuperacion">■ Contraseña:</div>
                    </div>
                    <div class="col-xs-6">                    
                        <div class="contrasena_correo_recuperacion">CONTRASENA</div>
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
