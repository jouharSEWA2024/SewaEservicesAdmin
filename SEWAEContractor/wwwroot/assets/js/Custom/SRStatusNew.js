$(document).ready(function () {
    $('#VerifyOTP').modal('hide');
    var ErrorCode = $('#ErrorCode').val();
    $('input[id="Owner"]').on("change", function () {

        $(ServiceStatus).submit();
    });
    $('input[id="SRNo"]').on("change", function () {

        $(ServiceStatus).submit();
    });
    if (ErrorCode == "4") {
        $('#VerifyOTP').modal('show');
    }
    var SR = $('#SRNo').val()
    if (SR != null || SR != undefined || SR != '') {
        $('#SRDocuments').focus();
    }
    
});
function LoadSR() {
    var OwnerId = $('#OwnerList').val();
    if (OwnerId != "" || OwnerId != null || OwnerId != undefined) {
        $(ServiceStatus).submit();
    }
}
function LoadSRBySRNo() {
    var SRNo = $('#SRNoInputText').val();
    if (SRNo != "" || SRNo != null || SRNo != undefined) {
        $(ServiceStatus).submit();
    }
}
//function LoadSRDtl() {
//    var SRNo = $('#SRList').val();
//    if (SRNo != "" || SRNo != null || SRNo != undefined) {
//        $(ServiceStatus).submit();
//    }
//}
function LoadSRDocuments(data) {
    $('#SRNo').val(data);
    var tab = document.getElementById('SRDocuments');
    tab.setAttribute('tabindex', '0');
   
    
    if (data != null || data != '') {
        $('#ServiceStatus').submit();
    }
    }

$(function () {
    $('#myModal').on('show.bs.modal', function (e) {
        var button = $(e.relatedTarget) // Button that triggered the modal
        var RecordNo = button.data('status') // Extract info from data-* attributes

        $(e.currentTarget).find("input[name='Id']").val(RecordNo);
    });
});