﻿$("a[id^='read-more']").click(function()
{
    var id = parseInt($(this).attr('id').split(" ")[1])
    console.log(id);
    $("#ModalMoreRead").load(`${location.origin}/Home/OnGetMoreInformation?id=` + id, function(){
        $('#moreinformation').modal('show')
    });
})