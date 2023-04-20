using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyApp
{
    public class VulnerableApp : Form
    {
        private Label usernameLabel;
        private TextBox usernameTextBox;
        private Button submitButton;
        private TextBox outputTextBox;

        public VulnerableApp()
        {
            usernameLabel = new Label();
            usernameLabel.Text = "Enter a username:";
            usernameLabel.Location = new System.Drawing.Point(10, 10);
            this.Controls.Add(usernameLabel);

            usernameTextBox = new TextBox();
            usernameTextBox.Location = new System.Drawing.Point(120, 10);
            this.Controls.Add(usernameTextBox);

            submitButton = new Button();
            submitButton.Text = "Submit";
            submitButton.Location = new System.Drawing.Point(250, 10);
            submitButton.Click += new EventHandler(submitButton_Click);
            this.Controls.Add(submitButton);

            outputTextBox = new TextBox();
            outputTextBox.Multiline = true;
            outputTextBox.Height = 100;
            outputTextBox.Width = 300;
            outputTextBox.Location = new System.Drawing.Point(10, 50);
            this.Controls.Add(outputTextBox);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string userInput = usernameTextBox.Text;

            string connectionString = "Server=myServer;Database=myDb;User Id=myUsername;Password=myPassword;";
            string query = $"SELECT * FROM users WHERE username='{userInput}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            outputTextBox.AppendText($"{reader["username"]}: {reader["email"]}" + Environment.NewLine);
                        }
                    }
                }
            }
        }

        static void Main()
        {
            Application.Run(new VulnerableApp());
        }
    }
}
