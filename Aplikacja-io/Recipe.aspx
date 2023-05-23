<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recipe.aspx.cs" Inherits="Aplikacja_io.Register" %>

<!DOCTYPE html>

<html lang="en">
<head>
      <title>Dodaj przepis</title>
        <link rel="stylesheet" href="Styless.css">

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="formularz">
                <div class="header2">
                    Dodaj przepis
                </div>
                    <div class="container2">
                        <div class="nazwaPrzepisu">
                            <asp:TextBox ID="TextBoxName" placeholder="Nazwa" runat="server" CssClass="form-style2"></asp:TextBox>
                        </div>
                         <div class="nazwaPrzepisu">
                            <asp:TextBox ID="TextBoxDescription" placeholder="Opis" runat="server" CssClass="form-style2"></asp:TextBox>
                        </div> 
                        <div class="nazwaPrzepisu">
                            <asp:TextBox ID="TextBoxLogin" placeholder="Ilość" runat="server" CssClass="form-style2"></asp:TextBox>
                        </div>
                        <div class="skladniki">
                            Składniki: 
                        </div>
                        <div class="listaskladnikow">
                            <asp:CheckBoxList ID="CheckBoxListS" runat="server" CssClass="wygladchecka"></asp:CheckBoxList>
                        </div>

                        <div class="skladniki">
                            Dodaj zdjęcia: 
                        </div>
                        
                        <div class="dodajBut2">
                            <asp:FileUpload ID="upload" runat="server" class="hidden" onclick="showThumbnail"/>
                            <label for="upload" class="btn">Wybierz plik</label>
                            <br />
                            <asp:Image ID="thumbnail" runat="server" AlternateText="Thumbnail" style="display: none; max-width: 200px; margin-top: 10px;" />
                        </div>
                        
        <div class="dodajBut">
             <asp:Button ID="ButtonZat" runat="server" Text="Dodaj" OnClick="ButtonZat_Click" class="btn mt-4"/>
        </div>
            </div>
            </div>
        </div>
    </form>
</body>
</html>
