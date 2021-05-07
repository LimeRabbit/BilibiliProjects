namespace BilibiliProjects
{
    partial class MyLabelTest
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
            this.groupBox_mode = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_fontcolor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_fontfamily = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar_fontsize = new System.Windows.Forms.TrackBar();
            this.label_fontsize = new System.Windows.Forms.Label();
            this.label_border_color = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_border_width = new System.Windows.Forms.Label();
            this.trackBar_border_width = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label_shadow_color = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.myLabel1 = new BilibiliProjects.MyLabel();
            this.trackBar_offsetx = new System.Windows.Forms.TrackBar();
            this.label_offsetx = new System.Windows.Forms.Label();
            this.label_offsety = new System.Windows.Forms.Label();
            this.trackBar_offsety = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_projection_value = new System.Windows.Forms.Label();
            this.trackBar_projection_value = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label_projection_color = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox_mode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_fontsize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_border_width)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_offsetx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_offsety)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_projection_value)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_mode
            // 
            this.groupBox_mode.Controls.Add(this.label_fontsize);
            this.groupBox_mode.Controls.Add(this.trackBar_fontsize);
            this.groupBox_mode.Controls.Add(this.label3);
            this.groupBox_mode.Controls.Add(this.comboBox_fontfamily);
            this.groupBox_mode.Controls.Add(this.label2);
            this.groupBox_mode.Controls.Add(this.label_fontcolor);
            this.groupBox_mode.Controls.Add(this.label1);
            this.groupBox_mode.Controls.Add(this.radioButton3);
            this.groupBox_mode.Controls.Add(this.radioButton2);
            this.groupBox_mode.Controls.Add(this.radioButton1);
            this.groupBox_mode.Location = new System.Drawing.Point(12, 118);
            this.groupBox_mode.Name = "groupBox_mode";
            this.groupBox_mode.Size = new System.Drawing.Size(986, 57);
            this.groupBox_mode.TabIndex = 1;
            this.groupBox_mode.TabStop = false;
            this.groupBox_mode.Text = "整体设定";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(134, 24);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(58, 19);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "投影";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.ModeChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(70, 24);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "阴影";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.ModeChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "描边";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.ModeChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_border_width);
            this.groupBox1.Controls.Add(this.trackBar_border_width);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label_border_color);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 82);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "描边设置";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(866, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "字体颜色";
            // 
            // label_fontcolor
            // 
            this.label_fontcolor.BackColor = System.Drawing.Color.Black;
            this.label_fontcolor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_fontcolor.Location = new System.Drawing.Point(939, 26);
            this.label_fontcolor.Name = "label_fontcolor";
            this.label_fontcolor.Size = new System.Drawing.Size(15, 15);
            this.label_fontcolor.TabIndex = 4;
            this.label_fontcolor.Click += new System.EventHandler(this.label_fontcolor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "字体";
            // 
            // comboBox_fontfamily
            // 
            this.comboBox_fontfamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_fontfamily.FormattingEnabled = true;
            this.comboBox_fontfamily.Location = new System.Drawing.Point(288, 23);
            this.comboBox_fontfamily.Name = "comboBox_fontfamily";
            this.comboBox_fontfamily.Size = new System.Drawing.Size(267, 23);
            this.comboBox_fontfamily.TabIndex = 6;
            this.comboBox_fontfamily.SelectedIndexChanged += new System.EventHandler(this.comboBox_fontfamily_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(579, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "字号";
            // 
            // trackBar_fontsize
            // 
            this.trackBar_fontsize.AutoSize = false;
            this.trackBar_fontsize.Location = new System.Drawing.Point(622, 23);
            this.trackBar_fontsize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar_fontsize.Maximum = 1000;
            this.trackBar_fontsize.Minimum = 100;
            this.trackBar_fontsize.Name = "trackBar_fontsize";
            this.trackBar_fontsize.Size = new System.Drawing.Size(163, 22);
            this.trackBar_fontsize.TabIndex = 10;
            this.trackBar_fontsize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_fontsize.Value = 500;
            this.trackBar_fontsize.Scroll += new System.EventHandler(this.trackBar_fontsize_Scroll);
            // 
            // label_fontsize
            // 
            this.label_fontsize.AutoSize = true;
            this.label_fontsize.Location = new System.Drawing.Point(791, 26);
            this.label_fontsize.Name = "label_fontsize";
            this.label_fontsize.Size = new System.Drawing.Size(23, 15);
            this.label_fontsize.TabIndex = 11;
            this.label_fontsize.Text = "50";
            // 
            // label_border_color
            // 
            this.label_border_color.BackColor = System.Drawing.Color.Red;
            this.label_border_color.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_border_color.Location = new System.Drawing.Point(84, 21);
            this.label_border_color.Name = "label_border_color";
            this.label_border_color.Size = new System.Drawing.Size(15, 15);
            this.label_border_color.TabIndex = 6;
            this.label_border_color.Click += new System.EventHandler(this.label_fontcolor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "描边颜色";
            // 
            // label_border_width
            // 
            this.label_border_width.AutoSize = true;
            this.label_border_width.Location = new System.Drawing.Point(256, 55);
            this.label_border_width.Name = "label_border_width";
            this.label_border_width.Size = new System.Drawing.Size(15, 15);
            this.label_border_width.TabIndex = 14;
            this.label_border_width.Text = "3";
            // 
            // trackBar_border_width
            // 
            this.trackBar_border_width.AutoSize = false;
            this.trackBar_border_width.Location = new System.Drawing.Point(87, 52);
            this.trackBar_border_width.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar_border_width.Maximum = 20;
            this.trackBar_border_width.Name = "trackBar_border_width";
            this.trackBar_border_width.Size = new System.Drawing.Size(163, 22);
            this.trackBar_border_width.TabIndex = 13;
            this.trackBar_border_width.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_border_width.Value = 3;
            this.trackBar_border_width.Scroll += new System.EventHandler(this.trackBar_border_width_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "描边宽度";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_offsety);
            this.groupBox2.Controls.Add(this.trackBar_offsety);
            this.groupBox2.Controls.Add(this.label_offsetx);
            this.groupBox2.Controls.Add(this.trackBar_offsetx);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label_shadow_color);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(315, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 126);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "阴影设置";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "阴影偏移量";
            // 
            // label_shadow_color
            // 
            this.label_shadow_color.BackColor = System.Drawing.Color.DimGray;
            this.label_shadow_color.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_shadow_color.Location = new System.Drawing.Point(84, 21);
            this.label_shadow_color.Name = "label_shadow_color";
            this.label_shadow_color.Size = new System.Drawing.Size(15, 15);
            this.label_shadow_color.TabIndex = 6;
            this.label_shadow_color.Click += new System.EventHandler(this.label_fontcolor_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "阴影颜色";
            // 
            // myLabel1
            // 
            this.myLabel1.AutoSize = true;
            this.myLabel1.BackColor = System.Drawing.Color.White;
            this.myLabel1.BorderColor = System.Drawing.Color.Red;
            this.myLabel1.BorderWidth = 10;
            this.myLabel1.EffectMode = BilibiliProjects.Effects.Border;
            this.myLabel1.Font = new System.Drawing.Font("楷体", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myLabel1.ForeColor = System.Drawing.Color.Lime;
            this.myLabel1.Location = new System.Drawing.Point(12, 316);
            this.myLabel1.Name = "myLabel1";
            this.myLabel1.ProjectionColor = System.Drawing.Color.Blue;
            this.myLabel1.ShadowColor = System.Drawing.Color.Goldenrod;
            this.myLabel1.ShadowOffsetX = 10F;
            this.myLabel1.ShadowOffsetY = 10F;
            this.myLabel1.Size = new System.Drawing.Size(371, 84);
            this.myLabel1.TabIndex = 0;
            this.myLabel1.Text = "测试文本";
            // 
            // trackBar_offsetx
            // 
            this.trackBar_offsetx.AutoSize = false;
            this.trackBar_offsetx.Location = new System.Drawing.Point(99, 52);
            this.trackBar_offsetx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar_offsetx.Maximum = 200;
            this.trackBar_offsetx.Name = "trackBar_offsetx";
            this.trackBar_offsetx.Size = new System.Drawing.Size(163, 22);
            this.trackBar_offsetx.TabIndex = 14;
            this.trackBar_offsetx.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_offsetx.Value = 150;
            this.trackBar_offsetx.Scroll += new System.EventHandler(this.ShadowOffsetChanged);
            // 
            // label_offsetx
            // 
            this.label_offsetx.AutoSize = true;
            this.label_offsetx.Location = new System.Drawing.Point(268, 55);
            this.label_offsetx.Name = "label_offsetx";
            this.label_offsetx.Size = new System.Drawing.Size(31, 15);
            this.label_offsetx.TabIndex = 15;
            this.label_offsetx.Text = "x=5";
            // 
            // label_offsety
            // 
            this.label_offsety.AutoSize = true;
            this.label_offsety.Location = new System.Drawing.Point(268, 81);
            this.label_offsety.Name = "label_offsety";
            this.label_offsety.Size = new System.Drawing.Size(31, 15);
            this.label_offsety.TabIndex = 17;
            this.label_offsety.Text = "y=5";
            // 
            // trackBar_offsety
            // 
            this.trackBar_offsety.AutoSize = false;
            this.trackBar_offsety.Location = new System.Drawing.Point(99, 78);
            this.trackBar_offsety.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar_offsety.Maximum = 200;
            this.trackBar_offsety.Name = "trackBar_offsety";
            this.trackBar_offsety.Size = new System.Drawing.Size(163, 22);
            this.trackBar_offsety.TabIndex = 16;
            this.trackBar_offsety.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_offsety.Value = 150;
            this.trackBar_offsety.Scroll += new System.EventHandler(this.ShadowOffsetChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_projection_value);
            this.groupBox3.Controls.Add(this.trackBar_projection_value);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label_projection_color);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(684, 181);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(314, 82);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "投影设置";
            // 
            // label_projection_value
            // 
            this.label_projection_value.AutoSize = true;
            this.label_projection_value.Location = new System.Drawing.Point(256, 55);
            this.label_projection_value.Name = "label_projection_value";
            this.label_projection_value.Size = new System.Drawing.Size(23, 15);
            this.label_projection_value.TabIndex = 14;
            this.label_projection_value.Text = "-1";
            // 
            // trackBar_projection_value
            // 
            this.trackBar_projection_value.AutoSize = false;
            this.trackBar_projection_value.Location = new System.Drawing.Point(87, 52);
            this.trackBar_projection_value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar_projection_value.Maximum = 200;
            this.trackBar_projection_value.Name = "trackBar_projection_value";
            this.trackBar_projection_value.Size = new System.Drawing.Size(163, 22);
            this.trackBar_projection_value.TabIndex = 13;
            this.trackBar_projection_value.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_projection_value.Scroll += new System.EventHandler(this.trackBar_projection_value_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "投影值";
            // 
            // label_projection_color
            // 
            this.label_projection_color.BackColor = System.Drawing.Color.Aqua;
            this.label_projection_color.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_projection_color.Location = new System.Drawing.Point(84, 21);
            this.label_projection_color.Name = "label_projection_color";
            this.label_projection_color.Size = new System.Drawing.Size(15, 15);
            this.label_projection_color.TabIndex = 6;
            this.label_projection_color.Click += new System.EventHandler(this.label_fontcolor_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "投影颜色";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.richTextBox1);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(986, 100);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "显示文本";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(6, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(974, 70);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "测试文本";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // MyLabelTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 677);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_mode);
            this.Controls.Add(this.myLabel1);
            this.Name = "MyLabelTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文字特效演示";
            this.groupBox_mode.ResumeLayout(false);
            this.groupBox_mode.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_fontsize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_border_width)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_offsetx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_offsety)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_projection_value)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyLabel myLabel1;
        private System.Windows.Forms.GroupBox groupBox_mode;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_fontcolor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_fontfamily;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar_fontsize;
        private System.Windows.Forms.Label label_fontsize;
        private System.Windows.Forms.Label label_border_color;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_border_width;
        private System.Windows.Forms.TrackBar trackBar_border_width;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_shadow_color;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_offsety;
        private System.Windows.Forms.TrackBar trackBar_offsety;
        private System.Windows.Forms.Label label_offsetx;
        private System.Windows.Forms.TrackBar trackBar_offsetx;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label_projection_value;
        private System.Windows.Forms.TrackBar trackBar_projection_value;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_projection_color;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}