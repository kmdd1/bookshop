using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace bookshop
{
    public partial class EditBooks : Form
    {
        private Books booksControl;
        private int bookId;
        private string connectionString = "server=localhost;user=root;password=khrysteldapa12;database=bookshopdb;";

        public EditBooks(int bookId, Books books)
        {
            InitializeComponent();
            this.bookId = bookId;
            this.booksControl = books;
        }

        private void EditBooks_Load(object sender, EventArgs e)
        {
            LoadGenres();
            LoadPublishers();
            LoadBookData();
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

        private void LoadBookData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM books WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", bookId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TitleBox.Text = reader["title"].ToString();
                            AuthorBox.Text = reader["author"].ToString();
                            PriceBox.Text = reader["price"].ToString();
                            QuantityBox.Text = reader["stock_quantity"].ToString();
                            cbGenre.SelectedValue = reader["genre_id"];
                            cbPublisher.SelectedValue = reader["publisher_id"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading book data: " + ex.Message);
                }
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
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
                    string query = @"UPDATE books 
                                     SET title = @title, author = @author,
                                         genre_id = @genre_id, publisher_id = @publisher_id,
                                         price = @price, stock_quantity = @quantity
                                     WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@author", author);
                    cmd.Parameters.AddWithValue("@genre_id", genreId);
                    cmd.Parameters.AddWithValue("@publisher_id", publisherId);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@id", bookId);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Book updated successfully!");
                        booksControl?.LoadBooksData();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No changes made or update failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {

        }
    }
}

