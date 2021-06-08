
namespace BilibiliProjects
{
    partial class Pictures3
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
            this.myPanel1 = new BilibiliProjects.MyPanel();
            this.button_save = new System.Windows.Forms.Button();
            this.button_pic = new System.Windows.Forms.Button();
            this.button_red = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // myPanel1
            // 
            this.myPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myPanel1.Location = new System.Drawing.Point(11, 11);
            this.myPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(900, 540);
            this.myPanel1.TabIndex = 2;
            this.myPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.myPanel1_Paint);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(826, 555);
            this.button_save.Margin = new System.Windows.Forms.Padding(2);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(85, 26);
            this.button_save.TabIndex = 26;
            this.button_save.Text = "保存当前图片";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_pic
            // 
            this.button_pic.Location = new System.Drawing.Point(11, 555);
            this.button_pic.Margin = new System.Windows.Forms.Padding(2);
            this.button_pic.Name = "button_pic";
            this.button_pic.Size = new System.Drawing.Size(56, 24);
            this.button_pic.TabIndex = 25;
            this.button_pic.Text = "原图";
            this.button_pic.UseVisualStyleBackColor = true;
            this.button_pic.Click += new System.EventHandler(this.button_pic_Click);
            // 
            // button_red
            // 
            this.button_red.Location = new System.Drawing.Point(114, 557);
            this.button_red.Name = "button_red";
            this.button_red.Size = new System.Drawing.Size(75, 23);
            this.button_red.TabIndex = 27;
            this.button_red.Text = "红";
            this.button_red.UseVisualStyleBackColor = true;
            this.button_red.Click += new System.EventHandler(this.button_red_Click);
            // 
            // Pictures3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 706);
            this.Controls.Add(this.button_red);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_pic);
            this.Controls.Add(this.myPanel1);
            this.Name = "Pictures3";
            this.Text = "Pictures3";
            this.ResumeLayout(false);

        }

        #endregion

        private MyPanel myPanel1;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_pic;
        private System.Windows.Forms.Button button_red;
    }
}