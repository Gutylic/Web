$(document).ready(function () {


    //Carrusel para que arranque funcionando
    $('.carousel').carousel();


    //Scroll
    $('.scroll-link').on('click', function (event) {
        event.preventDefault();
        var sectionID = $(this).attr("data-id");
        scrollToID("#" + sectionID, 750);
    });

    $('.scroll-top').on('click', function (event) {
        event.preventDefault();
        $('html, body').animate({ scrollTop: 0 }, 'slow');
    });


    // agrega la botonera para el Menu movil
    $('#mobile-menu-button').click(function () {
        $("#mobile-main-menu").slideToggle("slow");
    });


    // Scroll para el movil
    $('.scroll').click(function () {
        $("#main-header").css({ position: "fixed" });
    });

    $('.scroll-movil').click(function () {
        $("#mobile-main-menu").slideToggle("slow");
        $("#main-header").css({ position: "absolute" });
    });


    // funcion de scroll
    function scrollToID(id, speed) {
        var offSet = 50;
        var targetOffset = $(id).offset().top - offSet;
        var mainNav = $('#main-nav');
        $('html,body').animate({ scrollTop: targetOffset }, speed);
        if (mainNav.hasClass("open")) {
            mainNav.css("height", "1px").removeClass("in").addClass("collapse");
            mainNav.removeClass("open");
        }
    }
    if (typeof console === "undefined") {
        console = {
            log: function () { }
        };
    }
    // fin de la funcion
});


// funcion de validacion del logueo
function validar_logueo() {
    
    var cliente = true; // no permite que el boton se convierta en boton de servidor
    if ($(".js_session_1").val().length > 1 && $(".js_session_2").val().length < 1 || $(".js_session_1").val().length < 1 && $(".js_session_2").val().length > 1) { // usuario y password uno de los dos no vacios
        for (var x = 1; x <= 2; x++) {
            if ($(".js_session_" + x).val().length < 1) {
                $(".js_session_" + x).css({ border: "2px solid red" });
                alert("ningún campo puede encontrarse vacio");
                var cliente = true;// no permite que el boton se convierta en boton de servidor
            }
            else {
                $(".js_session_" + x).css({ border: "2px solid green" });
            }
        }
    }
    else // ahora analizamos los dos ultimos casos que los dos casilleros se encuentren vacios y llenos
    {
        if ($(".js_session_1").val().length > 1 && $(".js_session_2").val().length > 1) { // aca estan los casilleros llenos
            var cliente = false;//permite que el boton se convierta en boton de servidor
        }
        else // aca estan los dos casilleros vacios
        {
            for (var x = 1; x <= 2; x++) {
                $(".js_session_" + x).css({ border: "1px solid #cccccc" });
            }
        }
    }
    if (cliente) { // validacion para convertir boton en servidor o de cliente                
        return false;
    }
    else {
        return true;
    }
}
//fin de la funcion


// funcion de validacion del comentario
function validar_comentario() {

    var cliente = true; // no permite que el boton se convierta en boton de servidor
    for (var x = 1; x <= 3; x++) {

        if ($("js.contacto_" + x).val().length < 1) {
            $("js.contacto_" + x).css({ border: "2px solid red" });
           
            var cliente = true; // no permite que el boton se haga de servidor
        } else {
            $("js.contacto_" + x).css({ border: "2px solid #7CFF60" });
            var cliente = false; // permite que el boton sea de servidor
        }

    }

    if (cliente) { // validacion para convertir boton en servidor o de cliente                
        alert("ningún campo puede encontrarse vacio");
        return false;
    }
    else {
        return true;
    }
}
//fin de la funcion


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


// funcion de Abandono de Session
function session_expirada() {
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


