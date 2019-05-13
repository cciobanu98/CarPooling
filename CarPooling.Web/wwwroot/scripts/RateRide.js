$("#RatePartial").load("/Settings/Ratings/OnGetRatePartial")
$("[id^='RateRide']").click(function(){
    console.log($(this).val());
    $('#RateModal').modal('show');
    $("#rideId").val($(this).val());
})
$("[id^='EditRating']").click(function(){
    var rating = $(this).val();
    $("#EditRatePartial").load("/Settings/Ratings/EditRatingPartial?ratingId=" + rating);
    $('#EditRateModal').modal('show');
})
$("[id^='DeleteRating']").click(function(){
    var rating = $(this).val();
    console.log(rating);

    $.get("Delete" + "/" + rating, null, function()
    {
        location.reload();
    });
})