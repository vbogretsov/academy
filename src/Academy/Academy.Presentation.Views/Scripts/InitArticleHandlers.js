$(function () {
    $('button[id^="addCommentFor"]').each(function() {
        var articleId = $(this).attr('id').substring(13);
        InitArticleHandlers(articleId);
    });
    //$('button[id^="addCommentFor"]').click(function () {
    //    var articleId = $(this).attr('id').substring(13);
    //    $('#newCommentFor' + articleId).slideToggle('fast');
    //});
    //$('button[id^="showCommentsFor"]').click(function () {
    //    var articleId = $(this).attr('id').substring(15);
    //    var commentsId = '#commentsFor' + articleId;
    //    if ($(commentsId).is(':empty')) {
    //        $.ajax({
    //            url: 'Comment/GetArticleComments?articleId=' + articleId,
    //            success: function (page) {
    //                $(commentsId).html(page);
    //            }
    //        });
    //    }
    //    $(commentsId).slideToggle('fast');
    //});
    //$('button[id^="removeArticle"]').click(function () {
    //    alert($(this).attr('id'));
    //    // todo: remove article
    //});
})