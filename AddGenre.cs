using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bookshop
{
    public partial class AddGenre : Form
    {
        public AddGenre()
        {
            InitializeComponent();
        }

        private void genre_TextChanged(object sender, EventArgs e)
        {

        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            string genreName = genre.Text.Trim();

            if (string.IsNullOrEmpty(genreName))
            {
                MessageBox.Show("Please enter a genre name.");
                return;
            }

            string connectionString = "server=localhost;user=root;password=khrysteldapa12;database=bookshopdb;";
            string query = "INSERT INTO genres (genre_name) VALUES (@genre_name)";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@genre_name", genreName);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Genre added successfully!");
                    this.DialogResult = DialogResult.OK;  // Notify parent form to refresh
                    this.Close(); // Close the AddGenre form
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding genre: " + ex.Message);
                }
            }
        }

    }
}
