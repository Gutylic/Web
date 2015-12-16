function validar_correo() { // correo lleno   
    
    if ($("#TextBox_Correo").val().length < 1) {        
        $("#TextBox_Correo").css({ border: "2px solid red" });
        var cliente = true;
    }
    else {
        $("#TextBox_Correo").css({ border: "2px solid green" });
        var cliente = false;
    }
    
    if (cliente) { // validacion para pasar al servidor el boton
        
        return false;
    }
    else {
       
        return true;
    }
}

// fin de la funcion