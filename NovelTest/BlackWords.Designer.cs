
namespace BilibiliProjects.NovelTest
{
    partial class BlackWords
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_add = new System.Windows.Forms.Button();
            this.button_del = new System.Windows.Forms.Button();
            this.button_upd = new System.Windows.Forms.Button();
            this.button_clr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(479, 522);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "屏蔽词";
            this.columnHeader1.Width = 230;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "词语类型";
            this.columnHeader2.Width = 107;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "添加时间";
            this.columnHeader3.Width = 129;
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(497, 31);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(91, 23);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "添加屏蔽词";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_del
            // 
            this.button_del.Enabled = false;
            this.button_del.Location = new System.Drawing.Point(497, 76);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(91, 23);
            this.button_del.TabIndex = 2;
            this.button_del.Text = "删除选中";
            this.button_del.UseVisualStyleBackColor = true;
            this.button_del.Click += new System.EventHandler(this.button_del_Click);
            // 
            // button_upd
            // 
            this.button_upd.Enabled = false;
            this.button_upd.Location = new System.Drawing.Point(497, 124);
            this.button_upd.Name = "button_upd";
            this.button_upd.Size = new System.Drawing.Size(91, 23);
            this.button_upd.TabIndex = 3;
            this.button_upd.Text = "修改选中词";
            this.button_upd.UseVisualStyleBackColor = true;
            this.button_upd.Click += new System.EventHandler(this.button_upd_Click);
            // 
            // button_clr
            // 
            this.button_clr.Location = new System.Drawing.Point(497, 260);
            this.button_clr.Name = "button_clr";
            this.button_clr.Size = new System.Drawing.Size(91, 23);
            this.button_clr.TabIndex = 4;
            this.button_clr.Text = "清空所有词语";
            this.button_clr.UseVisualStyleBackColor = true;
            this.button_clr.Click += new System.EventHandler(this.button_clr_Click);
            // 
            // BlackWords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 546);
            this.Controls.Add(this.button_clr);
            this.Controls.Add(this.button_upd);
            this.Controls.Add(this.button_del);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.listView1);
            this.Name = "BlackWords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "屏蔽词管理";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.Button button_upd;
        private System.Windows.Forms.Button button_clr;
    }
}