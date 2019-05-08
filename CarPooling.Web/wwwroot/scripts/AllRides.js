$(function() {

    var loadTable = function(pageId, search) {
        console.log(mode);
        $('#AllRideTable').load('/Home/OnGetRidesPartial?pageId=' + pageId + '&pageSize=10&sortmode=' + mode+ '&search='+search);
    }


    $('.paginationAll').on('click', function() {
        var page = $(this).html();
        loadTable(page, $("#SearchRidesAll").val());
    });
});