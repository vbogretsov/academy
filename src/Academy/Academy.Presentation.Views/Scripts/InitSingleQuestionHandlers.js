function InitQuestionHandlers(questionId) {
    $('button[id^="addAnswerFor' + questionId + '"]').click(function () {
        $('#newAnswerFor' + questionId).slideToggle('fast');
    });
    $('button[id^="showAnswersFor' + questionId + '"]').click(function () {
        var answersId = '#answersFor' + questionId;
        if ($(answersId).is(':empty')) {
            $.ajax({
                url: 'Answer/GetQuestionAnswers?questionId=' + questionId,
                success: function (page) {
                    $(answersId).html(page);
                }
            });
        }
        $(answersId).slideToggle('fast');
    });
    $('button[id^="removeQuestion' + questionId + '"]').click(function () {
        $.ajax({
            url: 'Question/RemoveQuestion?id=' + questionId,
            success: function () {
                $('#titledPostId' + questionId).remove();
            }
        });
    });
}