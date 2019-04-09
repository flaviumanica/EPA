<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Utilizatori.aspx.cs" Inherits="Utilizatori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="Stylesheet" href="/Utilizatori.css" type="text/css" />
    <div class="filtru" align="center">

        <asp:Label class="Label" ID="Label_Utilizator" runat="server" Text="CAUTA UTILIZATOR: "></asp:Label>
        <asp:TextBox class="Text" ID="Text_User" CommandName="User" runat="server"></asp:TextBox> 
        <asp:Button class="but" ID="Buton_Utilizator" runat="server" Text="CAUTA" OnClick ="Cauta_Utilizator"/>
    </div>
    <br /> <br />
    <div align ="center" style="margin-bottom:10px;">
        <asp:HyperLink  ID="HyperLink6" runat="server" NavigateUrl="~/Cei_Mai_Activi_Useri.aspx">
           <%-- <asp:Button style="padding:10px;" class="but" ID="Button1" runat="server" Text="Vezi utilizatori activi"/>--%>
            <input style="padding:10px;" type="button" class="but" runat="server" value="Vezi utilizatori activi" />
        </asp:HyperLink>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" 
            runat="server"
            ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True" 
            SelectCommand="SELECT a.Id,Nume, Prenume, Email,Tip  FROM [User] a, [Roles] b, [UserInRoles] c WHERE  a.Id=c.Id_User and c.Id_Role=b.Id ORDER BY Nume "></asp:SqlDataSource>
   <!--<asp:GridView ID="GridView1" runat="server" CellPadding="3" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="Nume" HeaderText="Name" SortExpression="N" />
                    <asp:BoundField DataField="Prenume" HeaderText="Surname" SortExpression="S" />
                    <asp:BoundField DataField="Tip" HeaderText="Rol" SortExpression="e" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="e" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>-->
    <asp:Repeater ID="Repeater1" runat="server" 
          DataSourceID="SqlDataSource1">
          <HeaderTemplate>
              <table class="tot">
              <tr>
                 <th class="cap">NUME </th>
                 <th class="cap">PRENUME </th>
                 <th class="cap">EMAIL </th>
                 <th class="cap">TIP UTILIZATOR </th>
              </tr>
          </HeaderTemplate>

          <ItemTemplate>
          <tr>
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
                  <asp:Label runat="server" ID="Label4" 
                      text='<%# Eval("Tip") %>' />
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


