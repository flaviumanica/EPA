<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Publica_Stire_Propusa.aspx.cs" Inherits="Publica_Stire_Propusa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="Stylesheet" href="/Edit.css" type="text/css" />
    <div class="tot">
        <br /><br />
        <asp:Literal ID="Succes" runat="server"> </asp:Literal>
        <br />
        <br />
        <asp:Label class="txt"  ID="LTitlu" runat="server" Text="Titlu" AssociatedControlID="Titlu"></asp:Label>
        <br />
        <asp:TextBox class="textbox" ID="Titlu" runat="server" TextMode="multiline" Rows="3"></asp:TextBox>
        <asp:RequiredFieldValidator
                    ID="TitluRequired"
                    runat="server"
                    ControlToValidate="Titlu"
                    ErrorMessage="Titlu obligatoriu"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label class="txt" ID="Label2" runat="server" Text="Continut" AssociatedControlID="Continut"></asp:Label>
        <br />
        <asp:TextBox class="textbox" ID="Continut" runat="server" TextMode="multiline" Columns="100" Rows="20"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1"
                    runat="server"
                    ControlToValidate="Continut"
                    ErrorMessage="Continut obligatoriu"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label class="txt" ID="Label4" runat="server" Text="Scurta descriere" AssociatedControlID="Descriere"></asp:Label>
        <br />
        <asp:TextBox class="textbox" ID="Descriere" runat="server" TextMode="multiline" Columns="50" Rows="5" Text="Adauga descriere!"></asp:TextBox>
        <asp:RequiredFieldValidator
                    ID="descriereRequired"
                    runat="server"
                    ControlToValidate="Descriere"
                    ErrorMessage="Scurta descriere obligatorie"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button class="but" style="width:auto;" ID="Button2" runat="server" Text="Genereaza descriere" OnClick="Genereaza_Descriere" CausesValidation="false"/>
        <br />
         <asp:Label class="txt" ID="User" runat="server" Text="Propusa de "></asp:Label>
        <br />
         <asp:Label class="txt" ID="Data" runat="server" Text="La data "></asp:Label>
        <br />
         <asp:Button class="but" ID="Button1" runat="server" Text="Publica" OnClick="Salvare" />
        <br />
        
       </div>
</asp:Content>

