$(function () {
    $('#OrderBy').change(function() {
        this.closest('form').submit();
    });

    $("[data-toggle=popover]").on('show.bs.popover',
        function() {
            var self = $(this);
            if (self.data('ok') === 'ok') {
                return;
            }
            $.ajax({
                url: '/Home/TeamStats?name=' + self.data('team'),
                success: function(result) {
                    self.data('ok', 'ok');

                    var popover = self.attr('data-content', result).data('bs.popover');
                    popover.setContent();
                    popover.$tip.addClass(popover.options.placement);
                }
            });
        }).on('hide.bs.popover',
        function () {
            var self = $(this);
            self.data('ok', '');
        });
})