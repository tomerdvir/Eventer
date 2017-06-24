<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Models.EventModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2><%:Model.Name %></h2>
    <div class="row">
        <div class="span4">
            <h4>Upload Picture</h4>
            <form class="form-horizontal" action='../UploadPic' method="POST" enctype="multipart/form-data">
                <fieldset>
                    <input type="hidden" name="eventId" value="<%:Model.Id %>" />
                    <input type="hidden" name="ownerEmail" value="<%:Model.OwnerEmail %>" />
                    <input type="file" name="uploadPic" />
                    <button class="btn btn-success" type="submit">Upload</button>
                </fieldset>
            </form>
        </div><!-- .span4 -->   
    </div>
    <div class="row" style="border-top: 1px, solid;">
        <div class="container">
            <ul class="thumbnails">
            <% int index = 0;
                foreach (var pic in Model.Pictures)
                {
                    index++;%>
                
                  <li class="span4">
                    <a href="#pic<%= index %>" class="thumbnail" data-toggle="lightbox">
                      <img src="<%= pic.URL %>"/>
                    </a>
                    <div id="pic<%= index %>" class="lightbox hide fade"  tabindex="-1" role="dialog" aria-hidden="true">
	                    <div class='lightbox-content'>
		                    <img src="<%=pic.URL %>">
		                    <div class="lightbox-caption"><p>Taken By <%:pic.UserEmail %></p></div>
	                    </div>
                    </div>
                  </li>
            <%} %>                       
            </ul>
        </div>
    </div>		
</asp:Content>
