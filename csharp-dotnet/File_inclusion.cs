// Default.aspx.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string filename = Request.QueryString["file"];

        if (string.IsNullOrEmpty(filename))
        {
            lblFileContents.Text = "Please specify a file to read.";
            return;
        }

        string filepath = Server.MapPath(filename);

        if (!File.Exists(filepath))
        {
            lblFileContents.Text = "The specified file does not exist.";
            return;
        }

        if (!Path.IsPathRooted(filepath))
        {
            lblFileContents.Text = "The specified file path is not absolute.";
            return;
        }

        string fileContents = File.ReadAllText(filepath);

        lblFileContents.Text = fileContents;
    }
}