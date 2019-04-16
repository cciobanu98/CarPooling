// This example displays a marker at the center of Australia.
// When the user clicks the marker, an info window opens.

function initMap() {
    var uluru = {lat: -25.363, lng: 131.044};
    var map = new google.maps.Map(document.getElementById('map'), {
      zoom: 4,
      center: uluru
    });
  
    var contentString = `<table style="width:100%">` +
                        `<tr>` +
                          `<th style="text-align:center"><b>Name</b></th>` +
                        `</tr>` +
                        `<tr>` +
                          `<th><button class="fas fa-map-marker green iconsize  placestable"><div class="fontsize inline placestable">Source place</div></button></th>` +
                        `</tr>` +
                        `<tr>` +
                          `<th><button class="fas fa-map-marker blue iconsize placestable"><div class="fontsize inline placestable">Destination place</div></button></th>` +
                        `</tr>` +
                        `</table>`
  
    var infowindow = new google.maps.InfoWindow({
      content: contentString,
      position:uluru
    });
    map.addListener('click', function(event) {
      var latit = event.latLng.lat();
      var long = event.latLng.lng();
      var pos = {lat:latit, lng:long};
      infowindow.setPosition(pos); 
      infowindow.open(map);
    });
  }
 // $(".placestable").click(function(event) {
   // console.log(event.target);
//});
document.addEventListener('click', function (event) {

	// If the clicked element doesn't have the right selector, bail
	if (!event.target.matches('.placestable')) return;

	// Don't follow the link
	event.preventDefault();

	// Log the clicked element in the console
	console.log(event.target);

}, false);