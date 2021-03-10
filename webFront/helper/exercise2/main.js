var stations = null;

function retrieveAllContracts() {
    var targetUrl = "https://api.jcdecaux.com/vls/v3/contracts?apiKey=" + document.getElementById("apiKey").value;
    var requestType = "GET";

    var caller = new XMLHttpRequest();
    caller.open(requestType, targetUrl, true);
    // The header set below limits the elements we are OK to retrieve from the server.
    caller.setRequestHeader ("Accept", "application/json");
    // onload shall contain the function that will be called when the call is finished.
    caller.onload=contractsRetrieved;

    caller.send();
}

function contractsRetrieved() {
    // Let's parse the response:
    var response = JSON.parse(this.responseText);
    var options = '';

    response.forEach(c => {
        options += '<option value="' + c.name + '" />';
    });

    document.getElementById('contracts').innerHTML = options;
}

function retrieveContractStations() {
    var targetUrl = "https://api.jcdecaux.com/vls/v3/stations?contract=" + document.getElementById("input_contrats").value + "&apiKey=" + document.getElementById("apiKey").value;
    var requestType = "GET";

    var caller = new XMLHttpRequest();
    caller.open(requestType, targetUrl, true);
    // The header set below limits the elements we are OK to retrieve from the server.
    caller.setRequestHeader("Accept", "application/json");
    // onload shall contain the function that will be called when the call is finished.
    caller.onload = contractStationsRetrieved;

    caller.send();
}

function contractStationsRetrieved() {
    var response = JSON.parse(this.responseText);
    console.log(response);
    stations = response;
}

function getDistanceFrom2GpsCoordinates(lat1, lon1, lat2, lon2) {
    // Radius of the earth in km
    var earthRadius = 6371;
    var dLat = deg2rad(lat2 - lat1);
    var dLon = deg2rad(lon2 - lon1);
    var a =
        Math.sin(dLat / 2) * Math.sin(dLat / 2) +
        Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
        Math.sin(dLon / 2) * Math.sin(dLon / 2)
        ;
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    var d = earthRadius * c; // Distance in km
    return d;
}

function deg2rad(deg) {
    return deg * (Math.PI / 180)
}

function findClosestStation() {
    let lat = document.getElementById("input_lat").value;
    let long = document.getElementById("input_long").value;
    let closestStation = stations[0];
    let closestDistance = getDistanceFrom2GpsCoordinates(lat, long, closestStation.position.latitude, closestStation.position.longitude);

    this.stations.forEach(station => {
        let newDistance = getDistanceFrom2GpsCoordinates(lat, long, station.position.latitude, station.position.longitude);
        if (newDistance < closestDistance) {
            closestStation = station;
            closestDistance = newDistance;
        }
    });

    document.getElementById('label_closest_station').innerHTML = closestStation.address;
}