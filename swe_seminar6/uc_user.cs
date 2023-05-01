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
        public uc_user()
        {
            InitializeComponent();

       

           
                //  String query = "SELECT * FROM [dbo].[user] WHERE username = '" + textBox1.Text + "' AND password = '" + "'";
             //   SqlConnection con = new SqlConnection("Data Source=DESKTOP-FSF2P1H;Initial Catalog=SWE;Integrated Security=True");
               // SqlCommand cmd = new SqlCommand("select * from [dbo].[user]", con);

      
              //  SqlDataAdapter da = new SqlDataAdapter(cmd);

               // DataTable dt = new DataTable();

              //  da.Fill(dt);

              //  label7.Text = dt.Rows[0]["username"].ToString();

         
           
           
        }
       
        protected override void OnLoad(EventArgs e)
        {
            string db = "Data Source=DESKTOP-FSF2P1H;Initial Catalog=nw;Integrated Security=True";
            SqlConnection con = new SqlConnection(db);
            con.Open();
      
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE id='" + 1 + "'", con);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);


            lblUsername.Text = ds.Tables[0].Rows[0]["username"].ToString();
            lblPass.Text = ds.Tables[0].Rows[0]["password"].ToString();
            lblType.Text = ds.Tables[0].Rows[0]["firstname"].ToString();
            lblLast.Text = ds.Tables[0].Rows[0]["lastname"].ToString();
            lblRegister.Text = ds.Tables[0].Rows[0]["registerNumber"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0]["phone"].ToString();
            txtMail.Text = ds.Tables[0].Rows[0]["email"].ToString();



            base.OnLoad(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
