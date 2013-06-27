$(function () {
    $('#mainMenu > li').on('click', 'a', null, function () {
        $('#mainMenu > li').removeClass('active');
        $(this).parent().addClass('active');
    });
})