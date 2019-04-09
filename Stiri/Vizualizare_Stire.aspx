<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Vizualizare_Stire.aspx.cs" Inherits="Vizualizare_Stire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="Stylesheet" href="/Viz_Stire.css" type="text/css" />
    <div class="stire">
    <asp:Literal ID="Mesaj" runat="server"></asp:Literal>
    
    <asp:Label class="titlu" ID="Titlu" runat="server" ></asp:Label>
    <br />
    <asp:Image class="img" ID="Image1" runat="server" />
    <br />
        <div class="continut">
    <asp:Label ID="Continut" runat="server" ></asp:Label>
    <br /><br /><br /><br />
    <asp:Label ID="Data" runat="server" Text="Din: "></asp:Label>
    <br /><br />
    <asp:Label style="text-decoration:underline" ID="User" runat="server" Text="Adaugat de "></asp:Label>
    <br />
    <br />
    <div align="center">
</div>
    </div>
    </div>
       
            
    <br />
    <br /><br /><br /><br />
    <asp:Label  class="com" ID="Label1" runat="server" Text="Adauga un comentariu!" Visible="false" AssociatedControlID="Comm"></asp:Label>
    <br /> <br />
    <asp:TextBox style="margin-left:33%;margin-right:40%; width:400px;" ID="Comm"  runat="server" Visible="false" TextMode="multiline" Columns="40" Rows="4"></asp:TextBox>
    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "Comm" ID="RegularExpressionValidator1" ValidationExpression = "^[\s\S]{0,100}$" runat="server" ErrorMessage="Poti adauga maxim 100 de caractere"></asp:RegularExpressionValidator>
    <br /><br />
    <div align="center">
    <asp:Button style="padding:7px;" class="but"  ID="Adauga_comm" Visible="false" runat="server" Text="ADAUGA" OnClick="Adauga_Comentariu"/>
    </div>
     
</asp:Content>

