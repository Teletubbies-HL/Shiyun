//显示隐藏密码
$(".normalInput .showpassword").click(function () {
    $(this).hide();
    $('.normalInput #UserPass').attr("type", 'password');
    $(".normalInput .hidepassword").show();
});
$(".normalInput .hidepassword").click(function () {
    $(this).hide();
    $('.normalInput #UserPass').attr("type", 'text');
    $(".normalInput .showpassword").show();
});

$("#hlkNormalRegister").click(function () {
    $("#hlkNormalLogin").css("color", "#E5E5E5");
    $("#hlkNormalRegister").css("color", "rgb(50, 165, 231)");
});
$("#hlkNormalLogin").click(function () {
    $("#hlkNormalRegister").css("color", "#E5E5E5");
    $("#hlkNormalLogin").css("color", "rgb(50, 165, 231)");

});