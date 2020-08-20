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
using System.Data.Sql;

namespace New_Life_Hospital
{
    public partial class Patient_list : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JOCHJR\SQLEXPRESS;Initial Catalog=New_Life_Hospital;Integrated Security=True");
        SqlDataAdapter da;
        

        public Patient_list()
        {
            InitializeComponent();
            DGdata();
        }
        private void Patient_list_Load(object sender, EventArgs e)
        {
            
        }

        public void DGdata()
        {
            con.Open();
            da = new SqlDataAdapter("select * from patient_inf order by PatID desc", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Make_Appointment ma = new Make_Appointment();

            ma.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            
            ma.ShowDialog();
            //AutoGenerateID();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Dashboard ad = new Admin_Dashboard();
            ad.Show();
        }

        private void ourDoctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_Group pg = new Patient_Group();
            pg.Show();
        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        }

        private void transactionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Our_Doctors od = new Our_Doctors();
            od.Show();
        }

        /*  public void AutoGenerateID()
          {
              string cliid;
              string query = "select PatID from patient_inf order by PatID Desc";
              con.Open();
              SqlCommand cmd = new SqlCommand(query, con);
              SqlDataReader dr = cmd.ExecuteReader();

              if (dr.Read())
              {
                  int id = int.Parse(dr[0].ToString()) + 1;
                  cliid = id.ToString("000");
              }
              else if (Convert.IsDBNull(dr))
              {
                  cliid = ("001");
              }
              else
              {
                  cliid = ("001");
              }
              con.Close();

              textBox1.Text = cliid.ToString();
          }*/
    }
}
