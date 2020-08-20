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
    public partial class Appointment_by_clinic : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JOCHJR\SQLEXPRESS;Initial Catalog=New_Life_Hospital;Integrated Security=True");
        SqlDataAdapter da;
        public Appointment_by_clinic()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            FEVER();
        }
        public void FEVER()
        {
            con.Open();
            da = new SqlDataAdapter("select * from appointment_info where clinic_id= 001 order by PatID desc ", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Heart();
        }
        public void Heart()
        {
            con.Open();
            da = new SqlDataAdapter("select * from appointment_info where clinic_id= 002 order by PatID desc ", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Diabetes();
        }
        public void Diabetes()
        {
            con.Open();
            da = new SqlDataAdapter("select * from appointment_info where clinic_id= 003 order by PatID desc ", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Accident();
        }
        public void Accident()
        {
            con.Open();
            da = new SqlDataAdapter("select * from appointment_info where clinic_id= 004 order by PatID desc ", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Brain();
        }
        public void Brain()
        {
            con.Open();
            da = new SqlDataAdapter("select * from appointment_info where clinic_id= 005 order by PatID desc ", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Cancer();
        }
        public void Cancer()
        {
            con.Open();
            da = new SqlDataAdapter("select * from appointment_info where clinic_id= 006 order by PatID desc ", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Appointment_by_clinic_Load(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hp = new HomePage();
            hp.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Total_Appointments ta = new Total_Appointments();
            ta.Show();
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
    }
}
