<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Aplikacja_io.Home" %>

<!DOCTYPE html>

<html lang="en">
<head>
     <title>Strona Głowna</title>
     <link rel="stylesheet" href="Styles5.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="section">
            <div class="log-rej">
                <ul>
                    <li><a href="Test.aspx" style="font-size: 15px;">Logowanie/Rejestracja</a></li>
                    <li><asp:Button ID="ButtonLogOut" runat="server" Text="Wyloguj" OnClick="Log_Out" CssClass="btn mt-2" Visible="False" /></li><br>
                    <span style="font-size: 15px;"><asp:Literal ID="GreetingText" runat="server" Text=""></asp:Literal></span>
                </ul>
             </div>
            <div class="header">
               Przepisy
            </div>
            
            <nav>
                <ul>
                    <li><a href="Recipe.aspx">Dodaj przepis</a></li>
                </ul>
            </nav>
            <div class="search">
                <asp:TextBox ID="TextBoxPrzepis" runat="server" CssClass="form-style2" placeholder="Wyszukaj"></asp:TextBox>
            </div>
            <div class="searching">
                    <asp:Button ID="ButtonSzukaj" runat="server" Text="Szukaj" OnClick="ButtonSzukaj_Click" CssClass="btn mt-4"/>
            </div>

            <div class="write">

                        <asp:Repeater ID="repeaterPrzepisy" runat="server" >
                           <ItemTemplate>
                             <a href="Przepis.aspx?ID=<%# Eval("ID") %>"><%# Eval("Nazwa") %></a>
                            <br />
                         </ItemTemplate>
                        </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
