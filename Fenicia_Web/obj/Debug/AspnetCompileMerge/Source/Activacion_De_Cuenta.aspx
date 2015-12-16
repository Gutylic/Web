<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Activacion_De_Cuenta.aspx.cs" Inherits="Fenicia_Web.Activacion_De_Cuenta" %>

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
    <link rel="stylesheet" href="css/pagina_activacion.css" type="text/css" />

</head>

<body>

    <form id="form1" runat="server">


<%-- ------------------------------------Cabecera ---------------------------------------- --%>


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
                    <div class= "col-xs-12">
                        <div class="etiqueta_activacion_de_cuenta">Gracias por registrarse</div>
                    </div>
                    <div class= "col-xs-12">
                        <div class="etiqueta_xelados_activacion_de_cuenta">Nuestros profesores particulares en linea lo esperan</div>
                    </div>
                    <div class="col-xs-12">
                        <div class="etiqueta_explicacion_de_boton_de_activacion">Presione el botón para conezar a disfrutar de nuestros servicios</div>
                    </div>
                    <div class="col-xs-12" style="text-align:center">
                        <asp:Button class="boton_de_activacion" ID="Boton_De_Activacion" runat="server" Text="Activar su cuenta" onclick="Boton_De_Activacion_Click" />
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


