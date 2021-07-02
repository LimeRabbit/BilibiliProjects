
namespace BilibiliProjects.NovelTest
{
    partial class ChaptersList
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
            this.label_novel = new System.Windows.Forms.Label();
            this.textBox_chapter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_delete = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_novel
            // 
            this.label_novel.AutoSize = true;
            this.label_novel.BackColor = System.Drawing.SystemColors.Control;
            this.label_novel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_novel.ForeColor = System.Drawing.Color.Black;
            this.label_novel.Location = new System.Drawing.Point(214, 25);
            this.label_novel.Name = "label_novel";
            this.label_novel.Size = new System.Drawing.Size(59, 16);
            this.label_novel.TabIndex = 0;
            this.label_novel.Text = "小说名";
            // 
            // textBox_chapter
            // 
            this.textBox_chapter.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_chapter.ForeColor = System.Drawing.Color.Black;
            this.textBox_chapter.Location = new System.Drawing.Point(80, 199);
            this.textBox_chapter.Name = "textBox_chapter";
            this.textBox_chapter.Size = new System.Drawing.Size(193, 21);
            this.textBox_chapter.TabIndex = 11;
            this.textBox_chapter.TextChanged += new System.EventHandler(this.textBox_chapter_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "搜索章节：";
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView2.BackColor = System.Drawing.SystemColors.Control;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView2.ForeColor = System.Drawing.Color.Black;
            this.listView2.FullRowSelect = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(12, 226);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(481, 398);
            this.listView2.TabIndex = 9;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.VirtualMode = true;
            this.listView2.DoubleClick += new System.EventHandler(this.listView2_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "章节名";
            this.columnHeader1.Width = 204;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "地址";
            this.columnHeader2.Width = 208;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Control;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(11, 73);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(404, 118);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "来源";
            this.columnHeader3.Width = 194;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "章节数";
            this.columnHeader4.Width = 68;
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Maroon;
            this.button_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_delete.Enabled = false;
            this.button_delete.FlatAppearance.BorderSize = 0;
            this.button_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_delete.ForeColor = System.Drawing.Color.White;
            this.button_delete.Location = new System.Drawing.Point(421, 73);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 13;
            this.button_delete.Text = "删除选中";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.Color.Maroon;
            this.button_clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_clear.FlatAppearance.BorderSize = 0;
            this.button_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_clear.ForeColor = System.Drawing.Color.White;
            this.button_clear.Location = new System.Drawing.Point(421, 102);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 14;
            this.button_clear.Text = "清空所有";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "来源和章节数";
            // 
            // ChaptersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 636);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox_chapter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.label_novel);
            this.Name = "ChaptersList";
            this.Text = "章节列表";
            this.Controls.SetChildIndex(this.label_novel, 0);
            this.Controls.SetChildIndex(this.listView2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.textBox_chapter, 0);
            this.Controls.SetChildIndex(this.listView1, 0);
            this.Controls.SetChildIndex(this.button_delete, 0);
            this.Controls.SetChildIndex(this.button_clear, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_novel;
        private System.Windows.Forms.TextBox textBox_chapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Label label1;
    }
}