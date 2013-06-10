$(function () {
    $("#addAuthor").click(function () {
        console.log("xxx");
        $.ajax({
            url: this.href,
            cache: false,
            success: function (html) { $("#authors").append(html); }
        });
        return false;
    });

    $('body').on('click', 'a.author-delete', null, function () {
        $(this).parents('p').remove();
        return false;
    });
});