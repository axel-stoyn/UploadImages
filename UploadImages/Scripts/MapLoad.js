$(document).ready(function () {
    GetMap();
});

function GetMap() {

    google.maps.visualRefresh = true;
    var Minsk = new google.maps.LatLng(53.90393363, 27.55748749);

    var mapOptions = {
        zoom: 10,
        center: Minsk,
        mapTypeId: google.maps.MapTypeId.G_NORMAL_MAP
    };

    var map = new google.maps.Map(document.getElementById("canvas"), mapOptions);

    var myLatlng = new google.maps.LatLng(53.90393363, 27.55748749);

    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: 'Центр'
    });

    marker.setIcon('http://maps.google.com/mapfiles/ms/icons/red-dot.png')

    $.getJSON('@Url.Action("GetData","Home")', function (data) {
        $.each(data, function (i, item) {
            var marker = new google.maps.Marker({
                'position': new google.maps.LatLng(item.GeoLong, item.GeoLat),
                'map': map,
                'title': item.PlaceName
            });

            marker.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png')

        })
    });
}
