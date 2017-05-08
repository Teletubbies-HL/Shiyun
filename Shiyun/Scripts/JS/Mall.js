$(function () {
        $("#head_hot_goods_next").click(function() {
            $("#head_hot_goods_content").children("ul").animate({
                left: "-1226px"
            }, 300);
        });
        $("#head_hot_goods_prave").click(function() {
            $("#head_hot_goods_content").children("ul").animate({
                left: "0"
            }, 300);
        });
        $("#head_hot_goods_prave").hover(function() {
            $(this).css("color", "#ff6700");
        }, function() {
            $(this).css("color", "#BEBEBE");
        });
        $("#head_hot_goods_next").hover(function() {
            $(this).css("color", "#ff6700");
        }, function() {
            $(this).css("color", "#BEBEBE");
        });
});
$(function () {
    var headerSlider = new Slider($("section .imgListcontent"), {
        time: 3000,
        delay: 400,
        event: 'hover',
        auto: true,
        mode: 'fade',
        controller: $('#bannerCtrl'),
        activeControllerCls: 'active'
    });
    $("section .imgListcontent .prev").click(function () {
        headerSlider.prev();
    });

    $("section .imgListcontent .next").click(function () {
        headerSlider.next();
    });
});
$(function () {
    $("section .imgListcontent .sel #li11").hover(function () {
        $("section #idshowbox1").show();
        $("section .imgListcontent .sel .li1 #idli1-1").css("background-color", "rgba(221, 59, 68,0.8)");
    }, function () {
        $("section #idshowbox1").hide();
        $("section .imgListcontent .sel .li1 #idli1-1").css("background-color", "rgba(221, 59, 68,0)");
    });
    $("section #idshowbox1").hover(function () {
        $("section #idshowbox1").show();
        $("section .imgListcontent .sel .li1 #idli1-1").css("background-color", "rgba(221, 59, 68,0.8)");
    }, function () {
        $("section #idshowbox1").hide();
        $("section .imgListcontent .sel .li1 #idli1-1").css("background-color", "rgba(221, 59, 68,0)");
    });


    $("section .imgListcontent .sel #li12").hover(function () {
        $("section #idshowbox2").show();
        $("section .imgListcontent .sel .li1 #idli1-2").css("background-color", "rgba(221, 59, 68,0.8)");
    }, function () {
        $("section #idshowbox2").hide();
        $("section .imgListcontent .sel .li1 #idli1-2").css("background-color", "rgba(221, 59, 68,0)");
    });
    $("section #idshowbox2").hover(function () {
        $("section #idshowbox2").show();
        $("section .imgListcontent .sel .li1 #idli1-2").css("background-color", "rgba(221, 59, 68,0.8)");
    }, function () {
        $("section #idshowbox2").hide();
        $("section .imgListcontent .sel .li1 #idli1-2").css("background-color", "rgba(221, 59, 68,0)");
    });


    $("section .imgListcontent .sel #li13").hover(function () {
        $("section #idshowbox3").show();
        $("section .imgListcontent .sel .li1 #idli1-3").css("background-color", "rgba(221, 59, 68,0.8)");
    }, function () {
        $("section #idshowbox3").hide();
        $("section .imgListcontent .sel .li1 #idli1-3").css("background-color", "rgba(221, 59, 68,0)");
    });
    $("section #idshowbox3").hover(function () {
        $("section #idshowbox3").show();
        $("section .imgListcontent .sel .li1 #idli1-3").css("background-color", "rgba(221, 59, 68,0.8)");
    }, function () {
        $("section #idshowbox3").hide();
        $("section .imgListcontent .sel .li1 #idli1-3").css("background-color", "rgba(221, 59, 68,0)");
    });


    $("section .imgListcontent .sel #li14").hover(function () {
        $("section #idshowbox4").show();
        $("section .imgListcontent .sel .li1 #idli1-4").css("background-color", "rgba(221, 59, 68,0.8)");
    }, function () {
        $("section #idshowbox4").hide();
        $("section .imgListcontent .sel .li1 #idli1-4").css("background-color", "rgba(221, 59, 68,0)");
    });
    $("section #idshowbox4").hover(function () {
        $("section #idshowbox4").show();
        $("section .imgListcontent .sel .li1 #idli1-4").css("background-color", "rgba(221, 59, 68,0.8)");
    }, function () {
        $("section #idshowbox4").hide();
        $("section .imgListcontent .sel .li1 #idli1-4").css("background-color", "rgba(221, 59, 68,0)");
    });


    $("section .imgListcontent .sel #li15").hover(function () {
        $("section #idshowbox5").show();
        $("section .imgListcontent .sel .li1 #idli1-5").css("background-color", "rgba(221, 59, 68,0.8)");
    }, function () {
        $("section #idshowbox5").hide();
        $("section .imgListcontent .sel .li1 #idli1-5").css("background-color", "rgba(221, 59, 68,0)");
    });
    $("section #idshowbox5").hover(function () {
        $("section #idshowbox5").show();
        $("section .imgListcontent .sel .li1 #idli1-5").css("background-color", "rgba(221, 59, 68,0.8)");
    }, function () {
        $("section #idshowbox5").hide();
        $("section .imgListcontent .sel .li1 #idli1-5").css("background-color", "rgba(221, 59, 68,0)");
    });
});