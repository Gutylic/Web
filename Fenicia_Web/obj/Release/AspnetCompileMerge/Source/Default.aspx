<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Fenicia_Web.Default" %>

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
    <%--<script src="js/bootstrap.min.js"></script>--%>

<!-- CSS correspondiente a Bootstrap 3 -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <script>
        // funcion de Abandono de Session
        function session_expirada()
        {
            $.ajax({
                type: "POST",
                url: "Default.aspx/Abandonar_Session",
                data: {},
                contenType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
            });
        }
        //fin de la funcion

    </script>
    
    <style type="text/css">
        #form1 {
            font-weight: 700;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:Panel ID="Panel_Inicial" runat="server">
            Usuario
            <asp:TextBox ID="Usuario_Inicio" runat="server" Width="298px"></asp:TextBox>
            <br />
            Password
            <asp:TextBox ID="Password_Inicio" runat="server" Width="282px"></asp:TextBox>
            <br />
            <br />
            mantener conectado
            <asp:CheckBox ID="Mantener_Session" runat="server" />
            <br />
            <br />
            <asp:Button ID="Boton_Iniciar_Session" UseSubmitBehavior="false" runat="server" Text="Inicio Sesion" OnClick="Boton_Iniciar_Session_Click" />
            <br />
            <br />
            <asp:LinkButton ID="Olvido_Password" runat="server" OnClick="Olvido_Password_Click" >Recuperar Contraseña</asp:LinkButton>
            <br />
            <br />
            <asp:Button ID="Boton_Registrese" runat="server" Text="Boton_Registrese" OnClick="Boton_Registrese_Click" />
            <br />
        </asp:Panel>
    
    
        <asp:Panel ID="Panel_Logueado" runat="server" Visible ="false">
            <asp:Label ID="Usuario_Logueado" runat="server"></asp:Label>
            <br />
            <br />
            <asp:LinkButton ID="Mis_Ejercicios" runat="server" OnClick="Mis_Ejercicios_Click" >Mis Ejercicios</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="Mis_Explicaciones" runat="server" OnClick="Mis_Explicaciones_Click">Mis Explicaciones</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="Panel_De_Control" runat="server" OnClick="Panel_De_Control_Click" >Panel de Control</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="Panel_De_Movimientos" runat="server" OnClick="Panel_De_Movimientos_Click" >Panel de Movimientos</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="Panel_De_Credito" runat="server" OnClick="Panel_De_Credito_Click">Panel de Credito</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="Cerrar_Sesion" runat="server"  OnClientClick="session_expirada()" OnClick="Cerrar_Sesion_Click" >X</asp:LinkButton>
        </asp:Panel>

        <asp:Panel ID="Panel_Profesor_On_Line" runat="server">
            <asp:Button ID="Boton_Profesor_On_Line" runat="server" Text="Profesor" OnClick="Boton_Profesor_On_Line_Click" />
        </asp:Panel>

        <asp:Panel ID="Panel_De_Registro" runat="server" Visible="false">
            <asp:LinkButton ID="Reenviar_Activacion" runat="server" OnClick="Reenviar_Activacion_Click">No llego el mail de activacion</asp:LinkButton>
            <br />
            Usuario
            <asp:TextBox ID="Usuario_Registro" runat="server" Width="383px"></asp:TextBox>
            <br />
            password
            <asp:TextBox ID="Password_Registro" runat="server" Width="388px"></asp:TextBox>
            <br />
            repassword
            <asp:TextBox ID="RePassword_Registro" runat="server" Width="393px"></asp:TextBox>
            <br />
            correo
            <asp:TextBox ID="Correo_Registro" runat="server" Width="396px"></asp:TextBox>
            <br />
            <asp:Image ID="Imagen_Captcha" runat="server" />
            <br />
            captcha
            <asp:TextBox ID="Captcha_Registro" runat="server"></asp:TextBox>
            <br />
            coondiciones
            <asp:CheckBox ID="Condiciones_Registro" runat="server" />
            <br />
            <br />
            <asp:Button ID="Boton_Enviar_Registro" runat="server" Text="Enviar Registro" OnClick="Boton_Enviar_Registro_Click" />
        </asp:Panel>
        <asp:Panel ID="Panel_DataList" runat="server">
            <asp:DataList ID="DataList_De_Resultados" runat="server" OnItemCommand="Identificador" OnItemDataBound="Logos_Asociados">
                <ItemTemplate>
                    <asp:Image ID="Imagen_Logos" runat="server" />
                    <asp:LinkButton ID="Titulos_De_Productos" runat="server" CommandName='<%# Eval ("ID_Ejercicio") %>'><%# Eval ("Titulo") %></asp:LinkButton>
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>
        <asp:Panel ID="Panel_Botonera_DataList" runat="server">
        <div id="Centros_Paginados" runat="server" visible="false">
            <asp:LinkButton ID="Siguiente" runat="server" OnClick="Siguiente_Click">Siguiente</asp:LinkButton>
            <asp:LinkButton ID="Anterior" runat="server" OnClick="Anterior_Click">Anterior</asp:LinkButton>
        </div>
        <div id="Extremos_Paginados" runat="server">
            <asp:LinkButton ID="Siguiente_Primero" runat="server" OnClick="Siguiente_Click"  >Siguiente</asp:LinkButton>
            <asp:LinkButton ID="Anterior_Ultimo" runat="server" visible="false" OnClick="Anterior_Click">Anterior</asp:LinkButton>
        </div>
        </asp:Panel>
        <asp:Panel ID="Productos_DataList_Inicial" runat="server">
            <asp:Image ID="Enunciado" runat="server" />
            <div id="Ejercicios_Y_Explicaciones" Visible="false" runat="server">
                <asp:Button ID="Boton_Compra_Ejercicio" runat="server" Text="Comprar Ejercicio" OnClick="Boton_Compra_Ejercicio_Click"  />
                <br />
                <asp:Button ID="Boton_Compra_Explicacion" runat="server" Text="Comprar Explicacion" OnClick="Boton_Compra_Explicacion_Click"  />
            </div>
            <div id="Videos" Visible="false" runat="server">
                <asp:Button ID="Boton_Compra_Video" runat="server" Text="Comprar Video" OnClick="Boton_Compra_Video_Click"  />
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel_Buscador" runat="server">
            <asp:Button ID="Boton_Buscar" runat="server" OnClick="Boton_Buscar_Click" Text="Buscar" />
        </asp:Panel>
        <asp:Panel ID="Panel_De_Buqueda" runat="server" Visible="false">
            Tema
            <asp:TextBox ID="Buscar_x_Tema" runat="server"></asp:TextBox>
            <br />
            <br />
            Materia
            <asp:TextBox ID="Buscar_x_Materia" runat="server"></asp:TextBox>
            <br />
            <br />
            Profesor
            <asp:TextBox ID="Buscar_x_Profesor" runat="server"></asp:TextBox>
            <br />
            <br />
            Año
            <asp:TextBox ID="Buscar_x_Ano" runat="server"></asp:TextBox>
            <br />
            <br />
            Colegio
            <asp:TextBox ID="Buscar_x_Colegio" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Boton_Buscar_Seleccion" runat="server" OnClick="Boton_Buscar_Seleccion_Click" Text="Buscar" />
        </asp:Panel>
        <asp:Panel ID="Panel_De_Comentarios_De_Los_Usuarios" runat="server">
            Nombre:
            <asp:TextBox ID="Nombre_Contacto" runat="server"></asp:TextBox>
            <br />
            <br />
            Correo:<asp:TextBox ID="Correo_Contacto" runat="server"></asp:TextBox>
            <br />
            <br />
            Comentario:<asp:TextBox ID="Comentario_Contacto" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Boton_Contacto" runat="server" Text="Enviar Comentario" OnClick="Boton_Contacto_Click" />
        </asp:Panel>
        <asp:Panel ID="Panel_De_Perfil_Del_Usuario" runat="server" Visible="false">
            Usuario
            <asp:Label ID="Usuario_Panel_Control" runat="server"></asp:Label>
            <br />
            <br />
            Password
            <asp:TextBox ID="Contrasena_Panel_Control" runat="server"></asp:TextBox>
            <br />
            <br />
            Correo
            <asp:TextBox ID="Correo_Panel_Control" runat="server"></asp:TextBox>
            <br />
            <br />
            Skype
            <asp:TextBox ID="Skype_Panel_Control" runat="server"></asp:TextBox>
            <br />
            <br />
            Celular
            <asp:TextBox ID="Celular_Panel_Control" runat="server"></asp:TextBox>
            <br />
            <br />
            Modelo
            <asp:TextBox ID="Modelo_Panel_Control" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Boton_Actualizar_Datos" runat="server" OnClick="Boton_Actualizar_Datos_Click" Text="Actualizar" />
        </asp:Panel>
        <asp:Panel ID="Panel_De_Movimientos_De_Los_Usuarios" runat="server">
            <asp:Label ID="Usuario_Mis_Movimientos" runat="server"></asp:Label>
            <asp:Label ID="Credito_Usuario" runat="server"></asp:Label>
            <asp:DataList ID="DataList_Mis_Movimientos" runat="server" Width="100%">
                <ItemTemplate>
                    <div>
                        <%# Eval ("Fecha_Del_Movimiento","{0:d}") %>
                    </div>
                    <div>
                        <%# Eval ("Descripcion_De_Movimiento") %>
                    </div>
                    <div>
                        <%# Eval ("Plata_Debe","{0:c2}") %>
                    </div>
                    <div>
                        <%# Eval ("Plata_Haber","{0:c2}") %>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>
        <asp:Panel ID="Panel_De_Carga_De_Credito" runat="server" Visible ="false">
            <asp:Button ID="Boton_Prestamo" runat="server" Text="Prestamo SOS" OnClick="Boton_Prestamo_Click" />
            <br />
            <br />
            Codigo:
            <asp:TextBox ID="Codigo_Tarjeta" runat="server" Width="230px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Boton_Cargar_Tarjeta" runat="server" Text="Cargar Tarjeta" OnClick="Boton_Cargar_Tarjeta_Click"/>
        </asp:Panel>
    </form>
</body>
</html>
