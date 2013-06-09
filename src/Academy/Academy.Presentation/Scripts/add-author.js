$(function () {
    $("#addAuthor").click(function () {
        $.ajax({
            url: this.href,
            cache: false,
            success: function (html) { $("#authors").append(html); }
        });
        return false;
    });
});
