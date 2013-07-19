$(function () {
    $('button[id^="showCommentsFor"]').each(function() {
        var articleId = $(this).attr('id').substring(15);
        InitArticleHandlers(articleId);
    });
})