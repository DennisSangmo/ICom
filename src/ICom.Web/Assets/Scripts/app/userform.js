$(document).ready(function() {
    $("#nameinput").blur(function () {
        var username = $(this).val().toLowerCase().replace(" ", ".");
        $("#usernameinput").val(username);
    });
});