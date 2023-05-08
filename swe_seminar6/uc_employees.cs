using Guna.UI2.WinForms;
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
    public partial class uc_employees : UserControl
    {

        public int id;
        public uc_employees()
        {
            InitializeComponent();
        }
        private void get_data()
        {
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
            //string query = "SELECT * from Employees";
            string query = "SELECT EmployeeID, FirstName, LastName, Title, City, Address, HomePhone, Notes from Employees";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adap.Fill(ds);

            //guna2DataGridView1.AutoGenerateColumns = false;
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            int id = frm_edit_employee.get_data(0);

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

        private void uc_employees_Load_1(object sender, EventArgs e)
        {
            get_data();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = guna2DataGridView1.CurrentRow;
            int id = Convert.ToInt32(guna2DataGridView1.SelectedCells[0].Value);
            int ret_id = frm_edit_employee.get_data(id);
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

        private void uc_employees_Load(object sender, EventArgs e)
        {
          
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
         
        } 
    }
}
