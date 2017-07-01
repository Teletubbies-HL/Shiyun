(function ($) {
    //屏蔽，适合单个元素.
    $.fn.mask = function () {
        var divHtml = '<div class="divMask" style="position: absolute; width: 100%; height:90px; left: 0px; top: -43px; background: #fff; opacity: 0; filter: alpha(opacity=0)"> </div>';
        $(this).wrap('<span style="position: relative"></span>');
        $(this).parent().append(divHtml);
        $(this).data("mask", "true");
    }
    //取消屏蔽
    $.fn.unmask = function () {
        $(this).parent().find(".divMask").remove();
        $(this).unwrap();
        $(this).data("mask", "false");
    }
    $.fn.mask2 = function () {
        var divHtml = '<div class="divMask2" style="position: absolute; width: 440px; height:60px; left: 146px; top: -75px; background: #fff; opacity: 0; filter: alpha(opacity=0)"> </div>';
        $(this).wrap('<span style="position: relative"></span>');
        $(this).parent().append(divHtml);
        $(this).data("mask2", "true");
    }
    //取消屏蔽
    $.fn.unmask2 = function () {
        $(this).parent().find(".divMask2").remove();
        $(this).unwrap();
        $(this).data("mask2", "false");
    }
})(jQuery);

$(function () {
    var zongfenshu;
    var xuanzetidaan;
    $("#btn1").click(function () {
        
        $("#line2").css("background-color", "#4cd964");
        $("#rightbox1").hide();
        $("#rightbox2").css("display", "block");
        var daan = $(".a_1").text();
        $('#userdaan1').val(daan);
        $.ajax({
            url: "/Challenge/Panduan",
            type: "post",
            anync: true,
            data: { userdaan: $('#userdaan1').val(), id: $('#timu1id').val() },
            success: function (data) {
                if (data == "成功") {
                    $("#number1").css({ border: '1px solid #4cd964', color: '#4cd964' });
                    zongfenshu = 10 * 1 + $('.fs1').text() * 1;
                } else {
                    $("#number1").css({ border: '1px solid red', color: 'red' });
                    zongfenshu =  $('.fs1').text() * 1;
                }
                $('.fenshu').text(zongfenshu);
                zongfenshu = $('.fenshu').text(zongfenshu);
                $.ajax({
                    url: "/Challenge/AddUserdati",
                    type: "post",
                    data: { tid: $('#timu1id').val() },
                    success: function (data) {
                    }
                });
            }
        });
        $(".useranswer").empty();
    });
    $("#btn2").click(function () {
        
        //$("#number2").css({ border: '1px solid #4cd964', color: '#4cd964' });
        $("#line3").css("background-color", "#4cd964");
        $("#rightbox2").hide();
        $("#rightbox3").css("display", "block");
        var daan = $(".a_2").text();
        $('#userdaan1').val(daan);
        $.ajax({
            url: "/Challenge/Panduan",
            type: "post",
            anync: true,
            data: { userdaan: $('#userdaan1').val(), id: $('#timu2id').val() },
            success: function (data) {
                if (data == "成功") {
                    $("#number2").css({ border: '1px solid #4cd964', color: '#4cd964' });
                    zongfenshu = 10 * 1+ $('.fs1').text() * 1;
                } else {
                    $("#number2").css({ border: '1px solid red', color: 'red' }); 
                    zongfenshu =  $('.fs1').text() * 1;
                }
                $('.fenshu').text(zongfenshu);
                zongfenshu = $('.fenshu').text(zongfenshu);
                $.ajax({
                    url: "/Challenge/AddUserdati",
                    type: "post",
                    data: { tid: $('#timu2id').val() },
                    success: function (data) {
                    }
                });
            }
        });
        $(".useranswer").empty();
    });
    $("#btn3").click(function () {
        
        //$("#number3").css({ border: '1px solid #4cd964', color: '#4cd964' });
        $("#line4").css("background-color", "#4cd964");
        $("#rightbox3").hide();
        $("#rightbox4").css("display", "block");
        $("#timu1").hide();
        $("#timu2").show();
        $("#challengekname1").hide();
        $("#challengekname2").show();
        var daan = $(".a_3").text();
        $('#userdaan1').val(daan);
        $.ajax({
            url: "/Challenge/Panduan",
            type: "post",
            anync: true,
            data: { userdaan: $('#userdaan1').val(), id: $('#timu3id').val() },
            success: function (data) {
                if (data == "成功") {
                    $("#number3").css({ border: '1px solid #4cd964', color: '#4cd964' });
                    zongfenshu = 10 * 1 + $('.fs2').text() * 1;
                } else {
                    $("#number3").css({ border: '1px solid red', color: 'red' });
                    zongfenshu =  $('.fs2').text() * 1;
                }
                $('.fenshu').text(zongfenshu);
                zongfenshu = $('.fenshu').text(zongfenshu);
                $.ajax({
                    url: "/Challenge/AddUserdati",
                    type: "post",
                    data: { tid: $('#timu3id').val() },
                    success: function (data) {
                    }
                });
            }
        });
        $(".useranswer").empty();
    });
    $("#btn4").click(function () {
        
        $(".Aclass").css("border", "2px solid rgba(221, 59, 67, 1)");
        $("#number4").css({ border: '1px solid #4cd964', color: '#4cd964' });
        $("#line5").css("background-color", "#4cd964");
        $("#rightbox4").hide();
        $("#rightbox5").css("display", "block");
        var daan = $(".a_4").val();
        $('#userdaan1').val(daan);
        $.ajax({
            url: "/Challenge/Panduan",
            type: "post",
            anync: true,
            data: { userdaan: $('#userdaan1').val(), id: $('#timu4id').val() },
            success: function (data) {
                if (data == "成功") {
                    $("#number4").css({ border: '1px solid #4cd964', color: '#4cd964' });
                    zongfenshu = 10 * 1 + $('.fs3').text() * 1;
                } else {
                    $("#number4").css({ border: '1px solid red', color: 'red' });
                    zongfenshu =  $('.fs3').text() * 1;
                }
                $('.fenshu').text(zongfenshu);
                zongfenshu = $('.fenshu').text(zongfenshu);
                $.ajax({
                    url: "/Challenge/AddUserdati",
                    type: "post",
                    data: { tid: $('#timu4id').val() },
                    success: function (data) {
                    }
                });
            }
        });
        $(".useranswer").empty();
    });
    $("#btn5").click(function () {
        
        $(".Aclass").css("border", "2px solid rgba(221, 59, 67, 1)");
        $("#number5").css({ border: '1px solid #4cd964', color: '#4cd964' });
        $("#line5").css("background-color", "#4cd964");
        $("#line5-5").css("background-color", "#4cd964");
        $("#line6").css("background-color", "#4cd964");
        $("#rightbox5").hide();
        $("#rightbox6").css("display", "block");
        var daan = $(".a_5").val();
        $('#userdaan1').val(daan);
        $.ajax({
            url: "/Challenge/Panduan",
            type: "post",
            anync: true,
            data: { userdaan: $('#userdaan1').val(), id: $('#timu5id').val() },
            success: function (data) {
                if (data == "成功") {
                    $("#number5").css({ border: '1px solid #4cd964', color: '#4cd964' });
                    zongfenshu = 10 * 1 + $('.fs4').text() * 1;
                } else {
                    $("#number5").css({ border: '1px solid red', color: 'red' });
                    zongfenshu = $('.fs4').text() * 1;
                }
                $('.fenshu').text(zongfenshu);
                zongfenshu = $('.fenshu').text(zongfenshu);
                $.ajax({
                    url: "/Challenge/AddUserdati",
                    type: "post",
                    data: { tid: $('#timu5id').val() },
                    success: function (data) {
                    }
                });
            }
        });
        $(".useranswer").empty();
    });
    $("#btn6").click(function () {
        
        $(".Aclass").css("border", "2px solid rgba(221, 59, 67, 1)");
        $("#number6").css({ border: '1px solid #4cd964', color: '#4cd964' });
        $("#line7").css("background-color", "#4cd964");
        $("#rightbox6").hide();
        $("#rightbox7").css("display", "block");
        var daan = $(".a_6").val();
        $('#userdaan1').val(daan);
        $.ajax({
            url: "/Challenge/Panduan",
            type: "post",
            anync: true,
            data: { userdaan: $('#userdaan1').val(), id: $('#timu6id').val() },
            success: function (data) {
                if (data == "成功") {
                    $("#number6").css({ border: '1px solid #4cd964', color: '#4cd964' });
                    zongfenshu = 10 * 1 + $('.fs5').text() * 1;
                } else {
                    $("#number6").css({ border: '1px solid red', color: 'red' });
                    zongfenshu =  $('.fs5').text() * 1;
                }
                $('.fenshu').text(zongfenshu);
                zongfenshu = $('.fenshu').text(zongfenshu);
                $.ajax({
                    url: "/Challenge/AddUserdati",
                    type: "post",
                    data: { tid: $('#timu6id').val() },
                    success: function (data) {
                    }
                });
            }
        });
        $(".useranswer").empty();
    });
    $("#btn7").click(function () {
        
        $("#number7").css({ border: '1px solid #4cd964', color: '#4cd964' });
        $("#line8").css("background-color", "#4cd964");
        $("#rightbox7").hide();
        $("#rightbox8").css("display", "block");
        $("#timu2").hide();
        $("#timu3").show();
        $("#challengekname2").hide();
        $("#challengekname3").show();
        var daan = $(".a_7").val();
        $('#userdaan1').val(daan);
        $.ajax({
            url: "/Challenge/Panduan",
            type: "post",
            anync: true,
            data: { userdaan: $('#userdaan1').val(), id: $('#timu7id').val() },
            success: function (data) {
                if (data == "成功") {
                    $("#number7").css({ border: '1px solid #4cd964', color: '#4cd964' });
                    zongfenshu = 10 * 1 + $('.fs6').text() * 1;
                } else {
                    $("#number7").css({ border: '1px solid red', color: 'red' });
                    zongfenshu = $('.fs6').text() * 1;
                }
                $('.fenshu').text(zongfenshu);
                zongfenshu = $('.fenshu').text(zongfenshu);
                $.ajax({
                    url: "/Challenge/AddUserdati",
                    type: "post",
                    data: { tid: $('#timu7id').val() },
                    success: function (data) {
                    }
                });
            }
        });
        $(".useranswer").empty();
    });
    $("#btn8").click(function () {
        
        $("#number8").css({ border: '1px solid #4cd964', color: '#4cd964' });
        $("#line9").css("background-color", "#4cd964");
        $("#rightbox8").hide();
        $("#rightbox9").css("display", "block");
        var daan = $(".a_8").val();
        $('#userdaan1').val(daan);
        $.ajax({
            url: "/Challenge/Panduan",
            type: "post",
            anync: true,
            data: { userdaan: $('#userdaan1').val(), id: $('#timu8id').val() },
            success: function (data) {
                if (data == "成功") {
                    $("#number8").css({ border: '1px solid #4cd964', color: '#4cd964' });
                    zongfenshu = 10 * 1 + $('.fs7').text() * 1;
                } else {
                    $("#number8").css({ border: '1px solid red', color: 'red' });
                    zongfenshu = $('.fs7').text() * 1;
                }
                $('.fenshu').text(zongfenshu);
                zongfenshu = $('.fenshu').text(zongfenshu);
                $.ajax({
                    url: "/Challenge/AddUserdati",
                    type: "post",
                    data: { tid: $('#timu8id').val() },
                    success: function (data) {
                    }
                });
            }
        });
        $(".useranswer").empty();
    });
    $("#btn9").click(function () {
        
        $("#number9").css({ border: '1px solid #4cd964', color: '#4cd964' });
        $("#line10").css("background-color", "#4cd964");
        $("#rightbox9").hide();
        $("#rightbox10").css("display", "block");
        var daan = $(".a_9").val();
        $('#userdaan1').val(daan);
        $.ajax({
            url: "/Challenge/Panduan",
            type: "post",
            anync: true,
            data: { userdaan: $('#userdaan1').val(), id: $('#timu9id').val() },
            success: function (data) {
                if (data == "成功") {
                    $("#number9").css({ border: '1px solid #4cd964', color: '#4cd964' });
                    zongfenshu = 10 * 1 + $('.fs8').text() * 1;
                } else {
                    $("#number9").css({ border: '1px solid red', color: 'red' });
                    zongfenshu =  $('.fs8').text() * 1;
                }
                $('.fenshu').text(zongfenshu);
                zongfenshu = $('.fenshu').text(zongfenshu);
                $.ajax({
                    url: "/Challenge/AddUserdati",
                    type: "post",
                    data: { tid: $('#timu9id').val() },
                    success: function (data) {
                    }
                });
            }
        });
        $(".useranswer").empty();
    });
    $("#btn10").click(function () {
        
        $("#number10").css({ border: '1px solid #4cd964', color: '#4cd964' });
        $("#line10-5").css("background-color", "#4cd964");
        $("#rightbox10").hide();
        $("#rightbox11").css("display", "block");
        $("#timu3").hide();
        $("#timu4").show();
        var daan = $(".a_10").val();
        $('#userdaan1').val(daan);
        $.ajax({
            url: "/Challenge/Panduan",
            type: "post",
            anync: true,
            data: { userdaan: $('#userdaan1').val(), id: $('#timu10id').val() },
            success: function (data) {
                if (data == "成功") {
                    $("#number10").css({ border: '1px solid #4cd964', color: '#4cd964' });
                    zongfenshu = 10 * 1 + $('.fs9').text() * 1;
                    $.ajax({
                        url: "/Challenge/Updatejifen",
                        type: "post",
                        data: { nowjifen: zongfenshu },
                        success: function (data) {
                            
                        }
                    });
                } else {
                    $("#number10").css({ border: '1px solid red', color: 'red' });
                    zongfenshu =  $('.fs9').text() * 1;
                    $(".defen").text(zongfenshu);
                    $(".jifen").text(zongfenshu);
                    $.ajax({
                        url: "/Challenge/Updatejifen",
                        type: "post",
                        anync: true,
                        data: { nowjifen: zongfenshu },
                        success: function (data) {
                            
                        }
                    });
                }
                $('.fenshu').text(zongfenshu);
                zongfenshu = $('.fenshu').text(zongfenshu);
                $.ajax({
                    url: "/Challenge/AddUserdati",
                    type: "post",
                    data: { tid: $('#timu10id').val() },
                    success: function (data) {
                    }
                });
            }
        });
        $(".useranswer").empty();
        $("#challengekname3").hide();
        $(".tips").hide();
        $("#challengekname4").show();
        
    });
    $("#A1").click(function () {
        $(this).css("background-color", "rgba(221, 59, 67, 1)");
        $(this).css("color", "white");
        $(".Aclass").css("border", "none");
        $("#B1").mask2();
        $("#C1").mask2();
        $("#D1").mask2();
        var str = $("#A1 .Aclass").text();
        xuanzetidaan = str;
        $(".a_4").val(str);
    });
    $("#A2").click(function () {
        $(this).css("background-color", "rgba(221, 59, 67, 1)");
        $(this).css("color", "white");
        $(".Aclass").css("border", "none");
        $("#B2").mask2();
        $("#C2").mask2();
        $("#D2").mask2();
        var str = $("#A2 .Aclass").text();
        xuanzetidaan = str;
        $(".a_5").val(str);
    });
    $("#A3").click(function () {
        $(this).css("background-color", "rgba(221, 59, 67, 1)");
        $(this).css("color", "white");
        $(".Aclass").css("border", "none");
        $("#B3").mask2();
        $("#C3").mask2();
        $("#D3").mask2();
        var str = $("#A3 .Aclass").text();
        xuanzetidaan = str;
        $(".a_6").val(str);
    });
    $("#A4").click(function () {
        $(this).css("background-color", "rgba(221, 59, 67, 1)");
        $(this).css("color", "white");
        $(".Aclass").css("border", "none");
        $("#B4").mask2();
        $("#C4").mask2();
        $("#D4").mask2();
        var str = $("#A4 .Aclass").text();
        xuanzetidaan = str;
        $(".a_7").val(str);
    });
    $("#B1").click(function () {
        $(this).css("background-color", "rgba(221, 59, 67, 1)");
        $(this).css("color", "white");
        $(".Aclass").css("border", "none");
        $("#A1").mask2();
        $("#C1").mask2();
        $("#D1").mask2();
        var str = $("#B1 .Aclass").text();
        xuanzetidaan = str;
        $(".a_4").val(str);
    });
    $("#B2").click(function () {
        $(this).css("background-color", "rgba(221, 59, 67, 1)");
        $(this).css("color", "white");
        $(".Aclass").css("border", "none");
        $("#A2").mask2();
        $("#C2").mask2();
        $("#D2").mask2();
        var str = $("#B2 .Aclass").text();
        xuanzetidaan = str;
        $(".a_5").val(str);
    });
    $("#B3").click(function () {
        $(this).css("background-color", "rgba(221, 59, 67, 1)");
        $(this).css("color", "white");
        $(".Aclass").css("border", "none");
        $("#A3").mask2();
        $("#C3").mask2();
        $("#D3").mask2();
        var str = $("#B3 .Aclass").text();
        xuanzetidaan = str;
        $(".a_6").val(str);
    });
    $("#B4").click(function () {
        $(this).css("background-color", "rgba(221, 59, 67, 1)");
        $(this).css("color", "white");
        $(".Aclass").css("border", "none");
        $("#A4").mask2();
        $("#C4").mask2();
        $("#D4").mask2();
        var str = $("#B4 .Aclass").text();
        xuanzetidaan = str;
        $(".a_7").val(str);
    });
    $("#C1").click(function () {
        $(this).css("background-color", "rgba(221, 59, 67, 1)");
        $(this).css("color", "white");
        $(".Aclass").css("border", "none");
        $("#A1").mask2();
        $("#B1").mask2();
        $("#D1").mask2();
        var str = $("#C1 .Aclass").text();
        xuanzetidaan = str;
        $(".a_4").val(str);
    });
    $("#C2").click(function () {
        $(this).css("background-color", "rgba(221, 59, 67, 1)");
        $(this).css("color", "white");
        $(".Aclass").css("border", "none");
        $("#A2").mask2();
        $("#B2").mask2();
        $("#D2").mask2();
        var str = $("#C2 .Aclass").text();
        xuanzetidaan = str;
        $(".a_5").val(str);
    });
    $("#C3").click(function () {
        $(this).css("background-color", "rgba(221, 59, 67, 1)");
        $(this).css("color", "white");
        $(".Aclass").css("border", "none");
        $("#A3").mask2();
        $("#B3").mask2();
        $("#D3").mask2();
        var str = $("#C3 .Aclass").text();
        xuanzetidaan = str;
        $(".a_6").val(str);
    });
    $("#C4").click(function () {
        $(this).css("background-color", "rgba(221, 59, 67, 1)");
        $(this).css("color", "white");
        $(".Aclass").css("border", "none");
        $("#A4").mask2();
        $("#B4").mask2();
        $("#D4").mask2();
        var str = $("#C4 .Aclass").text();
        xuanzetidaan = str;
        $(".a_7").val(str);
    });
    $("#D1").click(function () {
        $(this).css("background-color", "rgba(221, 59, 67, 1)");
        $(this).css("color", "white");
        $(".Aclass").css("border", "none");
        $("#A1").mask2();
        $("#B1").mask2();
        $("#C1").mask2();
        var str = $("#D1 .Aclass").text();
        xuanzetidaan = str;
        $(".a_4").val(str);
    });
    $("#D2").click(function () {
        $(this).css("background-color", "rgba(221, 59, 67, 1)");
        $(this).css("color", "white");
        $(".Aclass").css("border", "none");
        $("#A2").mask2();
        $("#B2").mask2();
        $("#C2").mask2();
        var str = $("#D2 .Aclass").text();
        xuanzetidaan = str;
        $(".a_5").val(str);
    });
    $("#D3").click(function () {
        $(this).css("background-color", "rgba(221, 59, 67, 1)");
        $(this).css("color", "white");
        $(".Aclass").css("border", "none");
        $("#A3").mask2();
        $("#B3").mask2();
        $("#C3").mask2();
        var str = $("#D3 .Aclass").text();
        xuanzetidaan = str;
        $(".a_6").val(str);
    });
    $("#D4").click(function () {
        $(this).css("background-color", "rgba(221, 59, 67, 1)");
        $(this).css("color", "white");
        $(".Aclass").css("border", "none");
        $("#A4").mask2();
        $("#B4").mask2();
        $("#C4").mask2();
        var str = $("#D4 .Aclass").text();
        xuanzetidaan = str;
        $(".a_7").val(str);
    });
});
$(function () {
    $(".1-1").click(function () {
        var a = $(".1-1").text();
        $(".useranswer").append(a);
        $(".1-1").mask();
        $(".1-1").css("color", "rgba(0,0,0,0.3)");
        $(".1-1").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".1-2").click(function () {
        var a = $(".1-2").text();
        $(".useranswer").append(a);
        $(".1-2").mask();
        $(".1-2").css("color", "rgba(0,0,0,0.3)");
        $(".1-2").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".1-3").click(function () {
        var a = $(".1-3").text();
        $(".useranswer").append(a);
        $(".1-3").mask();
        $(".1-3").css("color", "rgba(0,0,0,0.3)");
        $(".1-3").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".1-4").click(function () {
        var a = $(".1-4").text();
        $(".useranswer").append(a);
        $(".1-4").mask();
        $(".1-4").css("color", "rgba(0,0,0,0.3)");
        $(".1-4").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".1-5").click(function () {
        var a = $(".1-5").text();
        $(".useranswer").append(a);
        $(".1-5").mask();
        $(".1-5").css("color", "rgba(0,0,0,0.3)");
        $(".1-5").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".1-6").click(function () {
        var a = $(".1-6").text();
        $(".useranswer").append(a);
        $(".1-6").mask();
        $(".1-6").css("color", "rgba(0,0,0,0.3)");
        $(".1-6").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".1-7").click(function () {
        var a = $(".1-7").text();
        $(".useranswer").append(a);
        $(".1-7").mask();
        $(".1-7").css("color", "rgba(0,0,0,0.3)");
        $(".1-7").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".1-8").click(function () {
        var a = $(".1-8").text();
        $(".useranswer").append(a);
        $(".1-8").mask();
        $(".1-8").css("color", "rgba(0,0,0,0.3)");
        $(".1-8").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".1-9").click(function () {
        var a = $(".1-9").text();
        $(".useranswer").append(a);
        $(".1-9").mask();
        $(".1-9").css("color", "rgba(0,0,0,0.3)");
        $(".1-9").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".1-10").click(function () {
        var a = $(".1-10").text();
        $(".useranswer").append(a);
        $(".1-10").mask();
        $(".1-10").css("color", "rgba(0,0,0,0.3)");
        $(".1-10").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".1-11").click(function () {
        var a = $(".1-11").text();
        $(".useranswer").append(a);
        $(".1-11").mask();
        $(".1-11").css("color", "rgba(0,0,0,0.3)");
        $(".1-11").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".1-12").click(function () {
        var a = $(".1-12").text();
        $(".useranswer").append(a);
        $(".1-12").mask();
        $(".1-12").css("color", "rgba(0,0,0,0.3)");
        $(".1-12").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".2-1").click(function () {
        var a = $(".2-1").text();
        $(".useranswer").append(a);
        $(".2-1").mask();
        $(".2-1").css("color", "rgba(0,0,0,0.3)");
        $(".2-1").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".2-2").click(function () {
        var a = $(".2-2").text();
        $(".useranswer").append(a);
        $(".2-2").mask();
        $(".2-2").css("color", "rgba(0,0,0,0.3)");
        $(".2-2").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".2-3").click(function () {
        var a = $(".2-3").text();
        $(".useranswer").append(a);
        $(".2-3").mask();
        $(".2-3").css("color", "rgba(0,0,0,0.3)");
        $(".2-3").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".2-4").click(function () {
        var a = $(".2-4").text();
        $(".useranswer").append(a);
        $(".2-4").mask();
        $(".2-4").css("color", "rgba(0,0,0,0.3)");
        $(".2-4").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".2-5").click(function () {
        var a = $(".2-5").text();
        $(".useranswer").append(a);
        $(".2-5").mask();
        $(".2-5").css("color", "rgba(0,0,0,0.3)");
        $(".2-5").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".2-6").click(function () {
        var a = $(".2-6").text();
        $(".useranswer").append(a);
        $(".2-6").mask();
        $(".2-6").css("color", "rgba(0,0,0,0.3)");
        $(".2-6").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".2-7").click(function () {
        var a = $(".2-7").text();
        $(".useranswer").append(a);
        $(".2-7").mask();
        $(".2-7").css("color", "rgba(0,0,0,0.3)");
        $(".2-7").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".2-8").click(function () {
        var a = $(".2-8").text();
        $(".useranswer").append(a);
        $(".2-8").mask();
        $(".2-8").css("color", "rgba(0,0,0,0.3)");
        $(".2-8").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".2-9").click(function () {
        var a = $(".2-9").text();
        $(".useranswer").append(a);
        $(".2-9").mask();
        $(".2-9").css("color", "rgba(0,0,0,0.3)");
        $(".2-9").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".2-10").click(function () {
        var a = $(".2-10").text();
        $(".useranswer").append(a);
        $(".2-10").mask();
        $(".2-10").css("color", "rgba(0,0,0,0.3)");
        $(".2-10").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".2-11").click(function () {
        var a = $(".2-11").text();
        $(".useranswer").append(a);
        $(".2-11").mask();
        $(".2-11").css("color", "rgba(0,0,0,0.3)");
        $(".2-11").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".2-12").click(function () {
        var a = $(".2-12").text();
        $(".useranswer").append(a);
        $(".2-12").mask();
        $(".2-12").css("color", "rgba(0,0,0,0.3)");
        $(".2-12").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".3-1").click(function () {
        var a = $(".3-1").text();
        $(".useranswer").append(a);
        $(".3-1").mask();
        $(".3-1").css("color", "rgba(0,0,0,0.3)");
        $(".3-1").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".3-2").click(function () {
        var a = $(".3-2").text();
        $(".useranswer").append(a);
        $(".3-2").mask();
        $(".3-2").css("color", "rgba(0,0,0,0.3)");
        $(".3-2").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".3-3").click(function () {
        var a = $(".3-3").text();
        $(".useranswer").append(a);
        $(".3-3").mask();
        $(".3-3").css("color", "rgba(0,0,0,0.3)");
        $(".3-3").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".3-4").click(function () {
        var a = $(".3-4").text();
        $(".useranswer").append(a);
        $(".3-4").mask();
        $(".3-4").css("color", "rgba(0,0,0,0.3)");
        $(".3-4").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".3-5").click(function () {
        var a = $(".3-5").text();
        $(".useranswer").append(a);
        $(".3-5").mask();
        $(".3-5").css("color", "rgba(0,0,0,0.3)");
        $(".3-5").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".3-6").click(function () {
        var a = $(".3-6").text();
        $(".useranswer").append(a);
        $(".3-6").mask();
        $(".3-6").css("color", "rgba(0,0,0,0.3)");
        $(".3-6").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".3-7").click(function () {
        var a = $(".3-7").text();
        $(".useranswer").append(a);
        $(".3-7").mask();
        $(".3-7").css("color", "rgba(0,0,0,0.3)");
        $(".3-7").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".3-8").click(function () {
        var a = $(".3-8").text();
        $(".useranswer").append(a);
        $(".3-8").mask();
        $(".3-8").css("color", "rgba(0,0,0,0.3)");
        $(".3-8").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".3-9").click(function () {
        var a = $(".3-9").text();
        $(".useranswer").append(a);
        $(".3-9").mask();
        $(".3-9").css("color", "rgba(0,0,0,0.3)");
        $(".3-9").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".3-10").click(function () {
        var a = $(".3-10").text();
        $(".useranswer").append(a);
        $(".3-10").mask();
        $(".3-10").css("color", "rgba(0,0,0,0.3)");
        $(".3-10").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".3-11").click(function () {
        var a = $(".3-11").text();
        $(".useranswer").append(a);
        $(".3-11").mask();
        $(".3-11").css("color", "rgba(0,0,0,0.3)");
        $(".3-11").css("background-color", "rgba(0,0,0,0.1)");
    });
    $(".3-12").click(function () {
        var a = $(".3-12").text();
        $(".useranswer").append(a);
        $(".3-12").mask();
        $(".3-12").css("color", "rgba(0,0,0,0.3)");
        $(".3-12").css("background-color", "rgba(0,0,0,0.1)");
    });
});


$(function () {
    $(".tabbox .tab a").mouseover(function () {
        $(this).addClass('on').siblings().removeClass('on');
        var index = $(this).index();
        number = index;
        $('.tabbox .content li').hide();
        $('.tabbox .content li:eq(' + index + ')').show();
    });

    var auto = 0;  //等于1则自动切换，其他任意数字则不自动切换
    if (auto == 1) {
        var number = 0;
        var maxNumber = $('.tabbox .tab a').length;
        function autotab() {
            number++;
            number == maxNumber ? number = 0 : number;
            $('.tabbox .tab a:eq(' + number + ')').addClass('on').siblings().removeClass('on');
            $('.tabbox .content ul li:eq(' + number + ')').show().siblings().hide();
        }
        //var tabChange = setInterval(autotab, 3000);
        //鼠标悬停暂停切换
        $('.tabbox').mouseover(function () {
            clearInterval(tabChange);
        });
        $('.tabbox').mouseout(function () {
            tabChange = setInterval(autotab, 3000);
        });
    }
});