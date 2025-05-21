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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadCounts();
            LoadOrders();
            LoadPayments();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Books booksControl = new Books();
            booksControl.Dock = DockStyle.Fill;

            mainpanel.Controls.Clear();
            mainpanel.Controls.Add(booksControl);
        }

        private string connectionString = "server=localhost;user=root;password=khrysteldapa12;database=bookshopdb;";

        private void LoadCounts()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Total books
                    MySqlCommand cmd3 = new MySqlCommand("SELECT COUNT(*) FROM books", conn);
                    books.Text = cmd3.ExecuteScalar().ToString();

                    // Total customers
                    MySqlCommand cmd1 = new MySqlCommand("SELECT COUNT(*) FROM customers", conn);
                    customers.Text = cmd1.ExecuteScalar().ToString();

                    // Total orders
                    MySqlCommand cmd2 = new MySqlCommand("SELECT COUNT(*) FROM orders", conn);
                    orders.Text = cmd2.ExecuteScalar().ToString();

                    // Total revenue from payments
                    MySqlCommand cmd4 = new MySqlCommand("SELECT SUM(amount) FROM payments", conn);
                    object result = cmd4.ExecuteScalar();
                    payments.Text = result != DBNull.Value ? Convert.ToDecimal(result).ToString("C") : "₱0.00";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading counts: " + ex.Message);
                }
            }
        }

        private void LoadOrders()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    o.id AS OrderID, 
                    CONCAT(c.first_name, ' ', c.last_name) AS CustomerName,
                    o.order_date, 
                    o.total_amount, 
                    os.status_name AS OrderStatus,
                    ps.status_name AS PaymentStatus
                FROM orders o
                JOIN customers c ON o.customer_id = c.id
                JOIN statuses os ON o.order_status_id = os.id
                JOIN statuses ps ON o.payment_status_id = ps.id
                ";


                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading orders: " + ex.Message);
                }
            }
        }

        private void LoadPayments()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    p.id AS PaymentID, 
                    o.id AS OrderID, 
                    p.payment_date, 
                    p.amount, 
                    s.status_name AS PaymentStatus
                FROM payments p
                JOIN orders o ON p.order_id = o.id
                JOIN statuses s ON p.status_id = s.id";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading payments: " + ex.Message);
                }
            }
        }



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void books_TextChanged(object sender, EventArgs e)
        {

        }

        private void customers_TextChanged(object sender, EventArgs e)
        {

        }

        private void orders_TextChanged(object sender, EventArgs e)
        {

        }

        private void payments_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Orders orderControl = new Orders();
            orderControl.Dock = DockStyle.Fill;

            mainpanel.Controls.Clear();
            mainpanel.Controls.Add(orderControl);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Payments paymentControl = new Payments();
            paymentControl.Dock = DockStyle.Fill;

            mainpanel.Controls.Clear();
            mainpanel.Controls.Add(paymentControl);
        }
    }
}
