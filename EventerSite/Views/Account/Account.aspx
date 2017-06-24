<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>


<!DOCTYPE html>

<html>
 <head>
         <meta charset="utf-8">
         <title>Eventer</title>         
        <script src="../../Scripts/jquery-ui-1.8.20.min.js" type="text/javascript"></script>  
        <script src="../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
        <script src="../../Scripts/jquery.validate.min.js" type="text/javascript"></script>
        <link rel="stylesheet" href="http://flip.hr/css/bootstrap.min.css">     
         <script src="../../Scripts/bootstrap.min.js" type="text/javascript"></script>        
 </head>
<script type="text/javascript">
    $(function () {
        $('.nav-tabs a').on('click', function (e) {
            e.preventDefault();
            $(this).tab('show');
        });
    });

    $(document).ready(function () {
        $('#loginForm').validate(
        {
            rules: {
                email: {
                    minlength: 2,
                    required: true
                },
                password: {                    
                    required: true                    
                }                
            },
            highlight: function (element) {
                $(element).closest('.control-group').removeClass('success').addClass('error');
            },
            success: function (element) {
                element
                .text('OK!').addClass('valid')
                .closest('.control-group').removeClass('error').addClass('success');
            }
        });

        $('#createForm').validate(
        {
            rules: {
                newUserName: {
                    minlength: 2,
                    required: true
                },
                newEmail: {
                    minlength: 2,
                    required: true
                },
                newPassword: {
                    required: true
                }
            },
            highlight: function (element) {
                $(element).closest('.control-group').removeClass('success').addClass('error');
            },
            success: function (element) {
                element
                .text('OK!').addClass('valid')
                .closest('.control-group').removeClass('error').addClass('success');
            }
        });
    });
</script>

<body>
        <div class="modal-body">
        <div class="well">
            <ul class="nav nav-tabs">
            <li class="active"><a href="#login" data-toggle="tab">Login</a></li>
            <li><a href="#create" data-toggle="tab">Create Account</a></li>
            </ul>
            <div id="myTabContent" class="tab-content">
            <div class="tab-pane active in" id="login">
                <form id="loginForm" class="form-horizontal" action='Account/Login' method="POST">
                <fieldset>
                    <div id="legend">
                    <legend class="">Login</legend>
                    </div>    
                    <div class="control-group">
                    <!-- Username -->
                    <label class="control-label"  for="email">Email</label>
                    <div class="controls">
                        <input type="text" id="email" name="email" placeholder="" class="input-xlarge">
                    </div>
                    </div>
 
                    <div class="control-group">
                    <!-- Password-->
                    <label class="control-label" for="password">Password</label>
                    <div class="controls">
                        <input type="password" id="password" name="password" placeholder="" class="input-xlarge">
                    </div>
                    </div>
 
 
                    <div class="control-group">
                    <!-- Button -->
                    <div class="controls">
                        <button class="btn btn-success" type="submit">Login</button>
                    </div>
                    </div>
                </fieldset>
                </form>                
            </div>
            <div class="tab-pane fade" id="create">
                <form id="createForm" action='Account/Create' method="POST">
                    <div class="control-group">                    
                        <label class="control-label" for="password">UserName</label>
                        <div class="controls">
                            <input type="text" id="newUserName" name="newUserName" class="input-xlarge">
                        </div>
                    </div>
                    <div class="control-group">                    
                        <label class="control-label" for="password">Email</label>
                        <div class="controls">
                            <input type="text" id="newEmail" name="newEmail" class="input-xlarge">                
                        </div>
                    </div>                    
                    <div class="control-group">                    
                        <label class="control-label" for="password">Password</label>
                        <div class="controls">
                            <input type="password" id="newPassword" name="newPassword" class="input-xlarge">  
                        </div>
                    </div>                    
                    <div>
                        <button class="btn btn-primary">Create Account</button>
                    </div>
                </form>
            </div>
        </div>
        </div>
    </div>
</body>
</html>
