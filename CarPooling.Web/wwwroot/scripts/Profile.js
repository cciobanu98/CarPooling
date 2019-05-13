$("a[id^='profile']").click(function()
{
    //var id = parseInt($(this).attr('id').split(" ")[1])
    var name = $(this).html();
    console.log(name);
    $("#ProfileDiv").load(`${location.origin}/Home/OnGetProfilePartial?userName=` + name, function(){
        $('#ProfileModal').modal('show')
    });
})
