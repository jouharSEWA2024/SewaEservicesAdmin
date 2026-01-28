function SaveOwnerInfo() {
    // hiding all screen and show loader tab
    if ($("#IsSelected").prop('checked') == true) {
        $(OwnerInfo).submit();
    }

}