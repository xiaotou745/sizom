$(document).ready(function () {

    $(".attention").click(function () {
        $.ajax({
            url: '/AjaxLogin/Attention',
            type: 'POST',
            data: { Id: $(this).attr("AttentionUserId") },
            dataType: 'Json',
            error: function () {
            },
            success: function (result) {
                if (result.IsLogOff) {
                    return alert("您还没有登录");
                }
                if (!result.IsError) {
                    alert("关注成功")
                    window.location.reload();
                } else {
                    alert(result.Message)
                }
            }
        });

    });
    $(".removeattention").click(function () {
        $.ajax({
            url: '/AjaxLogin/RemoveAttention',
            type: 'POST',
            data: { Id: $(this).attr("RemoveAttentionUserId") },
            dataType: 'Json',
            error: function () {
            },
            success: function (result) {
                if (result.IsLogOff) {
                    return alert("您还没有登录");
                }
                if (!result.IsError) {
                    alert("取消关注成功")
                    window.location.reload();
                } else {
                    alert(result.Message)
                }
            }
        });

    });
});