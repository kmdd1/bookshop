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
    public partial class Orders : UserControl
    {
        private string connectionString = "server=localhost;user=root;password=khrysteldapa12;database=bookshopdb;";

        public Orders()
        {
            InitializeComponent();
            LoadOrdersData();
        }

        public void LoadOrdersData()
        {
            string query = @"
                SELECT 
                    order_items.order_id AS `Order ID`,
                    order_items.book_id AS book_id,           -- Hidden column for internal use
                    books.title AS `Book Title`,
                    order_items.quantity AS `Quantity`,
                    books.price AS `Unit Price`,
                    (order_items.quantity * books.price) AS `Total Amount`
                FROM 
                    order_items
                JOIN 
                    books ON order_items.book_id = books.id
                JOIN 
                    orders ON order_items.order_id = orders.id";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    // Hide book_id column (for internal tracking)
                    if (dataGridView1.Columns.Contains("book_id"))
                    {
                        dataGridView1.Columns["book_id"].Visible = false;
                    }

                    // Add Edit button if not exists
                    if (!dataGridView1.Columns.Contains("Edit"))
                    {
                        DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                        editButton.HeaderText = "Edit";
                        editButton.Text = "Edit";
                        editButton.UseColumnTextForButtonValue = true;
                        editButton.Name = "Edit";
                        dataGridView1.Columns.Add(editButton);
                    }

                    // Add Delete button if not exists
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
                    MessageBox.Show("Error loading orders: " + ex.Message);
                }
            }
        }

        private void DeleteOrderItem(string orderId, string bookId)
        {
            string query = "DELETE FROM order_items WHERE order_id = @orderId AND book_id = @bookId";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    cmd.Parameters.AddWithValue("@bookId", bookId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting order item: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get order_id and book_id from the current row
                string orderId = dataGridView1.Rows[e.RowIndex].Cells["Order ID"].Value.ToString();
                string bookId = dataGridView1.Rows[e.RowIndex].Cells["book_id"].Value.ToString();

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this order item?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DeleteOrderItem(orderId, bookId);
                        LoadOrdersData(); // Refresh after deletion
                    }
                }
            }
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.Show();

            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Hide();
            }
        }

        private void Orders_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Books booksControl = new Books();
            booksControl.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(booksControl);

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Payments paymentsControl = new Payments();
            paymentsControl.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(paymentsControl);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bookpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}