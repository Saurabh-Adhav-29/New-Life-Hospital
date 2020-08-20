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
    public partial class Past_Appointments : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JOCHJR\SQLEXPRESS;Initial Catalog=New_Life_Hospital;Integrated Security=True");
        SqlDataAdapter da;
        public Past_Appointments()
        {
            InitializeComponent();
            past_date();
        }

        private void Add_Appintment_info_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void past_date()
        {
          
           // var date_now = DateTime.Today;
           

            con.Open();
            //current_date=Select GetDate();

            da = new SqlDataAdapter("select * from appointment_info where appt_date <= DATEADD(D,-1,GETDATE()) ", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void Past_Appointments_Load(object sender, EventArgs e)
        {

        }
    }
}
