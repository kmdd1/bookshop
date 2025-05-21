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

        public void LoadBooksData(string searchText = "")
        {
            string query = @"
        SELECT 
            books.id, 
            books.title, 
            books.author, 
            genres.genre_name AS genre, 
            publishers.publisher_name AS publisher, 
            books.price, 
            books.stock_quantity,
            book_availability_status(books.id) AS availability_status
        FROM 
            books
        JOIN 
            genres ON books.genre_id = genres.id
        JOIN 
            publishers ON books.publisher_id = publishers.id
        WHERE 
            books.title LIKE @search OR 
            books.author LIKE @search OR 
            genres.genre_name LIKE @search OR 
            publishers.publisher_name LIKE @search";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    // Optional: Rename column header
                    if (dataGridView1.Columns.Contains("availability_status"))
                    {
                        dataGridView1.Columns["availability_status"].HeaderText = "Availability";
                    }

                    // Avoid adding duplicate buttons
                    if (!dataGridView1.Columns.Contains("Edit"))
                    {
                        DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                        editButton.HeaderText = "Edit";
                        editButton.Text = "Edit";
                        editButton.UseColumnTextForButtonValue = true;
                        editButton.Name = "Edit";
                        dataGridView1.Columns.Add(editButton);
                    }

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
            Customers customersControl = new Customers();
            customersControl.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(customersControl);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Genre genresControl = new Genre();
            genresControl.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(genresControl);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Books booksControl = new Books();
            booksControl.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(booksControl);
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
            SignIn dashboardForm = new SignIn();
            dashboardForm.Show();

            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Hide();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Orders orderControl = new Orders();
            orderControl.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(orderControl);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            BooksLog archiveForm = new BooksLog();
            archiveForm.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            try
            {
                // Initialize Excel application
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                var workbook = excelApp.Workbooks.Add(Type.Missing);
                var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Book Report";

                int colIndex = 0;

                // Add column headers
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i].Visible && dataGridView1.Columns[i].Name != "Edit" && dataGridView1.Columns[i].Name != "Delete")
                    {
                        colIndex++;
                        worksheet.Cells[1, colIndex] = dataGridView1.Columns[i].HeaderText;
                    }
                }

                // Add data rows
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Columns[j].Visible && dataGridView1.Columns[j].Name != "Edit" && dataGridView1.Columns[j].Name != "Delete")
                        {
                            colIndex++;
                            object value = dataGridView1.Rows[i].Cells[j].Value;
                            worksheet.Cells[i + 2, colIndex] = value?.ToString() ?? "";
                        }
                    }
                }

                // Enable AutoFilter and AutoFit columns
                Microsoft.Office.Interop.Excel.Range usedRange = worksheet.UsedRange;
                usedRange.AutoFilter(1);
                usedRange.Columns.AutoFit();

                // Show Excel
                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export failed: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBooksData(txtSearch.Text.Trim());
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadBooksData(txtSearch.Text.Trim());
        }

    }
}