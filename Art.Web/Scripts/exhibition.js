$(document).ready(function () {
    inilocation($(".area"), $("#countryid"), $("#provinceid"), $("#cityid"), $("#Location"));

    $(".datepicker").click(function () {

        WdatePicker();
    })

    new AjaxUpload($("#imageupload"), {

        action: '/artistaccount/ExhibitionImageUpload',
        responseType: 'Json',
        onSubmit: function (file, ext) {
            if (!(ext && /^(jpg|jpeg|JPG|JPEG|PNG|png)$/.test(ext))) {
                $("#imageupload").next().removeClass("correctTip").addClass("errorTip").text("图片格式不正确,请选择 jpg 格式的文件!");
                return false;
            }
            $("#imageupload").next().removeClass("correctTip").removeClass("errorTip").text("图片上传中....");

        },
        onComplete: function (file, response) {
            if (response.IsError) {
                $(this).next().removeClass("correctTip").addClass("errorTip").text(response.Message);
                return false;
            }
            $("#imageupload").next().removeClass("errorTip").addClass("correctTip").text("上传成功");
            var classname = "ulList w110 pd_b20 mg_r20";
            if ($("#exhibitionimage").find('img').length > 0) {
                $("#imageupload").text("继续添加图片");
            }
            if (($("#exhibitionimage").find('img').length + 1) % 6 == 0) {
                classname = "ulList w110 pd_b20";
            }
            $("#exhibitionimage").append("<ul class='" + classname + "'><li><a href='#'><img width='110px' height='73px' src='" +$("#imageserverurl").val()+response.Data + "'/> </a></li><li><a class='imagedelete'  href='###'>删除</a></li></ul>");
            bindclick();
        }
    });
    bindclick();
    function bindclick() {
        $("#exhibitionimage").find("ul").each(function () {
            if (($("#exhibitionimage").find("ul").index($(this)) + 1) % 6 == 0) {
                $(this).removeClass("mg_r20");

            }
            else {

                $(this).removeClass("mg_r20").addClass("mg_r20");
            }
        })
        $(".imagedelete").unbind("click").click(function () {
            var index = $(".imagedelete").index($(this));
            $.ajax({
                url: '/ArtistAccount/ExhibitionImageDelete',
                type: 'POST',
                dataType: 'Json',
                data: { Id: index },
                success: function (returndata) {
                    if (!returndata.IsError) {
                        alert("删除成功")
                        $("#exhibitionimage").find("ul:eq(" + index + ")").remove();
                        bindclick();
                    }
                    else {
                        alert(returndata.Message)

                    }
                },
                error: function () {
                    alert("提交失败")
                }
            });
        })
    }

    $("#exhibition").click(function () {
        $("#ExhibitionEndDate").val($(".ExhibitionEndDate").text())
        $("#ExhibitionStartDate").val($(".ExhibitionStartDate").text())
        if (!$.formValidator.pageIsValid('1')) {
            return;
        }
        $.ajax({
            url: '/ArtistAccount/ExhibitionUploadSave',
            type: 'POST',
            dataType: 'Json',
            data: $("#exhibtionform").serialize(),
            success: function (returndata) {
                if (!returndata.IsError) {
                    alert("保存成功")
                    window.location.href = "/artistaccount/exhibitions/";
                }
                else {
                    alert(returndata.Message)

                }
            },
            error: function () {
                alert("提交失败")
            }
        })

    })
});