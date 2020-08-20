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
    public partial class Add_Appointment_details : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JOCHJR\SQLEXPRESS;Initial Catalog=New_Life_Hospital;Integrated Security=True");
        public Add_Appointment_details()
        {
            
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        public void InsertData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO add_appointment_detail VALUES (@appointment_time_add)", con);

            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@appointment_time_add",textBox1.Text);
            


            cmd.ExecuteNonQuery();
            MessageBox.Show("Appointment Time Add Successfully...");
            con.Close();

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            InsertData();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Dashboard ad = new Admin_Dashboard();
            ad.Show();
           
        }
    }
}
