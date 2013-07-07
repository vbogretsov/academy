$(function() {
    $('button[id^="showArticleFor"]').click(function() {
        var commentId = $(this).attr('id').substring(14);
        var articleArea = $('#articleFor' + commentId + ' div');
        var articleId = articleArea.attr('id').substring(7);
        if (articleArea.is(':empty')) {
            $.ajax({
                url: 'Article/GetArticle?articleId=' + articleId,
                cache: false,
                success: function(result) {
                    articleArea.html(result);
                    InitArticleHandlers(articleId);
                    articleArea.slideToggle('fast');
                }
            });
        } else {
            articleArea.slideToggle('fast');
        }
    });
});