$(window).load(function () {
    var clientHeight = document.getElementById('page-header').clientHeight;
    if (clientHeight <= 745) {
        // if ($(document).width() <= 745) {
        $("#aeo").attr("hidden", "hidden");
        $('#aei').removeAttr('hidden');
    }
    else {

        $('#aeo').removeAttr('hidden');
        $("#aei").attr("hidden", "hidden");
    }



});

function open(name) {
    $('body').removeClass();
    var path = window.location.pathname.split('/');
    path = path[path.length - 1];
    if (path !== undefined) {
        $("#sidebar-menu").find("a[href$='" + path + "']").addClass('sfActive');
        $("#sidebar-menu").find("a[href$='" + path + "']").parents().eq(3).superclick('show');
    }
    //$('.glyph-icon', this).toggleClass('icon-angle-right').toggleClass('icon-angle-left');
};
$(window).resize(function () {
    var clientHeight = document.getElementById('page-header').clientHeight;
    if (clientHeight <= 745) {
        //if ($(document).width() <= 745) {
        // if ($(document).width() <= 745) {
        $("#aeo").attr("hidden", "hidden");
        $('#aei').removeAttr('hidden');
    }
    else {

        $('#aeo').removeAttr('hidden');
        $("#aei").attr("hidden", "hidden");
    }
});
function calMinsize() {

    var min_height = 2510;
    var max_height = 1510;

    var clientHeight = document.getElementById('page-content').clientHeight;

    //min_height = $('#page-content').height();
    var sbsm = $(".sidebar-submenu").length, max = 0, li = 0;
    $(".sidebar-submenu").each(function (index, elem) {
        li = $(this).find("li").length;
        max = (li > max) ? li : max;
    });
    var minH = (36 * sbsm) + (32 * max) + 150;
    //alert("1:" + minH);
    //alert("2:" + min_height);
    if (minH < min_height)
        minH = min_height;
    if (minH > max_height)
        minH = max_height;
    //if (max_height < height)
    //    max_height = height;
    if (minH < clientHeight)
        minH = clientHeight + 150;
    if (max_height < clientHeight)
        max_height = max_height + 150;

    $("#page-sidebar").css({ "min-height": minH + "px" });
    $("#page-content").css({ "min-height": minH + "px" });
    $("#page-sidebar").css({ "max-height": max_height + "px" });
    $("#page-content").css({ "max-height": max_height + "px" });

}
function fullscreen() {
    var isInFullScreen = (document.fullscreenElement && document.fullscreenElement !== null) ||
        (document.webkitFullscreenElement && document.webkitFullscreenElement !== null) ||
        (document.mozFullScreenElement && document.mozFullScreenElement !== null) ||
        (document.msFullscreenElement && document.msFullscreenElement !== null);

    var docElm = document.documentElement;
    if (!isInFullScreen) {
        if (docElm.requestFullscreen) {
            docElm.requestFullscreen();
        } else if (docElm.mozRequestFullScreen) {
            docElm.mozRequestFullScreen();
        } else if (docElm.webkitRequestFullScreen) {
            docElm.webkitRequestFullScreen();
        } else if (docElm.msRequestFullscreen) {
            docElm.msRequestFullscreen();
        }
    } else {
        if (document.exitFullscreen) {
            document.exitFullscreen();
        } else if (document.webkitExitFullscreen) {
            document.webkitExitFullscreen();
        } else if (document.mozCancelFullScreen) {
            document.mozCancelFullScreen();
        } else if (document.msExitFullscreen) {
            document.msExitFullscreen();
        }
    }
}

var rgb = "102, 175, 233";
var rgbError = "255, 165, 0";
var TextBoxObj = [];
var InputColor = [];
var placeholder = [];
var v_fbi_id = [];
function addData(placeholderValue, v_fbi_idValue, inputElement) {
    TextBoxObj.push(inputElement);
    InputColor.push(rgb);
    placeholder.push(placeholderValue);
    v_fbi_id.push(v_fbi_idValue);
    $('#ciV-' + v_fbi_idValue).tooltip({ title: placeholderValue, trigger: "focus", placement: "top" });
    $('#v-' + v_fbi_idValue + '-fabtn').tooltip({ title: placeholderValue + ' +/**/', trigger: "focus", placement: "bottom" });
    $('#' + inputElement.id).tooltip({ title: placeholderValue + " chưa có thông tin hoặc không đúng.", trigger: "focus", placement: "bottom" });
    $('#' + inputElement.id).tooltip('disable');
}
$("button[class='fa-btn-c-V']").click(function () { return false; });
function validateInput(TextBoxObj, number, placeholder, v_fbi_id) {
    var obj = document.getElementById("ciV-" + v_fbi_id).style;
    if (TextBoxObj.value == placeholder || TextBoxObj.value != "C") {
        InputColor[number] = rgbError;
        obj.borderColor = "rgba(" + rgbError + ", 0.75)";
        $('#' + TextBoxObj.id).tooltip('enable');
        $('#ciV-' + v_fbi_id).tooltip('disable');
        return false;
    } else {
        InputColor[number] = rgb;
        obj.borderColor = "#ccc";
        $('#' + TextBoxObj.id).tooltip('disable');
        $('#ciV-' + v_fbi_id).tooltip('enable');
        return true;
    }
}
function v_c_empty_validation() {
    var InvalidInput = true;
    var length = TextBoxObj.length;

    //Đổi mầu khung khi nhập không hợp lệ
    for (i = 0; i < length; i++) {
        InvalidInput = validateInput(TextBoxObj[i], i, placeholder[i], v_fbi_id[i]);
    }

    //Cho con trỏ vào khung lỗi đầu tiên
    if (!InvalidInput) {
        for (i = 0; i < length; i++) {
            if (InputColor[i] == rgbError) {
                TextBoxObj[i].focus();
                break;
            }
        }
    }
    //return InvalidInput;
    return false;
}
//var closestByClass = function (el, clazz) {
//    while (el.className != clazz) {
//        el = el.parentNode;
//        if (!el) {
//            return null;
//        }
//    }
//    return el;
//}
function inputToggleFocus(idsc, type) {
    var obj = document.getElementById('ciV-' + idsc).style;
    var colorValue = getColorIndex(idsc);
    //var class_obj = closestByClass(element, 'fcV');
    //if (class_obj != undefined) {
    //obj = class_obj.style;
    if (type == "focus") {
        obj.borderColor = "rgba(" + colorValue + ", 0.8)";
        obj.boxShadow = "inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 8px rgba(" + colorValue + ", 0.6)";
    }
    else {
        if (colorValue == rgb) {
            obj.borderColor = "#ccc";
        }
        obj.boxShadow = "0 1px 1px rgba(0, 0, 0, 0.075) inset";
    }
    //}
}
function getColorIndex(value) {
    var size = v_fbi_id.length;
    if (size > 0) {
        for (i = 0; i < size; i++) {
            if (value == v_fbi_id[i]) {
                return InputColor[i];
            }
        }
    }
    return rgb;
}
//Dev code for password
function IsOldIE() {
    return ASPxClientUtils.ie && (ASPxClientUtils.browserMajorVersion < 9);
}

function SetInputType(input, newTypeValue) {
    if (IsOldIE())
        //Only for IE 8
        input.attributes("type").nodeValue = newTypeValue;
    else
        input.type = newTypeValue;
}

function txtPassword_Init(s, e) {
    if (s.GetText() != "")
        SetInputType(s.GetInputElement(), "password");
}

function txtPassword_GotFocus(s, e) {
    SetInputType(s.GetInputElement(), "password");
}

function txtPassword_LostFocus(s, e) {
    if (s.GetText() == "")
        SetInputType(s.GetInputElement(), "");
}
//End function for password