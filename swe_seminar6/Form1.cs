﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace swe_seminar6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       // string db = "Data Source=DESKTOP-FSF2P1H;Initial Catalog=nw;Integrated Security=True";

        //laptop 
        // string db = "Data Source=DESKTOP-VUTIQH1;Initial Catalog=nw;Integrated Security=True
        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                //  MessageBox.Show("Нэвтрэх нэрээ оруулна уу!");
                lblRed.Text = "Нэвтрэх нэрээ оруулна уу";
            }
            else if (guna2TextBox2.Text == "")
            {
                // MessageBox.Show("Нууц үгээ оруулна уу!");
                lblRed.Text = "Нууц үгээ оруулна уу!";
            }
            else
            {
                try
                {
                    String query = "SELECT * FROM [dbo].[user] WHERE username = '" + guna2TextBox1.Text + "' AND password = '" + "'";
                    SqlConnection con = new SqlConnection(Globals.database);


                    string username = guna2TextBox1.Text;
                    string password = guna2TextBox2.Text;

                    SqlCommand cmd = new SqlCommand("select * from [dbo].[Users] where username = @username and password = @password", con);

                    cmd.Parameters.AddWithValue("@username", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@password", guna2TextBox2.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //  MessageBox.Show("Амжилттай нэвтэрлээ");
                        lblRed.Text = "Амжилттай нэвтэрлээ";
                        int uid = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());

                        new Form2().Show();
                        //this.Hide();
                    }
                    else
                    {
                        // MessageBox.Show("Нэвтрэх нэр эсвэл нууц үг буруу байна");
                        lblRed.Text = "Нэвтрэх нэр эсвэл нууц үг буруу байна";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ymar nege aldaa" + ex);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }

    public partial class User
    {
        public string username { get; set; }
    }

}

