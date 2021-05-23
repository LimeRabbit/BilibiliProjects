
namespace BilibiliProjects.NovelTest
{
    partial class ReadNovel
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_page = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.屏蔽选中词语ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_pre = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.label_book = new System.Windows.Forms.Label();
            this.label_source = new System.Windows.Forms.Label();
            this.button_chapters = new System.Windows.Forms.Button();
            this.button_words = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(273, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "刷新当前页";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // textBox_page
            // 
            this.textBox_page.Location = new System.Drawing.Point(72, 36);
            this.textBox_page.Name = "textBox_page";
            this.textBox_page.ReadOnly = true;
            this.textBox_page.Size = new System.Drawing.Size(195, 21);
            this.textBox_page.TabIndex = 4;
            this.textBox_page.Text = "3/3734/6857780";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "当前页";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Blue;
            this.richTextBox1.Location = new System.Drawing.Point(14, 100);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(875, 581);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.屏蔽选中词语ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 屏蔽选中词语ToolStripMenuItem
            // 
            this.屏蔽选中词语ToolStripMenuItem.Name = "屏蔽选中词语ToolStripMenuItem";
            this.屏蔽选中词语ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.屏蔽选中词语ToolStripMenuItem.Text = "屏蔽选中词语";
            this.屏蔽选中词语ToolStripMenuItem.Click += new System.EventHandler(this.屏蔽选中词语ToolStripMenuItem_Click);
            // 
            // button_pre
            // 
            this.button_pre.BackColor = System.Drawing.Color.Teal;
            this.button_pre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_pre.FlatAppearance.BorderSize = 0;
            this.button_pre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_pre.ForeColor = System.Drawing.Color.White;
            this.button_pre.Location = new System.Drawing.Point(387, 36);
            this.button_pre.Name = "button_pre";
            this.button_pre.Size = new System.Drawing.Size(69, 23);
            this.button_pre.TabIndex = 6;
            this.button_pre.Text = "上一章";
            this.button_pre.UseVisualStyleBackColor = false;
            this.button_pre.Click += new System.EventHandler(this.button_pre_Click);
            // 
            // button_next
            // 
            this.button_next.BackColor = System.Drawing.Color.Teal;
            this.button_next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_next.FlatAppearance.BorderSize = 0;
            this.button_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_next.ForeColor = System.Drawing.Color.White;
            this.button_next.Location = new System.Drawing.Point(462, 36);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(69, 23);
            this.button_next.TabIndex = 7;
            this.button_next.Text = "下一章";
            this.button_next.UseVisualStyleBackColor = false;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // label_book
            // 
            this.label_book.AutoSize = true;
            this.label_book.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_book.Location = new System.Drawing.Point(12, 65);
            this.label_book.Name = "label_book";
            this.label_book.Size = new System.Drawing.Size(97, 15);
            this.label_book.TabIndex = 10;
            this.label_book.Text = "label_book";
            // 
            // label_source
            // 
            this.label_source.AutoSize = true;
            this.label_source.Location = new System.Drawing.Point(13, 20);
            this.label_source.Name = "label_source";
            this.label_source.Size = new System.Drawing.Size(53, 12);
            this.label_source.TabIndex = 11;
            this.label_source.Text = "当前来源";
            // 
            // button_chapters
            // 
            this.button_chapters.BackColor = System.Drawing.Color.Navy;
            this.button_chapters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_chapters.FlatAppearance.BorderSize = 0;
            this.button_chapters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_chapters.ForeColor = System.Drawing.Color.White;
            this.button_chapters.Location = new System.Drawing.Point(733, 34);
            this.button_chapters.Name = "button_chapters";
            this.button_chapters.Size = new System.Drawing.Size(75, 23);
            this.button_chapters.TabIndex = 12;
            this.button_chapters.Text = "章节列表";
            this.button_chapters.UseVisualStyleBackColor = false;
            this.button_chapters.Click += new System.EventHandler(this.button_chapters_Click);
            // 
            // button_words
            // 
            this.button_words.BackColor = System.Drawing.Color.Navy;
            this.button_words.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_words.FlatAppearance.BorderSize = 0;
            this.button_words.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_words.ForeColor = System.Drawing.Color.White;
            this.button_words.Location = new System.Drawing.Point(814, 34);
            this.button_words.Name = "button_words";
            this.button_words.Size = new System.Drawing.Size(75, 23);
            this.button_words.TabIndex = 13;
            this.button_words.Text = "屏蔽词管理";
            this.button_words.UseVisualStyleBackColor = false;
            this.button_words.Click += new System.EventHandler(this.button_words_Click);
            // 
            // ReadNovel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 693);
            this.Controls.Add(this.button_words);
            this.Controls.Add(this.button_chapters);
            this.Controls.Add(this.label_source);
            this.Controls.Add(this.label_book);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.button_pre);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox_page);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Name = "ReadNovel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "看小说";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_page;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button_pre;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Label label_book;
        private System.Windows.Forms.Label label_source;
        private System.Windows.Forms.Button button_chapters;
        private System.Windows.Forms.Button button_words;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 屏蔽选中词语ToolStripMenuItem;
    }
}

