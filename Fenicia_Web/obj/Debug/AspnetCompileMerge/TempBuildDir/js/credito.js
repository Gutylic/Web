/*evitar que cada boton cargue valores vacios*/
function validar_textbox_pagofacil() {
    if ($("#TextBox_PagoFacil").val().length < 1) {
        return false;
    }
    else {
        return true;
    }
};

function validar_textbox_tarjeta() {

    if ($("#TextBox_Tarjeta").val().length < 1) {
        return false;
    }
    else {
        return true;
    }
};

function validar_textbox_cuenta_digital() {
    if ($("#TextBox_Cuenta_Digital").val().length < 1) {
        return false;
    }
    else {
        return true;
    }
};

function validar_textbox_mercado_pago() {

    if ($("#TextBox_Mercado_Pago").val().length < 1) {
        return false;
    }
    else {
        return true;
    }

};

function validar_textbox_paypal() {
    if ($("#TextBox_PayPal").val().length < 1) {
        return false;
    }
    else {
        return true;
    }
};


function validar_textbox_pagofacil_movil() {
    if ($("#TextBox_PagoFacil_Movil").val().length < 1) {
        return false;
    }
    else {
        return true;
    }
};

function validar_textbox_prepago_movil() {

    if ($("#TextBox_Prepago_Movil").val().length < 1) {
        return false;
    }
    else {
        return true;
    }
};

function validar_textbox_cuenta_digital_movil() {
    if ($("#TextBox_Cuenta_Digital_Movil").val().length < 1) {
        return false;
    }
    else {
        return true;
    }
};

function validar_textbox_mercado_pago_movil() {

    if ($("#TextBox_Mercado_Pago_Movil").val().length < 1) {
        return false;
    }
    else {
        return true;
    }

};

function validar_textbox_paypal_movil() {
    if ($("#TextBox_PayPal_Movil").val().length < 1) {
        return false;
    }
    else {
        return true;
    }
};

//no permite escribir letras dentro de los textbox
function ValidNum() {
    if (event.keyCode < 48 || event.keyCode > 57) {
        event.returnValue = false;
    }
}


$(document).ready(function () { /* efecto hover sobre la botonera */

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

