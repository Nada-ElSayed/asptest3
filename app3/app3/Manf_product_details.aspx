<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manf_product_details.aspx.cs" Inherits="app3.Manf_product_details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <main>

        <section style="background:#fafafa">

            <div id="breadcrumbs" class="breadcrumbs">
              <div class="container">

                <ol style="color:#007bff">
                  <li >
                  Hospital Home</li>
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
      
                <asp:Label ID="Label1" runat="server" Text="Enter Quantity to Order:"></asp:Label>
                <br />
                <asp:TextBox ID="orderamountTXT"  runat="server" ></asp:TextBox>
                <br />
                <asp:RangeValidator ID="RangeValidator1" ControlToValidate="orderamountTXT" Type="Integer" runat="server" ErrorMessage="RangeValidator" MinimumValue="1" 
                EnableClientScript="false">       </asp:RangeValidator>
                
                <asp:Button class="btn-primary" ID="Button1" runat="server" Text="Place Order" onClick="placeOrder"/>
                <asp:Label ID="Label2" runat="server" ></asp:Label>
            </div>    
          </div> 

        
        </main>


            
         
    </form>
</body>
</html>
