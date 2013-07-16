function InitArticleHandlers(articleId) {
    $('button[id="addCommentFor' + articleId + '"]').unbind('click').bind('click', function () {
        $('#newCommentFor' + articleId).slideToggle('fast');
    });
    $('button[id="showCommentsFor' + articleId + '"]').unbind('click').bind('click', function () {
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
    $('button[id="removeArticle' + articleId + '"]').unbind('click').bind('click', function () {
        $.ajax({
            url: 'Article/RemoveArticle?articleId=' + articleId,
            success: function () {
                $('#titledPostId' + articleId).remove();
            }
        });
    });
}