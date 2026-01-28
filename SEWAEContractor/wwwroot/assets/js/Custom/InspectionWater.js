$(document).ready(function () {
    $("#preloadertab").css("display", "none");
    
    var ErrorCode = $('#ErrorCode').val();
    if (ErrorCode == "1") {
       
        $("#wizard_Service").css("display", "block");
    }
    if (ErrorCode == "2") {
       
        $("#wizard_Service").css("display", "none");
    }
   
})

function FinalSubmit() {
    // hiding all screen and show loader tab
    $("#wizard_Service").css("display", "none");
    $("#preloadertab").css("display", "block");
    $("#Error").hide();
    $(InspectionForm).submit();

}