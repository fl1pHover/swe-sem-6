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
        private Panel panel1;

        public Form2()
        {
            InitializeComponent();

            
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Хэрэглэгчийн төрөл");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Хэрэглэгчийн бүртгэл");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Хэрэглэгч", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Бүтээгдэхүүний бүртгэл");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Бүтээгдэхүүний төрөл");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Бүтээгдэхүүний үнэ");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Бүтээгдэхүүн", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
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
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode8.Name = "Node1";
            treeNode8.Text = "Хэрэглэгчийн төрөл";
            treeNode9.Checked = true;
            treeNode9.Name = "Node2";
            treeNode9.Text = "Хэрэглэгчийн бүртгэл";
            treeNode10.Checked = true;
            treeNode10.Name = "Node0";
            treeNode10.Text = "Хэрэглэгч";
            treeNode11.Name = "product_type";
            treeNode11.Text = "Бүтээгдэхүүний бүртгэл";
            treeNode12.Name = "Node1";
            treeNode12.Text = "Бүтээгдэхүүний төрөл";
            treeNode13.Name = "Node2";
            treeNode13.Text = "Бүтээгдэхүүний үнэ";
            treeNode14.Name = "Product";
            treeNode14.Text = "Бүтээгдэхүүн";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode14});
            this.treeView1.Size = new System.Drawing.Size(228, 424);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(684, 424);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 10);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Form2
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(684, 424);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
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
            if (tmp == "Бүтээгдэхүүний төрөл")
            {
                ProductControl pc = new ProductControl();
                pc.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(pc);


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
    }
}
