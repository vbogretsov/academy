$(function () {

    var bodyId = "#body";

    var app = $.sammy('#body', function (context) {

        this.get('#/Contacts', function () {
            alert('contacts');
            LoadView(bodyId, "Home/Contacts");
        });

        this.get('#/About', function () {
            alert('about');
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

function LoadView(divId, request, complete) {
    $.ajax({
        url: request,
        cache: false,
        success: function (result) {
            $(divId).html(result);
        }
    });
}