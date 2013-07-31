$(function () {
    $('#publishArticle').submit(function () {
        $.validator.unobtrusive.parse('#publishArticle');
        if ($('#publishArticle').valid()) {
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    $('#data').html(result);
                    $('#publishArticle').find(':input').each(function () {
                        var type = $(this).attr('type');
                        if (type != 'submit' && type != 'hidden' && type != 'checkbox') {
                            $(this).val('');
                        }
                    });
                    CollapseDisciplinesTree();
                }
            });
        }
        return false;
    });
})