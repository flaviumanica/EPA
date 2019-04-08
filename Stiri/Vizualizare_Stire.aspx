<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Vizualizare_Stire.aspx.cs" Inherits="Vizualizare_Stire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="Stylesheet" href="/Viz_Stire.css" type="text/css" />
    <div class="stire">
    <asp:Literal ID="Mesaj" runat="server"></asp:Literal>
    
    <asp:Label class="titlu" ID="Titlu" runat="server" ></asp:Label>
    <br />
    <asp:Image class="img" ID="Image1" runat="server" />
    <br />
        <div class="continut">
    <asp:Label ID="Continut" runat="server" ></asp:Label>
    <br /><br /><br /><br />
    <asp:Label ID="Data" runat="server" Text="Din: "></asp:Label>
    <br /><br />
    <asp:Label style="text-decoration:underline" ID="User" runat="server" Text="Adaugat de "></asp:Label>
    <br />
    <br />
    <div align="center">
</div>
    </div>
    </div> 
            
     
     <asp:SqlDataSource ID="SqlDataSource1" 
            runat="server"
            ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True" 
            SelectCommand="SELECT a.Id com, c.Id, Text, Username, Data FROM [Comentarii] a, [User] b, Articol c WHERE @alias=a.Id_Articol AND a.Id_User=b.Id AND a.Id_Articol=c.Id order by data desc">
         <SelectParameters>
                <asp:QueryStringParameter Name="alias" QueryStringField="id" />
         </SelectParameters>
     </asp:SqlDataSource>
     <asp:Repeater ID="Repeater1" runat="server" 
          DataSourceID="SqlDataSource1">
          <HeaderTemplate>
              <h5>Comentarii:</h5>
          </HeaderTemplate>
          <ItemTemplate>
              <br />
          <div class="coment" align="center"> 
          <div class="coment-content">
                <asp:Label runat="server" ID="Label1" 
                    text='<%# Eval("Text") %>' />
           </div>  
              <br />
           <div class="coment-content">
               Adaugat de:
                  <asp:Label runat="server" ID="Label2" 
                      text='<%# Eval("Username") %>' />
           </div > 
              <br/>
           <div class="coment-content">
                  <asp:Label runat="server" ID="Label3" 
                      text='<%# Eval("Data") %>' />
           </div> 
           <div class="coment-content" align="center"> 
               <%if (Session["user"] != null && Session["id"] != null && Session["role"].ToString() == "Admin") { %>
                <asp:Button class="but" ID="Button3" style="margin-top:2%; margin-bottom:2%; padding:7px;" runat="server" CommandArgument= '<%# Eval("com") %>' Text="STERGE" OnClick="Sterge_Comentariu" /> <% } %>   
           </div>
           </div>
           <br /><br />
          </ItemTemplate>
        </asp:Repeater>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        

</asp:Content>

