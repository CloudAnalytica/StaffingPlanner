$(document).ready(function () {
    console.log('document ready');
    if ($('#registerButton').length) {
        console.log('register button exists');
        $("registerButton").attr('disabled', true);
        $("registerButton").attr('disabled', 'disabled');
    };
    if ($('#registerButton2').length) {
        console.log('register button exists2');
        $("registerButton2").attr('disabled', true);
        $("registerButton2").attr('disabled', 'disabled');
    };


});