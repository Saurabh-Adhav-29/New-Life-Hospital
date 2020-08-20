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
    public partial class Patient_Dashboard : Form
    {
        public Patient_Dashboard()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hp = new HomePage();
            hp.Show();
        }

        private void ourDoctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Our_Doctors od = new Our_Doctors();
            od.Show();
        }

        private void Patient_Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
