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
    public partial class Total_Appointments : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JOCHJR\SQLEXPRESS;Initial Catalog=New_Life_Hospital;Integrated Security=True");
        SqlDataAdapter da;
        public Total_Appointments()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            Appointment_by_clinic abc = new Appointment_by_clinic();
            abc.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Delete_50_amount();
            appointment_info();
        }
        public void Delete_50_amount()
        {
            con.Open();
            da = new SqlDataAdapter("Delete  from appointment_info where amount<=400 ;", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Total_Appointments_Load(object sender, EventArgs e)
        {
            appointment_info();
        }
        public void appointment_info()
        {
            con.Open();
            da = new SqlDataAdapter("select * from appointment_info order by appt_id desc ", con);
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
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

        private void button2_Click(object sender, EventArgs e)
        {
            
            Past_Appointments pa = new Past_Appointments();
            pa.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Transaction_info ti = new Transaction_info();

            ti.textBox3.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

            ti.ShowDialog();
        }

        private void transactionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Total_Transactions ta = new Total_Transactions();
            ta.Show();
        }
    }
}
