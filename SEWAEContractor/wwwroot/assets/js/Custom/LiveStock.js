var allOptions = "";
$(document).ready(function () {
    $("#preloadertab").css("display", "none");
    LoadAttributes();
    KeepOnlyEMID();
    if ($("#IsTPSelected").is(":checked")) {
        EnableTPValidation();
    }
    else {
        DisableTPValidation();
    }
    $('#ExistingAccount').hide();
    var ErrorCode = $('#ErrorCode').val();
    if (ErrorCode == "10" ||ErrorCode == "5" || ErrorCode == "6") {
        $("#wizard_Service_verifyIdentity").css("display", "none");
        $("#wizard_Service_verifyPremise").css("display", "none");

        $("#wizard_Service_verifyDocuments").css("display", "none");
    }
    if (ErrorCode == "0") {   
        $("#wizard_Service_verifyIdentity").css("display", "none");
        $("#wizard_Service_verifyPremise").css("display", "block");      
    }
    if (ErrorCode == "3") {

        $("#wizard_Service_verifyIdentity").css("display", "none");
        $("#wizard_Service_verifyPremise").css("display", "none");
        $("#wizard_Service_verifyDocuments").css("display", "block");
    }
    if (ErrorCode == "4") {
        $('#VerifyOTP').modal('show');
    }
    if (ErrorCode == "2") {
        $("#wizard_Service_verifyPremise").css("display", "block"); 
        $("#wizard_Service_verifyIdentity").css("display", "none");
        $("#wizard_Service_verifyDocuments").css("display", "none");
    }
    
    var IsExistingAccount = $("#IsExistingAccount").val();
    var CAExisting = $('#IsCAExisting').val();
    var IsCADropdownExisting = $('#IsCADropdownExisting').val();

    if (CAExisting == 1 && IsExistingAccount == 'True') {
        $('#ExistingCA').attr('checked', 'checked');
    }
    else {
        $('#NewCA').attr('checked', 'checked');
    }
    $('input[id="ExistingCA"]').on("change", function () {
        $('#ExistingAccount').show();
    });
    $('input[id="NewCA"]').on("change", function () {
        $('#ExistingAccount').hide();
    });
    if (CAExisting == 1) {
        $('#ExistingAccount').show();
    }
    else {
        $('#ExistingAccount').hide();
    }
    if (IsCADropdownExisting == 1 || IsCADropdownExisting == 2) {
        $('#ExistingAccount').hide();
    }
    else {
        if (CAExisting == 1) {
            $('#ExistingAccount').show();
        }
        else {
            $('#ExistingAccount').hide();
        }
        
    }
});
function InitialSubmit() {
    if (InitialSubmitValidations()) {
        $("#StepName").val("FIRST");
        $("#preloadertab").css("display", "block");
        $(LiveStockForm).submit();
    }
   
}
function KeepOnlyEMID() {
    allOptions = $('#IDTypeList option').clone();
    // The value you want to keep
    var keepValue = "EMID";

    // Loop through the Bootstrap-Select dropdown items
    $('#IDTypeList option').each(function () {
        if ($(this).val() !== keepValue) {
            $(this).remove();  // remove everything else
        }
    });
    // Set the desired value as selected
    $('#IDTypeList').val(keepValue);
    LoadAttributes();
    // Refresh the Bootstrap-Select UI
    $('#IDTypeList').selectpicker('refresh');
}
function LoadAttributes() {
    var IdType = $('#IDTypeList :selected').val();

    if (IdType == "TradeLicense") {
        $("#IssuingAuthority").show();
    }
    else {
        $("#IssuingAuthority").hide();
    }
    
}
function EnableTPValidation() {
    var TPTransactionIDValidationRequired = $('#TPTransactionIDValidationRequired').val();

    if (TPTransactionIDValidationRequired == "True") {
        $('#TPTransactionTab').show();
    }
    else {
        $('#TPTransactionTab').hide();
    }
   
}
function DisableTPValidation() {
    $('#TPTransactionTab').hide();
}
function InitialSubmitValidations() {
    var culture = $('#culture').find(":selected").val();

    var IdType = $('#IDTypeList :selected').val();
    var IDNumber = $('#IDNumber').val();
    var TPTransactionIDValidationRequired = $('#TPTransactionIDValidationRequired').val();
    // validating ID type selected
    if (IdType == null || IdType == "" || IdType == undefined) {
        var errorMessage = $('#IDTypeErr').data('msg');
        $('#IDTypeErr').text(errorMessage);
        
        $('#IDTypeList').focus();
        return false;
    }
    // validating ID number entered (Emirates ID)
    if (IDNumber == null || IDNumber == "" || IDNumber == undefined) {
        var errorMessage = $('#IDNumberErr').data('msg');
        $('#IDNumberErr').text(errorMessage);
        $('#IDNumber').focus();
        return false;
    }

    // validating TP Transaction
    if ($("#IsTPSelected").is(":checked")) {
        if (TPTransactionIDValidationRequired == "True") {
            var TPTransactionID = $("#TPTransactionID").val();
            if (TPTransactionID == null || TPTransactionID == "" || TPTransactionID == undefined) {
                var errorMessage = $('#TPTransactionIDErr').data('msg');
                $('#TPTransactionIDErr').text(errorMessage);
                $('#TPTransactionID').focus();
                return false;
            }
        }
    }
    return true;
}
function LoadArea() {
    var CityId = $('#CityList').val();
    if (CityId != "" || CityId != null || CityId != undefined) {
        $("#StepName").val("AREASELECTED");
        $("#preloadertab").css("display", "block");
        $(LiveStockForm).submit();
    }
}
function SubmitOTP() {
    
    var OTP = $('#OTP').val();
    if (OTP != "" && OTP != null && OTP != undefined) {
        $("#preloadertab").css("display", "block");
        $(OTPForm).submit();
    }
    else {
        var errorMessage = $('#OTPErr').data('msg');
        $('#OTPErr').text(errorMessage);
        return false;
    }
}
function ValidateConsultant() {
    $('#ConsultantTradeLicenseErr').html("");
    $('#ConsultantIssuingAuthorityListErr').html("");
    var culture = $('#culture').find(":selected").val();
    var TradeLicense = $('#ConsultantTradeLicense').val();
    var IssueAuthorityId = $('#ConsultantIssuingAuthorityList').val();
    var base = $(location).attr('host');
    $.ajax({
        url: "https://" + base + "/Service/checkContractorConsultant?TradeLicense=" + TradeLicense + "&IssueAuthorityId=" + IssueAuthorityId,
        type: 'GET',
        contentType: false,
        processData: false,
        async: false,
        success: function (res) {
            console.log(res);
            if (res.bpId == null) {
                if ($(Cons).hasClass('fa fa-check')) {
                    $(Cons).removeClass('fa fa-check');
                    $(Cons).addClass('fa fa-close');
                }
                var licenseErr = "الرجاء إدخال تفاصيل ترخيص صالحة";
                var issueAuthorityErr = "الرجاء إدخال تفاصيل صالحة لجهة الإصدار";
                if (culture == "en-US") {
                    $('#ConsultantTradeLicenseErr').html("Please enter valid license details");
                    $('#ConsultantIssuingAuthorityListErr').html("Please enter valid Issuing Authority details");
                }
                else {
                    $('#ConsultantTradeLicenseErr').html(licenseErr);
                    $('#ConsultantIssuingAuthorityListErr').html(issueAuthorityErr);
                }

                $('#ConsultantTradeLicense').focus();
                $('#ConsultantIssuingAuthorityList').focus();
            }
            else {
                if ($(Cons).hasClass('fa fa-close')) {
                    $(Cons).removeClass('fa fa-close');
                    $(Cons).addClass('fa fa-check');
                }
            }

            $('#ConsultantBPId').val(res.bpId);
            $('#ConsultantTradeLicenseErr').html("");
            $('#ConsultantIssuingAuthorityListErr').html("");
        }
    });
    return false;
}
function ValidateContractor() {
    $('#ContractorTradeLicenseErr').html("");
    $('#ContractorIssuingAuthorityListErr').html("");
    var culture = $('#culture').find(":selected").val();
    var TradeLicense = $('#ContractorTradeLicense').val();
    var IssueAuthorityId = $('#ContractorIssuingAuthorityList').val();
    var base = $(location).attr('host');
    $.ajax({
        url: "https://" + base + "/Service/checkContractorConsultant?TradeLicense=" + TradeLicense + "&IssueAuthorityId=" + IssueAuthorityId,
        type: 'GET',
        async: false,
        contentType: false,
        processData: false,
        success: function (res) {
            console.log(res);
            if (res.bpId == null) {
                if ($(Cont).hasClass('fa fa-check')) {
                    $(Cont).removeClass('fa fa-check');
                    $(Cont).addClass('fa fa-close');
                }
                var licenseErr = "الرجاء إدخال تفاصيل ترخيص صالحة";
                var issueAuthorityErr = "الرجاء إدخال تفاصيل صالحة لجهة الإصدار";
                if (culture == "en-US") {
                    $('#ContractorTradeLicenseErr').html("Please enter valid license details");
                    $('#ContractorIssuingAuthorityListErr').html("Please enter valid Issuing Authority details");
                }
                else {
                    $('#ContractorTradeLicenseErr').html(licenseErr);
                    $('#ContractorIssuingAuthorityListErr').html(issueAuthorityErr);
                }

                $('#ContractorTradeLicense').focus();
                $('#ContractorIssuingAuthorityList').focus();
            }
            else {
                if ($(Cont).hasClass('fa fa-close')) {
                    $(Cont).removeClass('fa fa-close');
                    $(Cont).addClass('fa fa-check');
                }
                var BpId = res.bpId;
                $('#ContractorBPId').val(BpId);
                $('#ContractorTradeLicenseErr').html("");
                $('#ContractorIssuingAuthorityListErr').html("");
            }

        }
    });
    return false;
}
function ValidateMainContractor() {
    var culture = $('#culture').find(":selected").val();
    var TradeLicense = $('#MainContractorTradeLicense').val();
    var IssueAuthorityId = $('#MainContractorIssuingAuthorityList').val();
    var base = $(location).attr('host');
    $.ajax({
        url: "https://" + base + "/Service/checkContractorConsultant?TradeLicense=" + TradeLicense + "&IssueAuthorityId=" + IssueAuthorityId,
        type: 'GET',
        async: false,
        contentType: false,
        processData: false,
        success: function (res) {
            console.log(res);
            if (res.bpId == null) {
                if ($(MainCont).hasClass('fa fa-check')) {
                    $(MainCont).removeClass('fa fa-check');
                    $(MainCont).addClass('fa fa-close');

                }
                var licenseErr = "الرجاء إدخال تفاصيل ترخيص صالحة";
                var issueAuthorityErr = "الرجاء إدخال تفاصيل صالحة لجهة الإصدار";
                if (culture == "en-US") {
                    $('#MainContractorTradeLicenseErr').html("Please enter valid license details");
                    $('#MainContractorIssuingAuthorityListErr').html("Please enter valid Issuing Authority details");
                }
                else {
                    $('#MainContractorTradeLicenseErr').html(licenseErr);
                    $('#MainContractorIssuingAuthorityListErr').html(issueAuthorityErr);
                }
                $('#MainContractorTradeLicense').focus();
                $('#MainContractorIssuingAuthorityList').focus();
            }
            else {
                if ($(MainCont).hasClass('fa fa-close')) {
                    $(MainCont).removeClass('fa fa-close');
                    $(MainCont).addClass('fa fa-check');
                }
                var BpId = res.bpId;
                $('#MainContractorBPId').val(BpId);
                $('#MainContractorTradeLicenseErr').html("");
                $('#MainContractorIssuingAuthorityListErr').html("");
            }



        }

    });
    return false;
}
function SecondarySubmit() {
    if (SecondarySubmitValidations()) {
        $("#StepName").val("SECOND");
        $("#preloadertab").css("display", "block");
        $(LiveStockForm).submit();
    }
    
}
function SecondarySubmitValidations() {
    $('#ProjectDescriptionErr').text("");
    $('#ProjectCategoryListErr').text("");
    var IsNewBP = $("#IsNewBP").val();
    var culture = $('#culture').find(":selected").val();
    if (IsNewBP == 1) {
        $('#PhoneNumberErr').text("");
        var PhoneNumber = $("#PhoneNumber").val();
        if (PhoneNumber == null || PhoneNumber == "" || PhoneNumber == undefined) {
            var errorMessage = $('#PhoneNumberErr').data('msg');
            $('#PhoneNumberErr').text(errorMessage);
            $('#PhoneNumber').focus();
            return false;
        }
        if (PhoneNumber != null && PhoneNumber != "" && PhoneNumber != undefined) {
            var regex = /^\(?([0-9]{3})\)?[-]?([0-9]{7})$/;
            var PhoneNumberErr = " يرجى إدخال رقم الهاتف المتحرك بالصيغة المذكورة 0**-*******";
            if (!regex.test(PhoneNumber)) {
                if (culture == "en-US") {
                    $('#PhoneNumberErr').text('Please enter mobile no in mentioned format 0**-*******');
                }
                else {
                    $('#PhoneNumberErr').text(PhoneNumberErr);
                }
                $('#PhoneNumber').focus();
                return false;
            }
        }
    }
    if ($("#IsMunicipalitySelected").is(":checked")) {
        $('#PlotErr').text("");
        $('#CityListErr').text("");
        $('#AreaListErr').text("");
        $('#ProjectCategoryListErr').text("");
        var City = $("#CityList").val();
        if (City == null || City == "" || City == undefined) {
            var errorMessage = $('#CityListErr').data('msg');
            $('#CityListErr').text(errorMessage);
            $('#CityList').focus();
            return false;
        }
        var Area = $("#AreaList").val();
        if (Area == null || Area == "" || Area == undefined) {
            var errorMessage = $('#AreaListErr').data('msg');
            $('#AreaListErr').text(errorMessage);
            $('#AreaList').focus();
            return false;
        }
        var Plot = $("#Plot").val();
        if (Plot == null || Plot == "" || Plot == undefined) {
            var errorMessage = $('#PlotErr').data('msg');
            $('#PlotErr').text(errorMessage);
            $('#Plot').focus();
            return false;
        }
        var ProjectCategoryList = $("#ProjectCategoryList").val();
        if (ProjectCategoryList == null || ProjectCategoryList == "" || ProjectCategoryList == undefined) {
            var errorMessage = $('#ProjectCategoryListErr').data('msg');
            $('#ProjectCategoryListErr').text(errorMessage);
            $('#ProjectCategoryList').focus();
            return false;
        }
    }

    var ProjectDescription = $("#ProjectDescription").val();
    if (ProjectDescription == null || ProjectDescription == "" || ProjectDescription == undefined) {
        var errorMessage = $('#ProjectDescriptionErr').data('msg');
        $('#ProjectDescriptionErr').text(errorMessage);
        $('#ProjectDescription').focus();
        return false;
    }
    return true;
}
function FinalSubmit() {
    $("#StepName").val("THIRD");
    $("#preloadertab").css("display", "block");
    $('#LiveStockForm').trigger('submit');
}
// allowing only numbers
function checkAlphabetSpecial() {
    var charCode = (event.which) ? event.which : event.keyCode;
    console.log(charCode);
    if (!((charCode >= 33 && charCode <= 45) || charCode == 47 || (charCode >= 60 && charCode <= 64) || (charCode >= 91 && charCode <= 96) || (charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122))) {
        return true;
    }
    else {
        return false;
    }
}
function LoadPremiseScreen() {
    $("#wizard_Service_verifyIdentity").css("display", "none");
    $("#wizard_Service_verifyPremise").css("display", "block");
    $("#wizard_Service_verifyDocuments").css("display", "none");
}