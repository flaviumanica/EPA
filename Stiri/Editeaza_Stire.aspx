<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Editeaza_Stire.aspx.cs" Inherits="Editeaza_Stire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link rel="Stylesheet" href="/Edit.css" type="text/css" />
     <div class="tot">
       
         <h1>Editeaza articol</h1>
        <asp:Literal ID="Succes" runat="server"> </asp:Literal>
        <br />
        
        <asp:Label class="txt" ID="LTitlu" runat="server" Text="Titlu" AssociatedControlID="Titlu"></asp:Label>

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
        <asp:TextBox class="textbox" ID="Continut" runat="server" TextMode="multiline" Columns="50" Rows="20"></asp:TextBox>
        <br />
        <asp:Label class="txt" ID="Label3" runat="server" Text="Link" AssociatedControlID="Link"></asp:Label>
        <br />
        <asp:TextBox class="textbox" ID="Link" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Continut sau Link trebuie completate" OnServerValidate="validare"></asp:CustomValidator>
        <br />
        <asp:Label class="txt" ID="Label4" runat="server" Text="Scurta descriere" AssociatedControlID="Descriere"></asp:Label>
        <br />
        <asp:TextBox class="textbox" ID="Descriere" runat="server" TextMode="multiline" Columns="50" Rows="5"></asp:TextBox>
        <asp:RequiredFieldValidator
                    ID="descriereRequired"
                    runat="server"
                    ControlToValidate="Descriere"
                    ErrorMessage="Scurta descriere obligatorie"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
         <br />
         <asp:Label class="txt" ID="User" runat="server" Text="Adaugat de "></asp:Label>
         <br />

         <asp:Label class="txt" ID="Data" runat="server" Text="La data "></asp:Label>
        <br />
        <br />
        <asp:Button class="but" ID="Button1" runat="server" Text="Salveaza" OnClick="Salvare" />
       </div>
</asp:Content>

