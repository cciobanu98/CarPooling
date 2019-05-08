$( document ).ready(function(){
    var pageId = 1;
    var prev = null;
    var mode = null;
     var loadTable = function(pageId, sortMode, search =null) {
         $('#tableRides').load('/SelectRide/OnGetSelectRidePartial?pageId=' + pageId + '&pageSize=5&sort=' + sortMode + '&search='+search);
     }
     loadTable(1);
     $('.paginationRides').on('click', function() {
        var page = $(this).html();
        console.log(mode);
        loadTable(page, mode, $("#SearchRides").val());
    });
    $("a[id^='Sort']").on('click', function(e){
       e.preventDefault();
       pageId = 1;
       if (prev == $(this).attr("id"))
       {
           if (tog == 0)
           {
           loadTable(pageId, $(this).attr('id') + "descending",$("#SearchRides").val());
           mode = $(this).attr('id') + "descending";
           tog = 1;
           }
           else
           {
               loadTable(pageId, $(this).attr('id') + "ascending", $("#SearchRides").val());
               mode = $(this).attr('id') + "ascending"
               tog = 0;
           }
       }
       else
       {
           loadTable(pageId, $(this).attr('id') + "ascending", $("#SearchRides").val());
           tog = 0;
           mode = $(this).attr('id') + "ascending";
       }
       prev = $(this).attr("id");
   })
   $("#SearchRides").keyup(function(e){
       loadTable(pageId, $(this).attr('id') + "ascending", $(this).val());
   });

});