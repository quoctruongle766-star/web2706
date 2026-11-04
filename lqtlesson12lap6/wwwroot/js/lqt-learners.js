$(function () {
    $("#lqt-majors").on("click", "a[data-lqt-mid]", function (lqtEvent) {
        lqtEvent.preventDefault();
        var lqtMid = $(this).data("lqt-mid");
        $("#lqt-search input[name='mid']").val(lqtMid);
        $.ajax({
            url: $("#lqt-content").data("lqt-url"),
            data: { mid: lqtMid, keyword: $("#lqt-keyword").val() },
            success: function (lqtResponse) {
                $("#lqt-content").html(lqtResponse);
            }
        });
    });

    $("#lqt-content").on("click", "a[data-lqt-page]", function (lqtEvent) {
        lqtEvent.preventDefault();
        $.ajax({
            url: $("#lqt-content").data("lqt-url"),
            data: {
                mid: $(this).data("lqt-mid"),
                keyword: $(this).data("lqt-keyword"),
                pageIndex: $(this).data("lqt-page")
            },
            success: function (lqtResponse) {
                $("#lqt-content").html(lqtResponse);
            }
        });
    });

    $("#lqt-search").on("submit", function (lqtEvent) {
        lqtEvent.preventDefault();
        $.ajax({
            url: $("#lqt-content").data("lqt-url"),
            data: {
                mid: $("#lqt-search input[name='mid']").val(),
                keyword: $("#lqt-keyword").val()
            },
            success: function (lqtResponse) {
                $("#lqt-content").html(lqtResponse);
            }
        });
    });
});
