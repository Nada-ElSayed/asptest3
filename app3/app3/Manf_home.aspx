<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manf_home.aspx.cs" Inherits="Reachout1.Manf_home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">

<head runat="server">
  <meta charset="utf-8">
  <meta content="width=device-width, initial-scale=1.0" name="viewport"/>

  <title> Manufacturer Home </title>
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
    
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
  <!-- Template Main CSS File -->
  <link href="assets/css/ManfHome.css" rel="stylesheet"/>

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
          <li><a href="#">Home</a></li>
            <li><a href="#about">About</a></li>
            <li><a href="#">Language</a></li>

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

        <ol>
          <li><a href="">Home</a></li>
          <li>Manufacturer Home</li>
        </ol>
        <h2>Manufacturer Home</h2>

      </div>
    </section><!-- End Breadcrumbs -->

    <section class="inner-page">
      <div class="container">
          
          <form id="form1" runat="server">

             
      <div class="faq">
      <div style="background-color: white;">
        <div class="faq-list">
          <ul style="padding-left:0;">
            <li data-aos="fade-up" >
              <a data-toggle="collapse" class="collapse" href="#faq-list-1">Add A new Product? <i class="bx bx-chevron-down icon-show"></i><i class="bx bx-chevron-up icon-close"></i></a>
              <div id="faq-list-1" class="collapse show" data-parent=".faq-list">
                     <table cellpadding="2" >
                             
	            <tbody>
		            <tr>
			            <td><asp:Label ID="Label1" runat="server" Text="Product Name:" class="objects"></asp:Label>  </td>
			            <td> <asp:TextBox ID="txt_prod_name" runat="server"></asp:TextBox> <br /> </td>
		            </tr>
		            <tr>
			            <td> <asp:Label ID="Label2" runat="server" Text="Description:" class="objects"></asp:Label> </td>
			            <td> <asp:TextBox ID="txt_desc" runat="server"></asp:TextBox><br /></td>
		            </tr>
		            <tr>
			            <td><asp:Label ID="Label3" runat="server" Text="Unit Price: " class="objects"></asp:Label> </td>
			            <td> <asp:TextBox ID="txt_price" runat="server"></asp:TextBox> 
                            <asp:Label ID="error_price" runat="server"></asp:Label>
                            </td>
		            </tr>
		            <tr>
			            <td><asp:Label ID="Label4" runat="server" Text="Category:" class="objects"></asp:Label></td>
			            <td><asp:DropDownList ID="DropDown_category" runat="server"></asp:DropDownList></td>
		            </tr>
		            <tr>
			            <td>  <asp:Label ID="Label5" runat="server" Text="Amount Available:" class="objects"></asp:Label> </td>
			            <td> <asp:TextBox ID="txt_amount" runat="server"></asp:TextBox>
                            <asp:Label ID="error_amount" runat="server"></asp:Label>

			            </td>
		            </tr>
                    <tr>
			            <td>  <asp:Label ID="Label6" runat="server" Text="Global Trade Number" class="objects"></asp:Label> </td>
			            <td>  <asp:TextBox ID="txt_GTIN" runat="server"></asp:TextBox>
                            <asp:Label ID="error_GTIN" runat="server"></asp:Label>
			            </td>
		            </tr>
                     <tr>
			            <td><asp:Button ID="Button3" runat="server" Text="Add a New Product" OnClick="addProduct"/></td>
			            <td></td>
		            </tr>
	            </tbody>
            </table>
             </div>
            </li>
          </ul>
        </div>

      </div>
    </div>

               <div style="overflow-x:auto;width:100%" >

                <table>
                <tbody>
               
                <tr style="width:100%">
                
                <td style="height:221.1px; width : 221.1px">  <asp:Button ID="Button1"  class="btn-primary" runat="server" Text="View My Products" OnClick="viewMyProducts" Width="100%"/> </td>
                <td style="width : 221.1px"> <asp:Button  class="btn-primary" ID="Button2" runat="server" Text="View My Orders" OnClick="viewMyOrders" Width="100%"/>
                </td>
                <td style="width : 221.1px"></td>
                </tr>

                </tbody>
                </table>
            </div>


              <div class="container">
                   <asp:Label ID="txtWarning" runat="server" Text="" Style="font-family:Helvetica, sans-serif;font-size: 13px; color: red;"></asp:Label>

                  <asp:Literal ID="liTi" runat="server" Text=""></asp:Literal>
                  <asp:Panel ID="prodsList" runat="server"></asp:Panel>
               
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