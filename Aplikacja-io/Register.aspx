<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Aplikacja_io.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="formularz">
        <p>
        Zarejestruj się
    </p>
    <p>
         Imie: <asp:TextBox ID="TextBoxImie" runat="server"></asp:TextBox>
    </p>
    <p>
        Nazwisko: <asp:TextBox ID="TextBoxNazwisko" runat="server"></asp:TextBox>
    </p>
    
    <p>
        Login: <asp:TextBox ID="TextBoxLogin" runat="server"></asp:TextBox>
    </p>
    <p>
        Haslo: <asp:TextBox ID="TextBoxHaslo" runat="server" TextMode="Password"></asp:TextBox>
    </p>
    <p>
        Email: <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
    </p>
    
    
    
        <asp:Button ID="ButtonZat" runat="server" Text="Zatwierdz" OnClick="ButtonZat_Click" />
    
       </div>
        </div>
    </form>
</body>
</html>
