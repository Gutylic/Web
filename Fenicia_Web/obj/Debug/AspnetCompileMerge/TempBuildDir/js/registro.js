//funcion de validacion del registro
function validar_registro() {

    var cliente = false; // permite al boton ser de servidor 
    if ($("#Condiciones_Registro").is(':checked')) { // acepto terminos
        $("#condiciones_terminos").css({ color: "#428BCA" });
    }
    else // no acepto terminos
    {
        $("#condiciones_terminos").css({ color: "red" });
        
        var cliente = true;// no permite que el boton sea de servidor
    }
    for (var x = 1; x <= 5; x++) { // funcion de validacion de casilleros vacios
        if ($(".registro_" + x).val().length < 1) { // ver si algun casillero esta vacio
            $(".registro_" + x).css({ border: "2px solid red" });
           
            
            var cliente = true;// no permite que el boton sea de servidor
        }
        else// todos los casilleros bien
        {
            $(".registro_" + x).css({ border: "2px solid green" });
        }
    }
    if ($(".registro_2").val().length < 5) { // validacion de password de mas de 6 caracteres
        $(".registro_2").css({ border: "2px solid red" });        
        $(".registro_2").val("");
        var cliente = true;// no permite que el boton sea de servidor        
    }
    if ($(".registro_2").val() != $(".registro_3").val()) { // comparacion de los password
        $(".registro_2").css({ border: "2px solid red" });
        $(".registro_2").val("");
        $(".registro_3").css({ border: "2px solid red" });
        $(".registro_3").val("");
        var cliente = true;// no permite que el boton sea de servidor
        
    }
    if ($(".registro_4").val().indexOf('@', 0) == -1 || $(".registro_4").val().indexOf('.', 0) == -1) // mira si el correo tiene un @ y un punto para validarlo
    {
        $(".registro_4").css({ border: "2px solid red" });
        var cliente = true;// no permite que el boton sea de servidor
        
    }

   

    if (cliente) { // validacion para pasar al servidor el boton
        alert("verifique los casilleros en rojo");
        return false;
    }
    else {
        
        return true;
    }
}
// fin de la funcion


// funcion de mayusculas activado
function mayuscula_activado(e) {
    var fKeyCode = 0;
    var myShiftKey = true;
    var myMsg = 'El bloqueo de mayúsculas esta activado, es posible que escriba incorrectamente la contraseña';
    if (document.all) {
        fKeyCode = e.keyCode;
        myShiftKey = e.shiftKey;
    }
    else if (document.layers) {
        fKeyCode = e.which;
        myShiftKey = (fKeyCode == 16) ? true : false;
    }
    else if (document.getElementById) {
        fKeyCode = e.which;
        myShiftKey = (fKeyCode == 16) ? true : false;
    }
    if ((fKeyCode >= 65 && fKeyCode <= 90) && !myShiftKey) {
        alert(myMsg);
    }
}
// fin de la funcion


// funcion de prohibir caracteres blancos en el usuario y el correo
function pohibido_blanco(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 32) return false;
}
// fin de la funcion


// limpiar todos los campos del registro al cerrarlo 
function limpiar_registro() {
    for (var x = 1; x <= 5; x++) {
        $(".registro_" + x).val('');
        $(".registro_" + x).css({ border: "1px solid #cccccc" });
    }
    $("#Condiciones_Registro").attr('checked', false);
    $("#condiciones_terminos").css({ color: "#428BCA" });
}
// fin de la funcion

