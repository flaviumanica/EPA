using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Vizualizare_Stiri_Propuse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("~/Acces.aspx");
        }
        else
        {
            if (Session["role"].ToString() == "User") 
            {
                Response.Redirect("~/Acces.aspx");
            }
        }
        //if (Session["user"] != null)
        //    if (Session["role"].ToString() == "Editor")
        //    {
        //        Button1.Visible = true;
        //        Button2.Visible = true;
        //    }
    }
    protected void Sterge_Stire_Propusa(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        int id_stire_propusa = int.Parse(btn.CommandArgument);
        try
        {
            string query = "DELETE FROM [Stiri_Propuse]  WHERE Id = @id";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("id", id_stire_propusa);
            com.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/Vizualizare_Stiri_Propuse.aspx");
        }
        catch (Exception se)
        {
            Mesaj.Text = "Database connexion error : " + se.Message;
        }
    }

    protected void Cauta_Dupa_User(object sender, EventArgs e)
    {
        //string query = Server.UrlDecode(Request.Params["id"]);
        string autor = Text_Stiri_Dupa_User.Text;
        Mesaj.Text = "";
        Articole.SelectCommand = "select a.Id, Titlu_propunere, Continut_propunere, Username, Data_propunere, c.Nume,Imagine_propunere from [Stiri_Propuse] a, [User] b,[Categorii] c where b.Id=a.User_propunere and a.Categorie_propunere=c.Id and b.Username = @user";

        Articole.SelectParameters.Clear();
        Articole.SelectParameters.Add("user", autor);
        Articole.DataBind();
        Text_Stiri_Dupa_User.Text = "";
        pnl.Visible = false;

        //string dataCautare = Text_Data.Text;   
    }

    protected void Rezumat(object sender, EventArgs e)
    {
        pnl.Visible = true;
        Button btn = (Button)sender;
        string continut = btn.CommandArgument.ToString();
        //string scr = "<script>alert('" + continut + "'); </script>";
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", scr);
        Label1.Text = Text_Rank.TextRank.get_summary(continut);
    }
}

