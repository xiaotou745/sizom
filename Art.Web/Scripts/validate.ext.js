$(document).ready(function () {
    $(".inpCom").click(function () {

        $(this).parent().next().find("span").removeClass().addClass("tips").empty().text($(this).attr("tips"));
    })
})