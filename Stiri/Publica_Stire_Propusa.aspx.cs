using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class Publica_Stire_Propusa : System.Web.UI.Page
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
                string query = "select a.Id, Titlu_propunere, Continut_propunere, Username, Data_propunere, c.Nume,Imagine_propunere from [Stiri_Propuse] a, [User] b,[Categorii] c where b.Id=a.User_propunere and a.Categorie_propunere=c.Id and a.Id=@id";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
                con.Open();
                try
                {
                    SqlCommand com = new SqlCommand(query, con);
                    com.Parameters.AddWithValue("id", ID);
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {

                        Titlu.Text = reader["Titlu_propunere"].ToString();
                        User.Text += reader["Username"].ToString();
                        Data.Text += reader["Data_propunere"].ToString().Substring(0, 10);
                        Continut.Text = reader["Continut_propunere"].ToString();
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
    protected void Salvare(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
        con.Open();
        string ID = Request.Params["id"];
        string titlu = Titlu.Text;
        string continut = Continut.Text;
        string descriere = Descriere.Text;
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string categorie = "";
        string imagine = "";
        int user = Int32.Parse(Session["id"].ToString());

        string query1 = "select Id, Titlu_propunere, Continut_propunere, User_propunere, Data_propunere,Imagine_propunere,Categorie_propunere from [Stiri_Propuse] where Id=@id";
        SqlCommand com1 = new SqlCommand(query1, con);
        com1.Parameters.AddWithValue("id", ID);
        SqlDataReader reader = com1.ExecuteReader();
        while (reader.Read())
                    {

                        categorie = reader["Categorie_propunere"].ToString();
                        imagine = reader["Imagine_propunere"].ToString(); 
                    }
        reader.Close();



        string query = "INSERT INTO [Articol] (Titlu, Continut, Id_User, Data_Publicare, Descriere, Categorie) " +
                       "VALUES (@titlu, @continut, @user, @data, @descriere, @categorie); SELECT CAST(scope_identity() AS int) ";
        SqlCommand com = new SqlCommand(query, con);
        com.Parameters.AddWithValue("titlu", titlu);
        com.Parameters.AddWithValue("continut", continut);
        com.Parameters.AddWithValue("descriere", descriere);
        com.Parameters.AddWithValue("data", date);
        com.Parameters.AddWithValue("user", user);
        com.Parameters.AddWithValue("categorie", categorie);
        int IDUL = (Int32)com.ExecuteScalar();
        string query2 = "INSERT INTO [Imagine] (Id_Articol, Cale) " +
                       "VALUES (@id_art, @cale)";
        SqlCommand com2 = new SqlCommand(query2, con);
        com2.Parameters.AddWithValue("id_art", IDUL);
        com2.Parameters.AddWithValue("cale", imagine);
        com2.ExecuteNonQuery();
        con.Close();

        Response.Redirect("~/Home.aspx");
    }
    protected void Genereaza_Descriere(object sender, EventArgs e)
    {
        string text = Continut.Text;
        Descriere.Text = Text_Rank.TextRank.get_summary(text);
    }
}