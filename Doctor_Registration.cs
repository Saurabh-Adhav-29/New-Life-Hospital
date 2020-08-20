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
    public partial class Doctor_Registration : Form
    {
      
        public Doctor_Registration()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JOCHJR\SQLEXPRESS;Initial Catalog=New_Life_Hospital;Integrated Security=True");

        public void fillcombo()
        {
            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select clinic_id from clinic_details";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["clinic_id"].ToString());
            }
            con.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            Doctor_login lg = new Doctor_login();
            lg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hp = new HomePage();
            hp.Show();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            InsertData();
            ClearData();
            AutoGenerateID();
        }

        public void AutoGenerateID()
        {
            string cliid;
            string query = "select doc_Id_No from doctor_info order by doc_Id_No Desc";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                cliid = id.ToString("0");
            }
            else if (Convert.IsDBNull(dr))
            {
                cliid = ("1");
            }
            else
            {
                cliid = ("1");
            }
            con.Close();

            textBox1.Text = cliid.ToString();
        }
        public void InsertData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO doctor_info VALUES (@doc_Id_No, @firstname, @lastname,@city, @state, @clinicid, @password)", con);

            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@doc_Id_No", textBox1.Text);
            cmd.Parameters.AddWithValue("@firstname", textBox3.Text);
            cmd.Parameters.AddWithValue("@lastname", textBox4.Text);
            cmd.Parameters.AddWithValue("@city", textBox5.Text);
            cmd.Parameters.AddWithValue("@state", textBox6.Text);
            cmd.Parameters.AddWithValue("@clinicid", comboBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Doctor Registration Successfully...");
            con.Close();



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
            comboBox1.Items.Clear();
            con.Close();
        }

        private void Doctor_Registration_Load(object sender, EventArgs e)
        {
            AutoGenerateID();
            fillcombo();
        }
    }
}
