<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Vizualizare_Stiri_Propuse.aspx.cs" Inherits="Vizualizare_Stiri_Propuse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="Stylesheet" href="/Viz_Stire.css" type="text/css" />
    <asp:Panel>
        <asp:Literal ID="Mesaj" runat="server"></asp:Literal>
        
        
    <asp:SqlDataSource ID="Articole" 
            runat="server"
            ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True" 
            SelectCommand="select a.Id, Titlu_propunere, Continut_propunere, Username, Data_propunere, c.Nume,Imagine_propunere from [Stiri_Propuse] a, [User] b,[Categorii] c where b.Id=a.User_propunere and a.Categorie_propunere=c.Id"></asp:SqlDataSource> 
        <asp:Panel Visible="false" runat="server" id="pnl" class="rezumat">
        <h3 style="text-align:center;">Rezumat</h3>
        <asp:Label ID="Label1" runat="server" Text="Label"  > </asp:Label>
        </asp:Panel>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="Articole">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="stire" >
                <asp:Image CssClass="img" ID="Image1" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Imagine_propunere").ToString()%>' />
               <div class="continut">
                 <h3 id="titlu"><%# DataBinder.Eval(Container.DataItem, "Titlu_propunere")%></h3>
                   <p><%# DataBinder.Eval(Container.DataItem, "Continut_propunere")%></p>
                  
                   <p>Adaugat de: <%# DataBinder.Eval(Container.DataItem, "Username").ToString()%></p>
                   <p>Categoria: <%# DataBinder.Eval(Container.DataItem, "Nume").ToString()%></p>
                   <p>Data publicarii: <%# DataBinder.Eval(Container.DataItem, "Data_propunere").ToString().Substring(0,10)%></p>

                   
                        <%--<asp:Panel Visible="false" runat="server">
                       <asp:Label id="inp" type="text" runat="server"></asp:Label>
                   </asp:Panel>--%>
                </div>
            </div>
        </ItemTemplate>

    </asp:Repeater>
        </div>

</asp:Content>

