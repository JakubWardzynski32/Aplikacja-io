<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Aplikacja_io.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
            Login:<asp:TextBox ID="TextBoxLogin" runat="server" ></asp:TextBox>
            </p>
            <p>
            Haslo:<asp:TextBox ID="TextBoxHaslo" runat="server" TextMode="Password" ></asp:TextBox>
            </p>
            <asp:Button ID="ButtonZal" runat="server" Text="Zaloguj" OnClick="ButtonZal_Click" />
        </div>
    </form>
</body>
</html>
