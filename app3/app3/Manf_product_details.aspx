﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manf_product_details.aspx.cs" Inherits="app3.Manf_product_details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8">
  <meta content="width=device-width, initial-scale=1.0" name="viewport"/>

  <title>Order Information</title>
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

        <main>

        <section style="background:#fafafa">

            <div id="breadcrumbs" class="breadcrumbs">
              <div class="container">

                <ol style="color:#007bff">
                  <li >
                  Manufacturer's Home</li>
                  <li>Product Information</li>
                </ol>
               <div style="display:flex">
                <h3>Category:   </h3>
                <asp:Literal ID="liTi" runat="server" Text=" "></asp:Literal> 
             </div>

            </div>
          </div>
        </section>
            
          <div class="container" style="position: absolute;  bottom: 0;    top: 0;    left: 15px;    right: 15px;    display: flex;    justify-content: center;    align-items: center;    flex-direction: column;    text-align: center;">
              <div>
                <div id ="prodsList" runat ="server" style="display: flex;-ms-flex-wrap: wrap;flex-wrap: wrap;">
               </div>
                   

                  <br />
                  <asp:Label ID="Label1" runat="server" ></asp:Label>
                  <br />
                  <table cellpadding="2" >
                             
	            <tbody>

                  <tr>  
                   <td>
                  <asp:Label ID="Label2" runat="server" Text="Product Name"></asp:Label></td>
                  <td><asp:TextBox ID="Textpname" runat="server"></asp:TextBox></td>
                  </tr><tr>
                      <td>
                  <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label></td>
                       <td>
                  <asp:TextBox ID="Textinfo" runat="server"></asp:TextBox></td>
                 </tr><tr>
                     <td>
                  <asp:Label ID="Label4" runat="server" Text="Unit Price"></asp:Label></td>
                     <td>
                  <asp:TextBox ID="Textunit_price" runat="server"></asp:TextBox></td>
                  </tr><tr>
                      <td>
                  <asp:Label ID="Label5" runat="server" Text="Category"></asp:Label></td>
                       <td>
                  <asp:DropDownList ID="Dropcateg" runat="server"></asp:DropDownList></td>
                 </tr><tr>
                     <td>
                  <asp:Label ID="Label6" runat="server" Text="Amount available"></asp:Label></td>
                      <td>
                  <asp:TextBox ID="Textamount" runat="server"></asp:TextBox></td>
                  </tr><tr>
                      <td>
                  <asp:Label ID="Label7" runat="server" Text="Global Trade Number"></asp:Label></td>
                       <td>
                  <asp:TextBox ID="Textgtin" runat="server"></asp:TextBox></td>
                  </tr><tr>
                      <td>
                  <asp:Button ID="Button1" runat="server" Text="Submit Changes" OnClick="editProduct"/></td>
                      <td>
                  <asp:Button ID="Button2" runat="server" Text="Revert Changes" OnClick="revertChanges"/></td>
                    </tr>

                </tbody>
            </table>
              </div>    
          </div> 

        
        </main>


            
         
    </form>
</body>
</html>
