$(function() {
    $('button[id^="removeComment"]').click(function() {
        var commentId = $(this).attr('id').substring(13);
        $.ajax({
            url: 'Comment/RemoveComment?commentId=' + commentId,
            success: function() {
                $('#post' + commentId).remove();
            }
        });
    });
})