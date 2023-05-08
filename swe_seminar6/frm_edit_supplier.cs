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
    public partial class frm_edit_supplier : Form
    {

        int supplier_id = 0;
        public static int ret_supplier_id = 0;
        string db = "Data Source=DESKTOP-FSF2P1H;Initial Catalog=nw;Integrated Security=True";
        public frm_edit_supplier()
        {
            InitializeComponent();
        }
        public frm_edit_supplier(int _s_id)
        {
            InitializeComponent();
            supplier_id = _s_id;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Globals.database);
                con.Open();
                DataSet ds = new DataSet();
                SqlCommand com = new SqlCommand("mod_supplier", con) { CommandType = CommandType.StoredProcedure, CommandTimeout = 300 };
                SqlParameter[] parameters = new SqlParameter[7];

                parameters[0] = new SqlParameter("@supplier_id", supplier_id);
                parameters[1] = new SqlParameter("@CompanyName", txt_company.Text);
                parameters[2] = new SqlParameter("@ContactName", txt_contact.Text);
                parameters[3] = new SqlParameter("@ContactTitle", txt_contactTitle.Text);
                parameters[4] = new SqlParameter("@City", txt_address.Text);
                parameters[5] = new SqlParameter("@Address", txt_address.Text);
                parameters[6] = new SqlParameter("@Country", txt_city.Text);

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
                        ret_supplier_id = Convert.ToInt32(ds.Tables[0].Rows[0]["supplier_id"]);
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
        public static int get_data(int s_id)
        {
            frm_edit_supplier frm = new frm_edit_supplier(s_id);
            frm.ShowDialog();
            return ret_supplier_id;
        }

        private void frm_edit_supplier_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
            SqlCommand com = new SqlCommand("get_supplier", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            // ds.Tables[0].TableName = "Orders";

            SqlCommand com1 = new SqlCommand("SELECT SupplierID, CompanyName,ContactName, ContactTitle, Address, City,Country FROM Suppliers WHERE SupplierID = " + supplier_id + "", con);
            SqlDataAdapter adap1 = new SqlDataAdapter(com1);
            DataSet ds1 = new DataSet();
            adap1.Fill(ds1);
            if (ds1 == null || ds1.Tables[0].Rows.Count == 0)
            {
                return;
            }

            txt_company.Text = ds1.Tables[0].Rows[0]["CompanyName"].ToString();
            txt_contact.Text = ds1.Tables[0].Rows[0]["ContactName"].ToString();
            txt_contactTitle.Text = ds1.Tables[0].Rows[0]["ContactTitle"].ToString();
            txt_city.Text = ds1.Tables[0].Rows[0]["City"].ToString();
            txt_address.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
            txt_country.Text = ds1.Tables[0].Rows[0]["Country"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
