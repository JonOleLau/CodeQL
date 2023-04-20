// AccountSettings.aspx.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AccountSettings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.HttpMethod == "POST")
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];

            // Update account settings here
            // ...

            lblResult.Text = "Account settings updated successfully.";
        }
    }
}