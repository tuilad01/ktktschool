$(document).ready(() => {
    $("#toggle-bar > i").click(() => {
        $("nav.mobile > ul").fadeToggle();
    });
});