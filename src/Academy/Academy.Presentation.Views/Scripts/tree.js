$(function () {
    $('#body').on('click', '.tree span', null, function (e) {
        ToggleTree(e, $(this), $(this).siblings('img'));
    });
    $('#body').on('click', '.tree img', null, function (e) {
        ToggleTree(e, $(this), $(this));
    });
    $('#body').on('change', '.tree input:checkbox', null, function (e) {
        $(this).siblings('ul').find('input:checkbox').prop('checked', $(this).prop('checked'));
        if (!$(this).prop('checked')) {
            UncheckParents($(this));
        }
    });
});

function CollapseDisciplinesTree() {
    $('#body .tree li').hide();
    $('#body .tree li.root').show();
}

function ToggleTree(e, node, img) {
    var children = node.parent().find('> ul > li');
    if (children.is(":visible")) {
        children.hide('fast');
        img.attr('src', '/Content/Images/tree-plus.png');
    }
    else {
        children.show('fast');
        img.attr('src', '/Content/Images/tree-minus.png');
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