using Guna.UI2.WinForms;
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


        public int pid;
        public ProductControl()
        {
            InitializeComponent();
        }

        private void get_data()
        {
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
            string query = "SELECT ProductID, ProductName, B.CompanyName, C.CategoryName, A.QuantityPerUnit, A.UnitPrice, A.UnitsInStock FROM Products A INNER JOIN Suppliers B ON A.SupplierID = B.SupplierID INNER JOIN 	Categories C ON A.CategoryID = C.CategoryID";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adap.Fill(ds);

          //  dataGridView1.AutoGenerateColumns = false;
            guna2DataGridView1.DataSource = ds.Tables[0];

            this.guna2DataGridView1.Columns["ProductID"].Visible = true;
      
        }

        private void ProductControl_Load(object sender, EventArgs e)
        {

            get_data();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = frm_edit.get_data(0);
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

            int id = Convert.ToInt32(guna2DataGridView1.SelectedCells[0].Value);
            pid = id;
            int ret_id = frm_edit.get_data(pid);
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
            get_data();

        }

        private void btnDlt_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
            SqlCommand cmd = new SqlCommand("delProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@pid", pid);
            cmd.Parameters.Add(param[0]);
            string mes = "Та итгэлтэй байна уу?";
            string title = "Warning";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(mes, title, buttons);

            try
            {
                if(result == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Амжилттай устгалаа");
                    get_data();
                    if (pid != 0)
                    {
                        guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        guna2DataGridView1.ClearSelection();

                        foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                        {
                            if (Convert.ToInt32(item.Cells[0].Value) == pid)
                            {
                                item.Selected = true;
                                guna2DataGridView1.FirstDisplayedScrollingRowIndex = item.Index;
                                return;
                            }
                        }
                    }
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

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                guna2DataGridView1.CurrentRow.Selected = true;
                pid = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells["ProductID"].FormattedValue.ToString());
                textBox1.Text = pid.ToString();
            }
        }
    }
}
