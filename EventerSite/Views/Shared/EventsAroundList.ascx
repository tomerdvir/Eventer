<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<script type="text/javascript">
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(success, error);
    } else {
        error('geolocation not supported');
    }

    function error(msg) {        
        console.log(msg);
    }

    function success(position) {
        $.ajax({ type: "GET",
            cache: false,
            url: '/Event/ListEventsByLocation?lat=' + position.coords.latitude + '&lng=' + position.coords.longitude, success: function (data) {
                if (data) {
                    data.forEach(function (entry) {
                        var a = document.createElement("a");
                        a.textContent = entry.name;
                        a.href = "/Event/View/" + entry.id;

                        $('#eventsAroundList').append(a);
                        $('#eventsAroundList').append("</br>");
                    });
                } else {
                    $('#eventsAroundList').append('<div class="alert alert-info">No Events Around...</div>');
                }

            }
        });
    }
</script>

<div id="eventsAroundList">

</div>