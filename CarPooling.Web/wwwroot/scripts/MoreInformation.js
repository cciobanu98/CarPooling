$("a[id^='read-more']").click(function()
{
    var id = parseInt($(this).attr('id').split(" ")[1])
    $("#ModalMoreRead").load(`${location.origin}/Home/OnGetMoreInformation?id=` + id, function(){
        $('#moreinformation').modal('show')
    });
})

$("a[id^='profile']").click(function()
{
    //var id = parseInt($(this).attr('id').split(" ")[1])
    var name = $(this).html();
    console.log(name);
    //$("#ModalMoreRead").load(`${location.origin}/Home/OnGetProfilePartial?id=` + id, function(){
    //    $('#ProfileModal').modal('show')
   // });
})
