function GetAvailableSlots() {
    var AppointmentDate = $('#AppointmentDate').val();
    if (AppointmentDate != null && AppointmentDate != '' && AppointmentDate != undefined) {
        $(AppointmentForm).submit();
    }
}