using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Utilizatori : System.Web.UI.Page
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

    protected void Cauta_Utilizator(object sender, EventArgs e)
    {
        //String autor = Text_User.Text;
        TextBox t1 = this.FindControlRecursive("Text_User") as TextBox;
        String autor = t1.Text;
        SqlDataSource1.SelectCommand = "SELECT a.Id,Nume, Prenume, Email,Tip  FROM [User] a, [Roles] b, [UserInRoles] c WHERE  a.Id=c.Id_User and c.Id_Role=b.Id and (a.Username = @user or a.Nume = @user or a.Prenume= @user)";
        SqlDataSource1.SelectParameters.Clear();
        SqlDataSource1.SelectParameters.Add("user", autor);
        SqlDataSource1.DataBind();
        //Text_Utiliz.Text = "";
        
    }
}
public static class ControlExtensions
{
    /// <summary>
    /// recursively finds a child control of the specified parent.
    /// </summary>
    /// <param name="control"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Control FindControlRecursive(this Control control, string id)
    {
        if (control == null) return null;
        //try to find the control at the current level
        Control ctrl = control.FindControl(id);

        if (ctrl == null)
        {
            //search the children
            foreach (Control child in control.Controls)
            {
                ctrl = FindControlRecursive(child, id);

                if (ctrl != null) break;
            }
        }
        return ctrl;
    }
}
