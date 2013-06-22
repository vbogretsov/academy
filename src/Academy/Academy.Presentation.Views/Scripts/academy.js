$(function () {
    // init Add article form

    var app = $.sammy('#body', function (context) {

        // init side menu

        this.get("#/NewArticles", function () {
            LoadView('#body', "Notification/GetArticleNews");
        });

        this.get('#/Articles', function () {
            LoadView('#body', "Article/GetUserArticles", function () {
                CollapseDisciplinesTree();
                //InitArticleHandlers();
            });
        });

        this.get('#/Comments', function() {
            LoadView('#body', "Article/GetUserComments");
        });

        this.get('#/Questions', function() {
            LoadView('#body', "Question/GetUserQuestions", function() {
                CollapseDisciplinesTree();
            });
        });

        this.get('#/Answers', function() {
            LoadView('#body', "Question/GetUserAnswers");
        });

        // init main menu
        this.get('#/Edit', function () {
            $('#profile a.btn').removeClass('btn-primary');
            LoadView('#body', "Profile/Edit", function () {
                CollapseDisciplinesTree();
            });
        });

        this.get('#/ContactAdministration', function() {
            // TODO: contact administration
        });

        return false;
    });
    
    $(function () {
        app.run('#/');
    });

    // init profile menu buttons
    $('#profile a.btn').on('click', function () {
        $('#profile a.btn').removeClass('btn-primary');
        $(this).addClass('btn-primary');
    });

    //// add author editor
    //$('body').on('click', '#addAuthor', null, function () {
    //    $.ajax({
    //        url: this.href,
    //        cache: false,
    //        success: function (html) {
    //            $('#authors').append(html);
    //        }
    //    });
    //    return false;
    //});

    // delete author editor
    //$('body').on('click', 'a.author-delete', null, function () {
    //    $(this).parents('p').remove();
    //    return false;
    //});

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
                $('#editDisciplines').html('');
                $('#editDisciplines').append(html);
                $('body .modal-backdrop').fadeOut(250);
                CollapseDisciplinesTree();
            }
        });
        return false;
    });

    // init article creation form
    $('#body').on('submit', '#publishArticle', null, function (e) {
        $.validator.unobtrusive.parse("#publishArticle");
        if($('#publishArticle').valid()) {
            alert(this.method);
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (html) {
                    $('#body').html('');
                    $('#body').append(html);
                    CollapseDisciplinesTree();
                    $('#publishArticle')[0].reset();
                }
            });
        }
        return false;
    });

    // init question creation form
    $('#body').on('submit', '#askQuestion', null, function (e) {
        $.validator.unobtrusive.parse('#askQuestion');
        if ($('#askQuestion').valid()) {
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (html) {
                    $('#body').html('');
                    $('#body').append(html);
                    CollapseDisciplinesTree();
                    $('#askQuestion')[0].reset();
                }
            });
        }
        return false;
    });
});

//function InitArticleHandlers() {
//    $('button[id^="addCommentFor"]').each(function () {
//        var id = $(this).attr('id').substring(13);
//        var newCommentId = '#newCommentFor' + id;
//        $(this).click(function () {
//            $(newCommentId).slideToggle('fast');
//        });
//        var showCommentsId = '#showCommentsFor' + id;
//        var commentsId = "#commentsFor" + id;
//        $(showCommentsId).click(function () {
//            $(commentsId).slideToggle('fast');
//        });
//        var commentFormId = '#commentFormFor' + id;
//        $(commentFormId).on('submit', null, function (e) {
//            $.validator.unobtrusive.parse($(commentFormId));
//            if ($(commentFormId).valid()) {
//                $.ajax({
//                    type: this.method,
//                    url: this.action,
//                    data: $(this).serialize(),
//                    success: function (result) {
//                        $(commentsId).html('');
//                        $(commentsId).append(result);
//                        $(commentFormId)[0].reset();
//                    }
//                });
//            }
//            return false;
//        });
//    });
//}

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