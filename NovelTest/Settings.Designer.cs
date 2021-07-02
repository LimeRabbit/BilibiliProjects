
namespace BilibiliProjects.NovelTest
{
    partial class Settings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_nightmode = new System.Windows.Forms.CheckBox();
            this.checkBox_mycolor = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_forecolor = new System.Windows.Forms.Label();
            this.label_backcolor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_linkcolor = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_autosave = new System.Windows.Forms.CheckBox();
            this.checkBox_compress = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox_font = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar_fontsize = new System.Windows.Forms.TrackBar();
            this.label_scale = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_preview = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_fontsize)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_linkcolor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label_backcolor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label_forecolor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBox_mycolor);
            this.groupBox1.Controls.Add(this.checkBox_nightmode);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "颜色";
            // 
            // checkBox_nightmode
            // 
            this.checkBox_nightmode.AutoSize = true;
            this.checkBox_nightmode.Location = new System.Drawing.Point(6, 20);
            this.checkBox_nightmode.Name = "checkBox_nightmode";
            this.checkBox_nightmode.Size = new System.Drawing.Size(96, 16);
            this.checkBox_nightmode.TabIndex = 0;
            this.checkBox_nightmode.Text = "开启夜间模式";
            this.checkBox_nightmode.UseVisualStyleBackColor = true;
            this.checkBox_nightmode.CheckedChanged += new System.EventHandler(this.checkBox_nightmode_CheckedChanged);
            // 
            // checkBox_mycolor
            // 
            this.checkBox_mycolor.AutoSize = true;
            this.checkBox_mycolor.Location = new System.Drawing.Point(6, 42);
            this.checkBox_mycolor.Name = "checkBox_mycolor";
            this.checkBox_mycolor.Size = new System.Drawing.Size(84, 16);
            this.checkBox_mycolor.TabIndex = 1;
            this.checkBox_mycolor.Text = "自定义颜色";
            this.checkBox_mycolor.UseVisualStyleBackColor = true;
            this.checkBox_mycolor.CheckedChanged += new System.EventHandler(this.checkBox_mycolor_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "文字颜色";
            // 
            // label_forecolor
            // 
            this.label_forecolor.BackColor = System.Drawing.Color.Black;
            this.label_forecolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_forecolor.Enabled = false;
            this.label_forecolor.Location = new System.Drawing.Point(84, 67);
            this.label_forecolor.Name = "label_forecolor";
            this.label_forecolor.Size = new System.Drawing.Size(15, 15);
            this.label_forecolor.TabIndex = 3;
            this.label_forecolor.Click += new System.EventHandler(this.UI_Color_Changed);
            // 
            // label_backcolor
            // 
            this.label_backcolor.BackColor = System.Drawing.SystemColors.Control;
            this.label_backcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_backcolor.Enabled = false;
            this.label_backcolor.Location = new System.Drawing.Point(84, 92);
            this.label_backcolor.Name = "label_backcolor";
            this.label_backcolor.Size = new System.Drawing.Size(15, 15);
            this.label_backcolor.TabIndex = 5;
            this.label_backcolor.Click += new System.EventHandler(this.UI_Color_Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "背景颜色";
            // 
            // label_linkcolor
            // 
            this.label_linkcolor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label_linkcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_linkcolor.Enabled = false;
            this.label_linkcolor.Location = new System.Drawing.Point(108, 117);
            this.label_linkcolor.Name = "label_linkcolor";
            this.label_linkcolor.Size = new System.Drawing.Size(15, 15);
            this.label_linkcolor.TabIndex = 7;
            this.label_linkcolor.Click += new System.EventHandler(this.UI_Color_Changed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "链接文字颜色";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_compress);
            this.groupBox2.Controls.Add(this.checkBox_autosave);
            this.groupBox2.Location = new System.Drawing.Point(173, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 145);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "章节保存";
            // 
            // checkBox_autosave
            // 
            this.checkBox_autosave.AutoSize = true;
            this.checkBox_autosave.Location = new System.Drawing.Point(6, 20);
            this.checkBox_autosave.Name = "checkBox_autosave";
            this.checkBox_autosave.Size = new System.Drawing.Size(192, 16);
            this.checkBox_autosave.TabIndex = 1;
            this.checkBox_autosave.Text = "获取章节成功后自动保存到本地";
            this.checkBox_autosave.UseVisualStyleBackColor = true;
            this.checkBox_autosave.CheckedChanged += new System.EventHandler(this.checkBox_autosave_CheckedChanged);
            // 
            // checkBox_compress
            // 
            this.checkBox_compress.AutoSize = true;
            this.checkBox_compress.Checked = true;
            this.checkBox_compress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_compress.Location = new System.Drawing.Point(6, 42);
            this.checkBox_compress.Name = "checkBox_compress";
            this.checkBox_compress.Size = new System.Drawing.Size(84, 16);
            this.checkBox_compress.TabIndex = 2;
            this.checkBox_compress.Text = "保存时压缩";
            this.checkBox_compress.UseVisualStyleBackColor = true;
            this.checkBox_compress.CheckedChanged += new System.EventHandler(this.checkBox_compress_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_preview);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.trackBar_fontsize);
            this.groupBox3.Controls.Add(this.label_scale);
            this.groupBox3.Controls.Add(this.comboBox_font);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(385, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(235, 145);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "阅读字体";
            // 
            // comboBox_font
            // 
            this.comboBox_font.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_font.FormattingEnabled = true;
            this.comboBox_font.Location = new System.Drawing.Point(37, 17);
            this.comboBox_font.Name = "comboBox_font";
            this.comboBox_font.Size = new System.Drawing.Size(184, 20);
            this.comboBox_font.TabIndex = 25;
            this.comboBox_font.SelectedIndexChanged += new System.EventHandler(this.comboBox_font_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "字体";
            // 
            // trackBar_fontsize
            // 
            this.trackBar_fontsize.AutoSize = false;
            this.trackBar_fontsize.Location = new System.Drawing.Point(65, 45);
            this.trackBar_fontsize.Maximum = 30;
            this.trackBar_fontsize.Minimum = 10;
            this.trackBar_fontsize.Name = "trackBar_fontsize";
            this.trackBar_fontsize.Size = new System.Drawing.Size(156, 20);
            this.trackBar_fontsize.TabIndex = 27;
            this.trackBar_fontsize.TickFrequency = 2;
            this.trackBar_fontsize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_fontsize.Value = 20;
            this.trackBar_fontsize.Scroll += new System.EventHandler(this.trackBar_fontsize_Scroll);
            // 
            // label_scale
            // 
            this.label_scale.AutoSize = true;
            this.label_scale.BackColor = System.Drawing.Color.Transparent;
            this.label_scale.Location = new System.Drawing.Point(6, 50);
            this.label_scale.Name = "label_scale";
            this.label_scale.Size = new System.Drawing.Size(53, 12);
            this.label_scale.TabIndex = 26;
            this.label_scale.Text = "字号：20";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "预览：";
            // 
            // label_preview
            // 
            this.label_preview.AutoSize = true;
            this.label_preview.Location = new System.Drawing.Point(90, 104);
            this.label_preview.Name = "label_preview";
            this.label_preview.Size = new System.Drawing.Size(65, 12);
            this.label_preview.TabIndex = 29;
            this.label_preview.Text = "预览123Abc";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 167);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_fontsize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_nightmode;
        private System.Windows.Forms.CheckBox checkBox_mycolor;
        private System.Windows.Forms.Label label_linkcolor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_backcolor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_forecolor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_compress;
        private System.Windows.Forms.CheckBox checkBox_autosave;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox_font;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar_fontsize;
        private System.Windows.Forms.Label label_scale;
        private System.Windows.Forms.Label label_preview;
        private System.Windows.Forms.Label label5;
    }
}