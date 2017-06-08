
$("#mainform .normalInput .showpassword").click(function () {
    $(this).hide();
    $('#mainform .normalInput #txtPassword').prop("type", 'password');
    $('#mainform .normalInput #txtRePassword').prop("type", 'password');
    $("#mainform .normalInput .hidepassword").show();
});
$("#mainform .normalInput .hidepassword").click(function () {
    $(this).hide();
    $('#mainform .normalInput #txtPassword').prop("type", 'text');
    $('#mainform .normalInput #txtRePassword').prop("type", 'text');
    $("#mainform .normalInput .showpassword").show();
});
//用户名
$("#mainform .normalInput #txtUser").focus(function () {
    //显示提示
    $("#mainform .tip").show();
    $("#mainform .tip").css({
        left: "285px",
        top: "30px"
    });
    $("#mainform .tip1").text("长度为4-30个字符，支持数字、字母、下划线，字母开头");

});
$("#mainform .normalInput #txtUser").blur(function() {
    
        $("#mainform .tip").hide();
            //  验证用户名
            var reg = /^[a-zA-Z]{1}([a-zA-Z0-9_]*)[a-zA-Z0-9]{3,29}$/;
            //alert($("#mainform .normalInput #txtUser").val()); 获取输入的内容
            if (!reg.test($("#mainform .normalInput #txtUser").val())) {
                $("#mainform .normaluser").css({
                    border: "1px solid red"
                });
                $("#mainform .usertip").text("用户名格式错误");
                //alert("1");
            } else {

                $.ajax({
                    type:'POST',
                    url: "/UserInfo/Pipei",
                    data: { id: $("#txtUser").val() },
                    success: function (msg) {
                        if (msg == "1") {
                            $("#mainform .usertip").text("该用户名已被占用");
                            $("#mainform .normaluser").css({
                                border: "1px solid red"
                            });
                        } else {
                            $("#mainform .normaluser").css({
                                border: "1px solid #1ece6d"
                            });
                            $("#mainform .usertip").text("");
                        }
                    }
                });


                
            }
    });
//密码
    $("#mainform .normalInput #txtPassword").focus(function() {
        $("#mainform .tip").show();
        $("#mainform .tip").css({
            left: "285px",
            top: "105px"
        });
        $("#mainform .tip1").text("长度为8-16个字符，区分大小写，至少包含两种类型");
    });
    $("#mainform .normalInput #txtPassword").blur(function() {
        $("#mainform .tip").hide();
        //  验证密码
        var reg = /^(?![0-9]+$)(?![a-zA-Z]+$)[a-zA-Z0-9\?\-\^\+\$\.*%&=_#@!~&]{7,15}$/;
        if (!reg.test($("#mainform .normalInput #txtPassword").val())) {
            $("#mainform .normalpassword").css({
                border: "1px solid red",
            });
            $("#mainform .passtip").text("密码应为8-16个字符，区分大小写");
        } else {
            $("#mainform .normalpassword").css({
                border: "1px solid #1ece6d"
            });
            $("#mainform .passtip").text("");
        }
    });
//确认密码
    $("#mainform .normalInput #txtRePassword").focus(function() {
        $("#mainform .tip").show();
        $("#mainform .tip").css({
            left: "285px",
            top: "180px"
        });
        $("#mainform .tip1").text("与密码一致");
    });
    $("#mainform .normalInput #txtRePassword").blur(function() {
        $("#mainform .tip").hide();
        //  验证密码
        if ($("#mainform .normalInput #txtRePassword").val() != $("#mainform .normalInput #txtPassword").val()) {
            $("#mainform .normalrepassword").css({
                border: "1px solid red"
            });
        } else {
            $("#mainform .normalrepassword").css({
                border: "1px solid #1ece6d"
            });
            $("#mainform .repasstip").text("");
        }
    });
//邮箱
    $("#mainform .normalmail #txtMail").focus(function() {
        $("#mainform .tip").show();
        $("#mainform .tip").css({
            left: "285px",
            top: "255px"
        });
        $("#mainform .tip1").text("请输入邮箱");
    });
    $("#mainform .normalmail #txtMail").blur(function() {
        $("#mainform .tip").hide();
        // 邮箱验证码
        var reg = /^[A-Za-zd\d]+([-_.][A-Za-z\d]+)*@([A-Za-z]+[-.])+[A-Za-zd]{2,5}$/;
        if (!reg.test($("#mainform .normalmail #txtMail").val())) {
            $("#mainform .normalmail").css({
                border: "1px solid red"
            });
            $("#mainform .mailtip").text("邮箱格式错误");
        } else {
            $("#mainform .normalmail").css({
                border: "1px solid #1ece6d"
            });
            $("#mainform .mailtip").text("");
        }
    });
//checkbox
    $(".chebox-before").click(function () {
        $(".chebox-before").hide();
        $(".chebox-after").show();
        $("#ckbAgree").prop("checked", true);
        //if ($("#ckbAgree").is(":checked")) {
        //    alert("1");
        //}
        //else {
        //    alert("0");
        //}
    });
    $(".chebox-after").click(function () {
        $(".chebox-after").hide();
        $(".chebox-before").show();
        $("#ckbAgree").prop("checked", false);
        //if ($("#ckbAgree").is(":checked")) {
        //    alert("1");
        //}
        //else {
        //    alert("0");
        //}
    });
$("#btnRegister").click(function() {
    if ($("#ckbAgree").is(":checked")) {
        //alert("1");
    } else {
        $("#mainform .checkField .chebox-before").css({
            color: "red"
        });
        $("#mainform .checkField .chebox").css({
            color: "red"
        });
        return false;
    }
});

    $("#mainform  #hlkNormalRegister").click(function() {
        $("#mainform  #hlkNormalLogin").css("color", "#E5E5E5");
        $("#mainform  #hlkNormalRegister").css("color", "rgb(50, 165, 231)");

    });
    $("#mainform  #hlkNormalLogin").click(function() {
        $("#mainform  #hlkNormalRegister").css("color", "#E5E5E5");
        $("#mainform  #hlkNormalLogin").css("color", "rgb(50, 165, 231)");
    });