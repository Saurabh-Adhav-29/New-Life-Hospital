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
    public partial class Add_Clinic_Info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JOCHJR\SQLEXPRESS;Initial Catalog=New_Life_Hospital;Integrated Security=True");

        public Add_Clinic_Info()
        {
            InitializeComponent();
        }

        private void Add_Clinic_Info_Load(object sender, EventArgs e)
        {
            AutoGenerateID();
        }


        public void AutoGenerateID()
        {
            string cliid;
            string query = "select clinic_id from clinic_details order by clinic_id Desc";
            con.Open();
            SqlCommand cmd = new SqlCommand(query,con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                cliid = id.ToString("0000");
            }
            else if (Convert.IsDBNull(dr))
            {
                cliid = ("0001");
            }
            else
            {
                cliid = ("0001");
            }
            con.Close();

            textBox1.Text = cliid.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Dashboard Ad = new Admin_Dashboard();
            Ad.Show();
        }


        public void InsertData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO clinic_details VALUES (@clinic_id, @clinic_name, @city, @state)", con);

            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@clinic_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@clinic_name", textBox3.Text);
            cmd.Parameters.AddWithValue("@city", textBox4.Text);
            cmd.Parameters.AddWithValue("@state", textBox2.Text);

            
            cmd.ExecuteNonQuery();
            MessageBox.Show("Clinic Data Save Successfully...");
            con.Close();

           

        }

        public void ClearData()
        {
            con.Open();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            con.Close();
        }


        private void Submit_Click(object sender, EventArgs e)
        {
            InsertData();
            ClearData();
            AutoGenerateID();
        }
    }
}
