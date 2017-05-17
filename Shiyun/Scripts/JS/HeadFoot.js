﻿$(window).scroll(function () {
    //底部logo动画
    var this_scrollTop = $(window).scrollTop(); //当前滚动的位置值
    if ((this_scrollTop) > 1200) {
        $(".moon").fadeIn(1000); //一秒渐入动画  
        $(".moon").css("top", "0");
    } else {
        $(".moon").fadeOut(1000); //一秒渐出动画  
        $(".moon").css("top", "100px");
    }
    //回到顶部动画
    if ((this_scrollTop) > 100) {
        $("#toTop").fadeIn(1000);//一秒渐入动画  
    } else {
        $("#toTop").fadeOut(1000);//一秒渐出动画  
    }
    //回到顶部click事件
    $("#toTop").click(function () {
        $('body,html').animate({ scrollTop: 0 }, 1000);
        $('body,html').off("mousewheel", preventScroll); //去除scrollTop=0对滚动的限制
    });
});
/*顶部左右改变宽度*/
$(window).resize(function () {
    if ($(window).width() < 850) {
        $("header .bignav_same ul li").css("margin", "0 17px");
        $(".bignav_right_li1").css("margin", "0px 0px !important");
    } else {
        $("header .bignav_same ul li").css("margin", "0 30px");
    }
    if ($(window).width() < 650) {
        $("header .bignav").hide();
        $("header .smallnav").show();
    } else {
        $("header .bignav").show();
        $("header .smallnav").hide();
    }
});
$(function () {   //登陆和个人中心的hover
    var sessionid = $(".uid").val();
    if (sessionid != "") { //判断是否有session
        $(".userinfo").parent().on("click", function() {
            return false;
        });
        $(".userinfo").hover(function() {
            //$(".usercenterbox").fadeIn(500);
            //$(".zhuxiaobox").fadeIn(500);
            $(".usercenterbox").show();
            $(".zhuxiaobox").show();
        }, function() {
            $(".usercenterbox").hide();
            $(".zhuxiaobox").hide();
        });
        $(".usercenterbox").hover(function() {
            $(".usercenterbox").css("display", "block");
            $(".zhuxiaobox").css("display", "block");
        }, function() {
            $(".usercenterbox").hide();
            $(".zhuxiaobox").hide();
        });
        $(".zhuxiaobox").hover(function() {
            $(".usercenterbox").css("display", "block");
            $(".zhuxiaobox").css("display", "block");
        }, function() {
            $(".usercenterbox").hide();
            $(".zhuxiaobox").hide();
        });
    } else {
        $(".userinfo").parent().on("click", function () {
            return true;
        });
    }
});
$(function () {
    //导航栏切换
    $(".open1").click(function () {
        $(".smallnav .container").css("height", "285px");
        $(this).hide();
        $(".open2").show();
        $(".smallnav .container ul").fadeIn(1000);
    });
    $(".open2").click(function () {
        $(".smallnav .container").css("height", "50px");
        $(this).hide();
        $(".open1").show();
        $(".smallnav .container ul").fadeOut(500);
    });
    /*搜索隐藏*/
    $(".nav_search").click(function () {
        $(".search").show();
    });
    $(".search").click(function () {
        $(this).hide();
    });
    $(".input_search").click(function (event) {
        event.stopPropagation(); //阻止事件冒泡    
    });
    $(".btn_search").click(function (event) {
        event.stopPropagation(); //阻止事件冒泡    
    });
});

$(function () {
    
    $(".zhuxiao").click(function () {
        
        $.ajax({
            url: "/UserInfo/Zhuxiao",
            type: "post",
            data: { a:1 },
            success: function (data) {
                alert("注销成功");
                $(".userinfo").unbind("mouseenter").unbind("mouseleave");
                var A = data;
            }
        });
    });
});