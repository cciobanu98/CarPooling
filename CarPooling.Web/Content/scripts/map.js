//Setting map
var map = L.map('map').setView([47.0, 28.9], 13);

L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', {
    attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
    maxZoom: 18,
    id: 'mapbox.streets',
    accessToken: 'pk.eyJ1Ijoia2hhb3M5OCIsImEiOiJjanVsMGlvYTcwaG1oNDRsOGQwenUzdjF4In0.dlP7Uv4ew60B_inhdAzd2A'
}).addTo(map);
//Seting map
var contentString = `<table style="width:100%">` +
                        `<tr>` +
                          `<th style="text-align:center"><b>Name</b></th>` +
                        `</tr>` +
                        `<tr>` +
                          `<th><button id="source" class="fas fa-map-marker green iconsize  placestable"><div id = "source"class="fontsize inline placestable">Source place</div></button></th>` +
                        `</tr>` +
                        `<tr>` +
                          `<th><button id="destination" class="fas fa-map-marker blue iconsize placestable"><div id = "destination"class="fontsize inline placestable">Destination place</div></button></th>` +
                        `</tr>` +
                        `</table>`;
var destinationIcon = L.icon({
  iconUrl: 'http://maps.google.com/mapfiles/ms/micons/blue-dot.png',
  iconSize:     [25, 25],
  iconAnchor: [12, 25]
});
var sourceIcon = L.icon({
  iconUrl: 'http://maps.google.com/mapfiles/ms/micons/green-dot.png',
  iconSize:     [25, 25],
  iconAnchor: [12, 25]
});
var mainPopup = L.popup();
var sourceMarker = L.marker().setIcon(sourceIcon)
var destinationMarker = L.marker().setIcon(destinationIcon)
var clickPos;
var route = null;
function mainPopupSpawn(e) {
  mainPopup
      .setLatLng(e.latlng)
      .setContent(contentString)
      .openOn(map);
  clickPos = e.latlng;
}
map.on('click', mainPopupSpawn);


document.addEventListener('click', function (event) {
	if (!event.target.matches('.placestable')) return;
  event.preventDefault();
  if (event.target.id == "source")
    placeSourceMarker();
  if (event.target.id == "destination")
    placeDestinationMarker();
  if (sourceMarker.getLatLng() && destinationMarker.getLatLng())
    setRoute();
}, false);
function setRoute()
{
  if (route != null)
  {
    map.removeControl(route);
    route = null;
  }
    route = L.Routing.control({
     createMarker: function() { return null; }
    })
    route.setWaypoints([
      sourceMarker.getLatLng(),
     destinationMarker.getLatLng()
   ]);
   route.addTo(map);
  }
  var placesMarker = algoliasearch.initPlaces('plVH4XT517HR', '1f148d1bd3c617cff9ea9b43b76428a3');
function placeSourceMarker()
{
  map.closePopup();
  //sourceMarker = L.marker().setIcon(sourceIcon)
  sourceMarker.setLatLng(clickPos).addTo(map);
  var response = placesMarker.reverse({
    aroundLatLng: clickPos.lat + ',' + clickPos.lng,
    hitsPerPage: 1,
  }).then(updateInputSource);

}
function placeDestinationMarker()
{
  map.closePopup();
  //destinationMarker = L.marker().setIcon(destinationIcon)
  destinationMarker.setLatLng(clickPos).addTo(map);
  var response = placesMarker.reverse({
    aroundLatLng: clickPos.lat + ',' + clickPos.lng,
    hitsPerPage: 1,
  }).then(updateInputDestination);

}
function updateInputDestination(res)
{
  var hits = res.hits;
  var suggestion = hits[0];
  var str = suggestion.locale_names.default[0]  + ',' + suggestion.city.default[0] + ',' + suggestion.country.default || ''  ;
  document.querySelector('#destinationSearch').value = str;
  document.querySelector('#destinationLatitude').value = suggestion._geoloc.lat
  document.querySelector('#destinationLongitude').value = suggestion._geoloc.lng

}
function updateInputSource(res)
{
  var hits = res.hits;
  var suggestion = hits[0];
  var str = suggestion.locale_names.default[0]  + ',' + suggestion.city.default[0] + ',' + suggestion.country.default || ''  ;
  document.querySelector('#sourceSearch').value = str;
  document.querySelector('#sourceLatitude').value = suggestion._geoloc.lat
  document.querySelector('#sourceLongitude').value = suggestion._geoloc.lng
}
(function() {
  var placesAutocomplete = places({
    appId: 'plVH4XT517HR',
    apiKey: '1f148d1bd3c617cff9ea9b43b76428a3',
    container: document.querySelector('#sourceSearch')
  });

  var markers = [];
  placesAutocomplete.on('suggestions', handleOnSuggestions);
  placesAutocomplete.on('cursorchanged', handleOnCursorchanged);
  placesAutocomplete.on('change', handleOnChange);
  placesAutocomplete.on('clear', handleOnClear);

  function handleOnSuggestions(e) {
    markers.forEach(removeMarker);
    if(sourceMarker != null)
      map.removeLayer(sourceMarker)
    markers = [];

    if (e.suggestions.length === 0) {
      map.setView(new L.LatLng(0, 0), 1);
      return;
    }

    e.suggestions.forEach(addMarker);
    findBestZoom();
  }

  function handleOnChange(e) {
    markers
      .forEach(function(marker, markerIndex) {
        if (markerIndex === e.suggestionIndex) {
          markers = [marker];
          marker.setOpacity(1);
          findBestZoom();
        } else {
          removeMarker(marker);
        }
      });
      if (sourceMarker.getLatLng() && destinationMarker.getLatLng())
  {
  setRoute();
  }
else if (route != null)
{
   map.removeControl(route);
    //route = null;
}
  }

  function handleOnClear() {
    //map.setView(new L.LatLng(0, 0), 1);
    markers.forEach(removeMarker);
    sourceMarker = null;
    if (route != null)
{
   map.removeControl(route);
    //route = null;
}
  }

  function handleOnCursorchanged(e) {
    markers
      .forEach(function(marker, markerIndex) {
        if (markerIndex === e.suggestionIndex) {
          marker.setOpacity(1);
          marker.setZIndexOffset(1000);
          marker.setIcon(sourceIcon);
          sourceMarker = marker
        }
          else {
          marker.setZIndexOffset(0);
          marker.setOpacity(0.5);
          marker.setIcon(sourceIcon);
        }
      });
  }

  function addMarker(suggestion) {
    var marker = L.marker(suggestion.latlng, {opacity: .4});
    marker.addTo(map);
    markers.push(marker);
  }

  function removeMarker(marker) {
    map.removeLayer(marker);
  }

  function findBestZoom() {
    var featureGroup = L.featureGroup(markers);
    map.fitBounds(featureGroup.getBounds().pad(0.5), {animate: false});
  }
})();

(function() {
  var placesAutocomplete = places({
    appId: 'plVH4XT517HR',
    apiKey: '1f148d1bd3c617cff9ea9b43b76428a3',
    container: document.querySelector('#destinationSearch')
  });

  var markers = [];
  placesAutocomplete.on('suggestions', handleOnSuggestions);
  placesAutocomplete.on('cursorchanged', handleOnCursorchanged);
  placesAutocomplete.on('change', handleOnChange);
  placesAutocomplete.on('clear', handleOnClear);

  function handleOnSuggestions(e) {
    if(destinationMarker != null)
      map.removeLayer(destinationMarker)
    markers.forEach(removeMarker);
    markers = [];

    if (e.suggestions.length === 0) {
      map.setView(new L.LatLng(0, 0), 1);
      return;
    }

    e.suggestions.forEach(addMarker);
    findBestZoom();
  }

  function handleOnChange(e) {
    markers
      .forEach(function(marker, markerIndex) {
        if (markerIndex === e.suggestionIndex) {
          markers = [marker];
          marker.setOpacity(1);
          findBestZoom();
        } else {
          removeMarker(marker);
        }
      });
      if (sourceMarker.getLatLng() && destinationMarker.getLatLng())
  {
  setRoute();
  }
else if (route != null)
{
   map.removeControl(route);
    //route = null;
}
  }

  function handleOnClear() {
    //map.setView(new L.LatLng(0, 0), 1);
    markers.forEach(removeMarker);
    destinationMarker = null;
  if (route != null)
{
   map.removeControl(route);
    //route = null;
}
  }

  function handleOnCursorchanged(e) {
    markers
      .forEach(function(marker, markerIndex) {
        if (markerIndex === e.suggestionIndex) {
          marker.setOpacity(1);
          marker.setZIndexOffset(1000);
          marker.setIcon(destinationIcon);
          destinationMarker = marker
        }
          else {
          marker.setZIndexOffset(0);
          marker.setOpacity(0.5);
          marker.setIcon(destinationIcon);
        }
      });
  }

  function addMarker(suggestion) {
    var marker = L.marker(suggestion.latlng, {opacity: .4});
    marker.addTo(map);
    markers.push(marker);
  }

  function removeMarker(marker) {
    map.removeLayer(marker);
  }

  function findBestZoom() {
    var featureGroup = L.featureGroup(markers);
    map.fitBounds(featureGroup.getBounds().pad(0.5), {animate: false});
  }
})();