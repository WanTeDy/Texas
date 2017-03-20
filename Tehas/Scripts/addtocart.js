function showcart(id) {
    var disp = $("#order_" + id).css("display");
    if (disp == "none") {
        $("#order_" + id).css("display", "flex");
    } else {
        $("#order_" + id).css("display", "none");
    }
}

function addtocart(id) {
    var quantity = $("#quantity_" + id).val();
    var obj = {
        "Id": id,
        "Quantity": quantity
    }

    var json = JSON.stringify(obj);
    //$(buttonId).hide();
    //$(loadingId).show();

    $.ajax({
        url: "/cart/add",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: json,
        success: function (response) {
            $("#display_" + id).css("display", "block");
            setTimeout(function () {
                $("#display_" + id).css("display", "none");
            }, 1500);
        },
        error: function (response) {
        //    $(loadingId).hide();
        //    $("<span>Извините, при обработке запроса произошла ошибка. Пожалуйста обновите страницу</span>").appendTo($(container));
        }
    });
};

function changequantity(id) {
    var quantity = $("#quantity_" + id).val();
    var obj = {
        "Id": id,
        "Quantity": quantity
    }

    var json = JSON.stringify(obj);
    //$(buttonId).hide();
    //$(loadingId).show();

    $.ajax({
        url: "/cart/changequantity",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: json,
        success: function (response) {

        },
        error: function (response) {
            //    $(loadingId).hide();
            //    $("<span>Извините, при обработке запроса произошла ошибка. Пожалуйста обновите страницу</span>").appendTo($(container));
        }
    });
};

