//显示隐藏密码
$("#mainform .normalInput .showpassword").click(function () {
    $(this).hide();
    $('#mainform .normalInput #txtPassword').prop("type", 'password');
    $("#mainform .normalInput .hidepassword").show();
});
$("#mainform .normalInput .hidepassword").click(function () {
    $(this).hide();
    $('#mainform .normalInput #txtPassword').prop("type", 'text');
    $("#mainform .normalInput .showpassword").show();
});

$("#mainform  #hlkNormalRegister").click(function () {
    $("#mainform  #hlkNormalLogin").css("color", "#E5E5E5");
    $("#mainform  #hlkNormalRegister").css("color", "rgb(50, 165, 231)");

});
$("#mainform  #hlkNormalLogin").click(function () {
    $("#mainform  #hlkNormalRegister").css("color", "#E5E5E5");
    $("#mainform  #hlkNormalLogin").css("color", "rgb(50, 165, 231)");

});