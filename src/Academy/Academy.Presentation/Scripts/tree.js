$(function () {
    $('.tree li').hide();
    $('.tree li.root').show();
    $('.tree h').on('click', function (e) {
        var children = $(this).parent().find('> ul > li');
        if (children.is(":visible")) children.hide('fast');
        else children.show('fast');
        e.stopPropagation();
    });
});


$('.tree input:checkbox').on('change', function() {
    $(this).siblings('ul').find('input:checkbox').prop('checked', $(this).prop('checked'));
    if(!$(this).prop('checked')) {
        UncheckParents($(this));
    }
});

function UncheckParents (node) {
    var parent = node.parent().parent().siblings('input:checked');
    parent.prop('checked', false);
    if(parent.length > 0){
        UncheckParents(parent);
    }
}