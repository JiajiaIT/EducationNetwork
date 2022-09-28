//登录
$("#Login").click(function () {
    var username = $("#UserName").val();
    var password = $("#Password").val();
    var admin = {
        username: username,
        password: password
    }
    if (username == "" || password == "") {
        layer.msg('抱歉，账号或密码不能为空');
        return
    }
    else {
        $.post("/Manage/Account/Login", admin, function (data) {
            if (data.Code == 200 && data.Message == "登录成功") {
                layer.load(2);
                //此处演示关闭
                setTimeout(function () {
                    layer.closeAll('loading');
                }, 500);
                setTimeout(function () {
                    layer.msg('登录成功');
                    setTimeout(function () {
                        location.href = "/Manage/Admin/Index";
                    },100)
                    return;
                }, 510)
            }
            else {
                layer.load(2);
                //此处演示关闭
                setTimeout(function () {
                    layer.closeAll('loading');
                }, 500);
                setTimeout(function () {
                    layer.msg('抱歉，账号或密码错误');
                    return
                }, 510)

            }
        })
    }
})
