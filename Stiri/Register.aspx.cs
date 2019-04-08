using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        dateValidator.ValueToCompare = DateTime.Today.ToString("dd/MM/yyyy");
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

    protected void Adauga_user(object sender, EventArgs e)
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
                string dataInregistrare = DateTime.Now.ToString("yyyy-MM-dd");

                //Debug.WriteLine(nume + " " + prenume + " " + dataNasterii + " " + dataInregistrare + " " + user + " " + parola);

                string query = "SELECT * FROM [User] WHERE Username = @username";

                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("username", user);

                SqlDataReader reader = com.ExecuteReader();

                bool exista = false;
                while (reader.Read())
                {
                    exista = true;
                }
                reader.Close();
               // com.Cancel();
                con.Close();

                if (exista)
                {
                    Mesaj.Text = "Username deja existent !";
                    UserName.Text = "";
                }

                else
                {
                    //inserare daca user-ul nu exista deja
                    query = "INSERT INTO [User] (Nume, Prenume, Data_Nasterii, Email, Data_Inregistrare, Username, Parola)"
                                  + " VALUES (@nume, @prenume, @dataNasterii, @email, @dataInregistrare, @username, @parola)";

                    con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Master\Sem. 2\ElemProgrAvansata\Proiect\Prezentare\Stiri\App_Data\Database.mdf';Integrated Security=True");
                    con.Open();
                    com = new SqlCommand(query, con);
                    com.Parameters.AddWithValue("nume", nume);
                    com.Parameters.AddWithValue("prenume", prenume);
                    com.Parameters.AddWithValue("dataNasterii", dataNasterii);
                    com.Parameters.AddWithValue("email", email);
                    com.Parameters.AddWithValue("dataInregistrare", dataInregistrare);
                    com.Parameters.AddWithValue("username", user);
                    com.Parameters.AddWithValue("parola", parola);
                    com.ExecuteNonQuery();

                    // Do this only if insert works:
                    //    Mesaj.Text = "User added successfully!";
                    string query1 = "SELECT * FROM [User] WHERE Username = @username";
                    SqlCommand com1 = new SqlCommand(query1, con);
                    com1.Parameters.AddWithValue("username", user);
                    SqlDataReader reader1 = com1.ExecuteReader();
                    string ids = "";
                    while (reader1.Read())
                        ids = reader1["Id"].ToString();
                    reader1.Close();
                    int idi = Int32.Parse(ids);
                    string query2 = "INSERT INTO [UserInRoles] (Id_User, Id_Role)"
                                  + " VALUES (@idi,1)";
                    SqlCommand com2 = new SqlCommand(query2, con);
                    com2.Parameters.AddWithValue("idi", idi);
                    com2.ExecuteNonQuery();
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
    
}