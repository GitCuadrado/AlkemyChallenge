let menu = false;
var WebScript = WebScript || {

    init:function () {
        WebScript.AddCommonListenerMenu();
    },
    AddCommonListenerMenu: function () {
        $(".nav-bar__btn--item").click(function () {
            if (menu) {
                $(".nav-bar__items").removeClass("on");
                menu = false;
            } else {
                $(".nav-bar__items").addClass("on");
                menu = true;
            }
        });
    }
}