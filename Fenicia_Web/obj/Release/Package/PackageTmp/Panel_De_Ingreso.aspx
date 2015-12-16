<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Panel_De_Ingreso.aspx.cs" Inherits="Fenicia_Web.Panel_De_Ingreso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
    
    <title>Ingreso Fenicia</title>
         
    <!-- Jquery -->
    <script src="//code.jquery.com/jquery-1.11.0.min.js"></script>
   
    <!-- js Bootstrap 3 -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>

    <!-- CSS correspondiente a Bootstrap 3 -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />

    <!-- CSS correspondiente a la pagina de ingreso -->
    <link href="css/pagina_ingreso.css" rel="stylesheet" type="text/css" />

    <!-- JS de la pagina -->
    <script src="js/actividad.js" type="text/javascript"></script>
    <script src="js/registro.js" type="text/javascript"></script>

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


<%-- ------------------------------------cuerpo ---------------------------------------- --%>
        
        <section>       
            
 
<%-- -----------------------------iniciar sesion ---------------------------------------- --%>                        
                    
            <div class="container iniciar">
                <div class="col-xs-12">
                    <div class="row">
                        <div class="panel panel-primary panel_inicio" >
                            <div class="panel-heading encabezado">Iniciar Sesión</div>
                            <div class="panel-body cuerpo">
                                <div class="form-horizontal" role="form" >
                                    <div class="form-group etiqueta_usuario">
                                        <asp:Label ID="Usuario" for="TextBox_Usuario" CssClass="col-sm-2 control-label" runat="server" ForeColor="Gray">usuario</asp:Label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="Usuario_Inicio" class="form-control js_session_1" runat="server" Width="100%" MaxLength="10"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group etiqueta_contrasena">
                                        <asp:Label for="TextBox_Contrasena" class="col-sm-2 control-label" ID="Contrasena" runat="server" ForeColor="Gray">contraseña</asp:Label>
                                        <div class="col-sm-10">
                                            <asp:TextBox class="form-control js_session_2" ID="Password_Inicio" runat="server" Width="100%" MaxLength="10" TextMode="Password" onKeyPress="mayuscula_activado(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group etiqueta_olvido">                                   
                                        <div class="col-sm-12">
                                        <a href="Olvido_Contrasena.aspx" target="_parent" class="olvido" runat="server">¿olvidaste la contraseña?</a>  
                                        </div>
                                    </div>
                                    <div class="form-group margen_boton">
                                        <div class="col-sm-12" style="text-align:center">
                                            <asp:UpdatePanel ID="UpdatePanel_Ingresar" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="Boton_Iniciar_Session" runat="server" OnClick="Boton_Iniciar_Session_Click" OnClientClick="return validar_logueo()" Text="Iniciar Sesión" CssClass="btn btn-sm btn-primary"  />
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
        </section>


<%-- -----------------------------Registrarse ---------------------------------------- --%>     
        
        <section>
            <div class="container registro">
                <div class="row">
                    <div class="col-xs-12 hidden-xs">              
                        <div class="panel panel_registro">
                            <div class=" encabezado_registro panel-heading">Registrarse como Usuario</div>
                            <div class="panel-body" style="padding-bottom:0px">
                                <div class="form-horizontal" role="form" >
                                    <div class="form-group">
                                        <asp:Label ID="Usuario_Registrado" for="Usuario_Registro" CssClass="col-sm-2 control-label etiqueta_usuario" runat="server" ForeColor="Gray">usuario</asp:Label>
                                        <div class="col-sm-5">
                                            <asp:TextBox ID="Usuario_Registro" class="form-control registro_1" onKeyPress="return prohibido_blanco(event)" runat="server" Width="100%" MaxLength="10"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label for="Email_Registro" class="col-sm-2 control-label" ID="Registro_Correo" runat="server" ForeColor="Gray">correo</asp:Label>
                                        <div class="col-sm-5">
                                            <asp:TextBox class="form-control registro_4" ID="Correo_Registro" runat="server" TextMode="Email" MaxLength="30" Width="100%"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-5" style="text-align:center">
                                            <asp:Image ID="Image_Captcha" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Contrasena_1_Etiqueta" for="Password_1_Registro" CssClass="col-sm-2 control-label" runat="server" ForeColor="Gray">contraseña</asp:Label>
                                        <div class="col-sm-5">
                                            <asp:TextBox ID="Password_Registro" MaxLength="10" class="form-control registro_2" onKeyPress="mayuscula_activado(event)" TextMode="Password" runat="server" Width="100%"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-5" style="text-align:center">
                                            <asp:Label ID="Etiqueta_Captcha" runat="server" ForeColor="Gray" >ingrese la imágen</asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label for="Password_2_Registro" class="col-sm-2 control-label" ID="Contrasena_2_Etiqueta" runat="server"   ForeColor="Gray">confirme contraseña</asp:Label>
                                        <div class="col-sm-5">
                                            <asp:TextBox class="form-control registro_3" TextMode="Password" ID="RePassword_Registro" runat="server" Width="100%"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-5">
                                            <asp:TextBox class="form-control registro_5" style="text-align:center" ID="Captcha_Registro" runat="server" Width="100%" ></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-6">
                                            <div class="checkbox">
                                                <label style="color:gray">
                                                    <asp:CheckBox ID="Condiciones_Registro" runat="server" ForeColor="Gray" />
                                                    <a href="www.xelados.net" runat="server" id="condiciones_terminos"> acepto términos y condiciones</a>
                                                </label>
                                            </div>
                                        </div>
                                        <div class="col-sm-5 col-sm-offset-1" style="text-align:center">
                                            <asp:UpdatePanel ID="UpdatePanel_Registro" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="Boton_Enviar_Registro" runat="server" OnClick="Boton_Enviar_Registro_Click" OnClientClick="return validar_registro()" ForeColor="White" Text="Regístrese" CssClass="btn btn-sm btn-success" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>                           
                        </div>
                    </div>


                <%-- es la vista en el movil --%>
                    
                    <div class="col-xs-12 visible-xs">              
                        <div class="panel panel_registro">
                            <div class=" encabezado_registro panel-heading">Registrarse como Usuario</div>
                                <div class="panel-body cuerpo_registro">
                                    <div class="form-horizontal"  role="form" >
                                        <div class="form-group usuario_registro_movil">
                                            <asp:Label ID="Usuario_Registrado_Movil" for="Usuario_Registro_Movil" CssClass="col-sm-1 control-label etiqueta_usuario" runat="server" ForeColor="Gray">usuario</asp:Label>
                                            <div class="col-sm-11">
                                                <asp:TextBox ID="Usuario_Registro_Movil" class="form-control registro_1" onKeyPress="return prohibido_blanco(event)" runat="server" Width="100%" MaxLength="10"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group email_registro_movil">
                                            <asp:Label for="Email_Registro_Movil" class="col-sm-1 control-label" ID="Email_Registrado_Movil" runat="server" ForeColor="Gray">correo</asp:Label>
                                            <div class="col-sm-11">
                                                <asp:TextBox class="form-control registro_4" ID="Correo_Registro_Movil" runat="server" TextMode="Email" MaxLength="30" Width="100%"></asp:TextBox>
                                            </div>                                    
                                        </div>
                                        <div class="form-group contrasena_1_registro_movil">
                                            <asp:Label ID="Password_Registrado_Movil" for="Password_Registro_Movil" CssClass="col-sm-1 control-label" runat="server" ForeColor="Gray">contraseña</asp:Label>
                                            <div class="col-sm-11">
                                                <asp:TextBox ID="Password_Registro_Movil" MaxLength="10" class="form-control registro_2" onKeyPress="mayuscula_activado(event)" TextMode="Password" runat="server" Width="100%"></asp:TextBox>
                                            </div>                                   
                                        </div>
                                        <div class="form-group contrasena_registro_movil">
                                            <asp:Label for="Password_2_Registro_Movil" class="col-sm-1 control-label" ID="Password_2_Registrado_Movil" runat="server" style="margin-top:-10px"   ForeColor="Gray">confirme contraseña</asp:Label>
                                            <div class="col-sm-11">
                                                <asp:TextBox class="form-control registro_3" TextMode="Password" ID="RePassword_Registro_Movil" runat="server" Width="100%"></asp:TextBox>
                                            </div>                                    
                                        </div>
                                        <div class="form-group imagen_captcha_movil">
                                            <div class="col-sm-12" style="text-align:center">
                                                <asp:Image ID="Image_Captcha_Movil" Height="50" runat="server" />
                                            </div>
                                            <asp:Label ID="Captcha_Movil_Registrado" for="Captcha_Movil"  CssClass="col-sm-1 control-label" runat="server" ForeColor="Gray">ingrese la imágen</asp:Label>
                                            <div class="col-sm-11">
                                                <asp:TextBox class="form-control registro_5" style="text-align:center" ID="Captcha_Registro_Movil" runat="server" Width="100%" ></asp:TextBox>
                                            </div>
                                     <div class="form-group" style="margin-top:0px;margin-left: 0px;">
                                            <div class="col-sm-12">
                                                <div class="checkbox">
                                                    <label>
                                                        <asp:CheckBox ID="Condiciones_Registro_Movil"  runat="server"  ForeColor="Gray" />
                                                        <a href="www.xelados.net" runat="server" id="condiciones_terminos_movil"> acepto términos y condiciones</a>
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="col-sm-12" style="text-align:center; margin-top: 15px; margin-left: -10px;">
                                                <asp:UpdatePanel ID="UpdatePanel_Boton_Movil" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="Boton_Registro_Movil" runat="server" OnClick="Boton_Registro_Movil_Click" OnClientClick="return validar_registro()" ForeColor="White" Text="Regístrese" CssClass="btn btn-sm btn-success" />
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
            </div>
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
    

<%-- ------------------------------------Iniciar Session ----------------------------------------%>   

           <asp:UpdateProgress ID="Progreso" runat="server">
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
