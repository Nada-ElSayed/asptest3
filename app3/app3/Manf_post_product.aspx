<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manf_post_product.aspx.cs" Inherits="app3.Manf_post_product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <div class="container" style="position: absolute;  bottom: 0;    top: 0;    left: 15px;    right: 15px;    display: flex;    justify-content: center;    align-items: center;    flex-direction: column;    text-align: center;">
              <div>
                <div id ="prodsList" runat ="server" style="display: flex;-ms-flex-wrap: wrap;flex-wrap: wrap;">
                </div>
                  <br />
                  <asp:Label ID="Label1" runat="server" ></asp:Label>
                  <br />
                  <asp:Label ID="Label2" runat="server" Text="Product Name"></asp:Label>
                  <asp:TextBox ID="Textpname" runat="server"></asp:TextBox>
                  <br />
                  <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label>
                  <asp:TextBox ID="Textinfo" runat="server"></asp:TextBox>
                  <br />
                  <asp:Label ID="Label4" runat="server" Text="Unit Price"></asp:Label>
                  <asp:TextBox ID="Textunit_price" runat="server"></asp:TextBox>
                  <br />
                  <asp:Label ID="Label5" runat="server" Text="Category"></asp:Label>
                  <asp:DropDownList ID="Dropcateg" runat="server"></asp:DropDownList>
                  <br />
                  <asp:Label ID="Label6" runat="server" Text="Amount available"></asp:Label>
                  <asp:TextBox ID="Textamount" runat="server"></asp:TextBox>
                  <br />
                  <asp:Label ID="Label7" runat="server" Text="Global Trade Number"></asp:Label>
                  <asp:TextBox ID="Textgtin" runat="server"></asp:TextBox>
                  <br />
                  <asp:Button ID="Button1" runat="server" Text="Submit Changes" OnClick="editProduct"/>
                  <asp:Button ID="Button2" runat="server" Text="Revert Changes" OnClick="revertChanges"/>
              </div>    
          </div> 
        </div>
    </form>
</body>
</html>
