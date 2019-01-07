$(document).ready(function () {
    showBigImage();
})

function showBigImage()
{
    $(".small-img").off('click').on('click', function () {
        var obj = $(this);
        var src = obj.data('src');
        src = src.slice(1);
        $("#big-img").attr('src', src);
    })
}