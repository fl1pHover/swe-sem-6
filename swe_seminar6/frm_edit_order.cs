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
    public partial class frm_edit_order : Form
    {

        int order_id = 0;
        public static int ret_order_id = 0;
        string db = "Data Source=DESKTOP-FSF2P1H;Initial Catalog=nw;Integrated Security=True";
        public frm_edit_order()
        {
            InitializeComponent();
        }

        public frm_edit_order(int _o_id)
        {
            InitializeComponent();
            order_id = _o_id;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            bool error = false;
          //  if (txt_quantityPer.Text == "")
         //   {
         //       errorProvider1.SetError(txt_quantityPer, "Заавал оруулах шаардлагатай");
         //       error = true;
         //   }
       
         //   if (error == true)
         //   {
         //       return;
         //   }
            try
            {
                SqlConnection con = new SqlConnection(db);
                con.Open();
                DataSet ds = new DataSet();
                SqlCommand com = new SqlCommand("spu_mod_order", con) { CommandType = CommandType.StoredProcedure, CommandTimeout = 300 };
                SqlParameter[] parameters = new SqlParameter[6];
                parameters[0] = new SqlParameter("@order_id", order_id);
                parameters[1] = new SqlParameter("@Freight", Convert.ToDecimal(txt_freight.Text));
                parameters[2] = new SqlParameter("@ShipName", txt_shipName.Text);
                parameters[3] = new SqlParameter("@ShipAddress", txt_shipAddress.Text);
                parameters[4] = new SqlParameter("@ShipCity", txt_city.Text);
                parameters[5] = new SqlParameter("@ShipCountry", txt_country.Text);
           
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
                        ret_order_id = Convert.ToInt32(ds.Tables[0].Rows[0]["order_id"]);
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

        public static int get_data(int o_id)
        {
            frm_edit_order frm = new frm_edit_order(o_id);
            frm.ShowDialog();
            return ret_order_id;
        }

        private void frm_edit_order_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(db);
            con.Open();
            SqlCommand com = new SqlCommand("spu_get_order", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            ds.Tables[0].TableName = "Orders";



            SqlCommand com1 = new SqlCommand("SELECT * FROM Orders WHERE OrderID = " + order_id + "", con);
            SqlDataAdapter adap1 = new SqlDataAdapter(com1);
            DataSet ds1 = new DataSet();
            adap1.Fill(ds1);
            if (ds1 == null || ds1.Tables[0].Rows.Count == 0)
            {
                return;
            }

            txt_freight.Text = ds1.Tables[0].Rows[0]["Freight"].ToString();
            txt_shipName.Text = ds1.Tables[0].Rows[0]["ShipName"].ToString();
            txt_shipAddress.Text = ds1.Tables[0].Rows[0]["ShipAddress"].ToString();
            txt_city.Text = ds1.Tables[0].Rows[0]["ShipCity"].ToString();
            txt_country.Text = ds1.Tables[0].Rows[0]["ShipCountry"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
