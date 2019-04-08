using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cautare : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!Page.IsPostBack && Request.Params["q"] != null)
        {

           

            string query = Server.UrlDecode(Request.Params["q"]);
         
            if(query.Length > 0)
                Criteriu.Text = "Rezultatele cautarii: " + query;


            Articole.SelectCommand = "SELECT distinct [Articol].[Id],[Articol].[Titlu], [Articol].[Descriere],[Articol].[Data_Publicare],[Imagine].[Cale],  [User].[Username]"
                + " FROM [Articol],[User] ,[Imagine],[Categorii] "
                + " WHERE [Articol].[Id]=[Imagine].[Id_Articol] AND [Articol].[Id_User] = [User].[Id] AND [Articol].[Categorie] = [Categorii].[Id]"
                + " AND ([Articol].[Titlu] like @q OR [Articol].[Descriere] like @q OR [Categorii].[Nume] like @q) order by [Articol].[Titlu]";

		 Articole.SelectParameters.Clear();
            Articole.SelectParameters.Add("q", "%" + query + "%");
            Articole.DataBind();

       

        }
    
    }
}