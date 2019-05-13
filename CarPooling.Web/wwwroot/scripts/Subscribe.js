$("#SubscribeToRide").click(function (e) {
    var id = $("input[id^='Information']").val();
    console.log(id);
    $.ajax({
        //data:id,
        method: "POST",
        url:"/AddRide/SubscribeToRide?rideId=" + id,
        success:function(){
            $('#moreinformation').modal('hide')
        },
        error:function(err){
            console.log(err);
        }
    })
});
$("#AddEnrouteRide").click(function(e){
    $("#EnrouteModal").modal('show');
})