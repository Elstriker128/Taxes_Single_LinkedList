<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UIForClient.aspx.cs" Inherits="Taxes.UIForClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="~/StyleForUI.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <br />
            <div class="center">
            <asp:Label ID="Label1" runat="server" Text="Input citizen data"></asp:Label>
            &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Citizen file is essential" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Input tax data"></asp:Label>
            &nbsp;<asp:FileUpload ID="FileUpload2" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload2" ErrorMessage="Taxes file is essential" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <div class="center">
            <asp:Label ID="Label3" runat="server" Text="Input required month"></asp:Label>
            &nbsp;<asp:TextBox ID="TextBox1" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox1" ErrorMessage="Required month is essential" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Input required tax"></asp:Label>
            &nbsp;<asp:TextBox ID="TextBox2" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox2" ErrorMessage="Required tax is essential" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Calculate" />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Remove" CausesValidation="false" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Table ID="Table2" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Label ID="Label5" runat="server" CssClass="lab"></asp:Label>
            <br />
            <asp:Table ID="Table3" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Label ID="Label6" runat="server" CssClass="lab"></asp:Label>
            <br />
            <asp:Table ID="Table4" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Table ID="Table5" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
            </asp:Table>
        </div>
    </form>
</body>
</html>
