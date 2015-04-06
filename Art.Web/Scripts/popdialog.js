function pop_up_dialog(popdiv) {
    popdiv.fadeIn(500);
    $("<div class=\"pop_mark\"></div>").insertBefore(popdiv);
    popdiv.find(".pop_close").unbind("click").click(function () {
        popdiv.fadeOut(500);
        $(".pop_mark").remove();
    });
}