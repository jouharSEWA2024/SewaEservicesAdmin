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

        $("#wizard_Documents").css("display", "block");
    }
    if (ErrorCode == "4") {
        $('#VerifyOTP').modal('show');
    }
    if (ErrorCode == "5") {

        $("#wizard_Service").css("display", "none");

        $("#wizard_Documents").css("display", "none");
    }
    $("#IssuingAuthorityverifyIdentity").hide();
    var IdType = $('#IDTypeList :selected').val();
    if (IdType == "TradeLicense") {
        $("#IssuingAuthorityverifyIdentity").show();
    }
    else {
        $("#IssuingAuthorityverifyIdentity").hide();
    }
})

function LoadDocuments() {
    // hiding all screen and show loader tab
    var AccountNumber = $('#AccountNumber').val();
    if (AccountNumber != null || AccountNumber != '' || AccountNumber != undefined) {
        $(ApplyGasAlterationForm).submit();
    }
}
function FinalSubmit() {
    // hiding all screen and show loader tab
    $("#wizard_Service").css("display", "none");

    $("#wizard_Documents").css("display", "none");
    $("#preloadertab").css("display", "block");
    $("#Step").val("SECOND");
    $(ApplyGasAlterationForm).submit();

}
function InitialSubmit() {
    var culture = $('#culture').find(":selected").val();
    var IDType = $('#IDTypeList').val();
    var IDTypeErr = "الرجاء تحديد نوع الهوية"
    if (IDType == null || IDType == undefined || IDType == "") {
        if (culture == "en-US") {
            $('#IDTypeErr').html("Please select ID Type");
        }
        else {
            $('#IDTypeErr').html(IDTypeErr);
        }
        $('#IDTypeList').focus();
        return false;
    }
    if (IDType == "TradeLicense") {
        var IssueAuthorityverifyIdentityList = $('#IssueAuthorityverifyIdentityList').val();
        var IssueAuthorityverifyIdentityListErr = "الرجاء تحديد الجهة المصدرة";
        if (IssueAuthorityverifyIdentityList == null || IssueAuthorityverifyIdentityList == undefined || IssueAuthorityverifyIdentityList == "") {
            if (culture == "en-US") {
                $('#IssueAuthorityverifyIdentityListErr').html("Please select Issuing Authority");
            }
            else {
                $('#IssueAuthorityverifyIdentityListErr').html(IssueAuthorityverifyIdentityListErr);
            }
            $('#IssueAuthorityverifyIdentityList').focus();
            return false;
        }
    }
    var IDNumber = $('#IDNumber').val();
    var IDNumberErr = "الرجاء إدخال رقم الهوية"
    if (IDNumber == null || IDNumber == undefined || IDNumber == "") {
        if (culture == "en-US") {
            $('#IDNumberErr').html("Please enter ID Number");
        }
        else {
            $('#IDNumberErr').html(IDNumberErr);
        }
        $('#IDNumber').focus();
        return false;
    }
    var AccountNumber = $('#AccountNumber').val();
    var AccountNumberErr = "الرجاء إدخال رقم الحساب"
    if (AccountNumber == null || AccountNumber == undefined || AccountNumber == "") {
        if (culture == "en-US") {
            $('#AccountNumberErr').html("Please enter Account Number");
        }
        else {
            $('#AccountNumberErr').html(AccountNumberErr);
        }
        $('#AccountNumber').focus();
        return false;
    }
    $("#Step").val("FIRST");
    // hiding all screen and show loader tab
    $("#wizard_Service").css("display", "block");

    $("#wizard_Documents").css("display", "none");
    $("#preloadertab").css("display", "block");

    $(ApplyGasAlterationForm).submit();

}
function LoadAttributes() {
    var IdType = $('#IDTypeList :selected').val();
    if (IdType == "TradeLicense") {
        $("#IssuingAuthorityverifyIdentity").show();
    }
    else {
        $("#IssuingAuthorityverifyIdentity").hide();
    }
}
function VerifyOTPSubmit() {
    var culture = $('#culture').find(":selected").val();
    $("#OTPErr").html("");

    $("#StepName").val("FIRST");
    var OTP = $("#OTP").val();
    var statusofvalidation = 1;
    if (OTP == '' || OTP == null || OTP == undefined) {
        if (culture == "en-US") {
            $("#OTPErr").html("Please Enter OTP");
        }
        else {
            $("#OTPErr").html("الرجاء إدخال كلمة المرور لمرة واحدة");
        }
        statusofvalidation = 0;
        return false;
    }
    if (statusofvalidation == 1) {
        $("#preloadertab").css("display", "block");
        $("#wizard_Service").css("display", "none");
        $("#wizard_Documents").css("display", "none");
        $(ApplyGasAlterationOTPForm).submit();
    }
}
