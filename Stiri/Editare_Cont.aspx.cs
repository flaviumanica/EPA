using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace Stiri
{
    public partial class Editare_Cont : System.Web.UI.Page
    {
        int userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["id"] != null)
            {
                userId = Int32.Parse(Session["id"].ToString());

                if(!Page.IsPostBack)
                {
                    Load_UserDetails();
                }
            }
            else
            {
                Response.Redirect("~/Acces.aspx");
            }
        }

        protected void Load_UserDetails()
        {
            string query_select = "SELECT * FROM [User] WHERE Id = @id_user";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand(query_select, con);
            com.Parameters.AddWithValue("id_user", userId);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                UserName.Text = dt.Rows[0]["Username"].ToString();
                Nume.Text = dt.Rows[0]["Nume"].ToString();
                Prenume.Text = dt.Rows[0]["Prenume"].ToString();

                DateTime date = DateTime.Parse(dt.Rows[0]["Data_Nasterii"].ToString());
                Data.Text = date.ToString("yyyy-MM-dd");

                Email.Text = dt.Rows[0]["Email"].ToString();
                Password.Text = string.Empty;
                ConfirmPassword.Text = string.Empty;
            }

            con.Close();
        }

        protected void Editeaza_user(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
                con.Open();
                try
                {
                    string nume = Nume.Text;
                    string prenume = Prenume.Text;
                    string email = Email.Text;
                    string user = UserName.Text;
                    string parola_clar = Password.Text;
                    string parola = Criptare(parola_clar);
                    string dataNasterii = Data.Text;
                  
                    //Debug.WriteLine(nume + " " + prenume + " " + dataNasterii + " " + dataInregistrare + " " + user + " " + parola);

                    string query = "SELECT * FROM [User] WHERE Username = @username and Id != @user_id";

                    SqlCommand com = new SqlCommand(query, con);
                    com.Parameters.AddWithValue("username", user);
                    com.Parameters.AddWithValue("user_id", userId);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);

                    bool exista = false;

                    if(dt.Rows.Count > 0)
                    {
                        exista = true;
                    }

                    /*SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        exista = true;
                    }
                    reader.Close();*/

                    con.Close();

                    if (exista)
                    {
                        Mesaj.Text = "Username deja existent !";
                        UserName.Text = "";
                    }

                    else
                    {
                        //update daca user-ul nu exista deja
                        query = "update [User] set Nume=@nume, Prenume=@prenume, Data_Nasterii=@dataNasterii, Email=@email, Username=@username where Id=@userId";

                        if(!string.IsNullOrEmpty(Password.Text))
                        {
                            query += ", Parola=@parola";
                        }

                        con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
                        con.Open();
                        com = new SqlCommand(query, con);
                        com.Parameters.AddWithValue("nume", nume);
                        com.Parameters.AddWithValue("prenume", prenume);
                        com.Parameters.AddWithValue("dataNasterii", dataNasterii);
                        com.Parameters.AddWithValue("email", email);
                        com.Parameters.AddWithValue("username", user);
                        com.Parameters.AddWithValue("userId", userId);

                        if (!string.IsNullOrEmpty(Password.Text))
                        {
                            com.Parameters.AddWithValue("parola", parola);
                        }

                        com.ExecuteNonQuery();
                        con.Close();

                        Response.Redirect("~/Home.aspx");
                    }
                }
                catch (Exception ex)
                {
                    Mesaj.Text = "Database insert error : " + ex.Message;
                }
                finally
                {
                    con.Close();
                }


            }
        }

        internal static string Criptare(string text)
        {
            if (String.IsNullOrEmpty(text))
                return String.Empty;

            using (var sha = new SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }
    }
}