using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace New_Life_Hospital
{
    public partial class Our_Doctors : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JOCHJR\SQLEXPRESS;Initial Catalog=New_Life_Hospital;Integrated Security=True");
        SqlDataAdapter da;
        public Our_Doctors()
        {
            InitializeComponent();
        }

        private void Our_Doctors_Load(object sender, EventArgs e)
        {
            Our_Doctors1();
        }
        public void Our_Doctors1()
        {
            con.Open();
            da = new SqlDataAdapter("select doc_Id_No,firstname,lastname,city,state,clinicid from doctor_info ;", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hp = new HomePage();
            hp.Show();
        }

        private void ourDoctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_Group pg = new Patient_Group();
            pg.Show();
        }

        private void clinicInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_list pl = new Patient_list();
            pl.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Total_Appointments ta = new Total_Appointments();
            ta.Show();
        }
    }
}
