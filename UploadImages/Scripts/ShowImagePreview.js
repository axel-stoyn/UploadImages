$(function () {
    $('.little-preview').click(function () {
        $('.big-preview').attr('src', $(this).attr('src'));
    });
});