$(function () {

    var bodyId = '#body';
    var dataId = '#data';

    var app = $.sammy('#body', function (context) {

        // init side menu

        this.get('#/NewArticles', function () {
            var url = 'Notification/GetArticleNews?pageNumber='
                + this.params['pageNumber'] + '&pageSize='
                + this.params['pageSize'];
            LoadView(dataId, url);
        });

        this.get('#/NewComments', function () {
            var url = 'Notification/GetCommentNews?pageNumber='
                + this.params['pageNumber'] + '&pageSize='
                + this.params['pageSize'];
            LoadView(dataId, url);
        });

        this.get('#/NewQuestions', function () {
            var url = 'Notification/GetQuestionNews?pageNumber='
                + this.params['pageNumber'] + '&pageSize='
                + this.params['pageSize'];
            LoadView(dataId, url);
        });

        this.get('#/NewAnswers', function () {
            var url = 'Notification/GetAnswerNews?pageNumber='
                + this.params['pageNumber'] + '&pageSize='
                + this.params['pageSize'];
            LoadView(dataId, url);
        });

        this.get('#/Articles', function () {
            LoadView(dataId, 'Article/GetUserArticles');
        });

        this.get('#/Comments', function () {
            LoadView(dataId, 'Comment/GetUserComments');
        });

        this.get('#/Questions', function () {
            LoadView(dataId, 'Question/GetUserQuestions');
        });

        this.get('#/Answers', function () {
            LoadView(dataId, 'Answer/GetUserAnswers');
        });

        // init top menu
        this.get('#/Edit', function () {
            LoadView(bodyId, 'Profile/Edit');
        });

        this.get('#/SearchArticles', function () {
            LoadView(bodyId, 'Search/SearchArticles');
        });

        this.get('#/SearchQuestions', function () {
            LoadView(bodyId, 'Search/SearchQuestions');
        });

        // init user articles paging
        this.get('#/GetUserArticlesPage', function () {
            var id;
            var url;
            if ($('#userArticles').length > 0) {
                url = 'Article/GetUserArticlesPage?pageNumber='
                    + this.params['pageNumber'] + '&pageSize='
                    + this.params['pageSize'];
                id = '#userArticles';
            } else { // occurs during page reload
                url = 'Article/GetUserArticles?pageNumber='
                    + this.params['pageNumber'] + '&pageSize='
                    + this.params['pageSize'];
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
                    + this.params['pageNumber'] + '&pageSize='
                    + this.params['pageSize'];
                id = '#userQuestions';
            } else { // occurs during page reload
                url = 'Question/GetUserQuestions?pageNumber='
                    + this.params['pageNumber'] + '&pageSize='
                    + this.params['pageSize'];
                id = dataId;
            }
            LoadView(id, url);
        });

        this.get('#/GetUserComments', function () {
            var url = 'Comment/GetUserComments?pageNumber='
                + this.params['pageNumber'] + '&pageSize='
                + this.params['pageSize'];
            LoadView(dataId, url);
        });

        this.get('#/GetArticleComments', function () {
            var url = 'Comment/GetArticleComments?articleId='
                + this.params['articleId'] + '&pageNumber='
                + this.params['pageNumber'] + '&pageSize='
                + this.params['pageSize'];
            var id = '#commentsFor' + this.params['articleId'];
            LoadView(id, url);
        });

        this.get('#/GetUserAnswers', function() {
            var url = 'Answer/GetUserAnswers?userId='
                + this.params['userId'] + '&pageNumber='
                + this.params['pageNumber'] + '&pageSize='
                + this.params['pageSize'];
            LoadView(dataId, url);
        });

        this.get('#/GetQuestionAnswers', function() {
            var url = 'Answer/GetQuestionAnswers?questionId='
                + this.params['questionId'] + '&pageNumber='
                + this.params['pageNumber'] + '&pageSize='
                + this.params['pageSize'];
            var id = '#answersFor' + this.params['questionId'];
            LoadView(id, url);
        });

        this.get('#/GetUserNotes', function () {
            var id;
            var url;
            if ($('#userNotes').length > 0) {
                url = 'Note/GetUserNotesPage?pageNumber='
                    + this.params['pageNumber'] + '&pageSize='
                    + this.params['pageSize'];
                id = '#userNotes';
            } else {
                url = 'Note/GetUserNotes?pageNumber='
                    + this.params['pageNumber'] + '&pageSize='
                    + this.params['pageSize'];
                id = dataId;
            }
            LoadView(id, url);
        });

        return false;
    });

    $(function () {
        app.run('#/');
    });
});

function LoadView(divId, request) {
    $.ajax({
        url: request,
        cache: false,
        success: function (result) {
            $(divId).html(result);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
        }
    });
}