$("#RatePartial").load("/Settings/Ratings/OnGetRatePartial")
$("#RateRide").click(function(){
    console.log($(this).val());
    $('#RateModal').modal('show');
    $("#rideId").val($(this).val())
})