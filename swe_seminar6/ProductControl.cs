using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace swe_seminar6
{
    public partial class ProductControl : UserControl
    {

        string db = "Data Source=DESKTOP-FSF2P1H;Initial Catalog=nw;Integrated Security=True";
        public int id;
        public ProductControl()
        {
            InitializeComponent();
        }

        private void get_data()
        {
            SqlConnection con = new SqlConnection(db);
            con.Open();
            string query = "SELECT ProductID, ProductName, B.CompanyName, C.CategoryName, A.QuantityPerUnit, A.UnitPrice, A.UnitsInStock 	FROM Products A INNER JOIN 	Suppliers B ON A.SupplierID = B.SupplierID INNER JOIN 	Categories C ON A.CategoryID = C.CategoryID";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adap.Fill(ds);

          //  dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];
        }


        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        //  if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
        //  {
        //      dataGridView1.CurrentRow.Selected = true;
        //      this.id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ProductID"].FormattedValue.ToString());
         // }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            int id = Convert.ToInt32(row.Cells["ProductID"].Value);
            int ret_id = frm_edit.get_data(id);
            get_data();
          //  frm_edit frm_edit = new frm_edit();
           // frm_edit.ShowDialog();
        }

      

        private void ProductControl_Load(object sender, EventArgs e)
        {

            get_data();
         
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id =  frm_edit.get_data(0);
            get_data();
            if (id != 0)
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dataGridView1.ClearSelection();

                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(item.Cells[0].Value) == id)
                    {
                        item.Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = item.Index;
                        return;
                    }
                }
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDlt_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(db);
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Users where ProductID");
        }
    }
}
