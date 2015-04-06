function inilocation(container, countryobj, provinceobj, cityobj, valueobj) {
    if (countryobj.val() > 0) {
        load_province(countryobj.val(), provinceobj.val(), cityobj.val());
        load_city(provinceobj.val(), cityobj.val());
    }
    container.find(".country li").click(function () {
        valueobj.val($(this).val())
        $(".location").text($(this).text())

        load_province($(this).val(), 0, 0);
    });
    function load_province(countryid, provinceid, cityid) {
        if (countryid <= 0) {
            return;
        }
        $(".province").empty();
        $.ajax({
            url: '/Ajax/GetProvinceIdByCountry',
            type: 'POST',
            dataType: 'Json',
            data: { Id: countryid },
            success: function (returndata) {
                if (!returndata.IsError) {
                    $(".province").empty();
                    $(".city").empty();
                    for (var i in returndata.Data) {
                        var classname = "";
                        if (countryid == returndata.Data[i].Id) {
                            classname = "selected";
                        }
                        $(".province").append("<li class='" + classname + "' value='" + returndata.Data[i].Id + "'>" + returndata.Data[i].LocationName + "</li>")

                    }
                    $(".scrollp").jScrollPane();
                    $(".province li").click(function () {
                        valueobj.val($(this).val())
                        $(".location").text($(this).text())
                        load_city($(this).val(), cityid)
                    })
                }
                else {
                    alert(returndata.Message)

                }
            },
            error: function () {
                alert("提交失败")
            }
        });
    }
    function load_city(provinceid, cityid) {
        if (provinceid <= 0) {
            return;
        }

        $.ajax({
            url: '/Ajax/GetCityByProvince',
            type: 'POST',
            dataType: 'Json',
            data: { Id: provinceid },
            success: function (returndata) {
                if (!returndata.IsError) {
                    $(".city").empty();
                    for (var j in returndata.Data) {
                        var classname = "";
                        if (cityid == returndata.Data[j].Id) {
                            classname = "selected";
                        }
                        $(".city").append("<li class='" + classname + "' value='" + returndata.Data[j].Id + "'>" + returndata.Data[j].LocationName + "</li>")
                    }
                    $(".scrollp").jScrollPane();
                    $(".city li").click(function () {

                        valueobj.val($(this).val())
                        $(".location").text($(this).text())

                    })
                }
                else {
                    alert(returndata.Message)

                }
            },
            error: function () {
                alert("提交失败")
            }
        });
    }
    $(document).click(function (e) {

        if ($(".area").has($(e.target)).length > 0) {
            return false;
        }
        else {
            $(".areaFlBox").addClass("none");
        }
    })
    $(".location").click(function () {
        $(this).next().removeClass("none");
        $(".scrollp").jScrollPane();

    });
    $(".arearbutton").click(function () {
        $(".location").next().addClass("none")
    })
}
