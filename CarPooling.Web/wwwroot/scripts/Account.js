$("#LogginButton").click(function () {
    console.log("click on Loggin");
});
$("#RegisterButton").click(function () {
    console.log("click on Register");
})
$(".read-all").click(function () {
    window.location.replace("Home/AllRides");
});
var prev = null;
var mode = null
$(function() {
    var pageId = 1;

    var loadTable = function(pageId, search) {
        console.log(mode);
        $('#AllRideTable').load('/Home/OnGetRidesPartial?pageId=' + pageId + '&pageSize=10&sortmode=' + mode + '&search='+search);
    }

    loadTable(pageId);
    $("a[id^='Sort']").on('click', function(e){
        e.preventDefault();
        pageId = 1;
        if (prev == $(this).attr("id"))
        {
            if (tog == 0)
            {
            mode = $(this).attr('id') + "descending";
            loadTable(pageId,$("#SearchRidesAll").val());
            tog = 1;
            
            }
            else
            {
                mode = $(this).attr('id') + "ascending";
                loadTable(pageId, $("#SearchRidesAll").val());
                tog = 0;
            }
        }
        else
        {
            mode = $(this).attr('id') + "ascending";
            loadTable(pageId, $("#SearchRidesAll").val());
            tog = 0;
        }
        prev = $(this).attr("id");
    })
    $("#SearchRidesAll").keyup(function(e){
        mode = $(this).attr('id') + "ascending";
        loadTable(pageId, $(this).val());
    });
});

$( document ).ready(function(){
    $("#SearchButton").click(function(){
        e.preventDefault();
        $.ajax({
            url:'SelectedRides',
            data: $("#selectRideForm").serialize(),

        }).done(function(res){
            window.location.href = res.newUrl;
            loadTable(pageId, "default");
        })
        //location.replace("SelectedRides");
    })
});
