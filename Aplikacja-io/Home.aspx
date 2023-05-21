<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Aplikacja_io.Home" %>

<!DOCTYPE html>

<html lang="en">
<head>
     <title>Strona Głowna</title>
     <link rel="stylesheet" href="Styless.css">
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
                    <li><a href="Test.aspx">Rejestracja</a></li>
                </ul>
            </nav>
            
        </div>
    </form>
</body>
</html>
