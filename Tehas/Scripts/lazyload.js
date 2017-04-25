var page = 2,
        buttonId = "#button-more",
        loadingId = "#loading-div",
        container = "#data-container";
$(loadingId).hide();


function lazyload(id) {
    
    obj = {
        "PageNumber": page,
        "CategoryId": id
    }

    var json = JSON.stringify(obj);
    $(buttonId).hide();
    $(loadingId).show();

    $.ajax({
        url: "/menu/load",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: json,
        success: function (response) {
            if (response.noElements) {
                $(buttonId).fadeOut();
                $(loadingId).hide();
                if (page == 1) {
                    $('#data-container').html("По вашему запросу не были найдены объявления");
                }
                return;
            } 
            appendContests(response);
        },
        error: function (response) {
            $(loadingId).hide();
            $("<span>Извините, при обработке запроса произошла ошибка. Пожалуйста обновите страницу</span>").appendTo($(container));
        }
    });
};

function lazyloadComments() {

    obj = {
        "page": page
    }

    var json = JSON.stringify(obj);
    $(buttonId).hide();
    $(loadingId).show();

    $.ajax({
        url: "/comments/load",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: json,
        success: function (response) {
            if (response.noElements) {
                $(buttonId).fadeOut();
                $(loadingId).hide();
                if (page == 1) {
                    $('#data-container').html("По вашему запросу не были найдены объявления");
                }
                return;
            }
            appendContests(response);
        },
        error: function (response) {
            $(loadingId).hide();
            $("<span>Извините, при обработке запроса произошла ошибка. Пожалуйста обновите страницу</span>").appendTo($(container));
        }
    });
};

var appendContests = function (response) {
    var id = $(buttonId);

    $(buttonId).show();
    $(loadingId).hide();

    $(response).appendTo($(container));
    page += 1;
};