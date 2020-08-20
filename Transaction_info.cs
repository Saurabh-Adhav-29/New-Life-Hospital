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
    public partial class Transaction_info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JOCHJR\SQLEXPRESS;Initial Catalog=New_Life_Hospital;Integrated Security=True");
        public Transaction_info()
        {
            InitializeComponent();
            AutoGenerateID();
            fillcombo();
        }

        private void Transaction_info_Load(object sender, EventArgs e)
        {
            AutoGenerateID();
            fillcombo();
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
                cliid = id.ToString("0000000");
            }
            else if (Convert.IsDBNull(dr))
            {
                cliid = ("0000001");
            }
            else
            {
                cliid = ("0000001");
            }
            con.Close();

            textBox1.Text = cliid.ToString();
        }

        public void InsertData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO transaction_info VALUES (@trans_id, @PatID, @procedure_type, @procedure_date, @amount, @clinic_id, @provider_name)", con);

            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@trans_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@PatID", textBox3.Text);
            cmd.Parameters.AddWithValue("@procedure_type", comboBox1.Text);
            cmd.Parameters.AddWithValue("@procedure_date", Convert.ToDateTime(dateTimePicker1.Text));

            cmd.Parameters.AddWithValue("@amount", textBox5.Text);
            cmd.Parameters.AddWithValue("@clinic_id", comboBox1.Text);
            cmd.Parameters.AddWithValue("@provider_name", textBox7.Text);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Transaction Done Successfully...");
            con.Close();

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Total_Appointments ta = new Total_Appointments();
            ta.Show();
        }
    }
}
