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

   
}
