<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Models.UserModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(function () {
        $('.nav-tabs a').on('click', function (e) {
            e.preventDefault();
            $(this).tab('show');
        });
    });
</script>

 <div class="row-fluid">
         
 </div><!-- .row -->
 <div class="row">
    <div class="span6">
        <ul class="nav nav-tabs">
          <li class="active"><a href="#EventsAround" data-toggle="tab">Events Around Me</a></li>
          <li><a href="#MyEvents" data-toggle="tab">All My Events</a></li>
        </ul>    
        <div id="myTabContent" class="tab-content">
            <div class="tab-pane active in" id="EventsAround">
                <%Html.RenderPartial("/Views/Shared/EventsAroundList.ascx"); %>
            </div>
            <div class="tab-pane fade" id="MyEvents">
                <%Html.RenderPartial("/Views/Shared/MyEventsList.ascx"); %>
            </div>
        </div>
    </div>
 </div>

</asp:Content>
