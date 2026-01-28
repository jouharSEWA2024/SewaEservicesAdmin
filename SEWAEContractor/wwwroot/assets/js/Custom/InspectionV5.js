$(document).ready(function () {
    $("#preloadertab").css("display", "none");
    $("#ShopDrawing").hide();
    $("#FinalConnection").hide();
    $('#FirstInspectionType').hide();
    $('#AppointmentDateTab').hide();
    $('#OtherInspectionType').hide();
    var ErrorCode = $('#ErrorCode').val();
    if (ErrorCode == "1") {
       
        $("#wizard_Service").css("display", "block");
    }
    if (ErrorCode == "2") {
       
        $("#wizard_Service").css("display", "none");
    }
    var InspectionType = $("#InspectionType").val();
    var currentDate = new Date();
    currentDate.setDate(currentDate.getDate() + 7);
    var maximumDate = currentDate.toISOString().split('T')[0];
    if (InspectionType != "0") {
        if (InspectionType == "1") {
            $('#FirstInspectionType').show();
            $('#AppointmentDateTab').show();
            var picker=$('#AppointmentDate').bootstrapMaterialDatePicker({
                format: 'YYYY-MM-DD',  // Show date and hour in 12-hour format with AM/PM
                date: true,                 // Enable the date picker
                time: false,
                disabledDays: [7],// Disable Sundays (0 = Sunday)
                minDate: moment(),
                maxDate: maximumDate, // Disable past dates and times
                autoclose: true,

            });
      
           

            
           
            $('#OtherInspectionType').hide();
            var Shop = $("#Shop").val();
            var Final = $("#Final").val();
            if (Shop == "1") {
                $("#ShopDrawing").show();
                $("#FinalConnection").hide();
               
            }
            if (Final == "1") {
                $("#FinalConnection").show();
                $("#ShopDrawing").hide();
            }
        }
        else {
            $('#FirstInspectionType').hide();
            $('#AppointmentDateTab').hide();
            $('#OtherInspectionType').show();
        }
    }
    
   
})
function LoadInspectionType() {
    var checkedNum = $('input[id="customCheckBox6"]:checked').length;
    if (checkedNum > 1) {
        $("#ErrorMessage").val(" Please select only one service");
        $("#ErrorCode").val("1");
        
        return false;
    }

    if ($("#customCheckBox6").prop('checked') == true) {
        $(InspectionForm).submit();
    }
   
}
function CheckInspectionType(index) {
    var checkInspectionType = $('#CheckInspection_' + index).val();
    if (checkInspectionType == "1") {
        $('#FirstInspectionType').show();
        $('#AppointmentDateTab').show();
        $('#OtherInspectionType').hide();
        var Shop = $("#Shop").val();
        var Final = $("#Final").val();
        $("#SRNo").val("");
        if (Shop == "1") {
            
            $("#ShopDrawing").show();
            $("#FinalConnection").hide();
            
        }
        if (Final == "1") {
            
            $("#FinalConnection").show();
            $("#ShopDrawing").hide();
            
        }
    } else {
        $("#SRNo").val("");
        $('#OtherInspectionType').show();
        $('#FirstInspectionType').hide();
        $("#ShopDrawing").hide();
        $("#FinalConnection").hide();  
        $('#AppointmentDateTab').hide();
    }
}
    //if (checkedNum == 1) {
    //    var InspectionType = $('input[id="InspectionCheckBox"]:checked').val()
    //    if (InspectionType == 'true') {
            

    //    }
    //}
function LoadSRNo() {
    
    var check1 = $("input[id='IsShopDrawing']:checked").val();
    if (check1=="1") {
        $("#ShopDrawing").show();
        $("#FinalConnection").hide();
    }
        
    
    
    var check = $("input[id='IsFinalConnection']:checked").val();
        if (check) {
            $("#FinalConnection").show();
            $("#ShopDrawing").hide();
        }
        
    
    //$(InspectionForm).submit();
}
function FinalSubmit() {
    // hiding all screen and show loader tab
    $("#AppointmentDateErr").html("");
    $("#wizard_Service").css("display", "none");
    $("#preloadertab").css("display", "block");
    $("#Error").hide();
    var check1 = $("input[id='IsShopDrawing']:checked").val();
    if (check1 == "1") {
        var AppointmentDate = $('#AppointmentDate').val();
       

        if (AppointmentDate == null || AppointmentDate == '' || AppointmentDate == undefined) {
            $("#AppointmentDateErr").html("Please select Appointment Date");
            $("#preloadertab").css("display", "none");
            $("#wizard_Service").css("display", "block");
            return false;
        }
    }



    var check = $("input[id='IsFinalConnection']:checked").val();
    if (check) {
        var AppointmentDate = $('#AppointmentDate').val();

        if (AppointmentDate == null || AppointmentDate == '' || AppointmentDate == undefined) {
            $("#AppointmentDateErr").html("Please select Appointment Date");
            $("#preloadertab").css("display", "none");
            $("#wizard_Service").css("display", "block");
            return false;
        }
    }
    
    $(InspectionForm).submit();

}