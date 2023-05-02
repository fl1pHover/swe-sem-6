﻿using System;
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

        //laptop 
        // string db = "Data Source=DESKTOP-VUTIQH1;Initial Catalog=nw;Integrated Security=True";
        string db = "Data Source=DESKTOP-FSF2P1H;Initial Catalog=nw;Integrated Security=True";
        public int id;
        public uc_employees()
        {
            InitializeComponent();
        }
        private void get_data()
        {
            SqlConnection con = new SqlConnection(db);
            con.Open();
            string query = "SELECT * from Employees";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adap.Fill(ds);

            //guna2DataGridView1.AutoGenerateColumns = false;
            guna2DataGridView1.DataSource = ds.Tables[0];

            // this.guna2DataGridView1.Columns["OrderID"].Visible = false;
            this.guna2DataGridView1.Columns["TitleOfCourtesy"].Visible = false;
            this.guna2DataGridView1.Columns["BirthDate"].Visible = false;
            this.guna2DataGridView1.Columns["HireDate"].Visible = false;
            this.guna2DataGridView1.Columns["Extension"].Visible = false;
            this.guna2DataGridView1.Columns["ReportsTo"].Visible = false;
            this.guna2DataGridView1.Columns["PostalCode"].Visible = false;
            this.guna2DataGridView1.Columns["PhotoPath"].Visible = false;
        
        }

        private void uc_employees_Load(object sender, EventArgs e)
        {
          
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
         
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
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

        private void uc_employees_Load_1(object sender, EventArgs e)
        {
            get_data();
        }
    }
}