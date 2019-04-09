using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Modifica_tip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false && Request.Params["id"] != null)
        {
            //Mesaj.Text = Request.Params["id"];
            try
            {
                int ID = int.Parse(Request.Params["id"].ToString());
                string query = "SELECT a.Id, Nume, Prenume, Email, Tip  FROM [User] a, [Roles] b, [UserInRoles] c WHERE  a.Id=c.Id_User and c.Id_Role=b.Id and a.Id = @id";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
                con.Open();
                try
                {
                    SqlCommand com = new SqlCommand(query, con);
                    com.Parameters.AddWithValue("id", ID);
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {

                        NUME.Text = reader["Nume"].ToString();
                        PRENUME.Text = reader["Prenume"].ToString();
                        EMAIL.Text = reader["Email"].ToString();
                        TIP.Text = reader["Tip"].ToString();
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
    protected void Salveaza_Modificari(object sender, EventArgs e)
    {
        if (Page.IsValid && Request.Params["id"] != null)
        {
            try
            {
                int ID = int.Parse(Request.Params["id"].ToString());

                int IDTip = int.Parse(DDL.SelectedValue);
                string query = "UPDATE UserInRoles SET Id_Role = @id_tip WHERE Id_User = @id_user";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
                con.Open();
                try
                {
                    SqlCommand com = new SqlCommand(query, con);
                    com.Parameters.AddWithValue("id_tip", IDTip);
                    com.Parameters.AddWithValue("id_user", ID);
                    com.ExecuteNonQuery();
                    Response.Redirect("~/Utilizatori.aspx");
                }
                catch (Exception ex)
                {
                    Mesaj.Text = "Database update error : " + ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }
            catch (SqlException se)
            {
                Mesaj.Text = "Database connexion error : " + se.Message;
            }
            catch (Exception ex)
            {
                Mesaj.Text = "Data conversion error : " + ex.Message;
            }
        }
        }
}