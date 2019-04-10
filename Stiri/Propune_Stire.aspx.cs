using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class Propune_Stire : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("~/Acces.aspx");
        }
        
    }
    protected void Posteaza(object sender, EventArgs e)
    {
        //Mesaj.Text = DropDownList1.SelectedValue;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
        con.Open();
        try
        {
            string titlu = Titlu.Text;
            string continut = Continut.Text;
            string categorie = "";
            int ID_Categorie = 0;
            string sursa_img = null;

            if (AdaugaCategorie.Text.Length > 0)//daca introduce categorie noua;
            {
                categorie = AdaugaCategorie.Text;
                string queryCategorie = "INSERT INTO [Categorii] (Nume) VALUES (@categorie); SELECT CAST(scope_identity() AS int)";
                SqlCommand com1 = new SqlCommand(queryCategorie, con);
                com1.Parameters.AddWithValue("categorie", categorie);
                ID_Categorie = (Int32)com1.ExecuteScalar();
            }
            else
            {
                ID_Categorie = Int32.Parse(DDL.SelectedValue);
                
            }

 
            
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int user = Int32.Parse(Session["id"].ToString());
            string query = "INSERT INTO [Stiri_propuse] (Titlu_propunere, Continut_propunere, User_propunere, Data_propunere, Categorie_propunere, Imagine_propunere) "+
                           "VALUES (@titlu, @continut, @user, @date, @categorie, @img); SELECT CAST(scope_identity() AS int) ";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("titlu", titlu);
            com.Parameters.AddWithValue("continut", continut);
            com.Parameters.AddWithValue("date", date);
            com.Parameters.AddWithValue("user", user);
            com.Parameters.AddWithValue("categorie", ID_Categorie);
            if (Image.HasFile)
            {
                if (Image.PostedFile.ContentType.ToLower().EndsWith("jpeg") || Image.PostedFile.ContentType.ToLower().EndsWith("png"))
                {
                    //introduc imaginea in baza de date
                    Random random = new Random();
                    int rand = random.Next(0, 1000000000);
                    int rand1 = random.Next(0, 1000000000);
                    sursa_img = "~/Imagini_Stiri_Propuse/" + rand + rand1 + ".jpg";
                    

                    //salvez dupa id.
                    Image.SaveAs(Server.MapPath("~") + "/Imagini_Stiri_Propuse/" + rand + rand1 + ".jpg");
                }
                else
                    Mesaj.Text = "Image file is not in JPEG format! Format is: " + Image.PostedFile.ContentType.ToUpper();
            }
            else
            {
                Mesaj.Text = "No image file uploaded!";
            }
            com.Parameters.AddWithValue("img", sursa_img);

            //int IDUL = (Int32)com.ExecuteScalar();
            com.ExecuteNonQuery();
            //Mesaj.Text = "Id-ul este" + IDUL.ToString();

            
            
            con.Close();
        }
        catch (Exception ex)
        {
            Mesaj.Text = "Database insert error : " + ex.Message;
        }
        finally
        {
            con.Close();
            //Succes.Text = "Stire adaugata cu succes!!!";
            //Titlu.Text = " ";
            //Continut.Text = " ";
            //AdaugaCategorie.Text = " ";
            Response.Redirect("~/Home.aspx");


        }
    }
}