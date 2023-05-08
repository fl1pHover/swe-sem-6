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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace swe_seminar6
{
    public partial class frm_edit : Form
    {

        int product_id = 0;
        public static int ret_product_id = 0;

        public frm_edit()
        {
            InitializeComponent();
        
        }

        public frm_edit(int _p_id)
        {
            InitializeComponent();
            product_id = _p_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            bool error = false;
            if (txt_quantityPer.Text == "" )
            {
                errorProvider1.SetError(txt_quantityPer, "Заавал оруулах шаардлагатай");
                error = true;
            }
            if (txt_name.Text == "")
            {
                errorProvider1.SetError(txt_name, "Заавал оруулах шаардлагатай");
                error = true;
            }

            if (error == true)
            {
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(Globals.database);
                con.Open();
                DataSet ds = new DataSet();
                SqlCommand com = new SqlCommand("spu_mod_products", con) { CommandType = CommandType.StoredProcedure, CommandTimeout = 300 };
                SqlParameter[] parameters = new SqlParameter[6];
                parameters[0] = new SqlParameter("@product_id", product_id);
                parameters[1] = new SqlParameter("@ProductName", txt_name.Text);
                parameters[2] = new SqlParameter("@SupplierID", Convert.ToInt32(comboBox1.SelectedValue));
                parameters[3] = new SqlParameter("@CategoryID", Convert.ToInt32(comboBox2.SelectedValue));
                parameters[4] = new SqlParameter("@QuantityPerUnit", txt_quantityPer.Text);
                parameters[5] = new SqlParameter("@UnitPrice", Convert.ToDecimal(txt_unitPrice.Text));
                int parameters_leght = parameters.Length - 1;
                for (int index = 0; index <= parameters_leght; index++)
                {
                    com.Parameters.Add(parameters[index]);
                }
                try
                {
                    SqlDataAdapter adap = new SqlDataAdapter(com);
                    adap.Fill(ds);
                    if (ds == null)
                    {
                        com.Connection.Close();
                        Close();

                    }
                    else
                    {
                        ret_product_id = Convert.ToInt32(ds.Tables[0].Rows[0]["product_id"]);
                        MessageBox.Show("Амжилттай хадгалагдлаа");
                        Close();
                    }

                    con.Close();
                }
                catch (Exception)
                {
                    if (con.State == ConnectionState.Open)
                    { con.Close(); }
                }
            }
            catch
            {
                MessageBox.Show("Хадгалалт амжилтгүй");
            }
        }

        public static int get_data(int p_id)
        {
            frm_edit frm = new frm_edit(p_id);
            frm.ShowDialog();
            return ret_product_id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_edit_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
            SqlCommand com = new SqlCommand("spu_get_products", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adap.Fill(ds);
          //  ds.Tables[0].TableName = "Category";

            comboBox1.DataSource = ds.Tables[0];
            comboBox1.ValueMember = "CategoryID";
            comboBox1.DisplayMember = "CategoryName";

            comboBox2.DataSource = ds.Tables[2];
            comboBox2.ValueMember = "SupplierID";
            comboBox2.DisplayMember = "CompanyName";

            SqlCommand com1 = new SqlCommand("SELECT * FROM Products WHERE ProductID = " + product_id + "", con);
            SqlDataAdapter adap1 = new SqlDataAdapter(com1);
            DataSet ds1 = new DataSet();
            adap1.Fill(ds1);
            if (ds1 == null || ds1.Tables[0].Rows.Count == 0)
            {
                return;
            }

            txt_name.Text = ds1.Tables[0].Rows[0]["ProductName"].ToString();
            comboBox1.SelectedValue = ds1.Tables[0].Rows[0]["CategoryID"];
            comboBox2.SelectedValue = ds1.Tables[0].Rows[0]["SupplierID"];
            txt_quantityPer.Text = ds1.Tables[0].Rows[0]["QuantityPerUnit"].ToString();
            txt_unitPrice.Text = ds1.Tables[0].Rows[0]["UnitPrice"].ToString();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
