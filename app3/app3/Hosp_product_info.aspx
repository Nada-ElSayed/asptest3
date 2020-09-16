<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hosp_product_info.aspx.cs" Inherits="app3.Hosp_product_info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8">
  <meta content="width=device-width, initial-scale=1.0" name="viewport"/>

  <title>Product Details </title>
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
  <link href="assets/css/HospH.css" rel="stylesheet"/>

  <!-- =======================================================
  * Template Name: Valera - v2.1.0
  * Template URL: https://bootstrapmade.com/valera-free-bootstrap-theme/
  * Author: BootstrapMade.com
  * License: https://bootstrapmade.com/license/
  ======================================================== -->
   
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
              <div class="container">
              <asp:Literal ID="liTi" runat="server" Text=" "></asp:Literal>
              <div id ="prodsList" runat ="server" style="display: flex;-ms-flex-wrap: wrap;flex-wrap: wrap;margin-right: -15px;margin-left: -15px;">
              </div>       
          </div> 
            <asp:Label ID="Label1" runat="server" Text="Enter Quantity to Order"></asp:Label>
              <br />
                     <asp:TextBox ID="orderamountTXT"  runat="server" ></asp:TextBox>
              <br />
            <asp:RangeValidator ID="RangeValidator1" ControlToValidate="orderamountTXT" Type="Integer" runat="server" ErrorMessage="RangeValidator" MinimumValue="1" 
           EnableClientScript="false">       </asp:RangeValidator>
            <br/>
            <asp:Button class="btn-primary" ID="Button1" runat="server" Text="Place Order" onClick="placeOrder" 
                style="display:flex;align-items: center;justify-content:center; font-size: 24px;width: 40px;height: 40px;margin-top:0px;float:right;"/>
            <asp:Label ID="Label2" runat="server" ></asp:Label>
            </div>
    </form>
</body>
</html>
