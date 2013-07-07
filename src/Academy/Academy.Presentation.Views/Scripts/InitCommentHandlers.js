$(function() {
    $('button[id^="removeComment"]').click(function() {
        var commentId = $(this).attr('id').substring(13);
        alert(commentId);
        //todo: remove comment
    });
})