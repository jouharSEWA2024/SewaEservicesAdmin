function LoadOwnerInfoByArea() { 
    var Area = $('#AreaList').val();
    if (Area != "" || Area != null || Area != undefined) {
        $(OwnerInfo).submit();
    }
}
function LoadOwnerInfoByPlot() {
    var Plot = $('#PlotList').val();
    if (Plot!= "" || Plot != null || Plot != undefined) {
        $(OwnerInfo).submit();
    }
}