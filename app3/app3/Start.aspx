<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="Reachout1.Start" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
	<title>ReachOut</title>

	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">

<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="assets/css/util.css">
	<link rel="stylesheet" type="text/css" href="assets/css/startStyle.css">
<!--===============================================================================================-->
    
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Lobster"/>
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Oswald"/>

</head>
    
    
<body>
	
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<div class="loginForm-title" style="background-image: url(assets/img/gloved.jpg);">
					
                    <span style="font-weight: 500;
  letter-spacing: 0.5px; color:white; font-family: Lobster; font-size: 290%; text-align: center; text-shadow:1.5px 1.5px grey; vertical-align : text-bottom;" >
            ReachOut
            </span>
                    <span class="loginForm-title-1og">
						Log in
					</span>
				</div>

				<form class="login100-form validate-form" id="form1" runat="server">
					<div class="wrap-input100 validate-input m-b-26" data-validate="Username is required">
						<span class="label-input">Username</span>

						<asp:TextBox style= "height:45px;" class="input100" ID="txt_username" placeholder="Username" runat="server"  OnTextChanged="txt_username_TextChanged"/>

						<span class="focus-input100"></span>
					</div>

					<div class="wrap-input100 validate-input m-b-18" data-validate = "Password is required">
						<span class="label-input">Password</span>

						<asp:TextBox style= "height:45px;"  class="input100" placeholder="Password" ID="txt_password" runat="server" TextMode="Password"/>
						
						<span class="focus-input100"></span>
					</div>

					<!--<div class="flex-sb-m w-full p-b-30">
					

						<div>
							<a href="#" class="txt1">
								Forgot Password?
							</a>
						</div>
					</div>-->
		
					<div class="container-login100-form-btn">
						<asp:Button ID="loginForm_btn" runat="server" Text="Login" onclick="login"/>
			        </div>

					<span>
					
						<br />
						<asp:Label ID="Fail1" runat="server" Text="" Style="font-family:Helvetica, sans-serif;
								font-size: 13px;
								">

						</asp:Label>
					</span>
                    
                    
					<div class="No_Account">
            
            
               
						<div style= "font-family:Helvetica, sans-serif;
						font-size: 13px;
						line-height: 1.4;
						color: #999999;
						" > 
						Don't have an account?
						</div>
               

					<div >
						<asp:Button ID="Button1" runat="server" Text="Register as a Client" onclick="GoRegCust" Width="200px" style="border:None; height:21px; margin:5px" />
						<br/> 

						<asp:Button ID="Reg1" runat="server" Text="Register as a Vendor" onclick="GoRegVendor" Width="200px" style="border:None; height:21px; margin:5px" />
					</div>

				</div>

                    
			</form>
			</div>
		</div>
	</div>
	
<!--===============================================================================================-->
	<script src="assets/vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="assets/vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="assets/vendor/bootstrap/js/popper.js"></script>
	<script src="assets/vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="assets/vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="assets/vendor/daterangepicker/moment.min.js"></script>
	<script src="assets/vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="assets/vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="js/main.js"></script>

</body>
</html>