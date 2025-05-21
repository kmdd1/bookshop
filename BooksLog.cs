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
    public partial class BooksLog : Form
    {
        public BooksLog()
        {
            InitializeComponent();
            this.Load += new EventHandler(BooksLog_Load);

        }

        private string connectionString = "server=localhost;user=root;password=khrysteldapa12;database=bookshopdb;";

        private void BooksLog_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM audit_log";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading audit log: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: handle cell click events if needed
        }
    }
}
