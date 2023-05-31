<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecipeEdit.aspx.cs" Inherits="Aplikacja_io.RecipeEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="Styles1.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="formularz">
                <div class="header2">
                    Edytuj Przepis
                </div>
                <div class="container2">
                    <div class="nameofrecipe">
                        <asp:TextBox ID="TextBoxName" placeholder="Nazwa" runat="server" CssClass="form-style2"></asp:TextBox>
                    </div>
                    <div class="nameofrecipe">
                        <asp:TextBox ID="TextBoxDescription" placeholder="Opis" runat="server" CssClass="form-style2"></asp:TextBox>
                    </div>
                    <div class="heading">
                       Składniki:
                    </div>
                    <div class="listofigrediants">
                        <asp:CheckBoxList ID="CheckBoxListS" runat="server" CssClass="wygladchecka"></asp:CheckBoxList>
                    </div>

                    <div class="heading">
                        Dodaj zdjęcia: 
                    </div>

                    <div class="AddBut2">
                        <asp:FileUpload ID="upload" runat="server" class="hidden" onclick="showThumbnail" />
                        <label for="upload" class="btn">Wybierz plik</label>
                        <br />
                        <asp:Image ID="thumbnail" runat="server" AlternateText="Thumbnail" style="display: none; max-width: 200px; margin-top: 10px;" />
                    </div>

                    <div class="AddBut">
                        <asp:Button ID="ButtonZat" runat="server" Text="Zapisz Zmiany" OnClick="ButtonZat_Click" class="btn mt-4" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
