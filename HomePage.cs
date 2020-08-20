using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Life_Hospital
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Doctor_Registration login = new Doctor_Registration();
            login.Show();

           
        }

        private void Patient_Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_Dashboard pd = new Patient_Dashboard();
            pd.Show();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            
        }

        private void Admin_login_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
