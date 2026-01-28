$(document).ready(function () {
    $("#preloadertab").css("display", "none");
    var ErrorCode = $('#ErrorCode').val();
    if (ErrorCode == "2") {

        $("#wizard_Service").css("display", "none");

        $("#wizard_Documents").css("display", "block");
    }
    if (ErrorCode == "1") {

        $("#wizard_Service").css("display", "block");

        $("#wizard_Documents").css("display", "none");
    }
    if (ErrorCode == "3") {

        $("#wizard_Service").css("display", "none");

        $("#wizard_Documents").css("display", "none");
    }
    if (ErrorCode == "4") {

        $('#VerifyOTP').modal('show');
    }
})
function LoadDocuments() {
    // hiding all screen and show loader tab
    $("#preloadertab").css("display", "block");
    var AccountNumber = $('#AccountNumber').val();
    if (AccountNumber != null || AccountNumber != '' || AccountNumber != undefined) {
        $(CompanyRegistrationForm).submit();
    }


}
function FinalSubmit() {
    // hiding all screen and show loader tab
    $("#wizard_Service").css("display", "none");

    $("#wizard_Documents").css("display", "none");

    $("#preloadertab").css("display", "block");
    var AccountNumber = $('#AccountNumber').val();
    if (AccountNumber != null || AccountNumber != '' || AccountNumber != undefined) {
        $(CompanyRegistrationForm).submit();
    }
}