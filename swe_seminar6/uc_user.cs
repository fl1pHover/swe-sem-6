using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace swe_seminar6
{
    public partial class uc_user : UserControl
    {
        DataTable dt;
        int u_id;
        string db = "Data Source=DESKTOP-FSF2P1H;Initial Catalog=nw;Integrated Security=True";
        public uc_user()
        {
            InitializeComponent();

        }

        public uc_user(DataTable _dt)
        {
            InitializeComponent();
            dt = _dt;
        }

        protected override void OnLoad(EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(db);
            con.Open();
      
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE id='" + 1 + "'", con);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);


            lblUsername.Text = ds.Tables[0].Rows[0]["username"].ToString();
            lblPass.Text = ds.Tables[0].Rows[0]["password"].ToString();
            lblType.Text = ds.Tables[0].Rows[0]["id"].ToString();
            lblFirst.Text = ds.Tables[0].Rows[0]["firstname"].ToString();
            lblLast.Text = ds.Tables[0].Rows[0]["lastname"].ToString();
            lblRegister.Text = ds.Tables[0].Rows[0]["registerNumber"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0]["phone"].ToString();
            txtMail.Text = ds.Tables[0].Rows[0]["email"].ToString();



            base.OnLoad(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(db);
            con.Open();
            try
            {
                string query = "UPDATE Users SET address = '" + txtAddress.Text + "', phone ='" + txtPhone.Text + "', phone ='" + txtPhone.Text + "', email = '" + txtMail.Text + "'  WHERE id =" + u_id + " ";
                SqlCommand com = new SqlCommand(query, con);
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con;
                com.ExecuteNonQuery();
                MessageBox.Show("Амжилттай");
                string query2 = "SELECT * FROM Users WHERE id = " + u_id + "";
                SqlDataAdapter adap = new SqlDataAdapter(query2, con);
                DataSet ds = new DataSet();
                adap.Fill(ds);

                txtAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["phone"].ToString();
                txtMail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Амжилтгүй");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lblLast_Click(object sender, EventArgs e)
        {

        }
    }
}
