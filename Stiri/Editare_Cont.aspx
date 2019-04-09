<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Editare_Cont.aspx.cs" Inherits="Stiri.Editare_Cont" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="Stylesheet" href="/Inregistrare.css" type="text/css" />
    <asp:Literal ID="Mesaj" runat="server"></asp:Literal>
    <h1>Editare Cont</h1>
    <div class= "tab" align="center">
        <asp:Label  class="txt" ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Text="Username"></asp:Label>
        <br /><br />
        <asp:TextBox class="textbox" placeholder="@username" ID="UserName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="valid"
                    ID="UserNameRequired"
                    runat="server"
                    ControlToValidate="UserName"
                    ErrorMessage="Username obligatoriu!"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label class="txt"  ID="PasswordLabel" runat="server" AssociatedControlID="Password" Text="Parola"></asp:Label>
        <br /><br />
        <asp:TextBox class="textbox" placeholder="************" ID="Password" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Label class="txt" ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword" Text="Confirma parola"></asp:Label>
        <br /><br /> 
        <asp:TextBox class="textbox" placeholder="************" ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator CssClass="valid"
                    ID="PasswordCompare"
                    runat="server"
                    ControlToCompare="Password"
                    ControlToValidate="ConfirmPassword"
                    ErrorMessage="Parolele nu se potrivesc!"></asp:CompareValidator>
        <br />
        <asp:Label class="txt" ID="Label1" runat="server" AssociatedControlID="Nume" Text="Nume"></asp:Label>
        <br /><br />
        <asp:TextBox class="textbox" placeholder="@nume" ID="Nume" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="valid"
                    ID="RequiredFieldValidator1"
                    runat="server"
                    ControlToValidate="Nume"
                    ErrorMessage="Numele este obligatoriu!"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label class="txt" ID="Label2" runat="server" AssociatedControlID="Prenume" Text="Prenume"></asp:Label>
        <br /><br />
        <asp:TextBox class="textbox" placeholder="@prenume" ID="Prenume" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="valid"
                    ID="RequiredFieldValidator2"
                    runat="server"
                    ControlToValidate="Prenume"
                    ErrorMessage="Prenumele este obligatoriu!" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label class="txt" ID="Label3" runat="server" AssociatedControlID="Data" Text="Data nasterii"></asp:Label>
        <br /><br />
        <asp:TextBox class="textbox" type="date" ID="Data" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="valid"
                    ID="RequiredFieldValidator3"
                    runat="server"
                    ControlToValidate="Data"
                    ErrorMessage="Data nasterii este obligatorie!"
                    ForeColor="Red">*</asp:RequiredFieldValidator>

  
        <br />
        <asp:Label class="txt" ID="EmailLabel" placeholder="email@email.com" runat="server" AssociatedControlID="Email" Text="E-mail"></asp:Label>
        <br /><br />
        <asp:TextBox class="textbox" ID="Email" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="valid"
                    ID="EmailRequired"
                    runat="server"
                    ControlToValidate="Email"
                    ErrorMessage="E-mail obligatoriu!"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="valid"
                    ID="regexEmailValid"
                    runat="server"
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ControlToValidate="Email"
                    ErrorMessage="Format e-mail invalid!">
        </asp:RegularExpressionValidator>
        <br />
        <asp:Literal
                    ID="ErrorMessage"
                    runat="server"
                    EnableViewState="False"></asp:Literal>
         <asp:Button class="but" ID="Button2" runat="server" Text="Salveaza" OnClick="Editeaza_user" Height="45px" Width="283px" />
    </div>


</asp:Content>
