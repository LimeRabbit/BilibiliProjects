namespace BilibiliProjects
{
    partial class DrawVertifyCode
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
            this.button_change = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_autorefresh = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // button_change
            // 
            this.button_change.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button_change.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_change.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_change.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_change.ForeColor = System.Drawing.Color.White;
            this.button_change.Location = new System.Drawing.Point(67, 194);
            this.button_change.Name = "button_change";
            this.button_change.Size = new System.Drawing.Size(116, 30);
            this.button_change.TabIndex = 0;
            this.button_change.Text = "更换验证码";
            this.button_change.UseVisualStyleBackColor = false;
            this.button_change.Click += new System.EventHandler(this.button_change_Click);
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_save.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(235, 194);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(83, 30);
            this.button_save.TabIndex = 1;
            this.button_save.Text = "保存图片";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(65, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "验证码位数";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.numericUpDown1.ForeColor = System.Drawing.Color.Aqua;
            this.numericUpDown1.Location = new System.Drawing.Point(136, 164);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(47, 21);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.numericUpDown2.ForeColor = System.Drawing.Color.Aqua;
            this.numericUpDown2.Location = new System.Drawing.Point(271, 164);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(47, 21);
            this.numericUpDown2.TabIndex = 5;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(200, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "干扰线数量";
            // 
            // checkBox_autorefresh
            // 
            this.checkBox_autorefresh.AutoSize = true;
            this.checkBox_autorefresh.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_autorefresh.ForeColor = System.Drawing.Color.Aqua;
            this.checkBox_autorefresh.Location = new System.Drawing.Point(67, 133);
            this.checkBox_autorefresh.Name = "checkBox_autorefresh";
            this.checkBox_autorefresh.Size = new System.Drawing.Size(72, 16);
            this.checkBox_autorefresh.TabIndex = 6;
            this.checkBox_autorefresh.Text = "自动刷新";
            this.checkBox_autorefresh.UseVisualStyleBackColor = false;
            this.checkBox_autorefresh.CheckedChanged += new System.EventHandler(this.checkBox_autorefresh_CheckedChanged);
            // 
            // DrawVertifyCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(405, 240);
            this.Controls.Add(this.checkBox_autorefresh);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_change);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DrawVertifyCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "绘制验证码";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_change;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_autorefresh;
    }
}

