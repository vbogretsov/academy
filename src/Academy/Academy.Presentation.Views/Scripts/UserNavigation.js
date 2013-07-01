$(function () {

    var bodyId = "#body";
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
            LoadView(dataId, "Article/GetUserArticles");
        });

        this.get('#/Comments', function () {
            LoadView(dataId, "Article/GetUserComments");
        });

        this.get('#/Questions', function () {
            LoadView(dataId, "Question/GetUserQuestions");
        });

        this.get('#/Answers', function () {
            LoadView(dataId, "Question/GetUserAnswers");
        });

        this.get('#/ContactAdmin', function () {
            LoadView(dataId, 'Profile/ContactAdministration');
        });

        // init top menu
        this.get('#/Edit', function () {
            alert('edit');
            LoadView(bodyId, "Profile/Edit");
        });

        this.get('#/SearchArticles', function () {
            LoadView(bodyId, "Search/SearchArticles");
        });

        this.get('#/SearchQuestions', function () {
            LoadView(bodyId, "Search/SearchQuestions");
        });

        // init user articles paging
        this.get('#/GetUserArticlesPage', function () {
            var id;
            var url;
            if ($('#userArticles').length > 0) {
                url = 'Article/GetUserArticlesPage?pageNumber='
                    + this.params['pageNumber']
                    + '&pageSize=' + this.params['pageSize'];
                id = '#articlesPage';
            } else { // occurs during page reload
                url = 'Article/GetUserArticles?pageNumber='
                    + this.params['pageNumber']
                    + '&pageSize=' + this.params['pageSize'];
                id = dataId;
            }
            LoadView(id, url);
        });

        // init user questions paging
        this.get('#/GetUserQuestionsPage', function () {
            var id;
            var url;
            if ($('#userQuestions').length > 0) {
                url = 'Question/GetUserQuestionsPage?pageNumber='
                    + this.params['pageNumber']
                    + '&pageSize=' + this.params['pageSize'];
                id = '#questionsPage';
            } else { // occurs during page reload
                url = 'Question/GetUserQuestions?pageNumber='
                    + this.params['pageNumber']
                    + '&pageSize=' + this.params['pageSize'];
                id = dataId;
            }
            LoadView(id, url);
        });

        this.get('#/GetUserComments', function () {
            var url = 'Article/GetUserComments?pageNumber='
                + this.params['pageNumber']
                + '&pageSize=' + this.params['pageSize'];
            LoadView(dataId, url);
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
        }
    });
}