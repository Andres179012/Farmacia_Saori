$(function () {
    $(".val").click(function (e) {
        e.preventDefault();
        var a = $(this).attr("href");
        $(".screen").append(a);
        $(".outcome").val($(".outcome").val() + a);
    });

    $(".equal").click(function () {
        $(".outcome").val(eval($(".outcome").val()));
        $(".screen").html(eval($(".outcome").val()));
    });

    $(".clear").click(function () {
        $(".outcome").val("");
        $(".screen").html("");
    });

    $(".min").click(function () {
        $(".cal").stop().animate({ width: "0px", height: "0px", marginLeft: "700px", marginTop: "1000px" }, 500);
        setTimeout(function () { $(".cal").css("display", "none") }, 600);
    });

    $(".close").click(function () {
        $(".cal").css("display", "none");
    })
})