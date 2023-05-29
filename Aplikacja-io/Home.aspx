<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Aplikacja_io.Home" %>

<!DOCTYPE html>

<html lang="en">
<head>
     <title>Strona Głowna</title>
     <link rel="stylesheet" href="Stylesss.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="section">
            <div class="log-rej">
                <ul>
                    <li><a href="Test.aspx">Logowanie/Rejestracja</a></li>
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
            <div class="wyszukiwanie">
                <asp:TextBox ID="TextBoxPrzepis" runat="server" CssClass="form-style2" placeholder="Wyszukaj"></asp:TextBox>
            </div>
            <div class="szukanie">
                    <asp:Button ID="ButtonSzukaj" runat="server" Text="Szukaj" OnClick="ButtonSzukaj_Click" CssClass="btn mt-4"/>
            </div>

            <div class="wypisywanie">

                        <asp:Repeater ID="repeaterPrzepisy" runat="server" >
                           <ItemTemplate>
                             <a href=Przepis/<%# Eval("Nazwa") %>><%# Eval("Nazwa") %></a>
                            <br />
                         </ItemTemplate>
                        </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
