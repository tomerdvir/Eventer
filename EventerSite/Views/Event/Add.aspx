<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Models.EventModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?libraries=places&sensor=false"></script>
<h2>New Event</h2>
    <form id="newEvent" action='Add' method="POST">
    <%:Html.HiddenFor(e => e.Start, new { @id = "eventStart" })%>
    <%:Html.HiddenFor(e => e.End, new { @id = "eventEnd" })%>
    <%:Html.HiddenFor(e => e.Lang, new { @id = "eventLang" })%>
    <%:Html.HiddenFor(e => e.Lat, new { @id = "eventLat" })%>
    <%:Html.HiddenFor(e => e.OwnerEmail, new { @id = "ownerEmail" })%>
    <label>Event Name</label>
    <%:Html.TextBoxFor(e => e.Name, new {@class="input-xlarge"}) %>        
    <label>Is Public</label>
    <%:Html.CheckBoxFor(e => e.IsPublic, new { @class = "input-xlarge" })%>
    <label>Event Location</label>
    <input type="text" id="addresspicker" class="input-xlarge" placeholder="">
    <label>Radius</label>
    <%:Html.TextBoxFor(e => e.Radius, new { @class = "input-xlarge" })%>
    <label>Starts On</label>
    <div id="dpdStart" class="input-append date">
        <input data-format="dd/MM/yyyy hh:mm:ss" type="text"></input>
        <span class="add-on">
          <i data-time-icon="icon-time" data-date-icon="icon-calendar">
          </i>
        </span>
    </div>
    <label>Ends On</label>
    <div id="dpdEnd" class="input-append date">
        <input data-format="dd/MM/yyyy hh:mm:ss" type="text"></input>
        <span class="add-on">
          <i data-time-icon="icon-time" data-date-icon="icon-calendar">
          </i>
        </span>
    </div>        
    <div>
        <button class="btn btn-primary">Create Event</button>
    </div>
</form>
</asp:Content>