<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<script type="text/javascript">
    
    $.ajax({ type: "GET",
        cache: false,
        url: '/Event/ListMyEvents', 
        success: function (data) {
            if (data) {
                data.forEach(function (entry) {
                    var a = document.createElement("a");
                    a.textContent = entry.name;
                    a.href = "/Event/View?id=" + entry.id;

                    $('#myEventsList').append(a);
                    $('#myEventsList').append("</br>");
                });
            } else {
                $('#myEventsList').append('<div class="alert alert-info">You Have No Events...</div>');
            }

        }
    });
</script>

<div id="myEventsList">

</div>