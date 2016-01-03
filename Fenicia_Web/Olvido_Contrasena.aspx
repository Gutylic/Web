<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Olvido_Contrasena.aspx.cs" Inherits="Fenicia_Web.Olvido_Contrasena" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta name="viewport" content="width=device-width, initial-scale=1"/>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1"/>   

<title>Recuperar Contraseña</title>          
    
    <!-- Jquery -->
    <script src="//code.jquery.com/jquery-1.11.0.min.js"></script>
   
    <!-- js Bootstrap 3 -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>

    <!-- CSS correspondiente a Bootstrap 3 -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />

    <!-- CSS con los estilos-->
    <script src="js/recuperar.js" type="text/javascript"></script>
   
    <!-- CSS con los estilos-->
    <link rel="stylesheet" href="css/olvido_contrasena.css" type="text/css" />


<link rel="shortcut icon" type="image/png" href="favicon.icon" />
<link rel="apple-touch-icon" href="img/touch-icon.png"/>

    
</head>


<body>

    <form id="form1" runat="server">
     
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>     
        

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
        

<%-- ------------------------------------Panel de correo ---------------------------------------- --%>


        <section>
            <asp:UpdatePanel ID="Panel_Cuerpo_Correo" runat="server">                
                <ContentTemplate>                        
                    <div class="container">
                        <div class="row">
                            <div class="col-xs-12 ubicacion_panel">
                                <div class="panel panel-success">
                                    <div class="panel-heading encabezado">Recuperar Contraseña</div>
                                        <div class="panel-body cuerpo">
                                            <div class="form-horizontal" role="form">
                                                <div class="form-group">
                                                    <label for="TextBox_Correo" class="hidden-xs col-sm-2 control-label etiqueta_correo">Correo electrónico</label>
                                                    <label for="TextBox_Correo" class="col-xs-4 control-label visible-xs etiqueta_correo_movil">Correo electrónico</label>
                                                    <div class="col-xs-8 col-sm-10">
                                                        <asp:TextBox type="email" class="form-control" ID="Correo_Enviar_Contrasena" MaxLength="30" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-offset-2 col-sm-10 hidden-xs control-label etiqueta_subtitulo" >recuerde que su contraseña llegará a su correo electrónico y la misma puede encontrarse en su bandeja de entrada o span</label>
                                                </div>
                                                <div class="form-group">
                                                      <asp:UpdatePanel ID="Recuperacion_Contrasena" runat="server">
                                                            <ContentTemplate>
                                                                <div class="col-sm-offset-4 col-sm-4 hidden-xs" style="text-align:center">
                                                                    <asp:Button ID="Button_Correo" runat="server" Text="Enviarme la contraseña al correo" Cssclass="btn btn-success" OnClick="Boton_Recuperar_Password_Click" OnClientClick="return validar_correo()"/>

                                                                </div>
                                                                <div class="col-xs-12 visible-xs" style="text-align:center">
                                                                    <asp:Button ID="Button_Correo_Movil" runat="server" Text="Enviarme la contraseña al correo" Cssclass="btn btn-success" OnClick="Boton_Recuperar_Password_Click" OnClientClick="return validar_correo()" />
                                                                </div>
                                                           </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>                    
                    </ContentTemplate>        
                </asp:UpdatePanel>            
            </section>

              
<%-- ------------------------------------Panel del pie de la pagina --------------------------------%>        
                   
            <footer>                     
                <div class="container">
                    <div class="row">                
                        <div class="col-xs-12">
                            <div class="ubicacion_pie" >
                                <h6 class="main-footer pie_pagina">Fenicia S.A. © 2015 - WebMaster Martina Ivana Romero</h6>
                            </div>
                        </div>
                    </div>
                </div>
            </footer>
           

<%-- ------------------------------------Imagen de progreso ----------------------------------------%>   

           <asp:UpdateProgress ID="Boton_Recuperar_Contrasena" runat="server">
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
                
    </form>

</body>

</html>
