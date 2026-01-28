function LoadRealEstateInfoByEMID() {
    var EMID = $('#EMIDList').val();
    if (EMID != null || EMID != '' || EMID != undefined) {
        $(RealEstateInfo).submit();
    }
}