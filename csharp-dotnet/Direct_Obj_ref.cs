// Home.aspx.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Orders WHERE CustomerID=" + Request.QueryString["id"];
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                lblOrderDetails.Text += "<p>Order ID: " + reader["OrderID"] + ", Customer ID: " + reader["CustomerID"] + ", Product Name: " + reader["ProductName"] + "</p>";
            }
        }
    }
}