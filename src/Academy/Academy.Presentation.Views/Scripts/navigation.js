$(function() {
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

        this.get('#/Comments', function () {
            LoadView(dataId, "Article/GetUserComments");
        });

        this.get('#/Questions', function () {
            LoadView(dataId, "Question/GetUserQuestions", function () {
                CollapseDisciplinesTree();
            });
        });

        this.get('#/Answers', function () {
            LoadView(dataId, "Question/GetUserAnswers");
        });

        // init top menu
        this.get('#/Edit', function () {
            $('#profile a.btn').removeClass('btn-primary');
            LoadView(dataId, "Profile/Edit", function () {
                CollapseDisciplinesTree();
            });
        });

        this.get('#/ContactAdministration', function () {
            // TODO: contact administration
        });

        return false;
    });

    $(function () {
        app.run('#/');
    });
});

function LoadView(divId, request, complete) {
    $.ajax({
        url: request,
        cache: false,
        success: function (result) {
            $(divId).html(result);
            if (complete != null) {
                complete();
            }
        }
    });
}