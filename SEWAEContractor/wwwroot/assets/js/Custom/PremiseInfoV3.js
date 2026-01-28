$(document).ready(function () {
    $("#culture").prop("disabled", true);
    $("#preloadertab").css("display", "none");
    $('#CityTab').hide();
    $("#EMeterTab").hide();
    $("#ConsumerTab").hide();
    $("#ContractAccountTab").hide();
    $('#AreaSelection').hide();
    $('#AreaDropdownTab').hide();
    $('#AreaCodeTab').hide();
    $('#OutputTab').hide();
    const selected = $('input[name="IsOptionSelected"]:checked').val();
    if (selected == 1) {
        $('#CityTab').show();
        $('#AreaSelection').show();
        $("#EMeterTab").show();
        const selectedAreaOption = $('input[name="IsAreaCodeOrDropdownSelected"]:checked').val();
        if (selectedAreaOption == 1) {
            $('#AreaDropdownTab').show();
        }
        if (selectedAreaOption == 2) {
            $('#AreaCodeTab').show();
        }
    }
   
    if (selected == 2) {
        $('#CityTab').show();
        $('#AreaSelection').show();
        $("#ConsumerTab").show();
        const selectedAreaOption = $('input[name="IsAreaCodeOrDropdownSelected"]:checked').val();
        if (selectedAreaOption == 1) {
            $('#AreaDropdownTab').show();
        }
        if (selectedAreaOption == 2) {
            $('#AreaCodeTab').show();
        }
    }
    if (selected == 3) {
        $("#ContractAccountTab").show();
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
    var AreaCode = $('#AreaCode').val();
    var City = $('#City').val();
    var ConsumerNumber = $('#ConsumerNumber').val();
    var ContractAccount = $('#ContractAccount').val();
    var EMeterNo = $('#EMeterNo').val();
    var EMeterNoErr = "الرجاء إدخال رقم العداد الإلكترونيحدد المحول المطلوب";
    var AreaErr = "الرجاء إدخال المنطقة";
    var AreaCodeErr = "الرجاء إدخال رمز المنطقة";
    var CityErr = "الرجاء اختيار المدينة";
    var ConsumerNumberErr = "الرجاء إدخال رقم المستهلك";
    var ContractAccountErr = "الرجاء إدخال رقم الحساب";
    if (City != null && City != "" && City != undefined) {
        const selectedAreaOption = $('input[name="IsAreaCodeOrDropdownSelected"]:checked').val();
        if (selectedAreaOption == 1) {
            if (Area == null || Area == "" || Area == undefined) {
                if (culture == "en-US") {
                    $('#AreaErr').html("Please select Area");
                    return false;
                }
                else {
                    $('#AreaErr').html(AreaErr);
                    return false;
                }
            }
        }
        if (selectedAreaOption == 2) {
            if (AreaCode == null || AreaCode == "" || AreaCode == undefined) {
                if (culture == "en-US") {
                    $('#AreaCodeErr').html("Please enter Area Code");
                    return false;
                }
                else {
                    $('#AreaCodeErr').html(AreaCodeErr);
                    return false;
                }
            }
            else {
                // assigning the area code to area itself as both details are fetching area code internally.
                Area = AreaCode;
            }
        }
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
    }
    else {
        if (ContractAccount != null && ContractAccount != "" && ContractAccount != undefined) {
            setTokenForGoogleCaptcha();
            return false;
        }
        else {
            if (culture == "en-US") {
                $('#ContractAccountErr').html("Please enter Contract Account");

            }
            else {
                $('#ContractAccountErr').html(ContractAccountErr);

            }
        }
        if (culture == "en-US") {
            $('#CityErr').html("Please select city");

        }
        else {
            $('#CityErr').html(CityErr);

        }
    }
    
    
}

function setTokenForGoogleCaptcha() {
    $("#preloadertab").css("display", "block");
    grecaptcha.ready(function () {
        grecaptcha.execute('6LcQwj8rAAAAAF_bYmryLrZfpicA7EmC2SmoZMAK', { action: 'submit' }).then(function (token) {
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
        $('#CityTab').show();
        $('#AreaSelection').show();
        $('#AreaDropdownTab').hide();
        $('#AreaCodeTab').hide();
        const selectedAreaOption = $('input[name="IsAreaCodeOrDropdownSelected"]:checked').val();
        if (selectedAreaOption == 1) {
            $('#AreaDropdownTab').show();
            $('#AreaCode').val("");
        }
        if (selectedAreaOption == 2) {
            $('#AreaCodeTab').show();
            $('#Area').val('').selectpicker('refresh');
        }
        
        $("#EMeterTab").show();
        $("#ConsumerTab").hide();
        $("#ContractAccountTab").hide();
        $('#OutputTab').hide();
        $('#ConsumerNumber').val("");
        $('#ContractAccount').val("");
        $('#City').val('').selectpicker('refresh');
    }
    
    if (selected==2) {
        $('#CityTab').show();
        $('#AreaSelection').show();
        $('#AreaDropdownTab').hide();
        $('#AreaCodeTab').hide();
        const selectedAreaOption = $('input[name="IsAreaCodeOrDropdownSelected"]:checked').val();
        if (selectedAreaOption == 1) {
            $('#AreaDropdownTab').show();
            $('#AreaCode').val("");
        }
        if (selectedAreaOption == 2) {
            $('#AreaCodeTab').show();
            $('#Area').val('').selectpicker('refresh');
        }
        $("#ConsumerTab").show();
        $("#EMeterTab").hide();
        $("#ContractAccountTab").hide();
        $('#OutputTab').hide();
        $('#ContractAccount').val("");
        $('#EMeterNo').val("");
        $('#City').val('').selectpicker('refresh');
    }
   
    if (selected==3) {
        $("#ContractAccountTab").show();
        $("#ConsumerTab").hide();
        $('#CityTab').hide();
        $('#AreaSelection').hide();
        $('#AreaDropdownTab').hide();
        $('#AreaCodeTab').hide();
        $("#EMeterTab").hide();
        $('#OutputTab').hide();
        $('#ConsumerNumber').val("");
        $('#EMeterNo').val("");
        $('#City').val('').selectpicker('refresh');
    }
    
}

function LoadArea() {
    var City = $('#City').val();
    var culture = $('#culture').find(":selected").val();
    var base = $(location).attr('host');
    $.ajax({
        url: "https://" + base + "/Consumer/GetAreaByCity?CityId=" + City,
        type: 'GET',
        contentType: false,
        processData: false,
        async: false,
        success: function (res) {
      
            $('#Area').empty().append('<option value="">Select Area...</option>');
            
            $.each(res, function (index, value) {
                console.log("Value :" + value);
                $('#Area').append(
                    $('<option></option>').val(value.id).text(value.val)
                );
            });
            $('#Area').selectpicker('refresh');
           

        }
    });
}

function LoadAreaAttributes(){
    const selected = $('input[name="IsAreaCodeOrDropdownSelected"]:checked').val();
    if (selected == 1) {
        $('#AreaDropdownTab').show();
        $('#AreaCodeTab').hide();
    }
    if (selected == 2) {
        $('#AreaCodeTab').show();
        $('#AreaDropdownTab').hide();
    }
}
// restrict area code to digits

$('#AreaCode').on('keypress', function (e) {
    var charCode = e.which ? e.which : e.keyCode;

    // Allow only digits (ASCII codes 48 to 57)
    if (charCode < 48 || charCode > 57) {
        e.preventDefault();
    }
});
// restrict contract account to digits

$('#ContractAccount').on('keypress', function (e) {
    var charCode = e.which ? e.which : e.keyCode;

    // Allow only digits (ASCII codes 48 to 57)
    if (charCode < 48 || charCode > 57) {
        e.preventDefault();
    }
});
// restrict consumer number  to digits

$('#ConsumerNumber').on('keypress', function (e) {
    var charCode = e.which ? e.which : e.keyCode;

    // Allow only digits (ASCII codes 48 to 57)
    if (charCode < 48 || charCode > 57) {
        e.preventDefault();
    }
});