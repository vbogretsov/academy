$(function () {
    $('button[id^="removeAnswer"]').click(function () {
        var answerId = $(this).attr('id').substring(12);
        $.ajax({
            url: 'Answer/RemoveAnswer?answerId=' + answerId,
            success: function () {
                $('#post' + answerId).remove();
            }
        });
    });
})