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
    public partial class Doctor_Dashboard : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JOCHJR\SQLEXPRESS;Initial Catalog=New_Life_Hospital;Integrated Security=True");
        SqlDataAdapter da;
        public Doctor_Dashboard()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hp = new HomePage();
            hp.Show();
        }

        private void Doctor_Dashboard_Load(object sender, EventArgs e)
        {
            Today_appointment();
        }

        public void Today_appointment()
        {
            con.Open();
            da = new SqlDataAdapter("select * from appointment_info", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void ourDoctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Our_Doctors od = new Our_Doctors();
            od.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
