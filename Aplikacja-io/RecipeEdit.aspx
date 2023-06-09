﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecipeEdit.aspx.cs" Inherits="Aplikacja_io.RecipeEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="Styles6.css">
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
                    <div class="nameofrecipe2">
                        <asp:TextBox ID="TextBoxDescription" placeholder="Opis" TextMode="MultiLine" Rows="5" runat="server" CssClass="form-style2"></asp:TextBox>
                    </div>
                    <div class="heading3">
                       Składniki:
                    </div>
                    <div class="listofigrediants">
                        <asp:Repeater ID="repeaterSkladniki" runat="server" OnItemDataBound="repeaterSkladniki_ItemDataBound"  >
                           <ItemTemplate>
                               <asp:CheckBox ID="CheckBox" Text='<%# Eval("Nazwa") %>'  runat="server" />
                               <asp:Label ID="Label" runat="server" Text="" Visible="false" CssClass="form-style5"></asp:Label>
                               <asp:TextBox ID="TextBox" TextMode="Number" runat="server" CssClass="form-style4"></asp:TextBox>
                               <asp:Label ID="LabelJed" runat="server" CssClass="form-style6" Text='<%# Eval("opis") %>' ></asp:Label>
                            <br />
                         </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <div class="heading2">
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
                    <div class="butCancel">
                        <asp:Button ID="ButtonCancel" runat="server" Text="Odrzuć Zmiany" OnClick="ButtonCancel_Click" class="btn mt-4" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
