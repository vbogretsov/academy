$(function () {
    $('button[id^="addAnswerFor"]').each(function() {
        var questionId = $(this).attr('id').substring(12);
        InitQuestionHandlers(questionId);
    });
    //$('button[id^="addAnswerFor"]').click(function () {
    //    var questionId = $(this).attr('id').substring(12);
    //    $('#newAnswerFor' + questionId).slideToggle('fast');
    //});
    //$('button[id^="showAnswersFor"]').click(function () {
    //    var questionId = $(this).attr('id').substring(14);
    //    var answersId = '#answersFor' + questionId;
    //    if ($(answersId).is(':empty')) {
    //        $.ajax({
    //            url: 'Answer/GetQuestionAnswers?questionId=' + questionId,
    //            success: function (page) {
    //                $(answersId).html(page);
    //            }
    //        });
    //    }
    //    $(answersId).slideToggle('fast');
    //});
    //$('button[id^="removeQuestion"]').click(function () {
    //    alert($(this).attr('id'));
    //    // todo: remove article
    //});
})