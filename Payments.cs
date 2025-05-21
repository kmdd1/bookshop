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
    public partial class Payments : UserControl
    {
        private string connectionString = "server=localhost;user=root;password=khrysteldapa12;database=bookshopdb;";

        public Payments()
        {
            InitializeComponent();
            LoadPaymentsData();
        }

        public void LoadPaymentsData()
        {
            string query = @"
               SELECT 
            payments.id AS `Payment ID`,
            payments.order_id AS `Order ID`,
            payments.amount AS `Amount Paid`,
            payments.payment_date AS `Payment Date`,
            statuses.status_name AS `Status`
            FROM 
                payments
            JOIN
                statuses ON payments.status_id = statuses.id";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    // Hide Order ID column if you want it internal
                    if (dataGridView1.Columns.Contains("Order ID"))
                        dataGridView1.Columns["Order ID"].Visible = true;

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
                    MessageBox.Show("Error loading payments: " + ex.Message);
                }
            }
        }

        private void DeletePayment(string paymentId)
        {
            string query = "DELETE FROM payments WHERE id = @paymentId";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@paymentId", paymentId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting payment: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get Payment ID from the clicked row
                string paymentId = dataGridView1.Rows[e.RowIndex].Cells["Payment ID"].Value.ToString();

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    // TODO: Implement edit functionality here
                    MessageBox.Show("Edit functionality not yet implemented.");
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this payment?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DeletePayment(paymentId);
                        LoadPaymentsData(); // Refresh after deletion
                    }
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

        private void label1_Click_1(object sender, EventArgs e)
        {
            Books booksControl = new Books();
            booksControl.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(booksControl);
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}