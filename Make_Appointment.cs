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
    public partial class Make_Appointment : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JOCHJR\SQLEXPRESS;Initial Catalog=New_Life_Hospital;Integrated Security=True");
        public Make_Appointment()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            InsertData();
            AutoGenerateID();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public void AutoGenerateID()
        {
            string cliid;
            string query = "select appt_id from appointment_info order by appt_id Desc";
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

            textBox3.Text = cliid.ToString();
        }

        public void InsertData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO appointment_info VALUES (@PatID, @appt_id, @appt_date, @appt_time, @appt_length, @clinic_id, @amount)", con);

            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@PatID", textBox1.Text);
            cmd.Parameters.AddWithValue("@appt_id", textBox3.Text);
            cmd.Parameters.AddWithValue("@appt_date", Convert.ToDateTime(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@appt_time", comboBox2.Text);

            cmd.Parameters.AddWithValue("@appt_length", textBox5.Text);
            cmd.Parameters.AddWithValue("@clinic_id", comboBox1.Text);
            cmd.Parameters.AddWithValue("@amount", textBox7.Text);
            

            cmd.ExecuteNonQuery();
            MessageBox.Show("Appointment Book Successfully...");
            con.Close();

        }

        private void Make_Appointment_Load(object sender, EventArgs e)
        {
            AutoGenerateID();
            fillcombo();
            fillcombo1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_list pl = new Patient_list();
            pl.Show();
        }



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


        public void fillcombo1()
        {
            comboBox2.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select add_appointment_time from add_appointment_detail";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["add_appointment_time"].ToString());
            }
            con.Close();
        }

    }
}
