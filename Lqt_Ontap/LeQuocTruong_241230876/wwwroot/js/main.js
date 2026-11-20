// BookHub - hiệu ứng giao diện cơ bản (nút "lên đầu trang")
$(function () {
    $(window).on('scroll', function () {
        $('.to-top').toggle($(this).scrollTop() > 200);
    });
    $('.to-top').on('click', function () {
        $('html, body').animate({ scrollTop: 0 }, 400);
    });
    $('.search-box input').on('focus', function () { $(this).select(); });
    $('.loc-theo-the-loai').on('click', function (event) {
        event.preventDefault();

        $.get(this.href)
            .done(function (html) {
                $('#danh-sach-sach').html(html);
            })
            .fail(function () {
                alert('Không tải được danh sách sách.');
            });
    });
});
