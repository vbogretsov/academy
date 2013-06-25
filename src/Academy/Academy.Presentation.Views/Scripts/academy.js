$(function () {
    // init Add article form
    var dataId = "#data";

    var app = $.sammy('#body', function (context) {

        // init side menu

        this.get("#/NewArticles", function () {
            LoadView(dataId, "Notification/GetArticleNews");
        });

        this.get("#/NewComments", function () {
            LoadView(dataId, "Notification/GetCommentNews");
        });

        this.get("#/NewQuestions", function () {
            LoadView(dataId, "Notification/GetQuestionNews");
        });

        this.get("#/NewAnswers", function () {
            LoadView(dataId, "Notification/GetAnswerNews");
        });

        this.get('#/Articles', function () {
            LoadView(dataId, "Article/GetUserArticles", function () {
                CollapseDisciplinesTree();
            });
        });

        this.get('#/Comments', function() {
            LoadView(dataId, "Article/GetUserComments");
        });

        this.get('#/Questions', function() {
            LoadView(dataId, "Question/GetUserQuestions", function() {
                CollapseDisciplinesTree();
            });
        });

        this.get('#/Answers', function() {
            LoadView(dataId, "Question/GetUserAnswers");
        });

        // init main menu
        this.get('#/Edit', function () {
            $('#profile a.btn').removeClass('btn-primary');
            LoadView(dataId, "Profile/Edit", function () {
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