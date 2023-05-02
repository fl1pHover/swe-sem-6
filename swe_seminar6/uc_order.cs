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
    public partial class uc_order : UserControl
    {
        //laptop 
        // string db = "Data Source=DESKTOP-VUTIQH1;Initial Catalog=nw;Integrated Security=True";
        string db = "Data Source=DESKTOP-FSF2P1H;Initial Catalog=nw;Integrated Security=True";
        public int id;
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

           // this.guna2DataGridView1.Columns["OrderID"].Visible = false;
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
            int id = Convert.ToInt32(row.Cells["OrderID"].Value);
            int a_id = frm_edit_order.get_data(id);
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
    }
}
