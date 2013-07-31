$(function () {
    $('#askQuestion').submit(function () {
        $.validator.unobtrusive.parse('#askQuestion');
        if ($('#askQuestion').valid()) {
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (html) {
                    $('#data').html(html);
                    $('#askQuestion').find(':input').each(function () {
                        var type = $(this).attr('type');
                        if (type != 'submit' && type != 'hidden' && type != 'checkbox') {
                            $(this).val('');
                        }
                    });
                    CollapseDisciplinesTree();
                },
                error: function () {
                    alert('error');
                }
            });
        }
        return false;
    });
});