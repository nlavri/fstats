$(function () {
    $('#OrderBy').change(function() {
        this.closest('form').submit();
    });

    $('#clear').click(function() {
        $('input[name="Filter"]').removeAttr('checked');
        move($("#form"));
    });
    $('#process').click(function() {
        move($("#form"));
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
});

function move(form) {
   $("#progress").show();
   var bar = document.getElementById("bar");
    var width = 1;
    var id = setInterval(frame, 10);
    function frame() {
        if (width >= 100) {
            clearInterval(id);
            form.submit();
        } else {
            width++;
            bar.style.width = width + '%';
            bar.innerHTML = width * 1 + '%';
        }
    }
}