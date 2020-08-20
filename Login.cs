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
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JOCHJR\SQLEXPRESS;Initial Catalog=New_Life_Hospital;Integrated Security=True");
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            this.Hide();
            HomePage hp = new HomePage();
            hp.Show();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            HomePage hp = new HomePage();
            hp.Show();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter("select * from login where login_id='"+textBox1.Text+"' and password='"+textBox2.Text+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                this.Hide();
                Admin_Dashboard ad = new Admin_Dashboard();
                ad.Show();
            }
            else {
                MessageBox.Show("ID Number and Password is Incorrect...");
            }

            con.Close();
        }
    }
}
