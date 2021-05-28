
namespace BilibiliProjects
{
    partial class NomalTools
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
            this.label1 = new System.Windows.Forms.Label();
            this.radioT = new System.Windows.Forms.RadioButton();
            this.radioG = new System.Windows.Forms.RadioButton();
            this.radioM = new System.Windows.Forms.RadioButton();
            this.radioK = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.input2 = new BilibiliProjects.HintTextBox();
            this.input1 = new BilibiliProjects.HintTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.check_3D = new System.Windows.Forms.CheckBox();
            this.check_video = new System.Windows.Forms.CheckBox();
            this.check_picture = new System.Windows.Forms.CheckBox();
            this.check_doc = new System.Windows.Forms.CheckBox();
            this.check_download = new System.Windows.Forms.CheckBox();
            this.check_music = new System.Windows.Forms.CheckBox();
            this.check_desktop = new System.Windows.Forms.CheckBox();
            this.button_ok1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.input2);
            this.groupBox1.Controls.Add(this.input1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioT);
            this.groupBox1.Controls.Add(this.radioG);
            this.groupBox1.Controls.Add(this.radioM);
            this.groupBox1.Controls.Add(this.radioK);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "容量转换";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "GB =";
            // 
            // radioT
            // 
            this.radioT.AutoSize = true;
            this.radioT.Location = new System.Drawing.Point(201, 20);
            this.radioT.Name = "radioT";
            this.radioT.Size = new System.Drawing.Size(59, 16);
            this.radioT.TabIndex = 3;
            this.radioT.Tag = "4";
            this.radioT.Text = "TB/TiB";
            this.radioT.UseVisualStyleBackColor = true;
            this.radioT.CheckedChanged += new System.EventHandler(this.RadioStorageChecked);
            // 
            // radioG
            // 
            this.radioG.AutoSize = true;
            this.radioG.Checked = true;
            this.radioG.Location = new System.Drawing.Point(136, 20);
            this.radioG.Name = "radioG";
            this.radioG.Size = new System.Drawing.Size(59, 16);
            this.radioG.TabIndex = 2;
            this.radioG.TabStop = true;
            this.radioG.Tag = "3";
            this.radioG.Text = "GB/GiB";
            this.radioG.UseVisualStyleBackColor = true;
            this.radioG.CheckedChanged += new System.EventHandler(this.RadioStorageChecked);
            // 
            // radioM
            // 
            this.radioM.AutoSize = true;
            this.radioM.Location = new System.Drawing.Point(71, 20);
            this.radioM.Name = "radioM";
            this.radioM.Size = new System.Drawing.Size(59, 16);
            this.radioM.TabIndex = 1;
            this.radioM.Tag = "2";
            this.radioM.Text = "MB/MiB";
            this.radioM.UseVisualStyleBackColor = true;
            this.radioM.CheckedChanged += new System.EventHandler(this.RadioStorageChecked);
            // 
            // radioK
            // 
            this.radioK.AutoSize = true;
            this.radioK.Location = new System.Drawing.Point(6, 20);
            this.radioK.Name = "radioK";
            this.radioK.Size = new System.Drawing.Size(59, 16);
            this.radioK.TabIndex = 0;
            this.radioK.Tag = "1";
            this.radioK.Text = "KB/KiB";
            this.radioK.UseVisualStyleBackColor = true;
            this.radioK.CheckedChanged += new System.EventHandler(this.RadioStorageChecked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "GiB";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(89, 79);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(42, 21);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "保留小数位数";
            // 
            // input2
            // 
            this.input2.HintColor = System.Drawing.Color.Gray;
            this.input2.HintText = null;
            this.input2.InputType = BilibiliProjects.HintInputType.Decimal;
            this.input2.Location = new System.Drawing.Point(113, 42);
            this.input2.Name = "input2";
            this.input2.Size = new System.Drawing.Size(66, 21);
            this.input2.TabIndex = 7;
            this.input2.TextChanged += new System.EventHandler(this.InputTextChanged);
            // 
            // input1
            // 
            this.input1.HintColor = System.Drawing.Color.Gray;
            this.input1.HintText = null;
            this.input1.InputType = BilibiliProjects.HintInputType.Decimal;
            this.input1.Location = new System.Drawing.Point(6, 42);
            this.input1.Name = "input1";
            this.input1.Size = new System.Drawing.Size(66, 21);
            this.input1.TabIndex = 6;
            this.input1.TextChanged += new System.EventHandler(this.InputTextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_ok1);
            this.groupBox2.Controls.Add(this.check_desktop);
            this.groupBox2.Controls.Add(this.check_music);
            this.groupBox2.Controls.Add(this.check_download);
            this.groupBox2.Controls.Add(this.check_doc);
            this.groupBox2.Controls.Add(this.check_picture);
            this.groupBox2.Controls.Add(this.check_video);
            this.groupBox2.Controls.Add(this.check_3D);
            this.groupBox2.Location = new System.Drawing.Point(12, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 99);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "计算机管理";
            // 
            // check_3D
            // 
            this.check_3D.AutoSize = true;
            this.check_3D.Location = new System.Drawing.Point(23, 20);
            this.check_3D.Name = "check_3D";
            this.check_3D.Size = new System.Drawing.Size(60, 16);
            this.check_3D.TabIndex = 0;
            this.check_3D.Text = "3D对象";
            this.check_3D.UseVisualStyleBackColor = true;
            // 
            // check_video
            // 
            this.check_video.AutoSize = true;
            this.check_video.Location = new System.Drawing.Point(89, 20);
            this.check_video.Name = "check_video";
            this.check_video.Size = new System.Drawing.Size(48, 16);
            this.check_video.TabIndex = 1;
            this.check_video.Text = "视频";
            this.check_video.UseVisualStyleBackColor = true;
            // 
            // check_picture
            // 
            this.check_picture.AutoSize = true;
            this.check_picture.Location = new System.Drawing.Point(143, 20);
            this.check_picture.Name = "check_picture";
            this.check_picture.Size = new System.Drawing.Size(48, 16);
            this.check_picture.TabIndex = 2;
            this.check_picture.Text = "图片";
            this.check_picture.UseVisualStyleBackColor = true;
            // 
            // check_doc
            // 
            this.check_doc.AutoSize = true;
            this.check_doc.Location = new System.Drawing.Point(197, 20);
            this.check_doc.Name = "check_doc";
            this.check_doc.Size = new System.Drawing.Size(48, 16);
            this.check_doc.TabIndex = 3;
            this.check_doc.Text = "文档";
            this.check_doc.UseVisualStyleBackColor = true;
            // 
            // check_download
            // 
            this.check_download.AutoSize = true;
            this.check_download.Location = new System.Drawing.Point(23, 42);
            this.check_download.Name = "check_download";
            this.check_download.Size = new System.Drawing.Size(48, 16);
            this.check_download.TabIndex = 4;
            this.check_download.Text = "下载";
            this.check_download.UseVisualStyleBackColor = true;
            // 
            // check_music
            // 
            this.check_music.AutoSize = true;
            this.check_music.Location = new System.Drawing.Point(89, 42);
            this.check_music.Name = "check_music";
            this.check_music.Size = new System.Drawing.Size(48, 16);
            this.check_music.TabIndex = 5;
            this.check_music.Text = "音乐";
            this.check_music.UseVisualStyleBackColor = true;
            // 
            // check_desktop
            // 
            this.check_desktop.AutoSize = true;
            this.check_desktop.Location = new System.Drawing.Point(143, 42);
            this.check_desktop.Name = "check_desktop";
            this.check_desktop.Size = new System.Drawing.Size(48, 16);
            this.check_desktop.TabIndex = 6;
            this.check_desktop.Text = "桌面";
            this.check_desktop.UseVisualStyleBackColor = true;
            // 
            // button_ok1
            // 
            this.button_ok1.Location = new System.Drawing.Point(95, 64);
            this.button_ok1.Name = "button_ok1";
            this.button_ok1.Size = new System.Drawing.Size(75, 23);
            this.button_ok1.TabIndex = 7;
            this.button_ok1.Text = "确定";
            this.button_ok1.UseVisualStyleBackColor = true;
            this.button_ok1.Click += new System.EventHandler(this.button_ok1_Click);
            // 
            // NomalTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NomalTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "常用工具";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioT;
        private System.Windows.Forms.RadioButton radioG;
        private System.Windows.Forms.RadioButton radioM;
        private System.Windows.Forms.RadioButton radioK;
        private HintTextBox input1;
        private System.Windows.Forms.Label label2;
        private HintTextBox input2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_ok1;
        private System.Windows.Forms.CheckBox check_desktop;
        private System.Windows.Forms.CheckBox check_music;
        private System.Windows.Forms.CheckBox check_download;
        private System.Windows.Forms.CheckBox check_doc;
        private System.Windows.Forms.CheckBox check_picture;
        private System.Windows.Forms.CheckBox check_video;
        private System.Windows.Forms.CheckBox check_3D;
    }
}