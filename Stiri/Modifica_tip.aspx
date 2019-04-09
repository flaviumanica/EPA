<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Modifica_tip.aspx.cs" Inherits="Modifica_tip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="Stylesheet" href="/Modificare.css" type="text/css" />
    <h1>Modifica drepturi</h1>
    <div class="ddd">
        
    <table class="tot" align="center">
        <tr>
            <td class="unu" style="align-content:center">
                <asp:Label ID="_nume" runat="server" AssociatedControlID="NUME" Text="Nume:"></asp:Label>
                <asp:Label ID="NUME" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="unu" style="align-content:center">
                <asp:Label ID="_prenume" runat="server" AssociatedControlID="PRENUME" Text="Prenume:"></asp:Label>
                <asp:Label ID="PRENUME" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="unu" style="align-content:center">
                <asp:Label ID="_email" runat="server" AssociatedControlID="EMAIL" Text="Email:"></asp:Label>
                <asp:Label ID="EMAIL" runat="server" ></asp:Label>
            </td>
            </tr>
        <tr>
            <td class="unu" style="align-content:center">
                <asp:Label ID="_tip" runat="server" AssociatedControlID="TIP" Text="Tip:"></asp:Label>
                <asp:Label ID="TIP" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="unu" >
                <asp:Label ID="Label1" runat="server" AssociatedControlID="TIP" Text="Alege un tip:"></asp:Label>
                <asp:DropDownList ID="DDL" class="ddl" 
                    runat="server" 
                    DataSourceID="SqlDataSource1" 
                    DataTextField="Tip" 
                    DataValueField="Id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" 
                    runat="server"
                    ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True" 
                    SelectCommand="SELECT [Id], [Tip] FROM [Roles]"></asp:SqlDataSource>
            </td>
        </tr>
    
   </table>
        <div align="center">
    <asp:Button class="but" ID="Salveaza" runat="server" Text="Salveaza modificarile" OnClick="Salveaza_Modificari"/>
 </div>
       
        <br />
    <asp:Literal ID="Mesaj" runat="server"></asp:Literal>
     </div>
</asp:Content>

