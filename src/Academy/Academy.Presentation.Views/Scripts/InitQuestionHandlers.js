$(function () {
    $('button[id^="showAnswersFor"]').each(function() {
        var questionId = $(this).attr('id').substring(14);
        InitQuestionHandlers(questionId);
    });
})