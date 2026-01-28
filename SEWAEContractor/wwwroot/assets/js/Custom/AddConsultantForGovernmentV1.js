$(document).ready(function () {
    var ErrorCode = $("#ErrorCode").val();
    if (ErrorCode == "3") {
        $('#AddConsultantForm').hide();
    }
});

function LoadBPInfo() {
    $('#TradeLicenseErr').html("");
    $('#IssuingAuthorityErr').html("");
    $("#TPTransactionIDErr").html("");
    var culture = $('#culture').find(":selected").val();
    var TradeLicense = $('#TradeLicense').val();
    var IssuingAuthority = $('#IssueAuthorityList :selected').val();
    var TPTransactionID = $("#TPTransactionID").val();
    if (TradeLicense == null || TradeLicense == "" || TradeLicense == undefined) {
        var TradeLicenseErr = "الرجاء إدخال الرخصة التجارية";
        if (culture == "en-US") {
            $('#TradeLicenseErr').html("Please enter Trade License");
        }
        else {
            $('#TradeLicenseErr').html(TradeLicenseErr);
        }

        $('#TradeLicense').focus();
        return false;
    }
    if (IssuingAuthority == null || IssuingAuthority == "" || IssuingAuthority == undefined) {
        var IssuingAuthorityErr = "اختر جهة الإصدار";
        if (culture == "en-US") {
            $('#IssuingAuthorityErr').html("Please enter Trade License");
        }
        else {
            $('#IssuingAuthorityErr').html(IssuingAuthorityErr);
        }

        $('#IssuingAuthorityList').focus();
        return false;
    }

    if (TPTransactionID == null || TPTransactionID == "" || TPTransactionID == undefined) {
    var TPTransactionIDErr = "الرجاء إدخال معرف معاملة تخطيط (الخارطة)"
    if (culture == "en-US") {
        $('#TPTransactionIDErr').html("Please enter Town Planning Transaction ID");
    }
    else {
        $('#TPTransactionIDErr').html(TPTransactionIDErr);
    }
        $('#TPTransactionID').focus();
        return false;
            
    }
    if (TradeLicense != null || TradeLicense != "" || TradeLicense != undefined) {
        if (IssuingAuthority != null || IssuingAuthority != "" || IssuingAuthority != undefined) {
            if (TPTransactionID != null || TPTransactionID != "" || TPTransactionID != undefined) {
                $(AddConsultantForm).submit();
            }
        }
    }
}
function FinalSubmit() {

    var culture = $('#culture').find(":selected").val();

    var Plot = $('#Plot').val();
    var Area = $("#AreaList").val();
    var City = $("#CityList").val();
    var TradeLicense = $('#TradeLicense').val();
    var IssuingAuthority = $('#IssueAuthorityList :selected').val();
    var ConsultantExpiryDate = $('#ConsultantExpiryDate').val();
    if (TradeLicense == null || TradeLicense == "" || TradeLicense == undefined) {
        var TradeLicenseErr = "الرجاء إدخال الرخصة التجارية";
        if (culture == "en-US") {
            $('#TradeLicenseErr').html("Please enter Trade License");
        }
        else {
            $('#TradeLicenseErr').html(TradeLicenseErr);
        }

        $('#TradeLicense').focus();
        return false;
    }
    if (IssuingAuthority == null || IssuingAuthority == "" || IssuingAuthority == undefined) {
        var IssuingAuthorityErr = "اختر جهة الإصدار";
        if (culture == "en-US") {
            $('#IssuingAuthorityErr').html("Please enter Trade License");
        }
        else {
            $('#IssuingAuthorityErr').html(IssuingAuthorityErr);
        }

        $('#IssuingAuthorityList').focus();
        return false;
    }
    if (Plot == null || Plot == "" || Plot == undefined) {
        var PlotErr = "اختر قطعة الأرض";
        if (culture == "en-US") {
            $('#PlotErr').html("Select Plot");
        }
        else {
            $('#PlotErr').html(PlotErr);
        }

        $('#Plot').focus();
        return false;
    }
    if (Area == null || Area == "" || Area == undefined) {
        var AreaErr = "اختر المنطقة";
        if (culture == "en-US") {
            $('#AreaErr').html("Select Area");
        }
        else {
            $('#AreaErr').html(AreaErr);
        }

        $('#AreaList').focus();
        return false;
    }
    if (City == null || City == "" || City == undefined) {
        var CityErr = "اختر المدينة";
        if (culture == "en-US") {
            $('#CityErr').html("Select City");
        }
        else {
            $('#CityErr').html(CityErr);
        }

        $('#CityList').focus();
        return false;
    }
   
    if (ConsultantExpiryDate == null || ConsultantExpiryDate == "" || ConsultantExpiryDate == undefined) {
        var ConsultantExpiryDateErr = "الرجاء تحديد تاريخ انتهاء صلاحية الاستشاري";
        if (culture == "en-US") {
            $('#ConsultantExpiryDateErr').html("Please select Consultant Expiry Date");
        }
        else {
            $('#ConsultantExpiryDateErr').html(ConsultantExpiryDateErr);
        }

        $('#ConsultantExpiryDate').focus();
        return false;
    }
    else {
        let inputConsultantExpiryDate = new Date(ConsultantExpiryDate);
        let currentDate = new Date();

        if (inputConsultantExpiryDate.setHours(0, 0, 0, 0) < currentDate.setHours(0, 0, 0, 0)) {
            var ConsultantExpiryDateErr = "الرجاء تحديد تاريخ انتهاء صلاحية الاستشاري أكبر من التاريخ الحالي";
            if (culture == "en-US") {
                $('#ConsultantExpiryDateErr').html("Please select Consultant Expiry Date greater than CurrentDate");
            }
            else {
                $('#ConsultantExpiryDateErr').html(ConsultantExpiryDateErr);
            }
            return false;
        }
    }
    $(AddConsultantForm).submit();
}
function LoadArea() {
    $("#AreaList :selected").val("");
    $(AddConsultantForm).submit();
}