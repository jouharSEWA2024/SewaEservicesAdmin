$(document).ready(function () {
    $("#preloadertab").css("display", "none");
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
    if (ErrorCode == "5") {

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

