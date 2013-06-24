$(function () {

    var bodyId = "#body";

    var app = $.sammy('#body', function (context) {

        this.get('#/Contacts', function () {
            LoadView(bodyId, "Home/Contacts");
        });

        this.get('#/About', function () {
            LoadView(bodyId, "Home/About");
        });

        this.get('#/SearchArticles', function () {
            LoadView(bodyId, "Search/SearchArticles");
        });

        this.get('#/SearchQuestions', function () {
            LoadView(bodyId, "Search/SearchQuestions");
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
        }
    });
}