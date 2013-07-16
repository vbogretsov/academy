$(function () {
    $('button[id^="addCommentFor"]').each(function() {
        var articleId = $(this).attr('id').substring(13);
        InitArticleHandlers(articleId);
    });
})