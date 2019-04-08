<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Afis_Categ.aspx.cs" Inherits="Afis_Categ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="Stylesheet" href="/Stiri.css" type="text/css" />
    <asp:Literal ID="Mesaj" runat="server"></asp:Literal>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True"
            SelectCommand="Select a.Id,Titlu,Descriere,Username, Data_Publicare, b.Nume, Cale FROM Articol a, Categorii b,[User] c,Imagine d WHERE a.Categorie=b.Id AND a.Id_User=c.Id AND b.Id=@alias AND d.Id_Articol=a.Id ">
            <SelectParameters>
                <asp:QueryStringParameter Name="alias" QueryStringField="id" />
               
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True"
            SelectCommand="Select Nume from Categorii WHERE Id=@alias">
            <SelectParameters>
                <asp:QueryStringParameter Name="alias" QueryStringField="id" />
               
            </SelectParameters>
    </asp:SqlDataSource>
    <div class="ordonari" align = "center">
    <asp:Button style="margin-right: 50px;" class="but" ID="Button1" runat="server" Text="ORDONEAZA DUPA DATA" OnClick="Ordoneaza_data"/>
    <asp:Button style="margin-right: 50px;" class="but" ID="Button2" runat="server" Text="ORDONEAZA ALFABETIC" OnClick="Ordoneaza_alfabetic"/>
    <asp:Button class="but" ID="Button3" runat="server" Visible="false" Text="STERGE CATEGORIE" OnClick="Sterge_Categorie"/>
    </div>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <HeaderTemplate>
            <h1 style="text-align:center;">Stiri din <asp:Repeater id="ceva" DataSourceID="SqlDataSource2" runat="server">
                 <ItemTemplate><%# DataBinder.Eval(Container.DataItem, "Nume")%></ItemTemplate>
                           </asp:Repeater></h1>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="blocul" >
                <asp:Image CssClass="poza" ID="Image1" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Cale").ToString()%>' />
           <div class="continut">
                 <h3 id="titlu"><%# DataBinder.Eval(Container.DataItem, "Titlu")%></h3>
           
            
           
            <p><%# DataBinder.Eval(Container.DataItem, "Descriere")%></p>
            <p>Adaugat de: <%# DataBinder.Eval(Container.DataItem, "Username")%> </p>
            <p><%# DataBinder.Eval(Container.DataItem, "Data_Publicare")%> </p>
            
                <asp:HyperLink runat="server" NavigateUrl='<%# "~/Vizualizare_Stire.aspx?id=" + DataBinder.Eval(Container.DataItem, "Id")%>'>
                    <input class="but" type="button" value="Afla mai multe...">
                </asp:HyperLink>
                
               </div>
                </div>
        </ItemTemplate>
        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>
    </asp:Repeater>
    

</asp:Content>

