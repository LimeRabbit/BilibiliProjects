
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.屏蔽选中词语ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.替换为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_pre = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.label_source = new System.Windows.Forms.Label();
            this.button_chapters = new System.Windows.Forms.Button();
            this.button_words = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.linkLabel_copy = new System.Windows.Forms.LinkLabel();
            this.label_pagesite = new System.Windows.Forms.Label();
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
            this.button1.Location = new System.Drawing.Point(90, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "刷新当前页";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Location = new System.Drawing.Point(12, 96);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(880, 603);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.屏蔽选中词语ToolStripMenuItem,
            this.替换为ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 屏蔽选中词语ToolStripMenuItem
            // 
            this.屏蔽选中词语ToolStripMenuItem.Name = "屏蔽选中词语ToolStripMenuItem";
            this.屏蔽选中词语ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.屏蔽选中词语ToolStripMenuItem.Text = "屏蔽该词";
            this.屏蔽选中词语ToolStripMenuItem.Click += new System.EventHandler(this.屏蔽选中词语ToolStripMenuItem_Click);
            // 
            // 替换为ToolStripMenuItem
            // 
            this.替换为ToolStripMenuItem.Name = "替换为ToolStripMenuItem";
            this.替换为ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.替换为ToolStripMenuItem.Text = "替换为…";
            this.替换为ToolStripMenuItem.Click += new System.EventHandler(this.替换为ToolStripMenuItem_Click);
            // 
            // button_pre
            // 
            this.button_pre.BackColor = System.Drawing.Color.Teal;
            this.button_pre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_pre.FlatAppearance.BorderSize = 0;
            this.button_pre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_pre.ForeColor = System.Drawing.Color.White;
            this.button_pre.Location = new System.Drawing.Point(15, 61);
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
            this.button_next.Location = new System.Drawing.Point(171, 61);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(69, 23);
            this.button_next.TabIndex = 7;
            this.button_next.Text = "下一章";
            this.button_next.UseVisualStyleBackColor = false;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // label_source
            // 
            this.label_source.AutoSize = true;
            this.label_source.BackColor = System.Drawing.SystemColors.Control;
            this.label_source.ForeColor = System.Drawing.Color.Black;
            this.label_source.Location = new System.Drawing.Point(13, 35);
            this.label_source.Name = "label_source";
            this.label_source.Size = new System.Drawing.Size(53, 12);
            this.label_source.TabIndex = 11;
            this.label_source.Text = "当前页面";
            this.label_source.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_chapters
            // 
            this.button_chapters.BackColor = System.Drawing.Color.Navy;
            this.button_chapters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_chapters.FlatAppearance.BorderSize = 0;
            this.button_chapters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_chapters.ForeColor = System.Drawing.Color.White;
            this.button_chapters.Location = new System.Drawing.Point(246, 61);
            this.button_chapters.Name = "button_chapters";
            this.button_chapters.Size = new System.Drawing.Size(84, 23);
            this.button_chapters.TabIndex = 12;
            this.button_chapters.Text = "章节列表";
            this.button_chapters.UseVisualStyleBackColor = false;
            this.button_chapters.Click += new System.EventHandler(this.button_chapters_Click);
            // 
            // button_words
            // 
            this.button_words.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_words.BackColor = System.Drawing.Color.Navy;
            this.button_words.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_words.FlatAppearance.BorderSize = 0;
            this.button_words.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_words.ForeColor = System.Drawing.Color.White;
            this.button_words.Location = new System.Drawing.Point(814, 61);
            this.button_words.Name = "button_words";
            this.button_words.Size = new System.Drawing.Size(75, 23);
            this.button_words.TabIndex = 13;
            this.button_words.Text = "屏蔽词管理";
            this.button_words.UseVisualStyleBackColor = false;
            this.button_words.Click += new System.EventHandler(this.button_words_Click);
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.BackColor = System.Drawing.Color.Navy;
            this.button_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_save.FlatAppearance.BorderSize = 0;
            this.button_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(733, 61);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 17;
            this.button_save.Text = "保存到本地";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.Button_save_Click);
            // 
            // linkLabel_copy
            // 
            this.linkLabel_copy.AutoSize = true;
            this.linkLabel_copy.BackColor = System.Drawing.SystemColors.Control;
            this.linkLabel_copy.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel_copy.ForeColor = System.Drawing.Color.Black;
            this.linkLabel_copy.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel_copy.Location = new System.Drawing.Point(130, 34);
            this.linkLabel_copy.Name = "linkLabel_copy";
            this.linkLabel_copy.Size = new System.Drawing.Size(35, 14);
            this.linkLabel_copy.TabIndex = 20;
            this.linkLabel_copy.TabStop = true;
            this.linkLabel_copy.Text = "复制";
            this.linkLabel_copy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_copy_LinkClicked);
            // 
            // label_pagesite
            // 
            this.label_pagesite.AutoSize = true;
            this.label_pagesite.BackColor = System.Drawing.SystemColors.Control;
            this.label_pagesite.ForeColor = System.Drawing.Color.Black;
            this.label_pagesite.Location = new System.Drawing.Point(72, 35);
            this.label_pagesite.Name = "label_pagesite";
            this.label_pagesite.Size = new System.Drawing.Size(53, 12);
            this.label_pagesite.TabIndex = 21;
            this.label_pagesite.Text = "小说网址";
            this.label_pagesite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReadNovel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 711);
            this.Controls.Add(this.label_pagesite);
            this.Controls.Add(this.linkLabel_copy);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_words);
            this.Controls.Add(this.button_chapters);
            this.Controls.Add(this.label_source);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.button_pre);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.MinimumSize = new System.Drawing.Size(920, 750);
            this.Name = "ReadNovel";
            this.Text = "看小说";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.ReadNovel_Load);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.richTextBox1, 0);
            this.Controls.SetChildIndex(this.button_pre, 0);
            this.Controls.SetChildIndex(this.button_next, 0);
            this.Controls.SetChildIndex(this.label_source, 0);
            this.Controls.SetChildIndex(this.button_chapters, 0);
            this.Controls.SetChildIndex(this.button_words, 0);
            this.Controls.SetChildIndex(this.button_save, 0);
            this.Controls.SetChildIndex(this.linkLabel_copy, 0);
            this.Controls.SetChildIndex(this.label_pagesite, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button_pre;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Label label_source;
        private System.Windows.Forms.Button button_chapters;
        private System.Windows.Forms.Button button_words;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 屏蔽选中词语ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 替换为ToolStripMenuItem;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.LinkLabel linkLabel_copy;
        private System.Windows.Forms.Label label_pagesite;
    }
}

