function InitArticleHandlers(articleId) {
    $('button[id="addCommentFor' + articleId + '"]').click( function () {
        $('#newCommentFor' + articleId).slideToggle('fast');
    });
    $('button[id="showCommentsFor' + articleId + '"]').click(function () {
        var commentsId = '#commentsFor' + articleId;
        if ($(commentsId).is(':empty')) {
            $.ajax({
                url: 'Comment/GetArticleComments?articleId=' + articleId,
                success: function (page) {
                    $(commentsId).html(page);
                }
            });
        }
        $(commentsId).slideToggle('fast');
    });
    $('button[id="removeArticle' + articleId + '"]').click(function () {
        $.ajax({
            url: 'Article/RemoveArticle?articleId=' + articleId,
            success: function () {
                alert($('#titledPostId' + articleId).length);
                $('#titledPostId' + articleId).remove();
            }
        });
    });
}