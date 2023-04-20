using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        string password = txtPassword.Text;

        if (username == "admin" && password == "password123")
        {
            Session["authenticated"] = true;
            Response.Redirect("Home.aspx");
        }
        else
        {
            lblError.Text = "Invalid username or password";
        }
    }
}

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["authenticated"] != null && (bool)Session["authenticated"])
        {
            // User is authenticated, show sensitive information
            lblWelcome.Text = "Welcome, admin! Here's the top secret information: ...";
        }
        else
        {
            // User is not authenticated, redirect to login page
            Response.Redirect("Login.aspx");
        }
    }
}
