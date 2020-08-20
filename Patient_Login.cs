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
    public partial class Patient_Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JOCHJR\SQLEXPRESS;Initial Catalog=New_Life_Hospital;Integrated Security=True");

        public Patient_Login()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter("select * from patient_inf where PatID='" + textBox1.Text + "' and password='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                this.Hide();
                Patient_Dashboard pd = new Patient_Dashboard();
                pd.Show();
            }
            else
            {
                MessageBox.Show("ID Number and Password is Incorrect...");
            }

            con.Close();
        }
    }
}
