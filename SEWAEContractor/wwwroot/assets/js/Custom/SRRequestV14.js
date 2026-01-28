$(document).ready(function () {
    


    $("#preloadertab").css("display", "none");
    $("#TransformerView").hide();
    $("#TransformerType").hide();
    var TransformerRequired = $("#TransformerRequiredList :selected").val();
    if (TransformerRequired == "1") {
        $("#TransformerView").show();
        $("#TransformerType").show();
        var Transformer100KvValue = $('#Transformer100KvValue').val();
        if (Transformer100KvValue != "") {
            if (Transformer100KvValue != null || Transformer100KvValue != '' || Transformer100KvValue != undefined) {
                $('#Transformer100KvDeleteHtml').show();
            }
        }
        
        var Transformer200KvValue = $('#Transformer200KvValue').val();
        if (Transformer200KvValue != "") {
            if (Transformer200KvValue != null || Transformer200KvValue != '' || Transformer200KvValue != undefined) {
                $('#Transformer200KvDeleteHtml').show();
            }
        }
        var Transformer250KvValue = $('#Transformer250KvValue').val();
        if (Transformer250KvValue != "") {
            if (Transformer250KvValue != null || Transformer250KvValue != '' || Transformer250KvValue != undefined) {
                $('#Transformer250KvDeleteHtml').show();
            }
        }
        
        var Transformer500KvValue = $('#Transformer500KvValue').val();
        if (Transformer500KvValue != "") {
            if (Transformer500KvValue != null || Transformer500KvValue != '' || Transformer500KvValue != undefined) {
                $('#Transformer500KvDeleteHtml').show();
            }
        }
        var Transformer1000KvValue = $('#Transformer1000KvValue').val();
        if (Transformer1000KvValue != "") {
            if (Transformer1000KvValue != null || Transformer1000KvValue != '' || Transformer1000KvValue != undefined) {
                $('#Transformer1000KvDeleteHtml').show();
            }
        }
        var Transformer1500KvValue = $('#Transformer1500KvValue').val();
        if (Transformer1500KvValue != "") {
            if (Transformer1500KvValue != null || Transformer1500KvValue != '' || Transformer1500KvValue != undefined) {
                $('#Transformer1500KvDeleteHtml').show();
            }
        }
        var Transformer2000KvValue = $('#Transformer2000KvValue').val();
        if (Transformer2000KvValue != "") {
            if (Transformer2000KvValue != null || Transformer2000KvValue != '' || Transformer2000KvValue != undefined) {
                $('#Transformer2000KvDeleteHtml').show();
            }
        }
    }
    //var MainContractor = $('#MainContractorBPId').val();
    //if (MainContractor != null || MainContractor != '' || MainContractor == undefined) {
    //    if ($(MainCont).hasClass('fa fa-close')) {
    //        $(MainCont).removeClass('fa fa-close');
    //        $(MainCont).addClass('fa fa-check');
    //    }
    //}
    
    //var Contractor = $('#ContractorBPId').val();
    //if (Contractor != null || Contractor != '' || Contractor == undefined) {
    //    if ($(Cont).hasClass('fa fa-close')) {
    //        $(Cont).removeClass('fa fa-close');
    //        $(Cont).addClass('fa fa-check');
    //    }
    //}
    
    //var Consultant = $('#ConsultantBPId').val();
    //if (Consultant != null || Consultant != '' || Consultant == undefined) {
    //    if ($(Cons).hasClass('fa fa-close')) {
    //        $(Cons).removeClass('fa fa-close');
    //        $(Cons).addClass('fa fa-check');
    //    }
    //}
    
    $("#Error").show();

    $("#IssuingAuthority").hide();
    var IdType = $('#IDTypeList :selected').val();
    if (IdType == "TradeLicense") {
        $("#IssuingAuthority").show();
    }
    else {
        $("#IssuingAuthority").hide();
    }
    $('#ExistingAccount').hide();
    var ErrorCode = $('#ErrorCode').val();
    if (ErrorCode == "10") {
        $("#wizard_Time").css("display", "none");
        $("#wizard_Service").css("display", "none");
        
        $("#wizard_Details").css("display", "none");
    }
    if (ErrorCode == "0") {
        //$('#wizard_Service').hide();
        document.getElementById("wizard_Service").style.display = 'none';
        //$("#wizard_Service").css("display", "none");
        //$('#wizard_Time').show();
        document.getElementById("wizard_Time").style.display = 'block';
        //$("#wizard_Time").css("display", "block");
    }
    if (ErrorCode == "3") {

        $("#wizard_Time").css("display", "none");
        $("#wizard_Service").css("display", "none");
        //$('#wizard_Time').show();
        //document.getElementById("wizard_Time").style.display = 'block';
        $("#wizard_Details").css("display", "block");
    }
    if (ErrorCode == "4") {
        $('#VerifyOTP').modal('show');
    }
    if (ErrorCode == "2") {
        $("#wizard_Time").css("display", "block");
        $("#wizard_Service").css("display", "none");
        //$('#wizard_Time').show();
        //document.getElementById("wizard_Time").style.display = 'block';
        $("#wizard_Details").css("display", "none");
    }
    
    var IsNewAccount = $("#IsNewAccount").val();
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

    $('input[id="IsNew"]').on("change", function () {
       
        $(SRVerification).submit();
    });
    $('input[id="IsRenew"]').on("change", function () {
        
        $(SRVerification).submit();
    });
    if (ErrorCode == "5" || ErrorCode == "6") {

        $("#wizard_Time").css("display", "none");
        $("#wizard_Service").css("display", "none");
        //$('#wizard_Time').show();
        //document.getElementById("wizard_Time").style.display = 'block';
        $("#wizard_Details").css("display", "none");
    }
    
    
    if (CAExisting == 1) {
        $('#ExistingAccount').show();
    }
    else {
        $('#ExistingAccount').hide();
    }
    if (IsCADropdownExisting == 1 || IsCADropdownExisting==2) {
        $('#ExistingAccount').hide();
    }
    else {
        if (CAExisting == 1) {
            $('#ExistingAccount').show();
        }
        else {
            $('#ExistingAccount').hide();
        }
        //$('#ExistingAccount').show();
    }
});
function LoadAttributes() {
    var IdType = $('#IDTypeList :selected').val();
    if (IdType == "TradeLicense") {
        $("#IssuingAuthority").show();
    }
    else {
        $("#IssuingAuthority").hide();
    }
}

//function LoadServiceType() {
    
//    $("#wizard_Time").css("display", "none");
//    $("#wizard_Service").css("display", "none");
    
//        $("#wizard_Details").css("display", "block");
//}
function LoadDocuments() {
    var SubService = $('#SubServiceTypeList').val();
    if (SubService != "" || SubService != null || SubService != undefined) {
        $(SRVerification).submit();
    }
}
function LoadArea() {
    var CityId = $('#CityList').val();
    if (CityId != "" || CityId != null || CityId != undefined) {
        $(SRForm).submit();
    }
}
function FinalSubmit() {
    // hiding all screen and show loader tab
    $("#wizard_Time").css("display", "none");
    $("#wizard_Service").css("display", "none");
    
    $("#wizard_Details").css("display", "none");
    $("#preloadertab").css("display", "block");
    $("#Error").hide();
    $(SRForm).submit();
    
}
function ValidateConsultant() {
    var TradeLicense = $('#ConsultantTradeLicense').val();
    var IssueAuthorityId = $('#ConsultantIssuingAuthorityList').val();
    var base = $(location).attr('host');    
    $.ajax({
        url: "https://"+base+"/Service/checkContractorConsultant?TradeLicense=" + TradeLicense + "&IssueAuthorityId=" + IssueAuthorityId,
        type: 'GET',
        contentType: false,
        processData: false,
        async:false,
        success: function (res) {
            console.log(res);
            if (res.bpId == null) {
                if ($(Cons).hasClass('fa fa-check')) {
                    $(Cons).removeClass('fa fa-check');
                    $(Cons).addClass('fa fa-close');
                }
            }
            else {
                if ($(Cons).hasClass('fa fa-close')) {
                    $(Cons).removeClass('fa fa-close');
                    $(Cons).addClass('fa fa-check');
                }
            }
            
            $('#ConsultantBPId').val(res.bpId);
            
        }
    });
    return false;
}
function ValidateContractor() {
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

            }
            else {
                if ($(Cont).hasClass('fa fa-close')) {
                    $(Cont).removeClass('fa fa-close');
                    $(Cont).addClass('fa fa-check');
                }
                var BpId = res.bpId;
                $('#ContractorBPId').val(BpId);
            }
            
            //var form = $("SRForm").val();
            //var formdata = new FormData(form);
            //formdata.append("contractorbpid", res.bpId);
        }
    });
    return false;
}
function ValidateMainContractor() {
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
                
            }
            else {
                if ($(MainCont).hasClass('fa fa-close')) {
                    $(MainCont).removeClass('fa fa-close');
                    $(MainCont).addClass('fa fa-check');
                }
                var BpId = res.bpId;
                $('#MainContractorBPId').val(BpId);
            }
            
            
            
        }
        
    });
    return false;
}
function EnableTransformerType() {
    var culture = $('#culture').find(":selected").val();
    $("#TransformerRequiredErr").html("");
    var TransformerRequired = $("#TransformerRequiredList :selected").val();
    if (TransformerRequired == "" || TransformerRequired == null || TransformerRequired == undefined) {
        var transformerRquiredErr = "حدد المحول المطلوب";
        if (culture == "en-US") {
            $("#TransformerRequiredErr").html("Select Transformer Required");
        }
        else {
            $("#TransformerRequiredErr").html(transformerRquiredErr);
        }
        
        $("#TransformerType").hide();
        return false;
    }
    if (TransformerRequired == "1") {
        $("#TransformerType").show();
    }
    if (TransformerRequired == "2")
    {
        $("#TransformerType").hide();
    }
    return false;
}
function AddTransformerType() {
    $("#TransformerCapacityErr").html("");
    $("#TransformerTypeErr").html("");
    $('#TransformerView').hide();
    var TransformerCapacity = $("#TransformerCapacity").val();
    if (TransformerCapacity == "" || TransformerCapacity == null || TransformerCapacity == undefined) {
        var transformerCapacityErr = "أدخل قيمة سعة المحول";
        if (culture == "en-US") {
            $("#TransformerCapacityErr").html("Enter Transformer Capacity Value");
        }
        else {
            $("#TransformerCapacityErr").html(transformerCapacityErr);
        }
       
        return false;
    }
    var TransformerType = $("#TransformerTypeList :selected").val();
    if (TransformerType == "" || TransformerType == null || TransformerType == undefined) {
        var transformerRquiredErr = "حدد المحول المطلوب";
        if (culture == "en-US") {
            $("#TransformerTypeErr").html("Select Transformer Type");
        }
        else {
            $("#TransformerTypeErr").html(transformerRquiredErr);
        }
        return false;
    }
    if (TransformerType == "Transformer Quantity 100 KVA") {
        $("#Transformer100KvText").val(TransformerType);
        $("#Transformer100KvTextHtml").html(TransformerType);
        $("#Transformer100KvValue").val(TransformerCapacity);
        $("#Transformer100KvValueHtml").html(TransformerCapacity);
        $("#Transformer100KvDeleteHtml").css("display", "block");
    }
    
    if (TransformerType == "Transformer Quantity 200 KVA") {
        $("#Transformer200KvText").val(TransformerType);
        $("#Transformer200KvTextHtml").html(TransformerType);
        $("#Transformer200KvValue").val(TransformerCapacity);
        $("#Transformer200KvValueHtml").html(TransformerCapacity);
        $("#Transformer200KvDeleteHtml").css("display", "block");
    }
    if (TransformerType == "Transformer Quantity 250 KVA") {
        $("#Transformer250KvText").val(TransformerType);
        $("#Transformer250KvTextHtml").html(TransformerType);
        $("#Transformer250KvValue").val(TransformerCapacity);
        $("#Transformer250KvValueHtml").html(TransformerCapacity);
        $("#Transformer250KvDeleteHtml").css("display", "block");
    }
    if (TransformerType == "Transformer Quantity 500 KVA") {
        $("#Transformer500KvText").val(TransformerType);
        $("#Transformer500KvTextHtml").html(TransformerType);
        $("#Transformer500KvValue").val(TransformerCapacity);
        $("#Transformer500KvValueHtml").html(TransformerCapacity);
        $("#Transformer500KvDeleteHtml").css("display", "block");
    }
    if (TransformerType == "Transformer Quantity 1000 KVA") {
        $("#Transformer1000KvText").val(TransformerType);
        $("#Transformer1000KvTextHtml").html(TransformerType);
        $("#Transformer1000KvValue").val(TransformerCapacity);
        $("#Transformer1000KvValueHtml").html(TransformerCapacity);
        $("#Transformer1000KvDeleteHtml").css("display", "block");
    }
    if (TransformerType == "Transformer Quantity 1500 KVA") {
        $("#Transformer1500KvText").val(TransformerType);
        $("#Transformer1500KvTextHtml").html(TransformerType);
        $("#Transformer1500KvValue").val(TransformerCapacity);
        $("#Transformer1500KvValueHtml").html(TransformerCapacity);
        $("#Transformer1500KvDeleteHtml").css("display", "block");
    }
    if (TransformerType == "Transformer Quantity 2000 KVA") {
        $("#Transformer2000KvText").val(TransformerType);
        $("#Transformer2000KvTextHtml").html(TransformerType);
        $("#Transformer2000KvValue").val(TransformerCapacity);
        $("#Transformer2000KvValueHtml").html(TransformerCapacity);
        $("#Transformer2000KvDeleteHtml").css("display", "block");
    }
    $('#TransformerView').show();
    return false;
}
function SecondarySubmit() {
    $('#TransformerRequiredErr').html("");
    $('#RequestedLoadErr').html("");
    $('#MainContractorTradeLicenseErr').html("");
    $('#MainContractorIssuingAuthorityListErr').html("");
    $('#EnergizationDateErr').html("");
    $('#LetterCommentsErr').html("");
    $('#BuildingPermitCertificateDateErr').html("");
    $('#BuildingPermitCertificateNoErr').html("");
    $('#BuildingDescriptionErr').html("");
    $('#AccountListErr').html("");
    $('#AreaListErr').html("");
    $('#CityListErr').html("");
    $('#PlotErr').html("");
    $('#ProjectDescriptionErr').html("");
    var culture = $('#culture').find(":selected").val();
    var CityList = $('#CityList :selected ').val();
    if (CityList == null || CityList == "" || CityList == undefined) {
        var CityErr = "اختر المدينة";
        if (culture == "en-US") {
            $('#CityListErr').html("Please Select City");
        }
        else {
            $('#CityListErr').html(CityErr);
        }
        
        $('#CityList').focus();
        return false;
    }
    var AreaList = $('#AreaList :selected ').val();
    if (AreaList == null || AreaList == "" || AreaList == undefined) {
        var AreaErr = "اختر المنطقة";
        if (culture == "en-US") {
            $('#AreaListErr').html("Please select Area");
        }
        else {
            $('#AreaListErr').html(AreaErr);
        }
        
        $('#AreaList').focus();
        return false;
    }
    var AccountList = $('#AccountTypeList :selected ').val();
    if (AccountList == null || AccountList == "" || AccountList == undefined) {
        var AccountErr = "اختر نوع الحساب";
        if (culture == "en-US") {
            $('#AccountListErr').html("Please select Account Type");
        }
        else {

        } $('#AccountListErr').html(AccountErr);
       
        $('#AccountTypeList').focus();
        return false;
    }
    var Plot = $('#Plot').val();
    if (Plot == null || Plot == "" || Plot == undefined) {
        var PlotErr = "اختر قطعة الأرض";
        if (culture == "en-US") {
            $('#PlotErr').html("Please enter Plot");
        }
        else {
            $('#PlotErr').html(PlotErr);
        }
        
        $('#Plot').focus();
        return false;
    }
    var ProjectDescription = $('#ProjectDescription').val();
    if (ProjectDescription == null || ProjectDescription == "" || ProjectDescription == undefined) {
        var ProjectDescriptionErr = "الرجاء إدخال وصف المشروع";
        if (culture == "en-US") {

            $('#ProjectDescriptionErr').html("Please enter Project Description");
        }
        else {
            $('#ProjectDescriptionErr').html(ProjectDescriptionErr);
        }
        
        $('#ProjectDescription').focus();
        return false;
    }
    var AccountType = $('#AccountTypeList :selected ').text();
    $("#AccountType").val(AccountType);
    var IsMainContractorRequired = $('#IsMainContractorRequired').val();
    var IsContractorRequired = $('#IsContractorRequired').val();
    var IsConsultantRequired = $('#IsConsultantRequired').val();
    var IsDateofconnectionstatement = $('#IsDateofconnectionstatement').val();
    var IsCompletionCertificateRenew = $('#IsCompletionCertificateRenew').val();
    var CheckConsultant = $('#CheckConsultant').val();
    var CheckContractor = $('#CheckContractor').val();
    if (IsMainContractorRequired == "True") {
        var MainContractorBPId = $('#MainContractorBPId').val();
        if (MainContractorBPId == null || MainContractorBPId == "" || MainContractorBPId == undefined) {
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
            return false;
        }
    }
    if (CheckContractor == "True") {
        if (IsConsultantRequired == "True") {
            var ConsultantBPId = $('#ConsultantBPId').val();
            if (ConsultantBPId == null || ConsultantBPId == "" || ConsultantBPId == undefined) {
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
                return false;
            }
        }
    }
   
    if (CheckConsultant == "True") {
        if (IsContractorRequired == "True") {
            var ContractorBPId = $('#ContractorBPId').val();
            if (ContractorBPId == null || ContractorBPId == "" || ContractorBPId == undefined) {
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
                return false;
            }
        }
    }
    if (IsDateofconnectionstatement == "True") {
        var EnergizationDate = $('#EnergizationDate').val();
        var LetterComments = $('#LetterComments').val();

        if (EnergizationDate == null || EnergizationDate == "" || EnergizationDate == undefined) {
            var energizationDateErr = "الرجاء إدخال تاريخ التنشيط";
            if (culture == "en-US") {
                $('#EnergizationDateErr').html("Please enter energization date");
            }
            else {
                $('#EnergizationDateErr').html(energizationDateErr);
            }
            
            $('#EnergizationDate').focus();
            return false;
        }
        if (LetterComments == null || LetterComments == "" || LetterComments == undefined) {
            var letterErr = "الرجاء إدخال تعليقات الرسالة";
            if (culture == "en-US") {
                $('#LetterCommentsErr').html("Please enter Letter Comments");
            }
            else {
                $('#LetterCommentsErr').html(letterErr);
            }
           
            $('#LetterComments').focus();
            return false;
        }
    }
    if (IsCompletionCertificateRenew == "True") {
        var EnergizationDate = $('#EnergizationDate').val();
        var LetterComments = $('#LetterComments').val();
        var BuildingPermitCertificateDate = $('#BuildingPermitCertificateDate').val();
        var BuildingPermitCertificateNo = $('#BuildingPermitCertificateNo').val();
        var BuildingDescription=$('#BuildingDescription').val();
        if (LetterComments == null || LetterComments == "" || LetterComments == undefined) {
            var letterErr = "الرجاء إدخال تعليقات الرسالة";
            if (culture == "en-US") {
                $('#LetterCommentsErr').html("Please enter Letter Comments");
            }
            else {
                $('#LetterCommentsErr').html(letterErr);
            }
            
            $('#LetterComments').focus();
            return false;
        }
        if (BuildingPermitCertificateDate == null || BuildingPermitCertificateDate == "" || BuildingPermitCertificateDate == undefined) {
            var buildingPermitCertificateDateErr = "الرجاء إدخال تاريخ شهادة رخصة البناء";
            if (culture == "en-US") {
                $('#BuildingPermitCertificateDateErr').html("Please enter Building Permit Certificate Date");
            }
            else {
                $('#BuildingPermitCertificateDateErr').html(buildingPermitCertificateDateErr);
            }
            
            $('#BuildingPermitCertificateDate').focus();
            return false;
        }
        if (BuildingPermitCertificateNo == null || BuildingPermitCertificateNo == "" || BuildingPermitCertificateNo == undefined) {
            var buildingPermitCertificateNoErr = "الرجاء إدخال رقم شهادة رخصة البناء";
            if (culture == "en-US") {
                $('#BuildingPermitCertificateNoErr').html("Please enter Building Permit Certificate No");
            }
            else {
                
                $('#BuildingPermitCertificateNoErr').html(buildingPermitCertificateNoErr);
            }
            
            $('#BuildingPermitCertificateNo').focus();
            return false;
        }
        if (BuildingDescription == null || BuildingDescription == "" || BuildingDescription == undefined) {
            var buildingDescriptionErr = "الرجاء إدخال وصف المبنى";
            if (culture == "en-US") {
                $('#BuildingDescriptionErr').html("Please enter Building Description");
            }
            else {
                $('#BuildingDescriptionErr').html(buildingDescriptionErr);
            }
            
            $('#BuildingDescription').focus();
            return false;
        }
    }
    var ServiceList = $("#ServiceList").val();
    if (ServiceList != null && ServiceList != "" && ServiceList != undefined) {
        var Services = [];
        Services = ServiceList.split(",");
        if (Services != null && Services.length > 0) {
            for (let i = 0; i < Services.length; i++) {
                if (Services[i].toUpperCase().trim() == "ELECTRICITY") {
                    var TransformerRequired = $('#TransformerRequiredList').val();
                    if (TransformerRequired == null || TransformerRequired == "" || TransformerRequired == undefined) {
                        var TransformerRequiredErr = "الرجاء تحديد التحويل مطلوب أم لا";
                        if (culture == "en-US") {
                            $('#TransformerRequiredErr').html("Please select Transformed Required or not");
                        }
                        else {
                            $('#TransformerRequiredErr').html(TransformerRequiredErr);
                        }
                        
                        $('#TransformerRequiredList').focus();
                        return false;
                    }
                    var RequestedLoad = $("#RequestedLoad").val();
                    if (RequestedLoad == null || RequestedLoad == "" || RequestedLoad == undefined) {
                        var requestedLoadErr = "الرجاء إدخال الحمولة المطلوبة";
                        if (culture == "en-US") {
                            $('#RequestedLoadErr').html("Please enter Requested Load");
                        }
                        else {
                            $('#RequestedLoadErr').html(requestedLoadErr);
                        }
                        
                        $("#RequestedLoad").focus();
                        return false;
                    }
                    if (TransformerRequired != null || TransformerRequired != "" || TransformerRequired != undefined) {
                        if (RequestedLoad != null || RequestedLoad != "" || RequestedLoad != undefined) {
                            $(SRForm).submit();
                        }
                    }

                }
                else {
                    $(SRForm).submit();
                }
            }
        }
    }
   
}
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
function DeleteTransformerType(data) {
    if (data == "Transformer Quantity 100 KVA") {
        $("#Transformer100KvText").val("");
        $("#Transformer100KvTextHtml").html("");
        $("#Transformer100KvValue").val("");
        $("#Transformer100KvValueHtml").html("");
        $("#Transformer100KvDeleteHtml").css("display", "none");
    }

    if (data == "Transformer Quantity 200 KVA") {
        $("#Transformer200KvText").val("");
        $("#Transformer200KvTextHtml").html("");
        $("#Transformer200KvValue").val("");
        $("#Transformer200KvValueHtml").html("");
        $("#Transformer200KvDeleteHtml").css("display", "none");
    }
    if (data == "Transformer Quantity 250 KVA") {
        $("#Transformer250KvText").val("");
        $("#Transformer250KvTextHtml").html("");
        $("#Transformer250KvValue").val("");
        $("#Transformer250KvValueHtml").html("");
        $("#Transformer250KvDeleteHtml").css("display", "none");
    }
    if (data == "Transformer Quantity 500 KVA") {
        $("#Transformer500KvText").val("");
        $("#Transformer500KvTextHtml").html("");
        $("#Transformer500KvValue").val("");
        $("#Transformer500KvValueHtml").html("");
        $("#Transformer500KvDeleteHtml").css("display", "none");
    }
    if (data == "Transformer Quantity 1000 KVA") {
        $("#Transformer1000KvText").val("");
        $("#Transformer1000KvTextHtml").html("");
        $("#Transformer1000KvValue").val("");
        $("#Transformer1000KvValueHtml").html("");
        $("#Transformer1000KvDeleteHtml").css("display", "none");
    }
    if (data == "Transformer Quantity 1500 KVA") {
        $("#Transformer1500KvText").val("");
        $("#Transformer1500KvTextHtml").html("");
        $("#Transformer1500KvValue").val("");
        $("#Transformer1500KvValueHtml").html("");
        $("#Transformer1500KvDeleteHtml").css("display", "none");
    }
    if (data == "Transformer Quantity 2000 KVA") {
        $("#Transformer2000KvText").val("");
        $("#Transformer2000KvTextHtml").html("");
        $("#Transformer2000KvValue").val("");
        $("#Transformer2000KvValueHtml").html("");
        $("#Transformer2000KvDeleteHtml").css("display", "none");
    }

}
function LoadAccountScreen() {
    $("#wizard_Time").css("display", "block");
    $("#wizard_Service").css("display", "none");

    $("#wizard_Details").css("display", "none");
}