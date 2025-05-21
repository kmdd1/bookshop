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
    public partial class Customers : UserControl
    {
        private string connectionString = "server=localhost;user=root;password=khrysteldapa12;database=bookshopdb;";

        public Customers()
        {
            InitializeComponent();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

            this.Load += Customers_Load;
        }

        public void LoadCustomerNameView()
        {
           
            string query = @"
            SELECT 
                id, 
                CONCAT(first_name, ' ', last_name) AS name, 
                email, 
                phone_number AS phone, 
                address 
            FROM customers";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    // Remove old button columns first
                    if (dataGridView1.Columns.Contains("Edit"))
                        dataGridView1.Columns.Remove("Edit");
                    if (dataGridView1.Columns.Contains("Delete"))
                        dataGridView1.Columns.Remove("Delete");

                    // Now add button columns again
                    DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                    editButton.Name = "Edit";
                    editButton.HeaderText = "Edit";
                    editButton.Text = "Edit";
                    editButton.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(editButton);

                    DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                    deleteButton.Name = "Delete";
                    deleteButton.HeaderText = "Delete";
                    deleteButton.Text = "Delete";
                    deleteButton.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(deleteButton);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading customers: " + ex.Message);
                }
            }
        }

        private void DeleteCustomer(string customerId)
        {
            string query = "DELETE FROM customers WHERE id = @customerId"; // Use the correct column name here

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Customer deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting customer: " + ex.Message);
                }
            }
        }


        private void Customers_Load(object sender, EventArgs e)
        {
            LoadCustomerNameView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells["id"].Value;

                if (cellValue == null || string.IsNullOrEmpty(cellValue.ToString()))
                {
                    // Probably clicked on the "new row" or an invalid row, so just ignore
                    return;
                }

                string customerIdString = cellValue.ToString();

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    int customerId = int.Parse(customerIdString);
                    EditUser editForm = new EditUser(customerId);
                    editForm.ShowDialog();
                    LoadCustomerNameView();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DeleteCustomer(customerIdString);
                        LoadCustomerNameView();
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

        private void label5_Click(object sender, EventArgs e)
        {
            Orders ordersControl = new Orders();
            ordersControl.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(ordersControl);
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

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser adduserForm = new AddUser();
            adduserForm.ShowDialog();
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
    }
}