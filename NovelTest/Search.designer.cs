
namespace BilibiliProjects
{
    partial class Search
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_keyword = new System.Windows.Forms.TextBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.column_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_state = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.开始阅读ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.章节列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_hideChapter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_chapter = new System.Windows.Forms.TextBox();
            this.button_mybooks = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "小说名/作者名";
            // 
            // textBox_keyword
            // 
            this.textBox_keyword.Location = new System.Drawing.Point(110, 15);
            this.textBox_keyword.Name = "textBox_keyword";
            this.textBox_keyword.Size = new System.Drawing.Size(200, 21);
            this.textBox_keyword.TabIndex = 1;
            this.textBox_keyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_keyword_KeyDown);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(316, 13);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(50, 23);
            this.button_ok.TabIndex = 2;
            this.button_ok.Text = "搜";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_name,
            this.column_state,
            this.column_author,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(23, 42);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1049, 693);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // column_name
            // 
            this.column_name.Text = "书名";
            this.column_name.Width = 277;
            // 
            // column_state
            // 
            this.column_state.Text = "状态";
            // 
            // column_author
            // 
            this.column_author.Text = "作者";
            this.column_author.Width = 143;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "最新章节";
            this.columnHeader3.Width = 425;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "最后更新日期";
            this.columnHeader4.Width = 91;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始阅读ToolStripMenuItem,
            this.章节列表ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // 开始阅读ToolStripMenuItem
            // 
            this.开始阅读ToolStripMenuItem.Name = "开始阅读ToolStripMenuItem";
            this.开始阅读ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.开始阅读ToolStripMenuItem.Text = "开始阅读";
            this.开始阅读ToolStripMenuItem.Click += new System.EventHandler(this.开始阅读ToolStripMenuItem_Click);
            // 
            // 章节列表ToolStripMenuItem
            // 
            this.章节列表ToolStripMenuItem.Name = "章节列表ToolStripMenuItem";
            this.章节列表ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.章节列表ToolStripMenuItem.Text = "章节列表";
            this.章节列表ToolStripMenuItem.Click += new System.EventHandler(this.章节列表ToolStripMenuItem_Click);
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView2.FullRowSelect = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(1091, 42);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(470, 693);
            this.listView2.TabIndex = 5;
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
            // button_hideChapter
            // 
            this.button_hideChapter.Location = new System.Drawing.Point(1091, 13);
            this.button_hideChapter.Name = "button_hideChapter";
            this.button_hideChapter.Size = new System.Drawing.Size(93, 23);
            this.button_hideChapter.TabIndex = 6;
            this.button_hideChapter.Text = "隐藏章节列表";
            this.button_hideChapter.UseVisualStyleBackColor = true;
            this.button_hideChapter.Click += new System.EventHandler(this.button_hideChapter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1297, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "搜索章节：";
            // 
            // textBox_chapter
            // 
            this.textBox_chapter.Location = new System.Drawing.Point(1368, 15);
            this.textBox_chapter.Name = "textBox_chapter";
            this.textBox_chapter.Size = new System.Drawing.Size(193, 21);
            this.textBox_chapter.TabIndex = 8;
            this.textBox_chapter.TextChanged += new System.EventHandler(this.textBox_chapter_TextChanged);
            // 
            // button_mybooks
            // 
            this.button_mybooks.Location = new System.Drawing.Point(997, 14);
            this.button_mybooks.Name = "button_mybooks";
            this.button_mybooks.Size = new System.Drawing.Size(75, 23);
            this.button_mybooks.TabIndex = 9;
            this.button_mybooks.Text = "我的书架";
            this.button_mybooks.UseVisualStyleBackColor = true;
            this.button_mybooks.Click += new System.EventHandler(this.button_mybooks_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1624, 747);
            this.Controls.Add(this.button_mybooks);
            this.Controls.Add(this.textBox_chapter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_hideChapter);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.textBox_keyword);
            this.Controls.Add(this.label1);
            this.Name = "Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "搜索小说";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_keyword;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader column_name;
        private System.Windows.Forms.ColumnHeader column_author;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader column_state;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开始阅读ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 章节列表ToolStripMenuItem;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button_hideChapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_chapter;
        private System.Windows.Forms.Button button_mybooks;
    }
}