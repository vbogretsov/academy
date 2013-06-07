$(function () {
    $('.tree li').hide();
    $('.tree li.root').show();
    $('.tree span').on('click', function (e) {
        ToggleTree(e, $(this), $(this).siblings('img'));
    });
    $('.tree img').on('click', function (e) {
        ToggleTree(e, $(this), $(this));
    });
});


$('.tree input:checkbox').on('change', function () {
    $(this).siblings('ul').find('input:checkbox').prop('checked', $(this).prop('checked'));
    if (!$(this).prop('checked')) {
        UncheckParents($(this));
    }
});

function ToggleTree(e, node, img) {
    var children = node.parent().find('> ul > li');
    if (children.is(":visible")) {
        children.hide('fast');
        img.attr('src', '/Resources/Icons/tree-plus.png');
    }
    else {
        children.show('fast');
        img.attr('src', '/Resources/Icons/tree-minus.png');
    }
    e.stopPropagation();
}

function UncheckParents(node) {
    var parent = node.parent().parent().siblings('input:checked');
    parent.prop('checked', false);
    if (parent.length > 0) {
        UncheckParents(parent);
    }
}