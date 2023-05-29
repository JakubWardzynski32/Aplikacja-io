<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Przepis.aspx.cs" Inherits="Aplikacja_io.Przepis1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>
        <div id="Title">

        </div>
    </title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="Nazwa">
                <asp:Literal runat="server" ID="LiteralNazwa"></asp:Literal>
            </div>

            <div id="Opis">
                <asp:Literal runat="server" ID="LiteralOpis"></asp:Literal>
            </div>

            <div id="Ilosc">
                <asp:Literal runat="server" ID="LiteralIlosc"></asp:Literal>
            </div>

           <div id="Skladniki">
                <ul>
                    <asp:Repeater runat="server" ID="RepeaterSkladniki">
                        <ItemTemplate>
                            <li><%# Eval("Nazwa") %></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>

            <div id="Zdjecie">
               <asp:Repeater runat="server" ID="RepeaterZdjecia">
                    <ItemTemplate>
                        <img src="<%# GetImageUrl(Eval("Obraz")) %>" alt="" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </div>
    </form>
</body>
</html>