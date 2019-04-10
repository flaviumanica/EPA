<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Propune_Stire.aspx.cs" Inherits="Propune_Stire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="Stylesheet" href="/Posteaza_Stire.css" type="text/css" />
    <div class="tot">
         <h1> Propune stire </h1>
        <asp:Literal ID="Succes" runat="server"> </asp:Literal>
        
        <br />
        <asp:Label class="txt" ID="LTitlu" runat="server" Text="Titlu" AssociatedControlID="Titlu"></asp:Label>
        <br />
        <asp:TextBox ID="Titlu" class="textbox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator
                    ID="TitluRequired"
                    runat="server"
                    ControlToValidate="Titlu"
                    ErrorMessage="Titlu obligatoriu!"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label class="txt" ID="Label2" runat="server" Text="Continut" AssociatedControlID="Continut"></asp:Label>
        <br />
        <asp:TextBox ID="Continut" style="width:400px; height:250px;" class="textbox" runat="server" TextMode="multiline" Columns="50" Rows="5"></asp:TextBox>
        <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2"
                    runat="server"
                    ControlToValidate="Continut"
                    ErrorMessage="Continut obligatoriu!"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label class="txt" ID="Label5" runat="server" Text="Categorie"></asp:Label>
        <br />
        <asp:DropDownList ID="DDL" class="ddl"
            runat="server" 
            DataSourceID="SqlDataSource1" 
            DataTextField="Nume" 
            DataValueField="Id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" 
            runat="server"
            ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True" 
            SelectCommand="SELECT [Id], [Nume] FROM [Categorii]"></asp:SqlDataSource><br /><br />
        <asp:Label class="txt" ID="Label6" runat="server" Text="Adauga Categorie Noua"></asp:Label>
        <br />
        <asp:TextBox ID="AdaugaCategorie" class="textbox" runat="server"></asp:TextBox>
        <br /> <br />
        <asp:Literal ID="Mesaj" runat="server"></asp:Literal>
        <label class="file-upload">
            <span><strong>Adauga imagine</strong></span>
        <asp:FileUpload ID="Image" runat="server" > </asp:FileUpload>
            </label>
        <br />
        
        <asp:Button class="but" ID="Button1" runat="server" Text="Propune stire!" OnClick="Posteaza"/>

    </div>
    <asp:Literal ID="Literal1" runat="server"> </asp:Literal>
</asp:Content>

