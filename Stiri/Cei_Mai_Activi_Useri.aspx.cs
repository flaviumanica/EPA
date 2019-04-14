using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cei_Mai_Activi_Useri : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("~/Acces.aspx");
        }
        else
        {
            if (Session["role"].ToString() != "Admin")
            {
                Response.Redirect("~/Acces.aspx");
            }
        }
    }
}