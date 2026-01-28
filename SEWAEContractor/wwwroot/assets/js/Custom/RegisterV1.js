$(document).ready(function () {


    $('#Owner').hide();
    $('#Consultant').hide();
    $('#LoginButton').hide();
    //var IdType = $('#IDTypeList :selected').val();
    //if (IdType == "TradeLicense") {
    //    $("#IssuingAuthority").show();
        
    //}
    //else {
    //    $("#IssuingAuthority").hide();
    //}
    
});
function LoadAttributes()
{
    var IdType = $('#IDTypeList :selected').val();
    if (IdType == "TradeLicense") {
        $("#IssuingAuthority").show();
    }
    else {
        $("#IssuingAuthority").hide();
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


