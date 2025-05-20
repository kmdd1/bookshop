using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bookshop
{
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private Books booksControl;

        public AddBooks(Books books)
        {
            InitializeComponent();
            booksControl = books;
        }

        private string connectionString = "server=localhost;user=root;password=khrysteldapa12;database=bookshopdb;";

        private void AddBooks_Load(object sender, EventArgs e)
        {
            LoadGenres();
            LoadPublishers();
        }

        private void LoadGenres()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT id, genre_name FROM genres", conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbGenre.DataSource = dt;
                    cbGenre.DisplayMember = "genre_name";
                    cbGenre.ValueMember = "id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading genres: " + ex.Message);
                }
            }
        }

        private void LoadPublishers()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT id, publisher_name FROM publishers", conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbPublisher.DataSource = dt;
                    cbPublisher.DisplayMember = "publisher_name";
                    cbPublisher.ValueMember = "id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading publishers: " + ex.Message);
                }
            }
        }


        private void TitleBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string title = TitleBox.Text.Trim();
            string author = AuthorBox.Text.Trim();
            decimal price = Convert.ToDecimal(PriceBox.Text.Trim());
            int quantity = Convert.ToInt32(QuantityBox.Text.Trim());
            int genreId = Convert.ToInt32(cbGenre.SelectedValue);
            int publisherId = Convert.ToInt32(cbPublisher.SelectedValue);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO books (title, author, genre_id, publisher_id, price, stock_quantity) 
                             VALUES (@title, @author,
                                     @genre_id, @publisher_id, @price, @quantity)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@author", author);
                    cmd.Parameters.AddWithValue("@genre_id", genreId);
                    cmd.Parameters.AddWithValue("@publisher_id", publisherId);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@quantity", quantity);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Book added successfully!");
                        booksControl?.LoadBooksData();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Failed to add book.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ClearFields()
        {
            TitleBox.Clear();
            AuthorBox.Clear();
            PriceBox.Clear();
            QuantityBox.Clear();
            cbGenre.SelectedIndex = 0;
            cbPublisher.SelectedIndex = 0;
        }

    }
}
