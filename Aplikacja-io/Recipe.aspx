<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recipe.aspx.cs" Inherits="Aplikacja_io.Register" %>

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
         Nazwa: <asp:TextBox ID="TextBoxName" placeholder="Nazwa" runat="server"></asp:TextBox>
    </p>
    <p>
        Opis: <asp:TextBox ID="TextBoxNazwisko" runat="server"></asp:TextBox>
    </p>
    
    <p>
        Ilosc: <asp:TextBox ID="TextBoxLogin" runat="server"></asp:TextBox>
    </p>
    <p>
        Skladniki: <asp:CheckBoxList ID="CheckBoxListS" runat="server"></asp:CheckBoxList>
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
