<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Utilizatori.aspx.cs" Inherits="Utilizatori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="Stylesheet" href="/Utilizatori.css" type="text/css" />

    

    <h1>Utilizatori activi</h1>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" 
            runat="server"
            ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True" 
            SelectCommand="set rowcount 5 
                           Select COUNT(*) NR, Username, Nume, Prenume, u.Id,Email
                           from Stiri_Propuse a, [User] u 
                           where a.User_propunere = u.Id 
                           group by Username,Nume, Prenume,u.Id,Email
                           order by Count(*) desc">
    </asp:SqlDataSource>
    <asp:Repeater ID="Repeater1" runat="server" 
          DataSourceID="SqlDataSource1">
          <HeaderTemplate>
              <table class="tot">
              <tr>
                 <th class="cap">Stiri propuse</th>
                 <th class="cap">Nume utilizator </th>
                 <th class="cap">Nume </th>
                 <th class="cap">Prenume </th>
                 <th class="cap">Email </th>                
              </tr>
          </HeaderTemplate>

          <ItemTemplate>
          <tr>
              <td class="unu">
                <asp:Label  runat="server" ID="Label6" 
                    text='<%# Eval("NR") %>' />
              </td>
              <td class="unu">
                <asp:Label  runat="server" ID="Label5" 
                    text='<%# Eval("Username") %>' />
              </td>
              <td class="unu">
                <asp:Label  runat="server" ID="Label1" 
                    text='<%# Eval("Nume") %>' />
              </td>
              <td class="unu">
                  <asp:Label runat="server" ID="Label2" 
                      text='<%# Eval("Prenume") %>' />
              </td>
              <td class="unu">
                  <asp:Label runat="server" ID="Label3" 
                      text='<%# Eval("Email") %>' />
              </td>
              <td class="unu">
                  <asp:HyperLink class="hip" runat="server" NavigateUrl='<%# "~/Modifica_tip.aspx?id=" + DataBinder.Eval(Container.DataItem, "Id")%>'>
               <%--<input class="but" type="button" value="MODIFICA DREPTURI" />--%>
                MODIFICA DREPTURI </asp:HyperLink>
              </td>
          </tr>
          </ItemTemplate>
        </asp:Repeater>
        <asp:Literal ID="Mesaj" runat="server"></asp:Literal>
    
</asp:Content>

