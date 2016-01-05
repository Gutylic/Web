<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesor_OnLine_Selector.aspx.cs" Inherits="Fenicia_Web.Profesor_OnLine_Selector" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Seleccionar Profesor</title>
    <script>
        function redireccionar() {

            var XS = "Profesor_On_Line_Movil.aspx";
            var MD = "Profesor_On_Line.aspx";
            var LG = "Profesor_On_Line.aspx";
            var SM = "Profesor_On_Line.aspx";

            if (screen.width >= 1200)
                window.location.href = LG;
            
            if (screen.width >= 992 && screen.width < 1200)
                window.location.href = MD;

            if (screen.width >= 768 && screen.width < 992)
                window.location.href = SM;
            
            if (screen.width < 537)
                window.location.href = XS;

        }
    </script>


<link rel="shortcut icon" type="image/png" href="favicon.icon" />
<link rel="apple-touch-icon" href="img/touch-icon.png"/>

</head>
<body onLoad="redireccionar()">
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
