using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Vizualizare_Stiri_Propuse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("~/Acces.aspx");
        }
        else
        {
            if (Session["role"].ToString() == "User") 
            {
                Response.Redirect("~/Acces.aspx");
            }
        }
        //if (Session["user"] != null)
        //    if (Session["role"].ToString() == "Editor")
        //    {
        //        Button1.Visible = true;
        //        Button2.Visible = true;
        //    }
    }
    
    
    protected void Rezumat(object sender, EventArgs e)
    {
        pnl.Visible = true;
        Button btn = (Button)sender;
        string continut = btn.CommandArgument.ToString();
        //string scr = "<script>alert('" + continut + "'); </script>";
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", scr);
        Label1.Text = Text_Rank.TextRank.get_summary(continut);
    }
}

