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
    public partial class frm_edit_employee : Form
    {

        int employee_id = 0;
        public static int ret_employee_id = 0;

        public frm_edit_employee()
        {
            InitializeComponent();
        }

        public frm_edit_employee(int _e_id)
        {
            InitializeComponent();
            employee_id = _e_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Globals.database);
                con.Open();
                DataSet ds = new DataSet();
                SqlCommand com = new SqlCommand("mod_employee", con) { CommandType = CommandType.StoredProcedure, CommandTimeout = 300 };
                SqlParameter[] parameters = new SqlParameter[7];
                parameters[0] = new SqlParameter("@employee_id", employee_id);
                parameters[1] = new SqlParameter("@LastName", txt_lastName.Text);
                parameters[2] = new SqlParameter("@FirstName", txt_firstName.Text);            
                parameters[3] = new SqlParameter("@Address", txt_address.Text);
                parameters[4] = new SqlParameter("@Notes", txt_notes.Text);
               parameters[5] = new SqlParameter("@City", txt_city.Text);
                parameters[6] = new SqlParameter("@Title", txt_title.Text);
                // parameters[5] = new SqlParameter("@City", Convert.ToInt32(cmb_city.SelectedValue));

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
                        ret_employee_id = Convert.ToInt32(ds.Tables[0].Rows[0]["employee_id"]);
                        MessageBox.Show("Амжилттай хадгалагдлаа");
                        Close();
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    if (con.State == ConnectionState.Open)
                    { con.Close(); }
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                //   MessageBox.Show("Хадгалалт амжилтгүй");
                MessageBox.Show(ex.Message);
            }
        }

        public static int get_data(int e_id)
        {
            frm_edit_employee frm = new frm_edit_employee(e_id);
            frm.ShowDialog();
            return ret_employee_id;
        }
     

        private void frm_edit_employee_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
            SqlCommand com = new SqlCommand("get_employee", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adap.Fill(ds);

            SqlCommand com1 = new SqlCommand("SELECT EmployeeID, FirstName, LastName, Title, City, Address, HomePhone, Notes, Photo from Employees WHERE EmployeeID = " + employee_id + "", con);
            SqlDataAdapter adap1 = new SqlDataAdapter(com1);
            DataSet ds1 = new DataSet();
            adap1.Fill(ds1);
            if (ds1 == null || ds1.Tables[0].Rows.Count == 0)
            {
                return;
            }

            txt_lastName.Text = ds1.Tables[0].Rows[0]["LastName"].ToString();
            txt_firstName.Text = ds1.Tables[0].Rows[0]["FirstName"].ToString();
            txt_title.Text = ds1.Tables[0].Rows[0]["Title"].ToString();
            txt_address.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
            txt_notes.Text = ds1.Tables[0].Rows[0]["Notes"].ToString();
            txt_city.Text = ds1.Tables[0].Rows[0]["City"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
