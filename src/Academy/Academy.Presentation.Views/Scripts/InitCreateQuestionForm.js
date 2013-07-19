$(function () {
    $('#askQuestion').submit(function () {
        $.validator.unobtrusive.parse('#askQuestion');
        if ($('#askQuestion').valid()) {
            $.ajax({
                url: '#/Question/Ask',
                type: this.method,
                data: $(this).serialize(),
                success: function (html) {
                    $('#data').html(html);
                    $('#askQuestion').find(':input').each(function () {
                        if ($(this).attr('type') != 'submit') {
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