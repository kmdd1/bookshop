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
    public partial class BooksArchive : Form
    {
        public BooksArchive()
        {
            InitializeComponent();
        }

        private string connectionString = "server=localhost;user=root;password=khrysteldapa12;database=bookshopdb;";

        private void BooksArchive_Load(object sender, EventArgs e)
        {
            LoadArchivedBooks();

            if (!dataGridView1.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = "Delete";
                deleteButton.HeaderText = "Action";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(deleteButton);
            }

        }

        private void LoadArchivedBooks()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            ab.id, 
                            ab.title, 
                            ab.author, 
                            g.genre_name AS genre, 
                            p.publisher_name AS publisher, 
                            ab.price, 
                            ab.stock_quantity,
                            ab.archived_at
                        FROM 
                            archived_books ab
                        JOIN 
                            genres g ON ab.genre_id = g.id
                        JOIN 
                            publishers p ON ab.publisher_id = p.id";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading archived books: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();

                DialogResult confirm = MessageBox.Show("Delete this archived book permanently?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    DeleteArchivedBook(id);
                    LoadArchivedBooks();
                }
            }
        }

        private void DeleteArchivedBook(string id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM archived_books WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting archived book: " + ex.Message);
                }
            }
        }

    }
}
