$("#LogginButton").click(function () {
    console.log("click on Loggin");
});
$("#RegisterButton").click(function () {
    console.log("click on Register");
})

$(".read-all").click(function () {
    window.location.replace("Home/AllRides");
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
