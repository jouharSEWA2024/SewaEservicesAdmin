$(document).ready(function () {
   
    $('#Owner').hide();
    $('#Consultant').hide();
    $('#LoginButton').hide();
    $('#Register').hide();
    var userType = $("#UserTypeList :selected").text();


    if (userType == "Owner") {
        $('#Owner').show();
        $('#Consultant').hide();
        $('#LoginButton').hide();
        $('#Register').hide();
    }
    if (userType == "Consultant") {
        $('#Owner').hide();
        $('#Consultant').show();
        $('#LoginButton').show();
        $('#Register').show();
    }
    if (userType == "RealEstate") {
        $('#Owner').hide();
        $('#Consultant').show();
        $('#LoginButton').show();
        $('#Register').show();
    }
    if (userType == "Government") {
        $('#Owner').hide();
        $('#Consultant').show();
        $('#LoginButton').show();
        $('#Register').show();
    }
   
});

//function LoadUser()
//{
//    var userType1 = $("#UserTypeOwner").is(":checked");
//    var userType2 = $("#UserTypeConsultant").is(":checked");
//    var userType3 = $("#UserTypeRealEstate").is(":checked");

//    if (userType1) {
//        $('#Owner').show();
//        $('#Consultant').hide();
//        $('#LoginButton').hide();
//        $('#Register').hide();
//    }
//    if (userType2) {
//        $('#Owner').hide();
//        $('#Consultant').show();
//        $('#LoginButton').show();
//        $('#Register').show();
//    }
//    if (userType3) {
//        $('#Owner').hide();
//        $('#Consultant').show();
//        $('#LoginButton').show();
//        $('#Register').show();
//    }
//}

function LoadUser() {
    var userType = $("#UserTypeList :selected").text();
   

    if (userType=="Owner") {
        $('#Owner').show();
        $('#Consultant').hide();
        $('#LoginButton').hide();
        $('#Register').hide();
    }
    if (userType=="Consultant") {
        $('#Owner').hide();
        $('#Consultant').show();
        $('#LoginButton').show();
        $('#Register').show();
    }
    if (userType=="RealEstate") {
        $('#Owner').hide();
        $('#Consultant').show();
        $('#LoginButton').show();
        $('#Register').show();
    }
    if (userType == "Government") {
        $('#Owner').hide();
        $('#Consultant').show();
        $('#LoginButton').show();
        $('#Register').show();
    }
}
