!function t(n,e,i){function o(a,s){if(!e[a]){if(!n[a]){var c="function"==typeof require&&require;if(!s&&c)return c(a,!0);if(r)return r(a,!0);var l=new Error("Cannot find module '"+a+"'");throw l.code="MODULE_NOT_FOUND",l}var u=e[a]={exports:{}};n[a][0].call(u.exports,function(t){var e=n[a][1][t];return o(e?e:t)},u,u.exports,t,n,e,i)}return e[a].exports}for(var r="function"==typeof require&&require,a=0;a<i.length;a++)o(i[a]);return o}({1:[function(t,n,e){"use strict";var i={buildWithOption:function(t){var n='<div id="confirm-dialog" class="zoom-anim-dialog mfp-hide white"><h3 class="confirm-title">'+t.title+'</h3><p class="confirm-text">'+t.text+"</p>";$.each(t.buttons,function(t,e){n+='<a href="javascript:void(0)" class="rg-button '+e["class"]+'">'+e.title+"</a>",e.event||(e.event=function(){})}),n+="</div>";var e=$(n);return e.prependTo("body"),$("body").on("click","#confirm-dialog .rg-button",function(){var n=$(this).index("#confirm-dialog .rg-button"),e=t.buttons[n];return e.event(),!1}),e},destroy:function(){$("body").off("click","#confirm-dialog .rg-button");var t=$("#confirm-dialog");t.remove()}},o=function(){function t(){var t=$('<a href="#confirm-dialog"></a>');return t.magnificPopup({type:"inline",fixedBgPos:!0,overflowY:"auto",closeBtnInside:!0,preloader:!1,midClick:!0,removalDelay:300,mainClass:"my-mfp-slide-bottom",showCloseBtn:!1,retina:{ratio:1},callbacks:{open:function(){},close:function(){i.destroy()}}}),t}function n(){return void 0===e&&(e=t()),e}var e=void 0;return{open:function(){n().magnificPopup("open")},close:function(){n().magnificPopup("close")}}}(),r={show:function(t){i.buildWithOption(t),o.open()},hide:function(){o.close()}};n.exports=r},{}],2:[function(t,n,e){"use strict";var i={init:function(t){var n=$(t.editor),e=t.position?t.position:"bottom left",i=void 0;$(t.trigger).popup({on:"click",inline:!0,hoverable:!0,exclusive:!0,position:e,jitter:200,delay:{hide:1e3},onVisible:function(t){n.focus(),i=n},onHide:function(t){i=void 0}}),$("body").on("click",".emoji-tab-item",function(){var t=$(this),n=t.closest(".emoji-panel-head"),e=n.siblings(".emoji-panel-body");if(t.hasClass("active"))return!1;n.find(".active").toggleClass("active"),t.addClass("active");var i=t.attr("data-toggle");e.find(".emoji-panel-content").hide(),e.find("#"+i).fadeIn("fast")}),$("body").on("click",".face-item",function(){var t=$(this),n=t.attr("data-name");i&&i.val(i.val()+"["+n+"]")})}};n.exports=i},{}],3:[function(t,n,e){"use strict";var i={init:function(){function t(t){var n=document.body.scrollTop+document.documentElement.scrollTop;n>500?t.fadeIn():t.fadeOut()}var n=$("#gotoTop");t(n),$(window).on("scroll",function(){t(n)}),n.click(function(){$(window).scrollTo("body",500)})}};n.exports=i},{}],4:[function(t,n,e){"use strict";$.fn.showPopImage=function(t){$(this).find(t).each(function(t,n){var e=$(n).attr("src")?$(n).attr("src"):$(n).attr("href");$(n).magnificPopup({type:"image",items:{src:e},preloader:!0,closeOnContentClick:!0,showCloseBtn:!1,fixedContentPos:!0,mainClass:"mfp-no-margins mfp-with-zoom",image:{verticalFit:!1},zoom:{enabled:!0,duration:300,easing:"ease-in-out",opener:function(t){return $(n)}}})})}},{}],5:[function(t,n,e){"use strict";var i={showErrorNotice:function(t){$(".error-notice").empty(),$(".error-notice").append(t),setTimeout(function(){$(".error-notice").empty()},1e4)},clearErrorNotice:function(){$(".error-notice").empty()}},o={init:function(){$(".user-login").magnificPopup({type:"inline",fixedBgPos:!0,overflowY:"auto",closeBtnInside:!0,preloader:!1,midClick:!0,removalDelay:300,mainClass:"my-mfp-slide-bottom",showCloseBtn:!1,retina:{ratio:1}}),$("#loginbox-form").submit(function(){var t=$(this),n=t.find('input[name="email"]').val(),e=t.find('input[name="password"]').val();if(0==n.length)return i.showErrorNotice("邮箱不能为空!"),!1;if(e.length<6)return i.showErrorNotice("密码至少为6位!"),!1;i.clearErrorNotice();var o=(t.attr("method"),t.attr("action")),r=t.serialize();return $.ajax({url:o,data:r,dataType:"jsonp",success:function(t){0==t.error?location.reload():i.showErrorNotice(t.msg)},error:function(t){i.showErrorNotice("登录失败，请检查用户名或密码是否正确再重试")}}),!1}),$(".user-logout").click(function(){var t=$(this),n=t.attr("action");$.ajax({url:n,dataType:"jsonp",success:function(t){0==t.error&&location.reload()},error:function(t){}})});var t=$('div[data-menu="user-menu"]');t.on("mouseenter mouseleave",function(t){if("mouseenter"==t.type)$("#user-menu").fadeIn("fast");else{if("mouseleave"!=t.type)return!1;$("#user-menu").fadeOut("fast")}})},showLoginIfNeeded:function(){return!!RG.currentUser||($(".user-login").length>0&&$(".user-login").magnificPopup("open"),!1)}};n.exports=o},{}],6:[function(t,n,e){"use strict";function i(t){setTimeout(function(){t.transition("slide down")},3e3)}function o(t,n){var e=$('<div class="ui large floating message transition hidden"></div>');return e.addClass(t),$("<p></p>").appendTo(e).text(n),e.appendTo($(".message-container")).transition("slide down"),e}$(document).ready(function(){window.alert=function(t){r.show(t)},i($(".ui.floating.message"))});var r={show:function(t){i(o("info",t))},success:function(t){i(o("positive",t))},warning:function(t){i(o("warning",t))},error:function(t){i(o("negative",t))}};n.exports=r},{}],7:[function(t,n,e){"use strict";function i(t,n){var e=n.find(".progress"),i=e.find("span");i.length||(i=$('<div class="progress"><span></span></div>').appendTo(n)),i.css("width",parseInt(100*t)+"%"),i.text("上传中...")}function o(t,n,e,i,o){var r=$("#"+t.id),a=r.find("img");r.addClass("upload-state-done"),i&&a.attr("src",n.message.file),a.attr("file",n.message.file);var s=$('<input type="hidden" name="'+e+(o?"[]":"")+'">');return s.val(n.message.file),s.appendTo(r),l.success("上传成功"),r}function r(t){var n=$("#"+t.id),e=n.find("div.error");e.length||(e=$('<div class="error"></div>').appendTo(n)),e.text("上传失败"),l.error("上传失败")}function a(t,n){var e=t.val(),i=t.attr("name"),o=$('<div id="" class="file-item thumbnail old" style="display:inline-block;"><img src="'+e+'"><div class="info">'+e+'</div><div class="delete"><i class="ri ri-remove"></i></div><input type="hidden" name="'+i+'" value="'+e+'"></div>');return o.fadeIn().appendTo(n),t.remove(),o}function s(t,n){var e=$('<div id="'+t.id+'" class="file-item thumbnail" style="display:inline-block;"><img><div class="progress"><span></span></div><div class="info">'+t.name+'</div><div class="delete"><i class="ri ri-remove"></i></div></div>');return e.fadeIn().appendTo(n),e}function c(t,n,e){var i=t.attr("id");i&&n.removeFile(i,!0),e?t.fadeOut("fast",function(){t.remove()}):t.remove()}var l=t("../common/message"),u={initSingle:function(t,n){var e=WebUploader.create({auto:!0,server:n.url?n.url:"/api/upload",pick:{id:t,multiple:!1},accept:{title:"Images",extensions:"gif,jpg,jpeg,bmp,png",mimeTypes:"image/*"},compress:!1,formData:{_token:$('meta[name="csrf-token"]').attr("content")}}),u=$("#picPreview"),d=$("input[name="+n.inputName+"]");d.length>0&&a(d,u),e.on("fileQueued",function(t){c(u.find(".file-item"),e,!1);var n=s(t,u),i=n.find("img");e.makeThumb(t,function(t,n){return t?void i.replaceWith("<span>不能预览</span>"):void i.attr("src",n)},1,1)}),e.on("uploadProgress",function(t,n){i(n,$("#"+t.id))}),e.on("uploadSuccess",function(t,e){o(t,e,n.inputName,!0)}),e.on("uploadError",function(t){r(t),l.error("上传失败");var n=$("#"+t.id);c(n,e,!0)}),e.on("uploadComplete",function(t){u.find(".progress").remove()}),u.on("click",".delete",function(){var t=$(this).closest(".file-item");c(t,e,!0)})},initMultiple:function(t,n){var e=WebUploader.create({auto:!0,server:n.url?n.url:"/api/upload",pick:{id:t,multiple:!0},accept:{title:"Images",extensions:"gif,jpg,jpeg,bmp,png",mimeTypes:"image/*"},compress:!1,formData:{_token:$('meta[name="csrf-token"]').attr("content")}}),l=$("#picList"),u=$('input[name="'+n.inputName+'[]"]');u.each(function(t,n){a($(n),l)}),e.on("fileQueued",function(t){var n=s(t,l),i=n.find("img");e.makeThumb(t,function(t,n){return t?void i.replaceWith("<span>不能预览</span>"):void i.attr("src",n)},100,100)}),e.on("uploadProgress",function(t,n){i(n,$("#"+t.id))}),e.on("uploadSuccess",function(t,e){o(t,e,n.inputName,!1,!0)}),e.on("uploadError",function(t){r(t)}),e.on("uploadComplete",function(t){var n=$("#"+t.id);n.find(".progress").remove()}),l.on("click",".delete",function(){var t=$(this).closest(".file-item");c(t,e,!0)})}};n.exports=u},{"../common/message":6}],8:[function(t,n,e){"use strict";var i=function(){return{init:function(){var t=$(".platform"),n=t.prev(),e=$(".nav-bar"),i=$("section.sidebar");if(0==t.length)return!1;if(document.body.clientWidth<768)return!1;var o=$(".platform-left-section");return!(o.outerHeight()<i.outerHeight())&&void $(window).on("scroll",function(){var o=n.offset().top+n.innerHeight(),r=e.offset().top+e.height(),a=o-r;a<=0?(t.addClass("float"),t.css({width:i.width()})):t.removeClass("float")})}}}();n.exports=i},{}],9:[function(t,n,e){"use strict";$(document).ajaxStart(function(){NProgress.start()}),$(document).ajaxStop(function(){NProgress.done()}),$(document).ready(function(){NProgress.start()}),$(window).load(function(){NProgress.done()})},{}],10:[function(t,n,e){"use strict";t("../lib/jquery.highlight-5");var i={init:function(){function t(t,n){window.location.replace(i+"?keyword="+t+"&type="+n)}function n(){var n=e.find(".input-search"),i=n.val(),o="forum",r=e.siblings(".option");r.length>0&&(o=r.find('input[name="type"]:checked').val()),t(i,o)}var e=$(".search-box"),i=e.attr("action");e.on("keydown",".input-search",function(t){13==t.keyCode&&n()}),e.on("click",".do-search",function(){n()}),$(".result-list .result-item").find('[search-hit="true"]').each(function(t,n){var e=$(this),i=e.attr("keyword");e.highlight(i)})}};n.exports=i},{"../lib/jquery.highlight-5":16}],11:[function(t,n,e){"use strict";var i=t("../common/loginUI"),o=t("../common/search"),r=(t("../common/progress"),t("../common/gotoTop")),a=t("../common/platform"),s=(t("../common/imagePopup"),t("./school")),c=t("./post"),l=t("./reply"),u=t("./tweet"),d=function(){return{init:function(){i.init(),r.init(),s.init(),c.init(),l.init(),u.init(),o.init(),a.init(),$(".paper").showPopImage("img")}}}();n.exports=d},{"../common/gotoTop":3,"../common/imagePopup":4,"../common/loginUI":5,"../common/platform":8,"../common/progress":9,"../common/search":10,"./post":12,"./reply":13,"./school":14,"./tweet":15}],12:[function(t,n,e){"use strict";var i=(t("../utils/string"),t("../utils/lock"),t("../utils/http")),o=t("../common/loginUI"),r=t("../common/message"),a=t("../common/picker"),s={init:function(){var t=$("#postCreateForm"),n=$("#postEditForm"),e=$("#postReplyForm");(t.length>0||n.length>0||e.length>0)&&a.initMultiple("#picPicker",{inputName:"pictures",url:"/uploadImage"});var s=$(".post-actions");s.on("click",".goto-reply",function(){return!!o.showLoginIfNeeded()&&($(window).scrollTo(".reply-area",1e3,{onAfter:function(){$(".reply-area").find("textarea").focus()}}),!1)}),s.on("click",".do-like",function(){if(!o.showLoginIfNeeded())return!1;var t=$(this),n=t.attr("action");return i.init(n).lock(t).post(function(n){t.attr("has-liked","true"),t.html('<i class="ri ri-thumbs-o-up"></i> 已赞 ('+n.message.count+")"),r.success("赞得好~")},function(t){r.error(t)}),!1}),s.on("click",".do-nice",function(){var t=$(this),n=t.data("action");i.init(n).lock(t).post(function(){r.success("操作成功, 正在刷新页面"),location.reload()},function(t){r.error(t)})}),s.on("click",".do-stick",function(){var t=$(this),n=t.data("action");i.init(n).lock(t).post(function(){r.success("操作成功, 正在刷新页面"),location.reload()},function(t){r.error(t)})})}};n.exports=s},{"../common/loginUI":5,"../common/message":6,"../common/picker":7,"../utils/http":18,"../utils/lock":19,"../utils/string":20}],13:[function(t,n,e){"use strict";var i=t("../utils/string"),o=(t("../utils/lock"),t("../utils/http")),r=(t("../common/confirmUI"),t("../common/loginUI")),a=t("../common/message"),s=(t("../common/emoji"),{init:function(){function t(t){var n=t.find(".reply-meta"),e=$('<div class="ui form reply-simple"><input type="text" class="field" placeholder="输入回复内容，回车键发送"></div>');e.fadeIn("fast").appendTo(n).find("input").focus(),n.find(".reply-reply").data("open","on")}function n(t){var n=t.find(".reply-meta");n.find(".reply-simple").remove(),n.find(".reply-reply").data("open","off")}var e=$(".post-reply"),s=$(".reply-list"),c=$("#postReplyForm"),l=c.find("textarea");e.on("click",".do-reply",function(){var t=$(this),n=l.val(),e=[],r=c.find('input[name="pictures[]"]');if(r.each(function(t,n){e.push($(n).val())}),""==i.trim(n))return a.warning("内容不能为空!"),!1;var u=t.data("action");return o.init(u,{body:n,pictures:e}).lock(t).post(function(t){if("view"==t.type){var n=$(t.message);n.fadeIn().appendTo(s),l.val(""),c.find("#picList").html("")}},function(t){a.error(t)}),!1}),e.on("click",".reply-reply",function(){if(!r.showLoginIfNeeded())return!1;var e=$(this).closest(".reply-item");return"on"==$(this).data("open")?n(e):t(e),!1}),e.on("keydown",".reply-simple>input",function(t){if(13==t.which){var e=$(this),r=e.closest(".reply-list"),s=e.closest(".reply-item"),c=r.data("action"),l=s.data("reply-id"),u=e.val();if(""==i.trim(u))return a.warning("内容不能为空!"),!1;o.init(c,{reply_id:l,body:u}).lock(e).post(function(t){if("view"==t.type){var e=$(t.message);e.fadeIn().appendTo(r),n(s)}else a.warning(t)},function(t){a.error(t)})}});var u=$("#postReplyDeleteModal");e.on("click",".reply-delete",function(){var t=$(this).data("action");u.find("form").attr("action",t),u.modal("show")})}});n.exports=s},{"../common/confirmUI":1,"../common/emoji":2,"../common/loginUI":5,"../common/message":6,"../utils/http":18,"../utils/lock":19,"../utils/string":20}],14:[function(t,n,e){"use strict";var i=t("../utils/http"),o=t("../common/picker"),r=t("../common/message"),a=t("../common/loginUI"),s={init:function(){($("#schoolCreateForm").length>0||$("#schoolEditForm").length>0)&&o.initSingle("#picPicker",{inputName:"thumb",url:"/uploadAvatar"});var t=$(".applying.master");t.on("click",".agree",function(){var t=$(this).data("action"),n=$(this).data("user");i.init(t,{user_id:n}).lock($(this)).post(function(t){r.success("操作成功"),location.reload()},function(t){t.length>0?alert(t):alert("操作失败")})}),t.on("click",".refuse",function(){var t=$(this).data("action"),n=$(this).data("user");i.init(t,{user_id:n}).lock($(this)).post(function(t){r.success("操作成功"),location.reload()},function(t){t.length>0?alert(t):alert("操作失败")})});var n=$(".swiper-container");n.length>0&&n.swiper({direction:"horizontal",autoplay:3e3,loop:!0,pagination:".swiper-pagination",paginationClickable:!0}),$(".fi-quick-section").on("click",".action",function(){if(!a.showLoginIfNeeded())return!1;var t=$(this).siblings(".input-box"),n=$("#createModal");n.find("input[name=title]").val(t.val()),n.find("textarea[name=content]").val(t.val()),n.modal("show")})}};n.exports=s},{"../common/loginUI":5,"../common/message":6,"../common/picker":7,"../utils/http":18}],15:[function(t,n,e){"use strict";var i=t("../utils/http"),o=t("../common/loginUI"),r=t("../common/message"),a=t("../common/picker"),s={init:function(){var t=$("#tweetCreateForm");t.length>0&&a.initSingle("#picPicker",{inputName:"pictures",url:"/uploadImage"});var n=$(".tweet-item");n.on("keydown",".reply-input",function(t){13==t.which&&$(this).siblings(".do-reply").trigger("click")}),n.on("click",".do-reply",function(){if(!o.showLoginIfNeeded())return!1;var t=$(this),n=t.siblings(".reply-input"),e=n.val(),a=t.data("action");return i.init(a,{content:e}).lock(t).post(function(e){if(e.type="view"){var i=$(e.message),o=t.closest(".tweet-item").find(".reply-item");if(o.length>0)o.last().after(i.fadeIn());else{var r=t.closest(".tweet-item").find(".meta-content");r.after(i.fadeIn())}n.val("")}},function(t){r.error(t)}),!1}),n.on("click",".do-like",function(){if(!o.showLoginIfNeeded())return!1;var t=$(this);if(t.hasClass("has-liked"))return r.show("您已经喜欢过了."),!1;var n=t.data("action");i.init(n).lock(t).post(function(n){if(n.message.count){var e=n.message.count;t.html('<i class="ri ri-heart"></i> '+e),t.addClass("bounceIn animated").one("webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend",function(){t.removeClass("bounceIn animated")}),t.addClass("has-liked"),r.success("喜欢就好~")}else r.show(n.message)},function(t){r.error(t)})});var e=$("#tweetDeleteModal");n.on("click",".do-delete",function(){var t=$(this),n=t.data("action");e.find("form").attr("action",n),e.modal("show")}),n.on("mouseover mouseout",".reply-item",function(t){var n=$(this),e=n.find(".actions");"mouseover"==t.type?e.show():e.hide()}),n.on("click",".quick-at",function(){var t=$(this),n=t.closest(".tweet-item").find(".reply-input");$(window).scrollTo(n,500,{offset:-200,onAfter:function(){n.focus()}});var e=t.data("at");n.val("@"+e+" "+n.val())});var s=$("#tweetReplyDeleteModal");n.on("click",".reply-delete",function(){var t=$(this),n=t.data("action");s.find("form").attr("action",n),s.modal("show")})}};n.exports=s},{"../common/loginUI":5,"../common/message":6,"../common/picker":7,"../utils/http":18}],16:[function(t,n,e){"use strict";jQuery.fn.highlight=function(t){function n(t,e){var i=0;if(3==t.nodeType){var o=t.data.toUpperCase().indexOf(e);if(o-=t.data.substr(0,o).toUpperCase().length-t.data.substr(0,o).length,o>=0){var r=document.createElement("span");r.className="highlight";var a=t.splitText(o),s=(a.splitText(e.length),a.cloneNode(!0));r.appendChild(s),a.parentNode.replaceChild(r,a),i=1}}else if(1==t.nodeType&&t.childNodes&&!/(script|style)/i.test(t.tagName))for(var c=0;c<t.childNodes.length;++c)c+=n(t.childNodes[c],e);return i}return this.length&&t&&t.length?this.each(function(){n(this,t.toUpperCase())}):this},jQuery.fn.removeHighlight=function(){return this.find("span.highlight").each(function(){this.parentNode.firstChild.nodeName,replaceChild(this.parentNode.firstChild,this.parentNode),normalize()}).end()}},{}],17:[function(t,n,e){"use strict";var i=t("./forum/export");$(document).ready(function(){i.init()})},{"./forum/export":11}],18:[function(t,n,e){"use strict";var i,o=t("./lock"),r={url:"",type:"POST",data:{},dateType:"json"},a=function(t,n,e){return!(void 0!==i&&!o.lockEvent(i))&&void $.ajax({type:t.type,url:t.url,data:t.data,dataType:t.dataType?t.dataType:"json",success:function(t){return void 0!==i&&o.unlockEvent(i),0==t.error?n(t):e(t.message)},error:function(t){return void 0!==i&&o.unlockEvent(i),e("操作失败!")}})},s={init:function(t,n){return r.url=t,r.data=n||{},r.dataType="json",i=void 0,this},lock:function(t){return i=t,this},get:function(t,n){r.type="GET",a(r,t,n)},post:function(t,n){r.type="POST",a(r,t,n)},put:function(t,n){r.type="POST",r.data._method="PUT",a(r,t,n)},"delete":function(t,n){r.type="POST",r.data._method="DELETE",a(r,t,n)},jsonp:function(t,n){r.type="GET",r.dataType="jsonp",a(r,t,n)}};n.exports=s},{"./lock":19}],19:[function(t,n,e){"use strict";var i={lockEvent:function(t){function n(){i.unlockEvent(t)}return!t.hasClass("locked")&&(t.addClass("locked"),setTimeout(n,"10000"),!0)},unlockEvent:function(t){t.removeClass("locked")}};n.exports=i},{}],20:[function(t,n,e){"use strict";var i={trim:function(t){return t.replace(/(^\s*)|(\s*$)/g,"")},ltrim:function(t){return t.replace(/(^\s*)/g,"")},rtrim:function(t){return t.replace(/(\s*$)/g,"")}};n.exports=i},{}]},{},[17]);