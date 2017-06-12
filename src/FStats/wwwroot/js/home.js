$(function () {
    $('#OrderBy').change(function() {
        this.closest('form').submit();
    });
})