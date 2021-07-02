
namespace BilibiliProjects.NovelTest
{
    partial class ProgressForm
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_tip = new System.Windows.Forms.Label();
            this.label_process = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 28);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(480, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 0;
            // 
            // label_tip
            // 
            this.label_tip.AutoSize = true;
            this.label_tip.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_tip.Location = new System.Drawing.Point(213, 9);
            this.label_tip.Name = "label_tip";
            this.label_tip.Size = new System.Drawing.Size(93, 16);
            this.label_tip.TabIndex = 1;
            this.label_tip.Text = "保存中……";
            // 
            // label_process
            // 
            this.label_process.AutoSize = true;
            this.label_process.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_process.Location = new System.Drawing.Point(235, 54);
            this.label_process.Name = "label_process";
            this.label_process.Size = new System.Drawing.Size(26, 16);
            this.label_process.TabIndex = 2;
            this.label_process.Text = "1%";
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 81);
            this.ControlBox = false;
            this.Controls.Add(this.label_process);
            this.Controls.Add(this.label_tip);
            this.Controls.Add(this.progressBar1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(520, 120);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(520, 120);
            this.Name = "ProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "进度窗口";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label_tip;
        private System.Windows.Forms.Label label_process;
    }
}