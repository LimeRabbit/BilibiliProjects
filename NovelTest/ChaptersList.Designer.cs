
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
            this.SuspendLayout();
            // 
            // label_novel
            // 
            this.label_novel.AutoSize = true;
            this.label_novel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_novel.ForeColor = System.Drawing.Color.Blue;
            this.label_novel.Location = new System.Drawing.Point(215, 9);
            this.label_novel.Name = "label_novel";
            this.label_novel.Size = new System.Drawing.Size(59, 16);
            this.label_novel.TabIndex = 0;
            this.label_novel.Text = "小说名";
            // 
            // textBox_chapter
            // 
            this.textBox_chapter.Location = new System.Drawing.Point(81, 36);
            this.textBox_chapter.Name = "textBox_chapter";
            this.textBox_chapter.Size = new System.Drawing.Size(193, 21);
            this.textBox_chapter.TabIndex = 11;
            this.textBox_chapter.TextChanged += new System.EventHandler(this.textBox_chapter_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "搜索章节：";
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
            this.listView2.Location = new System.Drawing.Point(12, 65);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(470, 559);
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
            // ChaptersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 636);
            this.Controls.Add(this.textBox_chapter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.label_novel);
            this.Name = "ChaptersList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "章节列表";
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
    }
}