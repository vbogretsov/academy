$(function () {
    $('button[id^="addAnswerFor"]').each(function() {
        var questionId = $(this).attr('id').substring(12);
        InitQuestionHandlers(questionId);
    });
})