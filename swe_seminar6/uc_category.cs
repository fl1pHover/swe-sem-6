using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace swe_seminar6
{
    public partial class uc_category : UserControl
    {
        //laptop 
        // string db = "Data Source=DESKTOP-VUTIQH1;Initial Catalog=nw;Integrated Security=True";
        string db = "Data Source=DESKTOP-FSF2P1H;Initial Catalog=nw;Integrated Security=True";
        public uc_category()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            get_data();
        }

        private void get_data()
        {
            SqlConnection con = new SqlConnection(db);
            con.Open();
            string query = "SELECT * from Categories";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adap.Fill(ds);

            //guna2DataGridView1.AutoGenerateColumns = false;
            guna2DataGridView1.DataSource = ds.Tables[0];

            this.guna2DataGridView1.Columns["CategoryID"].Visible = false;
        }
    }
}
