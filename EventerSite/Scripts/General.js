$(document).ready(function () {
    $(function () {
        $('#dpdStart').datetimepicker({
            language: 'en'
        });

        $('#dpdStart').on('changeDate', function (e) {
            $('#eventStart').val(e.localDate.toUTCString());
        });
    });

    $(function () {
        $('#dpdEnd').datetimepicker({
            language: 'en'
        });

        $('#dpdEnd').on('changeDate', function (e) {
            $('#eventEnd').val(e.localDate.toUTCString());
        });
    });

    var input = document.getElementById("addresspicker");
    if (input) {
        var autocomplete = new google.maps.places.Autocomplete(input);

        google.maps.event.addListener(autocomplete, "place_changed", function () {
            var place = autocomplete.getPlace();

            if (place.geometry) {
                $('#eventLang').val(place.geometry.location.ob);
                $('#eventLat').val(place.geometry.location.nb);
            }
        });
    }
});