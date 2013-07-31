//function InitCreateAnswerForm(questionId) {
//    var formId = '#postAnswerForm' + questionId;
//    var answersId = '#answersFor' + questionId;
//    $(formId).submit(function () {
//        $.validator.unobtrusive.parse(formId);
//        if ($(formId).valid()) {
//            $.ajax({
//                url: this.action,
//                type: this.method,
//                data: $(this).serialize(),
//                success: function (result) {
//                    $(answersId).html(result);
//                    $(formId)[0].reset();
//                }
//            });
//        }
//        return false;
//    });
//}
