<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manf_home.aspx.cs" Inherits="Reachout1.Manf_home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
