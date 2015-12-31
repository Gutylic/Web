<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sefue.aspx.cs" Inherits="Fenicia_Web.sefue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta name="viewport" content="width=device-width, initial-scale=1"/>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1"/>   

<title>Desconectado</title>          
    
    <!-- Jquery -->
    <script src="//code.jquery.com/jquery-1.11.0.min.js"></script>
   
    <!-- js Bootstrap 3 -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>

    <!-- CSS correspondiente a Bootstrap 3 -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />

    <!-- CSS con los estilos-->
    <script src="js/recuperar.js" type="text/javascript"></script>
   
    <!-- CSS con los estilos-->
   
    
</head>


<body>

    <form id="form1" runat="server">
     
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>     
        

<%-- ------------------------------------cabecera ---------------------------------------- --%>
        
       

<%-- ------------------------------------Panel de correo ---------------------------------------- --%>


        <section>
                                   
                    <div class="container">
                        <div class="row">
                            <div class="col-xs-12" style="text-align:center">
                                <asp:Image ID="Image_triste" ImageUrl="~/imagen/triste.png"  Height="100%" Width="100%"  runat="server" />
                            </div>
                            
                        </div>
                    </div>      
            </section>

              
<%-- ------------------------------------Panel del pie de la pagina --------------------------------%>        
                   
           
           

<%-- ------------------------------------Imagen de progreso ----------------------------------------%>   

          
                
    </form>

</body>

</html>
