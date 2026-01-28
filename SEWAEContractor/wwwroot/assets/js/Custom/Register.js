$(document).ready(function () {

    $("#IssuingAuthority").hide();
    $('#Owner').hide();
    $('#Consultant').hide();
    $('#LoginButton').hide();
    var IdType = $('#IDTypeList :selected').val();
    if (IdType == "TradeLicense") {
        $("#IssuingAuthority").show();
    }
    else {
        $("#IssuingAuthority").hide();
    }
    
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


