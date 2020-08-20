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
    public partial class Admin_Dashboard : Form
    {
        public Admin_Dashboard()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Total_Appointments ta = new Total_Appointments();
            ta.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Admin_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hp = new HomePage();
            hp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Clinic_Info aci = new Add_Clinic_Info();
            aci.Show();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
           
            Add_Appointment_details aai = new Add_Appointment_details();
            aai.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_Registration hp = new Patient_Registration();
            hp.Show();
        }

        private void clinicInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_list pl = new Patient_list();
            pl.Show();
        }

        private void ourDoctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_Group pg = new Patient_Group();
            pg.Show();
        }

        private void transactionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Our_Doctors od = new Our_Doctors();
            od.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hp = new HomePage();
            hp.Show();
        }
    }
}
