$(document).ready(function () {
    var ToUserId = 0;
    var ToMessageId = 0;
    $(".messagesubmit").click(function () {
        var message = $(this).parent().find("textarea").val();
        if ($.trim(message).length < 0) {
            return alert("请输入您要发送的信息");
        }
        $.ajax({
            url: '/AjaxLogin/SendMessage',
            type: 'POST',
            data: { TargetUserId: ToUserId, FromMessageId: ToMessageId, MessageContent: message },
            dataType: 'Json',
            error: function () {
            },
            success: function (result) {
                if (!result.IsError) {

                    $(".sendmessagepop .pop_close").click();
                    return alert("发送成功");
                }
                else {
                    return alert(result.Message);
                }
            }
        });

    })
    $(".sendmessage").click(function () {
        $(".sendmessagepop textarea").val("");
        ToMessageId = $(this).attr("ToMessageId");
        ToUserId = $(this).attr("ToUserId");
        $(".targettruename").text($(this).attr("ToUserTrueName") + ":")
        $.ajax({
            url: '/AjaxLogin/IsLogin',
            type: 'POST',
            dataType: 'Json',
            error: function () {
            },
            success: function (result) {
                if (result.IsLogOff) {
                    return alert("您还没有登录，请先登录")
                }
                else {


                    pop_message_dialog();
                }
            }
        });

    });
    $(".sendmessagedelete").click(function () {
        $.ajax({
            url: '/AjaxLogin/MessageSendDelete',
            type: 'POST',
            data: { Id: $(this).attr("MessageId") },
            dataType: 'Json',
            error: function () {
            },
            success: function (result) {
                if (result.IsLogOff) {
                    return alert("您还没有登录，请先登录")
                }
                if (!result.IsError) {
                    alert("删除成功");
                    window.location.reload();
                }
                else {
                    return alert(result.Message);
                }
            }
        });

    });
    $(".receivemessagedelete").click(function () {
        $.ajax({
            url: '/AjaxLogin/MessageReceiveDelete',
            type: 'POST',
            data: { Id: $(this).attr("MessageId") },
            dataType: 'Json',
            error: function () {
            },
            success: function (result) {
                if (result.IsLogOff) {
                    return alert("您还没有登录，请先登录")
                }
                if (!result.IsError) {
                    alert("删除成功");
                    window.location.reload();
                }
                else {
                    return alert(result.Message);
                }
            }
        });

    });
    $(".collectionadd").click(function () {
        $.ajax({
            url: '/AjaxLogin/WorksCollect',
            type: 'POST',
            data: { Id: $(this).attr("WorksId") },
            dataType: 'Json',
            error: function () {
            },
            success: function (result) {
                if (result.IsLogOff) {
                    return alert("您还没有登录，请先登录")
                }
                if (!result.IsError) {
                    alert("收藏成功");
                    window.location.reload();
                }
                else {
                    return alert(result.Message);
                }
            }
        });

    });
    $(".collectionremove").click(function () {
        $.ajax({
            url: '/AjaxLogin/WorksCollectRemove',
            type: 'POST',
            data: { Id: $(this).attr("WorksId") },
            dataType: 'Json',
            error: function () {
            },
            success: function (result) {
                if (result.IsLogOff) {
                    return alert("您还没有登录，请先登录")
                }
                if (!result.IsError) {
                    alert("删除成功");
                    window.location.reload();
                }
                else {
                    return alert(result.Message);
                }
            }
        });

    });
    function pop_message_dialog() {
        $(".sendmessagepop").fadeIn(500);
        $("<div class=\"pop_mark\"></div>").insertBefore($(".sendmessagepop"));
        $(".sendmessagepop .pop_close").unbind("click").click(function () {
            $(".sendmessagepop").fadeOut(500);
            $(".pop_mark").remove();
        });
    }

})