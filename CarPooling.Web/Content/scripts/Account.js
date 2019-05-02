$("#LogginButton").click(function () {
    console.log("click on Loggin");
});
$("#RegisterButton").click(function () {
    console.log("click on Register");
})
$(".read-all").click(function () {
    window.location.replace("Home/AllRides");
});

$(function() {
    var pageId = 1;

    var loadTable = function(pageId) {
        $('#AllRideTable').load('/Home/OnGetRidesPartial?pageId=' + pageId + '&size=10');
    }

    loadTable(pageId);

    $('.paginationAll').on('click', function() {
        var page = $(this).html();
        loadTable(page);
    });
});
$(function(){
    var pageId = 1;
    var mod;
     var loadTable = function(pageId) {
         console.log('/SelectRide/OnGetSelectRidePartial?model'+ mod + '&pageId=' + pageId + '&pageSize=5');
         $('#SelectedRidesTable').load('/SelectRide/OnGetSelectRidePartial?'+mod + '&pageId=' + pageId + '&pageSize=5');
     }
    $("#SearchButton").click(function(e){
        e.preventDefault();
        mod = $('#selectRideForm').serialize()
        console.log(pageId);
        loadTable(pageId);
    })
     $('.paginationSelect').on('click', function() {
         var page = $(this).html();
         loadTable(page);
     });
});