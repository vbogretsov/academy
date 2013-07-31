$(function () {
    $('#addNote').submit(function () {
        $.validator.unobtrusive.parse('#addNote');
        if ($('#addNote').valid()) {
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    $('#data').html(result);
                    $('#addNote').find(':input').each(function () {
                        var type = $(this).attr('type');
                        if (type != 'submit' && type != 'hidden') {
                            $(this).val('');
                        }
                    });
                }
            });
        }
        return false;
    });
})