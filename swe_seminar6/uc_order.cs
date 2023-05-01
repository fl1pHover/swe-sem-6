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
    public partial class uc_order : UserControl
    {

        string db = "Data Source=DESKTOP-FSF2P1H;Initial Catalog=nw;Integrated Security=True";
        public uc_order()
        {
            InitializeComponent();
        }
        private void get_data()
        {
            SqlConnection con = new SqlConnection(db);
            con.Open();
            string query = "SELECT * from Orders";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adap.Fill(ds);

            //guna2DataGridView1.AutoGenerateColumns = false;
            guna2DataGridView1.DataSource = ds.Tables[0];

            //this.guna2DataGridView1.Columns["OrderID"].Visible = false;
            this.guna2DataGridView1.Columns["OrderDate"].Visible = false;
            this.guna2DataGridView1.Columns["CustomerID"].Visible = false;
            this.guna2DataGridView1.Columns["RequiredDate"].Visible = false;
            this.guna2DataGridView1.Columns["EmployeeID"].Visible = false;
            this.guna2DataGridView1.Columns["ShippedDate"].Visible = false;
            this.guna2DataGridView1.Columns["ShipPostalCode"].Visible = false;
            this.guna2DataGridView1.Columns["ShipVia"].Visible = false;
            this.guna2DataGridView1.Columns["ShipRegion"].Visible = false;
        }

        private void uc_order_Load(object sender, EventArgs e)
        {
            get_data();
        }
    }
}
