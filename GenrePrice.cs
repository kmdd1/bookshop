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
    public partial class GenrePrice : Form
    {
        public GenrePrice()
        {
            InitializeComponent();
        }

        private void GenrePrice_Load(object sender, EventArgs e)
        {

        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            decimal priceIncrease;
            int genreId;

            // Validate and parse inputs (assume you have TextBoxes: txtPriceIncrease and txtGenreId)
            if (!decimal.TryParse(txtPriceIncrease.Text, out priceIncrease))
            {
                MessageBox.Show("Please enter a valid price increase.");
                return;
            }

            if (!int.TryParse(txtGenreId.Text, out genreId))
            {
                MessageBox.Show("Please enter a valid genre ID.");
                return;
            }

            string connectionString = "server=localhost;user=root;password=khrysteldapa12;database=bookshopdb;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("UpdateBookPrice", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add input parameters
                        cmd.Parameters.AddWithValue("@priceIncrease", priceIncrease);
                        cmd.Parameters.AddWithValue("@genreInput", genreId);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Book prices updated successfully!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating prices: " + ex.Message);
                }
            }
        }
    }
}
