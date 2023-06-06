<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Przepis.aspx.cs" Inherits="Aplikacja_io.Przepis1" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> </title>
    <link rel="stylesheet" href="Styles5.css">
</head>
<body>
    <form id="form1" runat="server">
            <div class="name">
                <asp:Literal runat="server" ID="LiteralNazwa"></asp:Literal>
            </div>
            <div>
                
                <div class="ingrediants">
                    <div class="headerIngrediants">
                    Składniki:
                </div>
                    <ul>
                        <asp:Repeater runat="server" ID="RepeaterSkladniki">
                            <ItemTemplate>
                                <li><%# Eval("Nazwa") %> - <%# Eval("Ilosc") %> (<%# Eval("Opis") %>)</li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>

                <div class="photo">
                    <asp:Repeater runat="server" ID="RepeaterZdjecia">
                        <ItemTemplate>
                            <img src='<%# GetImageUrl(Eval("zdjecie")) %>' alt="" />
                        </ItemTemplate>
                    </asp:Repeater>
               </div>
                <div class="descriptonText">
                    Opis:
                </div>
                <div class="description">
                    <asp:Literal runat="server" ID="LiteralOpis"></asp:Literal>
                </div>               
            </div>
        <div class="butEdit">
            <asp:Button ID="ButtonEdit" runat="server" Text="Edytuj Przepis" onclick="ButtonEditClick" CssClass="btn mt-4"/>
        </div>
    </form>
</body>
</html>