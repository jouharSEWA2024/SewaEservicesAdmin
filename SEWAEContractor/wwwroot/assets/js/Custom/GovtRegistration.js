function SubmitValidations() {
    var culture = $('#culture').find(":selected").val();

    var GovtBP = $('#GovtList :selected').val();
    var UserName = $("#UserName").val();
    var Email = $("#Email").val();
    // validating entity selected
    if (GovtBP == null || GovtBP == "" || GovtBP == undefined) {
        var errorMessage = $('#GovtListErr').data('msg');
        $('#GovtListErr').text(errorMessage);

        $('#GovtList').focus();
        return false;
    }
    // validating username
    if (UserName == null || UserName == "" || UserName == undefined) {
        var errorMessage = $('#UserNameErr').data('msg');
        $('#UserNameErr').text(errorMessage);
        $('#UserName').focus();
        return false;
    }
    // validating Email
    if (Email == null || Email == "" || Email == undefined) {
        var errorMessage = $('#EmailErr').data('msg');
        $('#EmailErr').text(errorMessage);
        $('#Email').focus();
        return false;
    }
    return true;
}
function Submit() {
    if (SubmitValidations()) {
        $(CreateGovernmentUserForm).submit();
    }
}