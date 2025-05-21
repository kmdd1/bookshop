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
    public partial class Genre : UserControl
    {
        public Genre()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Genre_Load);

        }

        private void Genre_Load(object sender, EventArgs e)
        {
            LoadGenres();
        }

        private void LoadGenres()
        {
            string connectionString = "server=localhost;user=root;password=khrysteldapa12;database=bookshopdb;";
            string query = "SELECT id, genre_name FROM genres";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading genres: " + ex.Message);
                }
            }
        }


        private void updateprice_Click(object sender, EventArgs e)
        {
            GenrePrice addGenreForm = new GenrePrice();
            if (addGenreForm.ShowDialog() == DialogResult.OK)
            {
                LoadGenres();
            }
        }

        private void addgenre_Click(object sender, EventArgs e)
        {
            AddGenre addGenreForm = new AddGenre();
            if (addGenreForm.ShowDialog() == DialogResult.OK)
            {
                LoadGenres(); 
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Books booksControl = new Books();
            booksControl.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(booksControl);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Orders orderControl = new Orders();
            orderControl.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(orderControl);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Customers customersControl = new Customers();
            customersControl.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(customersControl);
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

        private void label2_Click(object sender, EventArgs e)
        {
            Genre genresControl = new Genre();
            genresControl.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(genresControl);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Payments paymentsControl = new Payments();
            paymentsControl.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(paymentsControl);
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
