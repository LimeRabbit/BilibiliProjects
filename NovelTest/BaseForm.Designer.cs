
namespace BilibiliProjects.NovelTest
{
    partial class BaseForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip_setting = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip_statistics = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip_about = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工具ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(553, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "菜单";
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStrip_setting,
            this.ToolStrip_statistics});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // ToolStrip_setting
            // 
            this.ToolStrip_setting.Name = "ToolStrip_setting";
            this.ToolStrip_setting.Size = new System.Drawing.Size(180, 22);
            this.ToolStrip_setting.Text = "设置";
            this.ToolStrip_setting.Click += new System.EventHandler(this.ToolStrip_setting_Click);
            // 
            // ToolStrip_statistics
            // 
            this.ToolStrip_statistics.Name = "ToolStrip_statistics";
            this.ToolStrip_statistics.Size = new System.Drawing.Size(180, 22);
            this.ToolStrip_statistics.Text = "统计";
            this.ToolStrip_statistics.Click += new System.EventHandler(this.ToolStrip_statistics_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStrip_about});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // ToolStrip_about
            // 
            this.ToolStrip_about.Name = "ToolStrip_about";
            this.ToolStrip_about.Size = new System.Drawing.Size(100, 22);
            this.ToolStrip_about.Text = "关于";
            this.ToolStrip_about.Click += new System.EventHandler(this.ToolStrip_about_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 243);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseForm";
            this.VisibleChanged += new System.EventHandler(this.BaseForm_VisibleChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip_setting;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip_statistics;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip_about;
    }
}