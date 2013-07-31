$(function() {
    $('button[id^="removeNote"]').each(function() {
        var noteId = $(this).attr('id').substring(10);
        var removeButtonId = '#removeNote' + noteId;
        $(removeButtonId).click(function () {
            $.ajax({
                url: 'Note/RemoveNote',
                type: 'post',
                data: {
                    'noteId': noteId
                },
                success: function (result) {
                    $('#data').html(result);
                }
            });
            return false;
        });
    });
})