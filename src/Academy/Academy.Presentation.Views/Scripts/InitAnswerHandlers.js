$(function () {
    $('button[id^="removeAnswer"]').click(function () {
        var answerId = $(this).attr('id').substring(12);
        alert(answerId);
        //todo: remove comment
    });
})