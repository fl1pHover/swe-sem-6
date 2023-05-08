using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace swe_seminar6
{
    public partial class Form2 : Form
    {
        private TreeView treeView1;
        private SplitContainer splitContainer1;
        private IContainer components;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;

        public Form2()
        {
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Хэрэглэгчийн төрөл");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Хэрэглэгчийн бүртгэл");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Хэрэглэгч", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Бүтээгдэхүүний төрөл");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Бүтээгдэхүүний үнэ");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Бүтээгдэхүүний бүртгэл");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Бүтээгдэхүүн", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Борлуулалт");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Худалдан авалт");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Ажил гүйлгээ", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Эд хөрөнгийн бүртгэл");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Эд хөрөнгийн төрөл");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Эд хөрөнгө", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Нийлүүлэлт бүртгэл");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Нийлүүлэлт", new System.Windows.Forms.TreeNode[] {
            treeNode14});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(44)))), ((int)(((byte)(76)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Calibri", 12F);
            this.treeView1.ForeColor = System.Drawing.SystemColors.Info;
            this.treeView1.Indent = 35;
            this.treeView1.ItemHeight = 30;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Хэрэглэгчийн төрөл";
            treeNode2.Checked = true;
            treeNode2.Name = "Node2";
            treeNode2.Text = "Хэрэглэгчийн бүртгэл";
            treeNode3.Checked = true;
            treeNode3.Name = "Node0";
            treeNode3.Text = "Хэрэглэгч";
            treeNode4.Name = "Node1";
            treeNode4.Text = "Бүтээгдэхүүний төрөл";
            treeNode5.Name = "Node2";
            treeNode5.Text = "Бүтээгдэхүүний үнэ";
            treeNode6.Name = "product_type";
            treeNode6.Text = "Бүтээгдэхүүний бүртгэл";
            treeNode7.Name = "Product";
            treeNode7.Text = "Бүтээгдэхүүн";
            treeNode8.Name = "Node1";
            treeNode8.Text = "Борлуулалт";
            treeNode9.Name = "Node2";
            treeNode9.Text = "Худалдан авалт";
            treeNode10.Name = "Node0";
            treeNode10.Text = "Ажил гүйлгээ";
            treeNode11.Name = "Node4";
            treeNode11.Text = "Эд хөрөнгийн бүртгэл";
            treeNode12.Name = "Node5";
            treeNode12.Text = "Эд хөрөнгийн төрөл";
            treeNode13.Name = "Node3";
            treeNode13.Text = "Эд хөрөнгө";
            treeNode14.Name = "Node1";
            treeNode14.Text = "Нийлүүлэлт бүртгэл";
            treeNode15.Name = "Node0";
            treeNode15.Text = "Нийлүүлэлт";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode7,
            treeNode10,
            treeNode13,
            treeNode15});
            this.treeView1.Size = new System.Drawing.Size(342, 570);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AllowDrop = true;
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(921, 570);
            this.splitContainer1.SplitterDistance = 342;
            this.splitContainer1.TabIndex = 2;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.AnimationInterval = 300;
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.LightGray;
            this.guna2ControlBox1.Location = new System.Drawing.Point(896, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(30, 29);
            this.guna2ControlBox1.TabIndex = 14;
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox3.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.LightGray;
            this.guna2ControlBox3.Location = new System.Drawing.Point(830, 0);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.Size = new System.Drawing.Size(30, 29);
            this.guna2ControlBox3.TabIndex = 16;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.LightGray;
            this.guna2ControlBox2.Location = new System.Drawing.Point(863, 0);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(30, 29);
            this.guna2ControlBox2.TabIndex = 15;
            // 
            // Form2
            // 
            this.AllowDrop = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(79)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(931, 600);
            this.Controls.Add(this.guna2ControlBox3);
            this.Controls.Add(this.guna2ControlBox2);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Padding = new System.Windows.Forms.Padding(0, 30, 10, 0);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string tmp = treeView1.SelectedNode.Text;
            if (tmp == "Хэрэглэгчийн бүртгэл")
            {
                uc_user uc = new uc_user();   
                uc.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(uc);
            }
            if (tmp == "Хэрэглэгчийн төрөл")
            {
                uc_employees em = new uc_employees();
                em.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(em);
            }
            if (tmp == "Бүтээгдэхүүний бүртгэл")
            {
                ProductControl pc = new ProductControl();
                pc.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(pc);
            }
            if (tmp == "Бүтээгдэхүүний төрөл")
            {
                uc_category cat = new uc_category();
                cat.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(cat);
            }
            if (tmp == "Борлуулалт")
            {
                uc_order or = new uc_order();
                or.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(or);
            }
            if (tmp == "Нийлүүлэлт бүртгэл")
            {
                uc_supplier su = new uc_supplier();
                su.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(su);
            }

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  UserControl uc = new UserControl();
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
     
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
