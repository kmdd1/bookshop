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
    public partial class Books : UserControl
    {
        private string connectionString = "server=localhost;user=root;password=khrysteldapa12;database=bookshopdb;";

        public Books()
        {
            InitializeComponent();
            LoadBooksData();
        }

        public void LoadBooksData()
        {
            string query = @"
        SELECT 
            books.id, 
            books.title, 
            books.author, 
            genres.genre_name AS genre, 
            publishers.publisher_name AS publisher, 
            books.price, 
            books.stock_quantity
        FROM 
            books
        JOIN 
            genres ON books.genre_id = genres.id
        JOIN 
            publishers ON books.publisher_id = publishers.id";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    // Add Edit Button
                    if (!dataGridView1.Columns.Contains("Edit"))
                    {
                        DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                        editButton.HeaderText = "Edit";
                        editButton.Text = "Edit";
                        editButton.UseColumnTextForButtonValue = true;
                        editButton.Name = "Edit";
                        dataGridView1.Columns.Add(editButton);
                    }

                    // Add Delete Button
                    if (!dataGridView1.Columns.Contains("Delete"))
                    {
                        DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                        deleteButton.HeaderText = "Delete";
                        deleteButton.Text = "Delete";
                        deleteButton.UseColumnTextForButtonValue = true;
                        deleteButton.Name = "Delete";
                        dataGridView1.Columns.Add(deleteButton);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }


        private void label8_Click(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.Show();

            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Hide();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddBooks addForm = new AddBooks(this);
            addForm.ShowDialog();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string bookIdString = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                int bookId = int.Parse(bookIdString); // convert to int

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    EditBooks editForm = new EditBooks(bookId, this);  // Pass the book ID and current form
                    editForm.ShowDialog(); // Use ShowDialog to make it modal
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DeleteBook(bookIdString);
                        LoadBooksData(); // Refresh the list
                    }
                }
            }
        }

        private void DeleteBook(string id)
        {
            string query = "DELETE FROM books WHERE id = @id";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting book: " + ex.Message);
                }
            }
        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            BooksArchive archiveForm = new BooksArchive();
            archiveForm.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bookpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Payments paymentControl = new Payments();
            paymentControl.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(paymentControl);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Orders orderControl = new Orders();
            orderControl.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(orderControl);
        }
    }
}