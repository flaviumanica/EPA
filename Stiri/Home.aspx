 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="Stylesheet" href="/Stiri.css" type="text/css" />
    <asp:Literal ID="Mesaj" runat="server"></asp:Literal>
    <!--<asp:FileUpload ID="FUImage" runat="server" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FUImage" ErrorMessage="Image is required." ForeColor="Red"></asp:RequiredFieldValidator>
-->
    <!--<asp:DropDownList ID="DDLBrand" runat="server" DataSourceID="SqlDataSource1" DataTextField="Nume" ></asp:DropDownList>
    <asp:TextBox ID="TextBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Nume"> </asp:TextBox>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True" SelectCommand="SELECT [Nume], [Prenume] FROM [User]"></asp:SqlDataSource>
-->   
    <div>
    <asp:SqlDataSource ID="Articole" 
            runat="server"
            ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True" 
            SelectCommand="set rowcount 10
                select b.Id, Titlu, Descriere, Username, Data_publicare, Cale from [Imagine] c,[Articol] b , [User] a where b.id_user = a.Id and b.Id = c.Id_Articol order by Data_publicare desc "></asp:SqlDataSource> 
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="Articole">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="blocul" >
               <%--<asp:Image CssClass="poza" ID="Image1" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Cale").ToString()%>' />--%>
               <div class="continut">
                 <h3 id="titlu"><%# DataBinder.Eval(Container.DataItem, "Titlu")%></h3>
                   <p><%# DataBinder.Eval(Container.DataItem, "Descriere")%></p>
                   <p>Adaugat de: <%# DataBinder.Eval(Container.DataItem, "Username").ToString()%></p>
                   <p>Data publicarii: <%# DataBinder.Eval(Container.DataItem, "Data_Publicare").ToString().Substring(0,9)%></p>
                    <asp:HyperLink runat="server" NavigateUrl='<%# "~/Vizualizare_Stire.aspx?id=" + DataBinder.Eval(Container.DataItem, "Id")%>'>
                        <input class="but"type="button" value="Afla mai multe...">
                    </asp:HyperLink>
                </div>
            </div>
        </ItemTemplate>

    </asp:Repeater>
        </div>
</asp:Content>
