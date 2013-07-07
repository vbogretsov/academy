$(function () {
    $('button[id^="showQuestionFor"]').click(function () {
        var answerId = $(this).attr('id').substring(15);
        var questionArea = $('#questionFor' + answerId + ' div');
        var questionId = questionArea.attr('id').substring(8);
        if (questionArea.is(':empty')) {
            $.ajax({
                url: 'Question/GetQuestion?questionId=' + questionId,
                cache: false,
                success: function (result) {
                    questionArea.html(result);
                    InitQuestionHandlers(questionId);
                    questionArea.slideToggle('fast');
                }
            });
        } else {
            questionArea.slideToggle('fast');
        }
    });
});