$(function () {
    $('#toggle-password').on('change',
        function (e) {
            var toggle = $(this);

            if (toggle.is(':checked')) {
                $('#password').attr({
                    'type': 'text'
                });
            } else {
                $('#password').attr({
                    'type': 'password'
                });
            }
        })
});