<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Posteaza Stire.aspx.cs" Inherits="Posteaza_Stire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="Stylesheet" href="/Posteaza_Stire.css" type="text/css" />
    <div class="tot">

        <h1> Posteaza articol </h1>
        <asp:Literal ID="Succes" runat="server"> </asp:Literal>
        <br />


        <asp:Label class="txt" ID="LTitlu" runat="server" Text="Titlu" AssociatedControlID="Titlu"></asp:Label>
        <br /><br />
        <asp:TextBox class="textbox" ID="Titlu" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator
                    ID="TitluRequired"
                    runat="server"
                    ControlToValidate="Titlu"
                    ErrorMessage="Titlu obligatoriu"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label class="txt" ID="Label2" runat="server" Text="Continut" AssociatedControlID="Continut"></asp:Label>
        <br /><br />
        <asp:TextBox class="textbox" style="width:400px; height:250px;" ID="Continut" runat="server" TextMode="multiline" Columns="50" Rows="5"></asp:TextBox>
        <br />
        <asp:Label class="txt" ID="Label3" runat="server" Text="Link" AssociatedControlID="Link"></asp:Label>
        <br /><br />
        <asp:TextBox class="textbox" ID="Link" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Continut sau Link trebuie completate" OnServerValidate="validare"></asp:CustomValidator>
        <br />
        <asp:Label class="txt" ID="Label4" runat="server" Text="Scurta descriere" AssociatedControlID="Descriere"></asp:Label>
        <br /><br />
        <asp:TextBox  class="textbox" style="width:400px;" ID="Descriere" runat="server" TextMode="multiline" Columns="50" Rows="7"></asp:TextBox>
        <asp:RequiredFieldValidator
                    ID="descriereRequired"
                    runat="server"
                    ControlToValidate="Descriere"
                    ErrorMessage="Scurta descriere obligatorie"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Button class="but" style="width:auto;" ID="Button2" runat="server" Text="Genereaza descriere" OnClick="Genereaza_Descriere" CausesValidation="false"/>
        <br />
        <asp:Label class="txt" ID="Label5" runat="server" Text="Categorie"></asp:Label>
        <br /><br />
        <asp:DropDownList ID="DDL" class="ddl"
            runat="server" 
            DataSourceID="SqlDataSource1" 
            DataTextField="Nume" 
            DataValueField="Id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" 
            runat="server"
            ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True" 
            SelectCommand="SELECT [Id], [Nume] FROM [Categorii]"></asp:SqlDataSource>
        <br /><br />
        <asp:Label class="txt" ID="Label6" runat="server" Text="Adauga Categorie Noua"></asp:Label>
        <br /><br />
        <asp:TextBox class="textbox" ID="AdaugaCategorie" runat="server"></asp:TextBox>
        <br /> 
        <asp:Literal ID="Mesaj" runat="server"></asp:Literal>
        <label class="file-upload">
            <span><strong>Adauga imagine</strong></span>
        <asp:FileUpload  class="img" ID="Image"  runat="server" ></asp:FileUpload>
        </label>
        <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2"
                    runat="server"
                    ControlToValidate="Image"
                    ErrorMessage="Trebuie sa adaugi o imagine"
                    ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button class="but" ID="Button1" runat="server" Text="Posteaza" OnClick="Posteaza"/>
    </div>
</asp:Content>

