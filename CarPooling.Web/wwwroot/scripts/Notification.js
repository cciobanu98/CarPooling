$(function () {
     $('[data-toggle="popover"]').popover({
        placement: 'bottom',
        content: function(){
            //console.log($("#notification-content").html())
            return $("#notification-content").html();
        },
        html: true
    });
  })
$('body').append(`<div id="notification-content" class="hide"></div>`)
function getNotification()
{
    var options = {  year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute:'numeric'};
    var res = "<div>";
    $.ajax({
        url:"Notification/GetNotification",
        method:"GET",
        success:function(result)
        {
            if(result.count!=0){
                $("#notificationCount").html(result.count);
                $("#notificationCount").show('slow');
                } else {
                    $("#notificationCount").html();
                    $("#notificationCount").hide('slow');
                    $("#notificationCount").popover('hide');                    
                }
                var notifications = result.requests;
                console.log(notifications);
                notifications.forEach(element => {
                    if (element.status == '0')
                    {
                    res = res + "<div> <a href='#'>" +element.user.userName + " " +
                    "</a> wants to travel in your ride from "+
                    " "+element.ride.sourceLocation.city + "" +
                    " to "+element.ride.destinationLocation.city+" "+
                    "on "+new Date(element.ride.travelStartDateTime).toLocaleDateString("en-US", options)+"<br/>"+
                    "<button type='button' class='btn btn-success' id='AcceptButton "+element.id+"' name='"+element.id+"' onclick='Accept("+element.id+")'>Accept</button>"+
                    "<button type='button' class='btn btn-danger' id='RejectButton "+element.id+"' name='"+element.id+"' onclick='Reject("+element.id+")'>Reject</button>"+
                    "<hr style='width: 100%; color: black; height: 1px; background-color:black;'/>"+
                    "</div>";
                    }
                    else
                    {
                        var Status = "Accepted";
                        if (element.status == "2")
                            Status = "Rejected";
                        res = res + "<div> <a href='#'>" +element.ride.car.user.userName + " " +
                        "</a> "+Status+" your request on ride from" +
                        " "+element.ride.sourceLocation.city + "" +
                        " to "+element.ride.destinationLocation.city+" "+
                        "on "+new Date(element.ride.travelStartDateTime).toLocaleDateString("en-US", options)+"<br/>"+
                        "<button type='button' class='btn btn-primary' id='AcceptButton "+element.id+"' name='"+element.id+"' onclick='Read("+element.id+")'>Read</button>"+
                        "<hr style='width: 100%; color: black; height: 1px; background-color:black;'/>"+
                        "</div>";
                    }
                });
                console.log(notifications);
                res = res + "</div>";
                //console.log(res);
                $("#notification-content").html(res);
                //console.log($("#notification-content").html())
        },
        error: function(error){
            console.log("Failure");
            console.log(error);
        }
    
    });

}
getNotification();

let hubUrl = `${location.origin}/notification`
const connection = new signalR.HubConnectionBuilder()
    .withUrl(hubUrl)
    .build();

    connection.on('displayNotification',()=>{
        console.log("NotificationGet");
        getNotification();
    });

    connection.start();
function Accept(requestId)
{
    $.ajax({
        url:"AddRide/AcceptPassengers?requestId=" + requestId,
        method:"POST",
        success:function(){

            //$('a[data-toggle="popover"]').hide('slow');
            $('a[data-toggle="popover"]').popover('hide'); 
        },
        error:function(error)
        {
            console.log(error);
        }
    })
}
function Reject(requestId)
{
    $.ajax({
        url:"AddRide/RejectPassengers?requestId=" + requestId,
        method:"POST",
        success:function(){

            //$('a[data-toggle="popover"]').hide('slow');
            $('a[data-toggle="popover"]').popover('hide'); 
        },
        error:function(error)
        {
            console.log(error);
            
        }
    })
}
function Read(requestId)
{
    $.ajax({
        url:"Notification/ReadNotification?requestId=" + requestId,
        method:"POST",
        success:function(){

            //$('a[data-toggle="popover"]').hide('slow');
            $('a[data-toggle="popover"]').popover('hide'); 
        },
        error:function(error)
        {
            console.log(error);
        }
    })
}