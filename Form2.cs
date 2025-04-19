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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form3 BooksForm = new Form3();
            BooksForm.Show();

            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form3 BooksForm = new Form3();
            BooksForm.Show();

            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form2 DashboardForm = new Form2();
            DashboardForm.Show();

            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form2 DashboardForm = new Form2();
            DashboardForm.Show();

            this.Hide();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 LoginForm = new Form1();
            LoginForm.Show();

            this.Hide();
        }
    }
}
