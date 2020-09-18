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
            <asp:Button ID="Button1" runat="server" Text="View My Products" OnClick="viewMyProducts"/>
            <asp:Button ID="Button2" runat="server" Text="View My Orders" OnClick="viewMyOrders"/>
            <asp:Button ID="Button3" runat="server" Text="Add a New Product" OnClick="addProduct"/>

            <asp:TextBox ID="txt_prod_name" runat="server"></asp:TextBox>
            <asp:TextBox ID="txt_desc" runat="server"></asp:TextBox>
            <asp:TextBox ID="txt_price" runat="server"></asp:TextBox>

            <asp:RadioButtonList ID="radiolist_category" runat="server"></asp:RadioButtonList>
            <asp:TextBox ID="txt_amount" runat="server"></asp:TextBox>
            <asp:TextBox ID="txt_GTIN" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
