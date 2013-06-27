$(function() {
    $('body').on('click', 'a[id$="SideMenu"]', null, function() {
        $('a[id$="SideMenu"]').removeClass('btn-primary');
        $(this).addClass('btn-primary');
    });
})