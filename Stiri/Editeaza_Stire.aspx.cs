using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Editeaza_Stire : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user"] == null)
        {
            Response.Redirect("~/Acces.aspx");
        }
        else
        {
            if (Session["role"].ToString() != "Editor")
            {
                Response.Redirect("~/Acces.aspx");
            }
        }
        if (Page.IsPostBack == false && Request.Params["id"] != null)
        {
            //Mesaj.Text = Request.Params["id"];
            try
            {
                int ID = int.Parse(Request.Params["id"].ToString());
                string query = "SELECT b.Id, Titlu, Continut,Descriere,Data_Publicare, Username,Link  FROM [Articol] b , [User] a WHERE  b.id_user = a.Id  and b.Id = @id";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
                con.Open();
                try
                {
                    SqlCommand com = new SqlCommand(query, con);
                    com.Parameters.AddWithValue("id", ID);
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {

                        Titlu.Text = reader["Titlu"].ToString();
                        Descriere.Text = reader["Descriere"].ToString();
                        User.Text += reader["Username"].ToString();
                        Data.Text += reader["Data_Publicare"].ToString().Substring(0,10);
                        Continut.Text = reader["Continut"].ToString();
                        Link.Text = reader["Link"].ToString();
                    }
                }

                catch (Exception ex)
                {
                    Succes.Text = "Database select error : " + ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception se)
            {
                Succes.Text = "Database connexion error : " + se.Message;
            }
        }
    }

    protected void validare(object sender, ServerValidateEventArgs e)
    {
        if (Continut.Text.Length + Link.Text.Length > 0)
            e.IsValid = true;
        else
            e.IsValid = false;
    }
     protected void Salvare(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
        con.Open();
        string ID = Request.Params["id"];
        string titlu = Titlu.Text;
        string continut = Continut.Text;
        string descriere = Descriere.Text;
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string link = Link.Text;
        int user = Int32.Parse(Session["id"].ToString());
        string query = "UPDATE [Articol] SET  Titlu = @titlu, Continut = @continut, Data_Publicare = @data, Descriere=@descriere, Link=@link"
                      + " WHERE Id = @id";
        SqlCommand com = new SqlCommand(query, con);
        com.Parameters.AddWithValue("titlu", titlu);
        com.Parameters.AddWithValue("continut", continut);
        com.Parameters.AddWithValue("descriere", descriere);
        com.Parameters.AddWithValue("data", date);
        com.Parameters.AddWithValue("link", link);
        com.Parameters.AddWithValue("user", user);
        com.Parameters.AddWithValue("id", ID);
        com.ExecuteNonQuery();
        con.Close();

        Response.Redirect("~/Home.aspx");

    }
}