<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyRecipes.aspx.cs" Inherits="Aplikacja_io.MyRecipes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownListRecipes" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="Button_Add" runat="server" Text="Dodaj" />
        </div>
        <div>
            <asp:Button ID="Button_Delete" runat="server" Text="Usun" />
        </div>
        <div>
            <asp:Button ID="Button_Edit" runat="server" Text="Edytuj" />
        </div>
    </form>
</body>
</html>
