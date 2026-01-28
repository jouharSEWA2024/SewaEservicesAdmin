$(document).ready(function () {
    $("#culture").prop("disabled", true);
    $("#preloadertab").css("display", "none");
    $('#AreaTab').hide();
    $("#EMeterTab").hide();
    $("#ConsumerTab").hide();
    $("#ConnectionObjectTab").hide();
    $('#OutputTab').hide();
    const selected = $('input[name="IsOptionSelected"]:checked').val();
    if (selected == 1) {
        $('#AreaTab').show();
        $("#EMeterTab").show();
    }
   
    if (selected == 2) {
        $('#AreaTab').show();
        $("#ConsumerTab").show();
    }
    if (selected == 3) {
        $("#ConnectionObjectTab").show();
    }
    var ErrorCode = $("#ErrorCode").val();
    if (ErrorCode == "2") {
        $('#OutputTab').show();
    }
});
function FinalSubmit() {
    var culture = $('#culture').find(":selected").val();
    $('EMeterNoErr').html("");
    var Area = $('#Area').val();
    var ConsumerNumber = $('#ConsumerNumber').val();
    var ConnectionObject = $('#ConnectionObject').val();
    var EMeterNo = $('#EMeterNo').val();
    var EMeterNoErr = "الرجاء إدخال رقم العداد الإلكترونيحدد المحول المطلوب";
    var AreaErr = "الرجاء إدخال المنطقة";
    var ConsumerNumberErr = "الرجاء إدخال رقم المستهلك";
    var ConnectionObjectErr = "الرجاء إدخال كائن الاتصالالرجاء إدخال رقم المستهلك";
    if (Area != null && Area != "" && Area != undefined) {
        if (EMeterNo != null && EMeterNo != "" && EMeterNo != undefined) {
            setTokenForGoogleCaptcha();
            return false;
        }
        else {
            if (culture == "en-US") {
                $('#EMeterNoErr').html("Please enter E -Meter No");
                
            }
            else {
                $('#EMeterNoErr').html(EMeterNoErr);
               
            }
        }
        if (ConsumerNumber != null && ConsumerNumber != "" && ConsumerNumber != undefined) {
            setTokenForGoogleCaptcha();
            return false;
        }
        else {
            if (culture == "en-US") {
                $('#ConsumerNumberErr').html("Please enter Consumer Number");
                
            }
            else {
                $('#ConsumerNumberErr').html(ConsumerNumberErr);
                
            }
        }
    }
    else {
        if (ConnectionObject != null && ConnectionObject != "" && ConnectionObject != undefined) {
            setTokenForGoogleCaptcha();
            return false;
        }
        else {
            if (culture == "en-US") {
                $('#ConnectionObjectErr').html("Please enter Connection Object");
                
            }
            else {
                $('#ConnectionObjectErr').html(ConnectionObjectErr);
                
            }
        }
        if (culture == "en-US") {
            $('#AreaErr').html("Please enter Area");
            
        }
        else {
            $('#AreaErr').html(AreaErr);
            
        }
    }
}

function setTokenForGoogleCaptcha() {
    $("#preloadertab").css("display", "block");
    grecaptcha.ready(function () {
        grecaptcha.execute('6LfYNjQrAAAAAEViD_bBW6FYI7Ivz0V_0JRmRzUl', { action: 'submit' }).then(function (token) {
            // Add the token to a hidden field   
            if (token != null && token != undefined && token != "") {
                $('#grecaptcharesponse').val(token);
                console.log("Token on input Field: " + $('#grecaptcharesponse').val());
                $(PremiseInfoForm).submit();
            }
        });
    });
}

function LoadInput() {

    const selected= $('input[name="IsOptionSelected"]:checked').val();
    if (selected==1) {
        $('#AreaTab').show();
        $("#EMeterTab").show();
        $("#ConsumerTab").hide();
        $("#ConnectionObjectTab").hide();
        $('#OutputTab').hide();
    }
    
    if (selected==2) {
        $('#AreaTab').show();
        $("#ConsumerTab").show();
        $("#EMeterTab").hide();
        $("#ConnectionObjectTab").hide();
        $('#OutputTab').hide();
    }
   
    if (selected==3) {
        $("#ConnectionObjectTab").show();
        $("#ConsumerTab").hide();
        $('#AreaTab').hide();
        $("#EMeterTab").hide();
        $('#OutputTab').hide();
    }
    
}