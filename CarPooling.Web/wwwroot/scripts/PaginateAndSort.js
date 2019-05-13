var prev = null;
var mode = null;
var tog = 1;
$(function() {
    var pageId = 1;
    var loadTable = function(pageId, search) {
        console.log(pageId);
        var split = (window.location.href).split("/");
        type = split[split.length - 1];
        console.log(type)
         $('#Table').load('OnGet' + type +'Partial?pageIndex=' + pageId + '&pageSize=10&sort=' + mode + '&search='+search);}
         $("[id^='Sort']").on('click', function(e){
            e.preventDefault();
            pageId = 1;
            
            if (prev == $(this).attr("id"))
            {
                if (tog == 1)
                {
                mode = $(this).attr('id') + "descending";
                loadTable(pageId,$("#Search").val());
                tog = 0;
                
                }
                else
                {
                    mode = $(this).attr('id') + "ascending";
                    loadTable(pageId, $("#Search").val());
                    tog = 1;
                }
            }
            else
            {
                mode = $(this).attr('id') + "descending";
                loadTable(pageId, $("#Search").val());
                tog = 0;
            }
            prev = $(this).attr("id");
        });
        $("#Search").keyup(function(e){
            loadTable(pageId, $(this).val());
        });
        loadTable(pageId);
});