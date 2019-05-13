$('#EditCarModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var recipient = button.data('whatever') // Extract info from data-* attributes
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this)
    var res = recipient.split("<>");
    console.log(res);
    modal.find('.modal-body #Id').val(res[0]);
    modal.find('.modal-body #Number').val(res[1]);
    modal.find('.modal-body #Model').val(res[2]);
    modal.find('.modal-body #Color').val(res[3]);
    modal.find('.modal-body #Seats').val(res[4]);
})
$(".DeleteButtonCar").click(function(){
    var val = $(this).val();
    $.get("Car/Delete" + "/" + val, null, function()
    {
        location.reload();
    });
})