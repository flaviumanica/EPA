using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Diagnostics;

public partial class Vizualizare_Stire : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user"] != null)
            if (/*Session["role"].ToString() == "Admin" || */Session["role"].ToString() == "Editor")
            {
                Button1.Visible = true;
                Button2.Visible = true;
            }
        if(Session["user"] != null && Session["id"] != null) 
        {
            Label1.Visible = true;
            Adauga_comm.Visible = true;
            Comm.Visible = true;
        }
        if (Session["user"] != null && Session["id"] != null && Session["role"].ToString() == "Admin")
        {
           // Button3.Visible = true;
        }
        if (Page.IsPostBack == false && Request.Params["id"] != null)
        {
            //Mesaj.Text = Request.Params["id"];
            try
            {
                int ID = int.Parse(Request.Params["id"].ToString());
                string query = "SELECT b.Id, Titlu, Continut, Data_Publicare,Username,Link,Cale  FROM [Articol] b , [User] a, [Imagine] c WHERE  b.id_user = a.Id and b.Id = c.Id_Articol  and b.Id = @id";
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
                        Data.Text += reader["Data_Publicare"].ToString();
                        User.Text += reader["Username"].ToString();
                        Image1.ImageUrl = reader["Cale"].ToString();
                        if (reader["Continut"].ToString().Length > 0)
                            Continut.Text = reader["Continut"].ToString();
                        else
                            Response.Redirect(reader["Link"].ToString());
                    }
                }

                catch (Exception ex)
                {
                    Mesaj.Text = "Database select error : " + ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception se)
            {
                Mesaj.Text = "Database connexion error : " + se.Message;
            }
        }

    }

    protected void Adauga_Comentariu(object sender, EventArgs e)
    {
        if(Comm.Text.Length > 0)
        {
            try
            {
                int ID = int.Parse(Request.Params["id"].ToString());
                string query = "INSERT INTO [Comentarii] (Text, Id_Articol, Id_User, Data) VALUES (@comentariu, @art, @usr, @Data)";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
                con.Open();
                string Data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string Com = Comm.Text;
                string usr = Session["id"].ToString();
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("comentariu", Com);
                com.Parameters.AddWithValue("art", ID);
                com.Parameters.AddWithValue("usr", Int32.Parse(usr));
                com.Parameters.AddWithValue("Data", Data);
                com.ExecuteNonQuery();
                con.Close();
                Response.Redirect("~/Vizualizare_Stire.aspx?id=" + Request.Params["id"]);
               
            }
            catch (Exception se)
            {
                Mesaj.Text = "Database connexion error : " + se.Message;
            }            
        }
     }
    protected void Editeaza(object sender, EventArgs e)
    {
        Response.Redirect("~/Editeaza_Stire.aspx?id=" + Request.Params["id"]);
        //Debug.WriteLine("aici " + Request.Params["id"]);
    }
    protected void Sterge_Articol(object sender, EventArgs e)
    {
        try
        {
            int ID = int.Parse(Request.Params["id"].ToString());
            string query = "DELETE FROM [Imagine]  WHERE Id_Articol = @id";
            string query1 = "DELETE FROM [Comentarii]  WHERE Id_Articol = @id";
            string query2 = "DELETE FROM [Articol]  WHERE Id = @id";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlCommand com1 = new SqlCommand(query1, con);
            SqlCommand com2 = new SqlCommand(query2, con);
            com.Parameters.AddWithValue("id", ID);
            com.ExecuteNonQuery();
            com1.Parameters.AddWithValue("id", ID);
            com1.ExecuteNonQuery();
            com2.Parameters.AddWithValue("id", ID);
            com2.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/Home.aspx");
        }
        catch (Exception se)
        {
            Mesaj.Text = "Database connexion error : " + se.Message;
        }
    }
    protected void Sterge_Comentariu(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        //Mesaj.Text = btn.CommandArgument.ToString();
        try
        {
            int ID = int.Parse(Request.Params["id"].ToString());
            int id_comentariu = int.Parse(btn.CommandArgument);
            string query = "DELETE FROM [Comentarii]  WHERE Id = @id";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("id", id_comentariu);
            com.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/Vizualizare_Stire.aspx?id=" + Request.Params["id"]);
        }
        catch (Exception se)
        {
            Mesaj.Text = "Database connexion error : " + se.Message;
        }
    }
    
}
