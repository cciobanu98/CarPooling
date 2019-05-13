
var loadTable = function(pageId, search) {
    console.log(mode);
    console.log(pageId);
    var split = (window.location.href).split("/");
    type = split[split.length - 1];
     $('#Table').load('OnGet' + type +'Partial?pageIndex=' + pageId + '&pageSize=10&sort=' + mode + '&search='+search);}
$('.myPage').on('click', function() {
    var page = $(this).html();
    loadTable(page, $("#Search").val());
});