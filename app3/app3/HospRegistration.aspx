    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HospRegistration.aspx.cs" Inherits="Reachout1.HospRegistration" %>

<!DOCTYPE html lang="en">
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">

<head runat="server">
  <meta charset="utf-8">
  <meta content="width=device-width, initial-scale=1.0" name="viewport"/>

  <title> Registration </title>
  <meta content="" name="descriptison"/>
  <meta content="" name="keywords"/>

  <!-- Favicons -->
 

  <!-- Google Fonts -->
<link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Raleway:300,300i,400,400i,500,500i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet">
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Lobster"/>

  <!-- Vendor CSS Files -->
  <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
  <link href="assets/vendor/icofont/icofont.min.css" rel="stylesheet"/>
  <link href="assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet"/>
  <link href="assets/vendor/remixicon/remixicon.css" rel="stylesheet"/>
  <link href="assets/vendor/line-awesome/css/line-awesome.min.css" rel="stylesheet"/>
  <link href="assets/vendor/owl.carousel/assets/owl.carousel.min.css" rel="stylesheet"/>
  <link href="assets/vendor/venobox/venobox.css" rel="stylesheet"/>

  <!-- Template Main CSS File -->
  <link href="assets/css/HospitalReg.css" rel="stylesheet"/>

  <!-- =======================================================
  * Template Name: Valera - v2.1.0
  * Template URL: https://bootstrapmade.com/valera-free-bootstrap-theme/
  * Author: BootstrapMade.com
  * License: https://bootstrapmade.com/license/
  ======================================================== -->
</head>

<body>

  <!-- ======= Header ======= -->
  <header id="header" class="header-inner-pages">
    <div class="container-fluid d-flex align-items-center justify-content-between">

      <h1 class="logo"><a href="index.html">ReachOut</a></h1>

      <nav class="nav-menu d-none d-lg-block">
        <ul>
          <li><a href="index.html">Home</a></li>
            <li><a href="#about">About</a></li>
            <%--<li><a href="#">Language</a></li>--%>

       <!-- <li class="drop-down"><a href="">Drop Down</a>
            <ul>
              <li><a href="#">Drop Down 1</a></li>
              <li class="drop-down"><a href="#">Deep Drop Down</a>
                <ul>
                  <li><a href="#">Deep Drop Down 1</a></li>
                  <li><a href="#">Deep Drop Down 2</a></li>
                  <li><a href="#">Deep Drop Down 3</a></li>
                  <li><a href="#">Deep Drop Down 4</a></li>
                  <li><a href="#">Deep Drop Down 5</a></li>
                </ul>
              </li>
              <li><a href="#">Drop Down 2</a></li>
              <li><a href="#">Drop Down 3</a></li>
              <li><a href="#">Drop Down 4</a></li>
            </ul>
          </li> 
            
          <li><a href="#contact">Contact</a></li> -->

        </ul>
      </nav><!-- .nav-menu -->

    </div>
    
  </header><!-- End Header -->

  <main id="main">

    <!-- ======= Breadcrumbs ======= -->
    <section id="breadcrumbs" class="breadcrumbs">
      <div class="container">

        <h2> Register as a Hospital </h2>

      </div>
    </section><!-- End Breadcrumbs -->

    <section class="inner-page">
      <div class="container">
          
          <form id="form1" runat="server">

              <div >
         
             <!-- <asp:TextBox ID="txtMessages" runat="server" Width="500px"></asp:TextBox> -->

              <asp:Label ID="txtWarning" runat="server" Text="" Style="font-family:Helvetica, sans-serif;
								font-size: 13px; color: red;
								">

						</asp:Label>


              <br />


                        <table cellpadding="2" >
	            <tbody>
		            <tr>
			            <td><asp:Label ID="lbl_username" runat="server" Text="Username:" class="objects"></asp:Label>  </td>
			            <td> <asp:TextBox ID="usr" runat="server"  class="objects"></asp:TextBox> <br /> </td>
		            </tr>
		            <tr>
			            <td> <asp:Label ID="lbl_password" runat="server" Text="Password:" class="objects"></asp:Label> </td>
			            <td>   <asp:TextBox ID="pass" runat="server" TextMode="Password" class="objects"></asp:TextBox><br /></td>
		            </tr>
		            <tr>
			            <td><asp:Label ID="lbl_email" runat="server" Text="Email:" class="objects"></asp:Label> </td>
			            <td> <asp:TextBox ID="eml" runat="server"  class="objects"></asp:TextBox> <br /></td>
		            </tr>
		            <tr>
			            <td><asp:Label ID="lbl_company_name" runat="server" Text="Hospital Name:" class="objects"></asp:Label></td>
			            <td>   <asp:DropDownList ID="DropDownList1" runat="server" Class="objects">
                   
                                </asp:DropDownList>  
                     </td>
		            </tr>
		            <tr>
			            <td>   <asp:Button ID="Register" runat="server" Text="Register" onclick="HospitalReg" /> </td>
			            <td> </td>
		            </tr>
	            </tbody>
            </table>


            </div>
          </form>
        
          
      </div>
    </section>

  </main><!-- End #main -->

  <!-- ======= Footer ======= -->
  <footer id="footer">

    <div class="footer-top">

      <div class="container">

        <div class="row  justify-content-center">
          <div class="col-lg-6">
            <h3>ReachOut</h3>
            <p>Connecting Healthcare Providers with PPE Suppliers.</p>
          </div>
        </div>
      </div>
    </div>

    <div class="container footer-bottom clearfix">
      <div class="copyright">
        &copy; Copyright <strong><span>Valera</span></strong>. All Rights Reserved
      </div>
      <div class="credits">
        <!-- All the links in the footer should remain intact. -->
        <!-- You can delete the links only if you purchased the pro version. -->
        <!-- Licensing information: https://bootstrapmade.com/license/ -->
        <!-- Purchase the pro version with working PHP/AJAX contact form: https://bootstrapmade.com/valera-free-bootstrap-theme/ -->
        Designed by <a href="https://bootstrapmade.com/">BootstrapMade</a>
      </div>
    </div>
  </footer><!-- End Footer -->

  <div id="preloader"></div>
  <a href="#" class="back-to-top"><i class="icofont-simple-up"></i></a>

  <!-- Vendor JS Files -->
  <script src="assets/vendor/jquery/jquery.min.js"></script>
  <script src="assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
  <script src="assets/vendor/jquery.easing/jquery.easing.min.js"></script>
  <script src="assets/vendor/php-email-form/validate.js"></script>
  <script src="assets/vendor/waypoints/jquery.waypoints.min.js"></script>
  <script src="assets/vendor/counterup/counterup.min.js"></script>
  <script src="assets/vendor/jquery-sticky/jquery.sticky.js"></script>
  <script src="assets/vendor/owl.carousel/owl.carousel.min.js"></script>
  <script src="assets/vendor/isotope-layout/isotope.pkgd.min.js"></script>
  <script src="assets/vendor/venobox/venobox.min.js"></script>

  <!-- Template Main JS File -->
  <script src="assets/js/main.js"></script>

</body>

</html>