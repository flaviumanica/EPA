using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Afis_Categ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null && Session["role"].ToString() == "Admin")
        {
            Button3.Visible = true;
        }
    }
    protected void Ordoneaza_data(object sender, EventArgs e)
    {
       
            string query = Server.UrlDecode(Request.Params["id"]);
            
            SqlDataSource1.SelectCommand = "Select a.Id,Titlu,Descriere,Username, Data_Publicare, b.Nume, Cale FROM Articol a, Categorii b,[User] c,Imagine d WHERE a.Categorie=b.Id AND a.Id_User=c.Id AND b.Id=@query AND d.Id_Articol=a.Id Order by Data_Publicare desc";
            
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("query", query);
            SqlDataSource1.DataBind();     
    }

    protected void Ordoneaza_alfabetic(object sender, EventArgs e)
    {

        string query = Server.UrlDecode(Request.Params["id"]);


        SqlDataSource1.SelectCommand = "Select a.Id,Titlu,Descriere,Username, Data_Publicare, b.Nume, Cale FROM Articol a, Categorii b,[User] c,Imagine d WHERE a.Categorie=b.Id AND a.Id_User=c.Id AND b.Id=@query AND d.Id_Articol=a.Id Order by Titlu ";

        SqlDataSource1.SelectParameters.Clear();
        SqlDataSource1.SelectParameters.Add("query", query);
        SqlDataSource1.DataBind();

    }
    protected void Sterge_Categorie(object sender, EventArgs e)
    {
        //string id_categorie = Server.UrlDecode(Request.Params["id"]);
        try
        {
            int id_categorie = int.Parse(Request.Params["id"].ToString());
            //selectez toate categoriile
            string query_select = "SELECT Id FROM [Articol] WHERE Categorie = @id_categorie";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand(query_select, con);
            com.Parameters.AddWithValue("id_categorie", id_categorie);
            SqlDataReader reader = com.ExecuteReader();

            //sterg imaginile, comentariile unui articol si articolul
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
            con1.Open();
            while (reader.Read())
            {
                int id_articol = int.Parse(reader["Id"].ToString());

                string query = "DELETE FROM [Imagine]  WHERE Id_Articol = @id";
                string query1 = "DELETE FROM [Comentarii]  WHERE Id_Articol = @id";
                string query2 = "DELETE FROM [Articol]  WHERE Id = @id";
                SqlCommand com3 = new SqlCommand(query, con1);
                SqlCommand com1 = new SqlCommand(query1, con1);
                SqlCommand com2 = new SqlCommand(query2, con1);
                com3.Parameters.AddWithValue("id", id_articol);
                com3.ExecuteNonQuery();
                com1.Parameters.AddWithValue("id", id_articol);
                com1.ExecuteNonQuery();
                com2.Parameters.AddWithValue("id", id_articol);
                com2.ExecuteNonQuery();
            }
            reader.Close();
            con.Close();
            //stergere stiri propuse din categoria de sters
            string query_stiri_propuse = "DELETE FROM [Stiri_Propuse]  WHERE Categorie_Propunere = @id";
            SqlCommand com5 = new SqlCommand(query_stiri_propuse, con1);
            com5.Parameters.AddWithValue("id", id_categorie);
            com5.ExecuteNonQuery();

            //stergere categorie
            string query_categorii = "DELETE FROM [Categorii]  WHERE Id = @id";
            SqlCommand com4 = new SqlCommand(query_categorii, con1);
            com4.Parameters.AddWithValue("id", id_categorie);
            com4.ExecuteNonQuery();
            con1.Close();
        }
        catch (Exception se)
        {
            Mesaj.Text = "Database connexion error : " + se.Message;
        }
        finally
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}