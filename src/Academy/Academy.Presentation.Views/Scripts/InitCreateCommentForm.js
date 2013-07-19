$(function () {
    $('#@postCommentFormId').submit(function () {
        $.validator.unobtrusive.parse($('#@postCommentFormId'));
        if ($('#@postCommentFormId').valid()) {
            $.ajax({
                type: this.method,
                url: this.action,
                data: $(this).serialize(),
                success: function (result) {
                    $('#@commentsId').html(result);
                    $('#@postCommentFormId')[0].reset();
                }
            });
        }
        return false;
    });
});