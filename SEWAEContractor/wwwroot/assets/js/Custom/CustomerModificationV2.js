$(document).ready(function () {
    $("#preloadertab").css("display", "none");
    $('#OwnerContactNoOptional').hide();
    $('#OwnerContactNoMandatory').hide();
    $('#VerifyOTP').hide();
    if ($("#IsOwner").is(':checked') == true) {
        $('#OwnerContactNoOptional').show();
        $('#OwnerContactNoMandatory').hide();
    }
    if ($("#IsTenant").is(':checked') == true) {
        $('#OwnerContactNoOptional').hide();
        $('#OwnerContactNoMandatory').show();
    }

    var ErrorCode = $('#ErrorCode').val();

    if (ErrorCode == "0") {
        $("#wizard_Service_verifyIdentity").css("display", "none");
        $("#wizard_Service").css("display", "block");
        $("#wizard_Documents").css("display", "none");
        $("#Error").hide();
    }
    if (ErrorCode == "1") {

        $("#wizard_Service").css("display", "none");
        $("#wizard_Service_verifyIdentity").css("display", "block");
        $("#wizard_Documents").css("display", "none");
    }
    if (ErrorCode == "2") {

        $("#wizard_Service").css("display", "block");
        $("#wizard_Service_verifyIdentity").css("display", "none");
        $("#wizard_Documents").css("display", "none");
    }
    if (ErrorCode == "3") {

        $("#wizard_Service").css("display", "none");
        $("#wizard_Service_verifyIdentity").css("display", "none");
        $("#wizard_Documents").css("display", "block");
    }
    if (ErrorCode == "5") {

        $("#wizard_Service").css("display", "none");
        $("#wizard_Service_verifyIdentity").css("display", "none");
        $("#wizard_Documents").css("display", "none");
    }
    if (ErrorCode == "4") {
        $('#VerifyOTP').modal('show');
    }
    $("#IssuingAuthorityverifyIdentity").hide();
    var IdType = $('#IDTypeList :selected').val();
    if (IdType == "TradeLicense") {
        $("#IssuingAuthorityverifyIdentity").show();
    }
    else {
        $("#IssuingAuthorityverifyIdentity").hide();
    }
});
function LoadAttributes() {
    var IdType = $('#IDTypeList :selected').val();
    if (IdType == "TradeLicense") {
        $("#IssuingAuthorityverifyIdentity").show();
    }
    else {
        $("#IssuingAuthorityverifyIdentity").hide();
    }
}
function LoadOptions() {
    if ($("#IsOwner").is(':checked') == true) {
        $('#OwnerContactNoOptional').show();
        $('#OwnerContactNoMandatory').hide();
    }
    if ($("#IsTenant").is(':checked') == true) {
        $('#OwnerContactNoOptional').hide();
        $('#OwnerContactNoMandatory').show();
    }
}
function PartialSubmitIdentity() {
    $("#StepName").val("FIRST");
    $("#IDTypeErr").html("");
    $("#IDNumberErr").html("");
    $("#IssueAuthorityListErr").html("");
    var statusofvalidation = 1;
    var IdType = $('#IDTypeList :selected').val();
    var IDNumber = $("#IDNumber").val();
    if (IdType == '' || IdType == null || IdType == undefined) {
        $("#IDTypeErr").html("Select ID Type");
        statusofvalidation = 0;
        return false;
    }
    if (IDNumber == '' || IDNumber == null || IDNumber == undefined) {
        $("#IDNumberErr").html("Enter ID Value");
        statusofvalidation = 0;
        return false;
    }
    var IdType = $('#IDTypeList :selected').val();
    if (IdType == "TradeLicense") {
        var IssueAuthority = $("#IssueAuthorityverifyIdentityList :selected").val();
        if (IssueAuthority == null || IssueAuthority == '' || IssueAuthority == undefined) {
            $("#IssueAuthorityListErr").html("Select Issuing Authority");
            statusofvalidation = 0;
            return false;
        }
    }
    if (statusofvalidation == 1) {
        $("#preloadertab").css("display", "block");
        $("#wizard_Service").css("display", "none");
        $("#wizard_Service_verifyIdentity").css("display", "none");
        $("#wizard_Documents").css("display", "none");
        $(AdditionalLoadForm).submit();
    }
}
function VerifyOTPSubmit() {
    $("#OTPErr").html("");

    $("#StepName").val("FIRST");
    var OTP = $("#OTP").val();
    var statusofvalidation = 1;
    if (OTP == '' || OTP == null || OTP == undefined) {
        $("#OTPErr").html("Please Enter OTP");
        statusofvalidation = 0;
        return false;
    }
    if (statusofvalidation == 1) {
        $("#preloadertab").css("display", "block");
        $("#wizard_Service").css("display", "none");
        $("#wizard_Service_verifyIdentity").css("display", "none");
        $("#wizard_Documents").css("display", "none");
        $(AdditionalLoadOTPForm).submit();
    }


}
function PartialSubmit() {
    $('#AccountNumberErr').html("");

    $("#StepName").val("SECOND");
    var AccountNumber = $('#AccountNumber').val();
    var ElectricalContractorTradeLicense = $('#ElectricalContractorTradeLicense').val();
    var ProposedAdditionalLoad = $('#ProposedAdditionalLoad').val();
    var OwnerMobNumber = $('#OwnerContactNoMandatory').val();
    var statusofvalidation = 1;
    if (AccountNumber == '' || AccountNumber == undefined || AccountNumber == null) {
        $('#AccountNumberErr').html("Enter account No");
        statusofvalidation = 0;
        return false;
    }
    if (ElectricalContractorTradeLicense == '' || ElectricalContractorTradeLicense == undefined || ElectricalContractorTradeLicense == null) {
        $('#ElectricalContractorTradeLicenseErr').html("Enter Electrical Contractor Trade License No");
        statusofvalidation = 0;
        return false;
    }
    if (ProposedAdditionalLoad == '' || ProposedAdditionalLoad == undefined || ProposedAdditionalLoad == null) {
        $('#ProposedAdditionalLoadListErr').html("Enter Proposed Additional Load");
        statusofvalidation = 0;
        return false;
    }
    var IssuingAuthority = $('#IssueAuthorityList :selected').val();
    if (IssuingAuthority == "") {
        statusofvalidation = 0;
       // $('#IssueAuthorityListErr').html("Issuing Authority is Mandatory");
       
        return false;
    }
    //if ($("#IsOwner").is(':checked') == false) {
    //    if (OwnerMobNumber == '' || OwnerMobNumber == undefined || OwnerMobNumber == null) {
    //        $('#OwnerContactNoManErr').html("Enter Owner Mobile Number");
    //        return false;
    //    }
    //}
    if (statusofvalidation == 1) {
        $("#preloadertab").css("display", "block");
        $("#wizard_Service").css("display", "none");
        $("#wizard_Service_verifyIdentity").css("display", "none");
        $("#wizard_Documents").css("display", "none");
        $(AdditionalLoadForm).submit();
    }
   
    
}
function FinalSubmit() {
  
    $("#StepName").val("FINAL");
    $("#preloadertab").css("display", "block");
    $("#wizard_Service").css("display", "none");
    $("#wizard_Service_verifyIdentity").css("display", "none");
    $("#wizard_Documents").css("display", "none");
    $(AdditionalLoadForm).submit();



}
function checkAlphabetSpecial() {
    var charCode = (event.which) ? event.which : event.keyCode;
    console.log(charCode);
    if (!((charCode >= 33 && charCode <= 43) || charCode == 45 || charCode == 47 || (charCode >= 60 && charCode <= 64) || (charCode >= 91 && charCode <= 96) || (charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122))) {
        return true;
    }
    else {
        return false;
    }
}