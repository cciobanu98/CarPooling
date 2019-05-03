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
var mod;
var prev;
var tog;
$( document ).ready(function(){
    $("#SearchButton").click(function(){
        e.preventDefault();
        console.log($("#selectRideForm").serialize())
        $.ajax({
            url:'SelectedRides',
            data: $("#selectRideForm").serialize(),

        }).done(function(res){
            console.log("Succes");
            window.location.href = res.newUrl;
        })
        //location.replace("SelectedRides");
    })
});
