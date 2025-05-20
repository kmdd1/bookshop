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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Dashboard DashboardForm = new Dashboard();
            DashboardForm.Show();

            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Dashboard DashboardForm = new Dashboard();
            DashboardForm.Show();

            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            SignIn LoginForm = new SignIn();
            LoginForm.Show();

            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SignIn LoginForm = new SignIn();
            LoginForm.Show();

            this.Hide();
        }
    }
}
