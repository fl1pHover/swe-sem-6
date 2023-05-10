using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace swe_seminar6
{
    public partial class uc_order : UserControl
    {

        public int oid;
        public uc_order()
        {
            InitializeComponent();
        }
        private void get_data()
        {
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
            string query = "SELECT OrderID, Freight,ShipName, ShipAddress, ShipCity, ShipCountry from Orders";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adap.Fill(ds);

            guna2DataGridView1.DataSource = ds.Tables[0];

          
        }

        private void uc_order_Load(object sender, EventArgs e)
        {
            get_data();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = frm_edit_order.get_data(0);
            get_data();
            if (id != 0)
            {
                guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                guna2DataGridView1.ClearSelection();

                foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                {
                    if (Convert.ToInt32(item.Cells[0].Value) == id)
                    {
                        item.Selected = true;
                        guna2DataGridView1.FirstDisplayedScrollingRowIndex = item.Index;
                        return;
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = guna2DataGridView1.CurrentRow;
            //  int id = Convert.ToInt32(row.Cells["OrderID"].Value);
            int id = Convert.ToInt32(guna2DataGridView1.SelectedCells[0].Value);
           oid = id;
            int ret_id = frm_edit_order.get_data(oid);
            get_data();
            if (id != 0)
            {
                guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                guna2DataGridView1.ClearSelection();

                foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                {
                    if (Convert.ToInt32(item.Cells[0].Value) == id)
                    {
                        item.Selected = true;
                        guna2DataGridView1.FirstDisplayedScrollingRowIndex = item.Index;
                        return;
                    }
                }
            }
      
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                guna2DataGridView1.CurrentRow.Selected = true;
                oid = int.Parse(guna2DataGridView1.SelectedCells[0].FormattedValue.ToString());
                textBox1.Text = oid.ToString();
            }
        }

        private void btnDlt_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
            SqlCommand cmd = new SqlCommand("delOrder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@oid", oid);
            cmd.Parameters.Add(param[0]);
            string mes = "Та итгэлтэй байна уу?";
            string title = "Warning";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(mes, title, buttons);

            try
            {
                if (result == DialogResult.Yes)
                {
                   
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Амжилттай устгалаа");
                    get_data();
                    
                }
                else
                {

                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
