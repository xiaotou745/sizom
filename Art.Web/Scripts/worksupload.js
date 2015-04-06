$(document).ready(function () {
    $(".datepicker").click(function () {

        WdatePicker();
    })

    iniradiobutton($("#WorkSizeType"));
    iniselect($(".arttype"), $("#WorksType"));

    bindclick();
    function bindclick() {
        $("#worksimages").find("ul").each(function () {
            if (($("#worksimages").find("ul").index($(this)) + 1) % 4 == 0) {
                $(this).removeClass("mg_r20");

            }
            else {

                $(this).removeClass("mg_r20").addClass("mg_r20");
            }
        })
        $(".imagedelete").unbind("click").click(function () {
            var index = $(".imagedelete").index($(this));
            $.ajax({
                url: '/ArtistAccount/WorksImageDelete',
                type: 'POST',
                dataType: 'Json',
                data: { Id: index },
                success: function (returndata) {
                    if (!returndata.IsError) {
                        alert("删除成功")
                        $("#worksimages").find("ul:eq(" + index + ")").remove();
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

    if ($("#worksimages").find('img').length == 0) {
        $("#imageupload").text("添加图片");
    }

    new AjaxUpload($("#imageupload"), {

        action: '/artistaccount/WorksImageUpload',
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
            var classname = "f_l mg_r20 mg_b20";
            if ($("#worksimages").find('img').length > 0) {
                $("#imageupload").text("继续添加图片");
            }
            if (($("#worksimages").find('img').length + 1) % 4 == 0) {
                classname = "f_l mg_b20";
            }
            $("#imageupload").before("<ul class='" + classname + "'><li><a href='#'><img width='200px' height='160px' src='" + $("#imageserverurl").val() + response.Data + "'/> </a></li><li><a class='imagedelete'  href='###'>删除</a></li></ul>");
            bindclick();
        }
    });
    $("#workssubmit").click(function () {
        var worksizetype = $('#WorkSizeType').val();
        $("#FinishTime").val($(".datepicker").text())
        $("#WorkSizeLength").val($("#WorkSizeLength" + worksizetype).val());
        $("#WorkSizeHeight").val($("#WorkSizeHeight" + worksizetype).val());
        $("#WorkSizeWidth").val($("#WorkSizeWidth" + worksizetype).val());
        if (!$.formValidator.pageIsValid('1'))
        {
            return;
        }
        $.ajax({
            url: '/ArtistAccount/WorksUploadSave',
            type: 'POST',
            dataType: 'Json',
            data: $("#workupload").serialize(),
            success: function (returndata) {
                if (!returndata.IsError) {
                    alert("保存成功")
                    window.location.href = "/artistaccount/works/" ;
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
    