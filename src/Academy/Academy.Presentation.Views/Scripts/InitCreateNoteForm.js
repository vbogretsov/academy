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
                        if ($(this).attr('type') != 'submit') {
                            $(this).val('');
                        }
                    });
                }
            });
        }
        return false;
    });
})