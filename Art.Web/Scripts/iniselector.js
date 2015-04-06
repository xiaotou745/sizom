function iniradiobutton(selector) {
    var index = selector.val() - 1;
    $(".radioIcon:eq(" + index + ")").addClass("checked");
    $(".radioIcon").click(function () {
        if ($(this).parent().hasClass("checked")) {
            return false;
        }
        else {
            $(".radioIcon").parent().removeClass("checked");
            $(this).parent().addClass("checked");
            selector.val($(this).attr("value"));


        }
    });
}
function iniselect(selectcontainer, selector) {
    selectcontainer.find(".selSpan").click(function () {
        $(this).next().removeClass("none").jScrollPane();
        $(".jspPane").width(130);

    })
    selectcontainer.find(".selUl li").hover(
                    function () {
                        $(this).addClass("hovername");
                        $(this).siblings().removeClass("hovername");
                    },
                    function () {
                        $(this).removeClass("hovername");
                    });
                    selectcontainer.find(".selUl li").click(function () {
                        $(this).parents(".selDiv").prev().text($(this).text());
                        $(this).parents(".selDiv").addClass("none");
                        $(this).addClass("selected").siblings().removeClass("selected");
               selector.val($(this).val());


                    })
    $(document).click(function (e) {
        if (selectcontainer.has($(e.target)).length > 0) {
            return false;
        }
        else {
            selectcontainer.find(".selDiv").addClass("none");
        }
    })
}