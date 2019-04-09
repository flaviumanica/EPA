using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Diagnostics;

public partial class Posteaza_Stire : System.Web.UI.Page
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
    }

    protected void validare(object sender, ServerValidateEventArgs e)
    {
        if (Continut.Text.Length + Link.Text.Length > 0)
            e.IsValid = true;
        else
            e.IsValid = false;
    }
    protected void Posteaza(object sender, EventArgs e)
        {
            //Mesaj.Text = DropDownList1.SelectedValue;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
            con.Open();
            try
            {
                StiriDb context = new StiriDb();
                Repository rep = new Repository();

                string categorie;
                int ID_Categorie = 0;
                string titlu = Titlu.Text;
                string continut = Continut.Text;
                string descriere = Descriere.Text;
                string link = Link.Text;
                DateTime dataPublicare = DateTime.Now;
                User user = context.User.Find(Int32.Parse(Session["id"].ToString()));

                if (AdaugaCategorie.Text.Length > 0)//daca introduce categorie noua;
                {
                    //string queryCategorie = "INSERT INTO [Categorii] (Nume) VALUES (@categorie); SELECT CAST(scope_identity() AS int)";
                    //SqlCommand com1 = new SqlCommand(queryCategorie, con);
                    //com1.Parameters.AddWithValue("categorie", categorie);
                    //ID_Categorie = (Int32)com1.ExecuteScalar();

                    categorie = AdaugaCategorie.Text;
  
                    ID_Categorie = rep.AdaugareCategorie(context, categorie);
                }
                else
                {
                    ID_Categorie = Int32.Parse(DDL.SelectedValue);
                }

                int IDUL = rep.AdaugareArticol(context, ID_Categorie, titlu, continut, descriere, link, dataPublicare, user);
                //string link = Link.Text;
                //int user = Int32.Parse(Session["id"].ToString());
                //string query = "INSERT INTO [Articol] (Titlu, Continut, Id_User, Data_Publicare, Descriere, Categorie, Link) " +
                //               "VALUES (@titlu, @continut, @user, @date, @descriere, @categorie, @link); SELECT CAST(scope_identity() AS int) ";
                //SqlCommand com = new SqlCommand(query, con);
                //com.Parameters.AddWithValue("titlu", titlu);
                //com.Parameters.AddWithValue("continut", continut);
                //com.Parameters.AddWithValue("descriere", descriere);
                //com.Parameters.AddWithValue("date", date);
                //com.Parameters.AddWithValue("link", link);
                //com.Parameters.AddWithValue("user", user);
                //com.Parameters.AddWithValue("categorie", ID_Categorie);

                //int IDUL = (Int32)com.ExecuteScalar();
                //com.ExecuteNonQuery();
                //Mesaj.Text = "Id-ul este" + IDUL.ToString();


                if (Image.HasFile)
                {
                    if (Image.PostedFile.ContentType.ToLower().EndsWith("jpeg"))
                    {
                        //introduc imaginea in baza de date
                        string query1 = "INSERT INTO [Imagine] (Id_Articol, Cale) VALUES (@id_articol, @cale)";
                        SqlCommand com1 = new SqlCommand(query1, con);
                        com1.Parameters.AddWithValue("id_articol", IDUL);
                        com1.Parameters.AddWithValue("cale", "~/Images/" + IDUL.ToString() + ".jpg");
                        com1.ExecuteNonQuery();

                        //salvez dupa id.
                        Image.SaveAs(Server.MapPath("~") + "/Images/" + IDUL + ".jpg");
                    }
                    else
                        Mesaj.Text = "Imaginea nu este format jpg, formatul este: " + Image.PostedFile.ContentType.ToUpper();
                }
                else
                {
                    Mesaj.Text = "Nicio imagine incarcata!";
                }
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
                //Descriere.Text = " ";
                //AdaugaCategorie.Text = " ";
                //Link.Text = " ";
                Response.Redirect("~/Home.aspx");


            }


        }

    protected void Genereaza_Descriere(object sender, EventArgs e)
    {
        string text = Continut.Text;
        Descriere.Text = Text_Rank.TextRank.get_summary(text);
    }

}