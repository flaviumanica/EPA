using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Cauta_Dupa_Data(object sender, EventArgs e)
    {
        //string query = Server.UrlDecode(Request.Params["id"]);
        DateTime dataCautare;
        if(DateTime.TryParse(Text_Data.Text, out dataCautare))
        {
            Mesaj.Text = "";
            Articole.SelectCommand = "select b.Id, Titlu, Descriere, Username, Data_publicare, Cale from [Imagine] c,[Articol] b , [User] a where b.id_user = a.Id and b.Id = c.Id_Articol and convert(datetime, convert(varchar(10), Data_Publicare, 102))  = convert(datetime, @data)";

            Articole.SelectParameters.Clear();
            Articole.SelectParameters.Add("data", dataCautare.ToString());
            Articole.DataBind();
            Text_Data.Text = "";
        }
    else
        {
            Mesaj.Text = "Introdu o data valida!";
        }

            //string dataCautare = Text_Data.Text;   
    }

    protected void Cauta_Dupa_Autor(object sender, EventArgs e)
    {
        //string query = Server.UrlDecode(Request.Params["id"]);
        string autor = Text_Dupa_Autor.Text;
        Mesaj.Text = "";
        Articole.SelectCommand = "SELECT b.Id, Titlu, Descriere, Username, Data_publicare, Cale FROM [Imagine] c,[Articol] b , [User] a WHERE b.id_user = a.Id AND b.Id = c.Id_Articol AND a.Username = @user";

        Articole.SelectParameters.Clear();
        Articole.SelectParameters.Add("user", autor);
        Articole.DataBind();
        Text_Dupa_Autor.Text = "";

        //string dataCautare = Text_Data.Text;   
    }
}
