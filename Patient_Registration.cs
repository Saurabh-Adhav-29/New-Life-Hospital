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
    public partial class Patient_Registration : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JOCHJR\SQLEXPRESS;Initial Catalog=New_Life_Hospital;Integrated Security=True");
        public Patient_Registration()
        {
            InitializeComponent();
        }

        private void Patient_Registration_Load(object sender, EventArgs e)
        {
            AutoGenerateID();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Dashboard hp = new Admin_Dashboard();
            hp.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Patient_Login pl = new Patient_Login();
            pl.Show();
        }

        public void AutoGenerateID()
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
        }

        public void InsertData()
        {
            con.Open();
             SqlCommand cmd = new SqlCommand("INSERT INTO patient_inf VALUES (@PatID, @firstname, @lastname, @city,@state, @gender, @patient_agreement, @age, @birthdate)", con);

            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@PatID", textBox1.Text);
            cmd.Parameters.AddWithValue("@firstname", textBox3.Text);
            cmd.Parameters.AddWithValue("@lastname", textBox4.Text);
            cmd.Parameters.AddWithValue("@city", textBox5.Text);

            cmd.Parameters.AddWithValue("@state", textBox6.Text);
            cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@patient_agreement", comboBox2.Text);
            cmd.Parameters.AddWithValue("@age", textBox2.Text);
            cmd.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(dateTimePicker1.Text));
          
            cmd.ExecuteNonQuery();
            MessageBox.Show("Patient Add Successfully...");
            con.Close();

           /* SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO patient_inf VALUES ('"+ textBox1.Text+ "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Text + "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Patient Registration Successfully...");
            con.Close();*/

        }

        public void ClearData()
        {
            con.Open();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
           
            con.Close();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            InsertData();
            ClearData();
            AutoGenerateID();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = dateTimePicker1.Value;
            DateTime to = DateTime.Now;
            TimeSpan Tsapn = to - from;
            double days = Tsapn.TotalDays;
            textBox2.Text = (days / 365).ToString("0");
        }
    }
}
