$('#LoginButton').on('click', function(e){
    $.get("Views/Home/Login.cshtml", function (data) {
        var url = '@Url.Content("~/Views/Home/Login.cshtml")'
        console.log(url);
    });
  });