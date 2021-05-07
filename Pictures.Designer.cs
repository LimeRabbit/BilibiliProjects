namespace BilibiliProjects
{
    partial class Pictures
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
            this.button_pic = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_current_bright = new System.Windows.Forms.Label();
            this.trackBar_bright = new System.Windows.Forms.TrackBar();
            this.button_gray = new System.Windows.Forms.Button();
            this.button_reverse = new System.Windows.Forms.Button();
            this.button_mosaic = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_mosaic_size = new System.Windows.Forms.Label();
            this.trackBar_mosaic = new System.Windows.Forms.TrackBar();
            this.button_bright = new System.Windows.Forms.Button();
            this.button_color = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton_red = new System.Windows.Forms.RadioButton();
            this.radioButton_green = new System.Windows.Forms.RadioButton();
            this.radioButton_blue = new System.Windows.Forms.RadioButton();
            this.radioButton_yellow = new System.Windows.Forms.RadioButton();
            this.radioButton_purple = new System.Windows.Forms.RadioButton();
            this.radioButton_cyan = new System.Windows.Forms.RadioButton();
            this.button_save = new System.Windows.Forms.Button();
            this.button_relief = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label_power_r = new System.Windows.Forms.Label();
            this.trackBar_power_r = new System.Windows.Forms.TrackBar();
            this.label_power_g = new System.Windows.Forms.Label();
            this.trackBar_power_g = new System.Windows.Forms.TrackBar();
            this.label_power_b = new System.Windows.Forms.Label();
            this.trackBar_power_b = new System.Windows.Forms.TrackBar();
            this.myPanel1 = new BilibiliProjects.MyPanel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_bright)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_mosaic)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_power_r)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_power_g)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_power_b)).BeginInit();
            this.SuspendLayout();
            // 
            // button_pic
            // 
            this.button_pic.Location = new System.Drawing.Point(12, 706);
            this.button_pic.Name = "button_pic";
            this.button_pic.Size = new System.Drawing.Size(75, 30);
            this.button_pic.TabIndex = 1;
            this.button_pic.Text = "原图";
            this.button_pic.UseVisualStyleBackColor = true;
            this.button_pic.Click += new System.EventHandler(this.button_pic_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_current_bright);
            this.groupBox1.Controls.Add(this.trackBar_bright);
            this.groupBox1.Location = new System.Drawing.Point(274, 708);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 87);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "亮度调节(基于原图)";
            this.groupBox1.Visible = false;
            // 
            // label_current_bright
            // 
            this.label_current_bright.AutoSize = true;
            this.label_current_bright.Location = new System.Drawing.Point(17, 48);
            this.label_current_bright.Name = "label_current_bright";
            this.label_current_bright.Size = new System.Drawing.Size(114, 15);
            this.label_current_bright.TabIndex = 1;
            this.label_current_bright.Text = "当前亮度：100%";
            // 
            // trackBar_bright
            // 
            this.trackBar_bright.AutoSize = false;
            this.trackBar_bright.Location = new System.Drawing.Point(6, 25);
            this.trackBar_bright.Maximum = 20;
            this.trackBar_bright.Name = "trackBar_bright";
            this.trackBar_bright.Size = new System.Drawing.Size(251, 20);
            this.trackBar_bright.TabIndex = 0;
            this.trackBar_bright.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_bright.Value = 10;
            this.trackBar_bright.Scroll += new System.EventHandler(this.trackBar_bright_Scroll);
            // 
            // button_gray
            // 
            this.button_gray.Location = new System.Drawing.Point(150, 818);
            this.button_gray.Name = "button_gray";
            this.button_gray.Size = new System.Drawing.Size(75, 30);
            this.button_gray.TabIndex = 3;
            this.button_gray.Text = "灰度";
            this.button_gray.UseVisualStyleBackColor = true;
            this.button_gray.Click += new System.EventHandler(this.button_gray_Click);
            // 
            // button_reverse
            // 
            this.button_reverse.Location = new System.Drawing.Point(12, 742);
            this.button_reverse.Name = "button_reverse";
            this.button_reverse.Size = new System.Drawing.Size(75, 30);
            this.button_reverse.TabIndex = 4;
            this.button_reverse.Text = "反色";
            this.button_reverse.UseVisualStyleBackColor = true;
            this.button_reverse.Click += new System.EventHandler(this.button_reverse_Click);
            // 
            // button_mosaic
            // 
            this.button_mosaic.Location = new System.Drawing.Point(150, 706);
            this.button_mosaic.Name = "button_mosaic";
            this.button_mosaic.Size = new System.Drawing.Size(118, 30);
            this.button_mosaic.TabIndex = 5;
            this.button_mosaic.Text = "马赛克";
            this.button_mosaic.UseVisualStyleBackColor = true;
            this.button_mosaic.Click += new System.EventHandler(this.Button_mosaic_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_mosaic_size);
            this.groupBox2.Controls.Add(this.trackBar_mosaic);
            this.groupBox2.Location = new System.Drawing.Point(274, 801);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 87);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "马赛克调节";
            this.groupBox2.Visible = false;
            // 
            // label_mosaic_size
            // 
            this.label_mosaic_size.AutoSize = true;
            this.label_mosaic_size.Location = new System.Drawing.Point(17, 48);
            this.label_mosaic_size.Name = "label_mosaic_size";
            this.label_mosaic_size.Size = new System.Drawing.Size(98, 15);
            this.label_mosaic_size.TabIndex = 1;
            this.label_mosaic_size.Text = "方格大小：10";
            // 
            // trackBar_mosaic
            // 
            this.trackBar_mosaic.AutoSize = false;
            this.trackBar_mosaic.Location = new System.Drawing.Point(6, 25);
            this.trackBar_mosaic.Maximum = 40;
            this.trackBar_mosaic.Minimum = 5;
            this.trackBar_mosaic.Name = "trackBar_mosaic";
            this.trackBar_mosaic.Size = new System.Drawing.Size(251, 20);
            this.trackBar_mosaic.TabIndex = 0;
            this.trackBar_mosaic.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_mosaic.Value = 10;
            this.trackBar_mosaic.Scroll += new System.EventHandler(this.trackBar_mosaic_Scroll);
            // 
            // button_bright
            // 
            this.button_bright.Location = new System.Drawing.Point(150, 744);
            this.button_bright.Name = "button_bright";
            this.button_bright.Size = new System.Drawing.Size(118, 30);
            this.button_bright.TabIndex = 7;
            this.button_bright.Text = "亮度调节";
            this.button_bright.UseVisualStyleBackColor = true;
            this.button_bright.Click += new System.EventHandler(this.button_bright_Click);
            // 
            // button_color
            // 
            this.button_color.Location = new System.Drawing.Point(150, 780);
            this.button_color.Name = "button_color";
            this.button_color.Size = new System.Drawing.Size(118, 30);
            this.button_color.TabIndex = 8;
            this.button_color.Text = "颜色滤镜";
            this.button_color.UseVisualStyleBackColor = true;
            this.button_color.Click += new System.EventHandler(this.button_color_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton_cyan);
            this.groupBox3.Controls.Add(this.radioButton_purple);
            this.groupBox3.Controls.Add(this.radioButton_yellow);
            this.groupBox3.Controls.Add(this.radioButton_blue);
            this.groupBox3.Controls.Add(this.radioButton_green);
            this.groupBox3.Controls.Add(this.radioButton_red);
            this.groupBox3.Location = new System.Drawing.Point(543, 708);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 87);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "颜色滤镜";
            this.groupBox3.Visible = false;
            // 
            // radioButton_red
            // 
            this.radioButton_red.AutoSize = true;
            this.radioButton_red.Checked = true;
            this.radioButton_red.Location = new System.Drawing.Point(6, 26);
            this.radioButton_red.Name = "radioButton_red";
            this.radioButton_red.Size = new System.Drawing.Size(58, 19);
            this.radioButton_red.TabIndex = 0;
            this.radioButton_red.Text = "红色";
            this.radioButton_red.UseVisualStyleBackColor = true;
            this.radioButton_red.CheckedChanged += new System.EventHandler(this.Lvjing_checked);
            // 
            // radioButton_green
            // 
            this.radioButton_green.AutoSize = true;
            this.radioButton_green.Location = new System.Drawing.Point(70, 26);
            this.radioButton_green.Name = "radioButton_green";
            this.radioButton_green.Size = new System.Drawing.Size(58, 19);
            this.radioButton_green.TabIndex = 1;
            this.radioButton_green.Text = "绿色";
            this.radioButton_green.UseVisualStyleBackColor = true;
            this.radioButton_green.CheckedChanged += new System.EventHandler(this.Lvjing_checked);
            // 
            // radioButton_blue
            // 
            this.radioButton_blue.AutoSize = true;
            this.radioButton_blue.Location = new System.Drawing.Point(134, 26);
            this.radioButton_blue.Name = "radioButton_blue";
            this.radioButton_blue.Size = new System.Drawing.Size(58, 19);
            this.radioButton_blue.TabIndex = 2;
            this.radioButton_blue.Text = "蓝色";
            this.radioButton_blue.UseVisualStyleBackColor = true;
            this.radioButton_blue.CheckedChanged += new System.EventHandler(this.Lvjing_checked);
            // 
            // radioButton_yellow
            // 
            this.radioButton_yellow.AutoSize = true;
            this.radioButton_yellow.Location = new System.Drawing.Point(6, 51);
            this.radioButton_yellow.Name = "radioButton_yellow";
            this.radioButton_yellow.Size = new System.Drawing.Size(66, 19);
            this.radioButton_yellow.TabIndex = 3;
            this.radioButton_yellow.Text = "红+绿";
            this.radioButton_yellow.UseVisualStyleBackColor = true;
            this.radioButton_yellow.CheckedChanged += new System.EventHandler(this.Lvjing_checked);
            // 
            // radioButton_purple
            // 
            this.radioButton_purple.AutoSize = true;
            this.radioButton_purple.Location = new System.Drawing.Point(78, 51);
            this.radioButton_purple.Name = "radioButton_purple";
            this.radioButton_purple.Size = new System.Drawing.Size(66, 19);
            this.radioButton_purple.TabIndex = 4;
            this.radioButton_purple.Text = "红+蓝";
            this.radioButton_purple.UseVisualStyleBackColor = true;
            this.radioButton_purple.CheckedChanged += new System.EventHandler(this.Lvjing_checked);
            // 
            // radioButton_cyan
            // 
            this.radioButton_cyan.AutoSize = true;
            this.radioButton_cyan.Location = new System.Drawing.Point(147, 51);
            this.radioButton_cyan.Name = "radioButton_cyan";
            this.radioButton_cyan.Size = new System.Drawing.Size(66, 19);
            this.radioButton_cyan.TabIndex = 5;
            this.radioButton_cyan.Text = "绿+蓝";
            this.radioButton_cyan.UseVisualStyleBackColor = true;
            this.radioButton_cyan.CheckedChanged += new System.EventHandler(this.Lvjing_checked);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(1099, 693);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(113, 33);
            this.button_save.TabIndex = 9;
            this.button_save.Text = "保存当前图片";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_relief
            // 
            this.button_relief.Location = new System.Drawing.Point(12, 778);
            this.button_relief.Name = "button_relief";
            this.button_relief.Size = new System.Drawing.Size(75, 30);
            this.button_relief.TabIndex = 10;
            this.button_relief.Text = "浮雕";
            this.button_relief.UseVisualStyleBackColor = true;
            this.button_relief.Click += new System.EventHandler(this.button_relief_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label_power_b);
            this.groupBox4.Controls.Add(this.trackBar_power_b);
            this.groupBox4.Controls.Add(this.label_power_g);
            this.groupBox4.Controls.Add(this.trackBar_power_g);
            this.groupBox4.Controls.Add(this.label_power_r);
            this.groupBox4.Controls.Add(this.trackBar_power_r);
            this.groupBox4.Location = new System.Drawing.Point(543, 801);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(205, 106);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "灰度效果加权";
            this.groupBox4.Visible = false;
            // 
            // label_power_r
            // 
            this.label_power_r.AutoSize = true;
            this.label_power_r.Location = new System.Drawing.Point(140, 28);
            this.label_power_r.Name = "label_power_r";
            this.label_power_r.Size = new System.Drawing.Size(54, 15);
            this.label_power_r.TabIndex = 1;
            this.label_power_r.Text = "R：0.7";
            // 
            // trackBar_power_r
            // 
            this.trackBar_power_r.AutoSize = false;
            this.trackBar_power_r.Location = new System.Drawing.Point(6, 25);
            this.trackBar_power_r.Name = "trackBar_power_r";
            this.trackBar_power_r.Size = new System.Drawing.Size(128, 20);
            this.trackBar_power_r.TabIndex = 0;
            this.trackBar_power_r.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_power_r.Value = 7;
            this.trackBar_power_r.ValueChanged += new System.EventHandler(this.Gray_power_changed);
            // 
            // label_power_g
            // 
            this.label_power_g.AutoSize = true;
            this.label_power_g.Location = new System.Drawing.Point(140, 53);
            this.label_power_g.Name = "label_power_g";
            this.label_power_g.Size = new System.Drawing.Size(54, 15);
            this.label_power_g.TabIndex = 3;
            this.label_power_g.Text = "G：0.2";
            // 
            // trackBar_power_g
            // 
            this.trackBar_power_g.AutoSize = false;
            this.trackBar_power_g.Location = new System.Drawing.Point(6, 50);
            this.trackBar_power_g.Name = "trackBar_power_g";
            this.trackBar_power_g.Size = new System.Drawing.Size(128, 20);
            this.trackBar_power_g.TabIndex = 2;
            this.trackBar_power_g.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_power_g.Value = 2;
            this.trackBar_power_g.ValueChanged += new System.EventHandler(this.Gray_power_changed);
            // 
            // label_power_b
            // 
            this.label_power_b.AutoSize = true;
            this.label_power_b.Location = new System.Drawing.Point(140, 79);
            this.label_power_b.Name = "label_power_b";
            this.label_power_b.Size = new System.Drawing.Size(54, 15);
            this.label_power_b.TabIndex = 5;
            this.label_power_b.Text = "B：0.1";
            // 
            // trackBar_power_b
            // 
            this.trackBar_power_b.AutoSize = false;
            this.trackBar_power_b.Location = new System.Drawing.Point(6, 76);
            this.trackBar_power_b.Name = "trackBar_power_b";
            this.trackBar_power_b.Size = new System.Drawing.Size(128, 20);
            this.trackBar_power_b.TabIndex = 4;
            this.trackBar_power_b.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_power_b.Value = 1;
            this.trackBar_power_b.ValueChanged += new System.EventHandler(this.Gray_power_changed);
            // 
            // myPanel1
            // 
            this.myPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myPanel1.Location = new System.Drawing.Point(12, 12);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(1200, 675);
            this.myPanel1.TabIndex = 0;
            this.myPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.myPanel1_Paint);
            // 
            // Pictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 900);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button_relief);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button_color);
            this.Controls.Add(this.button_bright);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_mosaic);
            this.Controls.Add(this.button_reverse);
            this.Controls.Add(this.button_gray);
            this.Controls.Add(this.button_pic);
            this.Controls.Add(this.myPanel1);
            this.Name = "Pictures";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片处理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_bright)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_mosaic)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_power_r)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_power_g)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_power_b)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyPanel myPanel1;
        private System.Windows.Forms.Button button_pic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_current_bright;
        private System.Windows.Forms.TrackBar trackBar_bright;
        private System.Windows.Forms.Button button_gray;
        private System.Windows.Forms.Button button_reverse;
        private System.Windows.Forms.Button button_mosaic;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_mosaic_size;
        private System.Windows.Forms.TrackBar trackBar_mosaic;
        private System.Windows.Forms.Button button_bright;
        private System.Windows.Forms.Button button_color;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton_blue;
        private System.Windows.Forms.RadioButton radioButton_green;
        private System.Windows.Forms.RadioButton radioButton_red;
        private System.Windows.Forms.RadioButton radioButton_cyan;
        private System.Windows.Forms.RadioButton radioButton_purple;
        private System.Windows.Forms.RadioButton radioButton_yellow;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_relief;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label_power_b;
        private System.Windows.Forms.TrackBar trackBar_power_b;
        private System.Windows.Forms.Label label_power_g;
        private System.Windows.Forms.TrackBar trackBar_power_g;
        private System.Windows.Forms.Label label_power_r;
        private System.Windows.Forms.TrackBar trackBar_power_r;
    }
}