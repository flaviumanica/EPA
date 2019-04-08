<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cautare.aspx.cs" Inherits="Cautare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="Stylesheet" href="/Stiri.css" type="text/css" />
     <asp:Literal ID="EroareBazaDate" runat="server"></asp:Literal>
    <br/>

    <asp:SqlDataSource ID="Articole" runat="server"  
        ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True" 
        SelectCommand="SELECT [Articol].[Id],[Articol].[Titlu], [Articol].[Data_Publicare],[Articol].[Descriere],[Imagine].[Cale] , [User].[Username]  FROM [Articol] , [Imagine] , [User] WHERE [Articol].[Id] = [Imagine].[Id_Articol] AND [Articol].[Id_User] = [User].[Id] order by [Articol].[Titlu]"></asp:SqlDataSource>
 <div>&nbsp;</div>
    <br />
    <div class ="crit">
    <asp:Literal ID="Criteriu" runat="server" > </asp:Literal>
    </div>
   

    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="Articole">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="blocul" >
                <asp:Image CssClass="poza" ID="Image1" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Cale").ToString()%>' />
                <div class="continut">
                <h3 id="titlu"><%# DataBinder.Eval(Container.DataItem, "Titlu")%></h3>
                 <p><%# DataBinder.Eval(Container.DataItem, "Descriere")%></p>
                   <p>Adaugat de: <%# DataBinder.Eval(Container.DataItem, "Username").ToString()%></p>
                   <p>Data publicarii: <%# DataBinder.Eval(Container.DataItem, "Data_Publicare").ToString().Substring(0,10)%></p>
                    <asp:HyperLink runat="server" NavigateUrl='<%# "~/Vizualizare_Stire.aspx?id=" + DataBinder.Eval(Container.DataItem, "Id")%>'>
                        <input class="but"type="button" value="Afla mai multe...">
                    </asp:HyperLink>
                     </div>
            </div>
        </ItemTemplate>
        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>
    </asp:Repeater>

</asp:Content>

