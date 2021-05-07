namespace BilibiliProjects
{
    partial class LifeGame
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
            this.myPanel1 = new BilibiliProjects.MyPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_bg = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button_clear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.myPanel2 = new BilibiliProjects.MyPanel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // myPanel1
            // 
            this.myPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myPanel1.BackColor = System.Drawing.Color.White;
            this.myPanel1.Location = new System.Drawing.Point(12, 42);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(696, 427);
            this.myPanel1.TabIndex = 0;
            this.myPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.myPanel1_Paint);
            this.myPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.myPanel1_MouseClick);
            this.myPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.myPanel1_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(278, 12);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(90, 23);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 69;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "演化速度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(556, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "颜色";
            // 
            // label_bg
            // 
            this.label_bg.BackColor = System.Drawing.Color.Maroon;
            this.label_bg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_bg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_bg.Location = new System.Drawing.Point(591, 17);
            this.label_bg.Name = "label_bg";
            this.label_bg.Size = new System.Drawing.Size(13, 13);
            this.label_bg.TabIndex = 5;
            this.label_bg.Click += new System.EventHandler(this.label_bg_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(93, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 16);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "随机生成初始细胞";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(633, 12);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 7;
            this.button_clear.Text = "清屏";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(390, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "网格大小";
            // 
            // trackBar2
            // 
            this.trackBar2.AutoSize = false;
            this.trackBar2.Location = new System.Drawing.Point(449, 12);
            this.trackBar2.Maximum = 30;
            this.trackBar2.Minimum = 5;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(90, 23);
            this.trackBar2.TabIndex = 8;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar2.Value = 20;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // myPanel2
            // 
            this.myPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.myPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.myPanel2.Location = new System.Drawing.Point(12, 469);
            this.myPanel2.Name = "myPanel2";
            this.myPanel2.Size = new System.Drawing.Size(200, 24);
            this.myPanel2.TabIndex = 10;
            this.myPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.myPanel2_Paint);
            // 
            // LifeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 494);
            this.Controls.Add(this.myPanel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label_bg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.myPanel1);
            this.Name = "LifeGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生命游戏";
            this.Resize += new System.EventHandler(this.LifeGame_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyPanel myPanel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_bg;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Button button1;
        private MyPanel myPanel2;
    }
}