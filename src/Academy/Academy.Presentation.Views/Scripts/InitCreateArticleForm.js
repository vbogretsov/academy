$(function () {
    $('#publishArticle').submit(function () {
        $.validator.unobtrusive.parse('#publishArticle');
        if ($('#publishArticle').valid()) {
            $.ajax({
                url: '#/Article/Publish',
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    $('#data').html(result);
                    $('#publishArticle').find(':input').each(function () {
                        if ($(this).attr('type') != 'submit') {
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