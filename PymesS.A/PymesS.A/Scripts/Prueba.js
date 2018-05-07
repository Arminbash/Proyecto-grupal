var maxArt;
var cuentaDetalle = 1;

var Ordenes = @ViewBag.Ordenes

//function DesactivarBoton(tipo, id) {
//    if (tipo.localeCompare('Producto') == 0) {
//        $("#Producto_" + id).prop("disabled", true);
//    }
//}

//function activarBoton(tipo, id) {
//    if (tipo.localeCompare('Producto') == 0) {
//        $("#Producto_" + id).prop("disabled", false);
//    }
//}

function agregarObjeto(tipo, numero, id) {
    if (tipo.localeCompare('Producto') == 0) {
        //DesactivarBoton(tipo, id);
        agregarAlDetalle("-", $("#Nombre_" + numero).text(), $("#Inventario_" + numero).text(), $("#Cantidad_" + numero).text(), $("#Precio_" + numero).text(), id, "Producto");

    }

}

function agregarAlDetalle(codigo, nombre, inventario, cantidad, precio, id, tipo) {

    var registro = "<tr id='fila" + cuentaDetalle + "' data-id='" + id + "' data-tipo='" + tipo + "' ><td>" + cuentaDetalle + "</td><td>" + nombre + "</td><td>" + inventario + "</td><td>" + precio + "</td><td>" + cantidad +  "</td><td id='precio" + cuentaDetalle + "'>" + precio + "</td><td><input type='number' id='cantidad" + cuentaDetalle + "' onClick='cambiar(" + cuentaDetalle + ")' class='form-control' value='" + 1 + "'/></td><td id='subTotal" + cuentaDetalle + "'>" + precio + "</td><td ><a id='eliminar" + cuentaDetalle + "' onclick='eliminar(" + cuentaDetalle + ")'>Eliminar</a></td></tr>";

    $("#bodyTablaDetalle").append(registro);

    //var valor = parseInt($("#totalPrecio").val()) + parseInt(precio)
    //$("#totalPrecio").val(valor);

    cuentaDetalle++;
}


function cambiar(i) {
    $('#cantidad' + i).change(function () {
        $("#subTotal" + i).text(parseInt($("#precio" + i).text() * parseInt($("#cantidad" + i).val())));
        // recalcula el total
        calcularTotal();

    });
}

function calcularTotal() {
    var valor = 0;
    for (let j = 1; j < cuentaDetalle; j++) {
        valor += parseInt($("#subTotal" + j).text());
    }

    $("#totalPrecio").val(valor);
}

function eliminar(i) {

    activarBoton($("#fila" + i).attr("data-tipo"), $("#fila" + i).attr("data-id"));
    $("#fila" + i).remove();


    if (i >= 1) {
        reOrdenar(i);
    }
    // si cuentaDetalle == 1 significa que ya no hay registros
    if (cuentaDetalle > 1) {
        cuentaDetalle--;
    }
    calcularTotal();
}

function reOrdenar(j) {
    for (let i = j; i < cuentaDetalle; i++) {
        $('#fila' + i).attr('id', 'fila' + (i - 1));

        //$('#fila' + i).attr('id', 'fila' + (i - 1));
        //$('#fila' + i).attr('id', 'fila' + (i - 1));


        $('#precio' + i).attr('id', 'precio' + (i - 1));

        $('#cantidad' + i).attr('onclick', 'cambiar(' + (i - 1) + ')');
        $('#cantidad' + i).attr('id', 'cantidad' + (i - 1));


        $('#subTotal' + i).attr('id', 'subTotal' + (i - 1));

        $('#eliminar' + i).attr('onclick', 'eliminar(' + (i - 1) + ')');
        $('#eliminar' + i).attr('id', 'eliminar' + (i - 1));
    }


}

function agregarDatosDeTabla() {
    //var tabla;  // usarlo como array

    var tipo, id, cantidad;

    tipo = "<input type='text' id='detalleTotal' name='detalleTotal' value='" + cuentaDetalle + "' />";
    $(".escondido").append(tipo);

    for (let i = 1; i < cuentaDetalle; i++) {

        tipo = "<input type='text' id='detalleTipo" + i + "' name='detalleTipo" + i + "' value='" + $("#fila" + i).attr("data-tipo") + "' />";
        $(".escondido").append(tipo);

        id = "<input type='text' id='detalleId" + i + "' name='detalleId" + i + "' value='" + $("#fila" + i).attr("data-id") + "' />";
        $(".escondido").append(id);

        cantidad = "<input type='text' id='detalleCantidad" + i + "' name='detalleCantidad" + i + "' value='" + $('#cantidad' + i).val() + "' />";
        $(".escondido").append(cantidad);

        //  tipo                                   id                           cantidad
        //tabla[i] = [$("#fila" + i).attr("data-tipo"), $("#fila" + i).attr("data-id"),$('#cantidad' + i).val()];
    }

    $("#enviar").trigger("click");


}

function mostrarOrdenes(i) {
    $('#cliente').change(function () {
        // ver como agregar la lista aqui

        $("#ordenes" + i).text(parseInt($("#precio" + i).text() * parseInt($("#cantidad" + i).val())));
        // recalcula el total
        calcularTotal();

    });
}