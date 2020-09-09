<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HospRegistration.aspx.cs" Inherits="Reachout1.HospRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
            <div>
              Vendor Registration
            <br />
                         <asp:TextBox ID="txtMessages" runat="server" Width="500px"></asp:TextBox>
                        <br />


              <asp:Label ID="lbl_username" runat="server" Text="Username: "></asp:Label>
                <asp:TextBox ID="usr" runat="server"></asp:TextBox> <br />

             <asp:Label ID="lbl_password" runat="server" Text="Password: "></asp:Label>
                 <asp:TextBox ID="pass" runat="server" TextMode="Password"></asp:TextBox><br />

             <asp:Label ID="lbl_email" runat="server" Text="Email: "></asp:Label>
                <asp:TextBox ID="eml" runat="server"></asp:TextBox> <br />
           
             <asp:Label ID="lbl_company_name" runat="server" Text="Manufacturer name: "></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>

            <br />
                
                <br />
                
                             <asp:Button ID="Register" runat="server" Text="Register" onclick="HospitalReg" />
                            <br />           
                  

        
    </div>
    </form>
</body>
</html>
