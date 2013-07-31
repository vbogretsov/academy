//function InitCreateCommentForm(articleId) {
//    var formId = '#commentFormFor' + articleId;
//    var commentsId = '#commentsFor' + articleId;
//    $(formId).submit(function () {
//        $.validator.unobtrusive.parse($(formId));
//        if ($(formId).valid()) {
//            $.ajax({
//                type: this.method,
//                url: this.action,
//                data: $(this).serialize(),
//                success: function (result) {
//                    $(commentsId).html(result);
//                    $(formId)[0].reset();
//                }
//            });
//        }
//        return false;
//    });
//}