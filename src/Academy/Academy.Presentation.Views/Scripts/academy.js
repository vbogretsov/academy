$(function () {
    // init main menu 

    $('#editProfile').click(function () {
        $('#profile a.btn').removeClass('btn-primary');
        LoadView('#body', this.href, function () {
            $('#body .tree li').hide();
            $('#body .tree li.root').show();
        });
        return false;
    });

    // init profile menu

    // init profile menu buttons
    $('#profile a.btn').on('click', function () {
        $('#profile a.btn').removeClass('btn-primary');
        $(this).addClass('btn-primary');
    });

    // init Add article form
    $('#myArticles').click(function () {
        LoadView('#body', this.href, function () {
            CollapseDisciplinesTree();
        });
        return false;
    });

    // add author editor
    $('body').on('click', '#addAuthor', null, function () {
        $.ajax({
            url: this.href,
            cache: false,
            success: function (html) {
                $('#authors').append(html);
            }
        });
        return false;
    });

    // delete author editor
    $('body').on('click', 'a.author-delete', null, function () {
        $(this).parents('p').remove();
        return false;
    });

    // tree initializing
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

    // init profile editor form
    $('#body').on('submit', '#selectDisciplines', null, function (e) {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (html) {
                $('#body').html('');
                $('#body').append(html);
                $('body .modal-backdrop').fadeOut(250);
                CollapseDisciplinesTree();
            }
        });
        return false;
    });
    
    // init article editor form
    $('#body').on('submit', '#publishArticle', null, function (e) {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (html) {
                $('#body').html('');
                $('#body').append(html);
                $.validator.unobtrusive.parse($("#publishArticle"));
                //$('body .modal-backdrop').fadeOut(250);
                CollapseDisciplinesTree();
            }
        });
        return false;
    });
});

function LoadView(divId, request, complete) {
    $(divId).html('');
    $.ajax({
        url: request,
        cache: false,
        success: function (html) {
            $(divId).append(html);
            if (complete != null) {
                complete();
            }
        }
    });
}

function CollapseDisciplinesTree() {
    $('#body .tree li').hide();
    $('#body .tree li.root').show();
}

// tree functions
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