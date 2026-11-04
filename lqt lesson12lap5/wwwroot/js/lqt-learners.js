$(function () {
    $("#lqt-majors").on("click", "a[data-lqt-mid]", function (lqtEvent) {
        lqtEvent.preventDefault();
        var lqtMid = $(this).data("lqt-mid");
        $.ajax({
            url: $("#lqt-content").data("lqt-url"),
            data: { mid: lqtMid },
            success: function (lqtResponse) {
                $("#lqt-content").html(lqtResponse);
            }
        });
    });
});
