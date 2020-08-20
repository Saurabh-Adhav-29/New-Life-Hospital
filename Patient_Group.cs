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
    public partial class Patient_Group : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JOCHJR\SQLEXPRESS;Initial Catalog=New_Life_Hospital;Integrated Security=True");
        SqlDataAdapter da;
        public Patient_Group()
        {
            InitializeComponent();
            DGdata();
            DGdata1();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Make_Appointment ma = new Make_Appointment();

            ma.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

            ma.ShowDialog();
        }



        public void DGdata()
        {
            con.Open();
            da = new SqlDataAdapter("select PatID,firstname,lastname,age,gender from patient_inf where age < 18 order by PatID desc  ;", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void DGdata1()
        {
            con.Open();
            da = new SqlDataAdapter("select PatID,firstname,lastname,age,gender from patient_inf  where age >= 18 order by PatID desc ;", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Make_Appointment ma = new Make_Appointment();

            ma.textBox1.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();

            ma.ShowDialog();
        }

        private void Patient_Group_Load(object sender, EventArgs e)
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

        private void transactionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Our_Doctors od = new Our_Doctors();
            od.Show();
        }
    }
}
