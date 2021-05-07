namespace BilibiliProjects
{
    partial class ChemicalForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_fontfamily = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar_fontsize = new System.Windows.Forms.TrackBar();
            this.label_fontsize = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_color = new System.Windows.Forms.Label();
            this.label_supcolor = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label_subcolor = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label_equalcolor = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label_conditioncolor = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.hintTextBox_condition = new BilibiliProjects.HintTextBox();
            this.hintTextBox_equal = new BilibiliProjects.HintTextBox();
            this.chemicalEquation1 = new BilibiliProjects.ChemicalEquation();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_fontsize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "方程式";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "反应条件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "字体";
            // 
            // comboBox_fontfamily
            // 
            this.comboBox_fontfamily.DropDownHeight = 180;
            this.comboBox_fontfamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_fontfamily.FormattingEnabled = true;
            this.comboBox_fontfamily.IntegralHeight = false;
            this.comboBox_fontfamily.Location = new System.Drawing.Point(82, 74);
            this.comboBox_fontfamily.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_fontfamily.Name = "comboBox_fontfamily";
            this.comboBox_fontfamily.Size = new System.Drawing.Size(185, 20);
            this.comboBox_fontfamily.TabIndex = 7;
            this.comboBox_fontfamily.SelectedIndexChanged += new System.EventHandler(this.comboBox_fontfamily_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(290, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "字号";
            // 
            // trackBar_fontsize
            // 
            this.trackBar_fontsize.AutoSize = false;
            this.trackBar_fontsize.Location = new System.Drawing.Point(323, 74);
            this.trackBar_fontsize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBar_fontsize.Maximum = 400;
            this.trackBar_fontsize.Minimum = 100;
            this.trackBar_fontsize.Name = "trackBar_fontsize";
            this.trackBar_fontsize.Size = new System.Drawing.Size(173, 18);
            this.trackBar_fontsize.TabIndex = 9;
            this.trackBar_fontsize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_fontsize.Value = 100;
            this.trackBar_fontsize.Scroll += new System.EventHandler(this.trackBar_fontsize_Scroll);
            // 
            // label_fontsize
            // 
            this.label_fontsize.AutoSize = true;
            this.label_fontsize.Location = new System.Drawing.Point(501, 77);
            this.label_fontsize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_fontsize.Name = "label_fontsize";
            this.label_fontsize.Size = new System.Drawing.Size(17, 12);
            this.label_fontsize.TabIndex = 10;
            this.label_fontsize.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "文字颜色";
            // 
            // label_color
            // 
            this.label_color.BackColor = System.Drawing.Color.Green;
            this.label_color.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_color.Location = new System.Drawing.Point(70, 112);
            this.label_color.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_color.Name = "label_color";
            this.label_color.Size = new System.Drawing.Size(11, 12);
            this.label_color.TabIndex = 12;
            this.label_color.Click += new System.EventHandler(this.Color_Clicked);
            // 
            // label_supcolor
            // 
            this.label_supcolor.BackColor = System.Drawing.Color.Purple;
            this.label_supcolor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_supcolor.Location = new System.Drawing.Point(166, 112);
            this.label_supcolor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_supcolor.Name = "label_supcolor";
            this.label_supcolor.Size = new System.Drawing.Size(11, 12);
            this.label_supcolor.TabIndex = 14;
            this.label_supcolor.Click += new System.EventHandler(this.Color_Clicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(112, 112);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "上标颜色";
            // 
            // label_subcolor
            // 
            this.label_subcolor.BackColor = System.Drawing.Color.Blue;
            this.label_subcolor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_subcolor.Location = new System.Drawing.Point(269, 112);
            this.label_subcolor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_subcolor.Name = "label_subcolor";
            this.label_subcolor.Size = new System.Drawing.Size(11, 12);
            this.label_subcolor.TabIndex = 16;
            this.label_subcolor.Click += new System.EventHandler(this.Color_Clicked);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(214, 112);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 15;
            this.label10.Text = "下标颜色";
            // 
            // label_equalcolor
            // 
            this.label_equalcolor.BackColor = System.Drawing.Color.Orange;
            this.label_equalcolor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_equalcolor.Location = new System.Drawing.Point(387, 112);
            this.label_equalcolor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_equalcolor.Name = "label_equalcolor";
            this.label_equalcolor.Size = new System.Drawing.Size(11, 12);
            this.label_equalcolor.TabIndex = 18;
            this.label_equalcolor.Click += new System.EventHandler(this.Color_Clicked);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(321, 112);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 17;
            this.label12.Text = "等于号颜色";
            // 
            // label_conditioncolor
            // 
            this.label_conditioncolor.BackColor = System.Drawing.Color.Magenta;
            this.label_conditioncolor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_conditioncolor.Location = new System.Drawing.Point(507, 112);
            this.label_conditioncolor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_conditioncolor.Name = "label_conditioncolor";
            this.label_conditioncolor.Size = new System.Drawing.Size(11, 12);
            this.label_conditioncolor.TabIndex = 20;
            this.label_conditioncolor.Click += new System.EventHandler(this.Color_Clicked);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(430, 112);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 19;
            this.label14.Text = "反应条件颜色";
            // 
            // hintTextBox_condition
            // 
            this.hintTextBox_condition.HintColor = System.Drawing.Color.Gray;
            this.hintTextBox_condition.HintText = "输入反应条件";
            this.hintTextBox_condition.InputType = BilibiliProjects.HintInputType.All;
            this.hintTextBox_condition.Location = new System.Drawing.Point(82, 42);
            this.hintTextBox_condition.Margin = new System.Windows.Forms.Padding(2);
            this.hintTextBox_condition.Name = "hintTextBox_condition";
            this.hintTextBox_condition.Size = new System.Drawing.Size(184, 21);
            this.hintTextBox_condition.TabIndex = 5;
            this.hintTextBox_condition.TextChanged += new System.EventHandler(this.hintTextBox_condition_TextChanged);
            // 
            // hintTextBox_equal
            // 
            this.hintTextBox_equal.HintColor = System.Drawing.Color.Gray;
            this.hintTextBox_equal.HintText = "输入化学方程式";
            this.hintTextBox_equal.InputType = BilibiliProjects.HintInputType.All;
            this.hintTextBox_equal.Location = new System.Drawing.Point(82, 14);
            this.hintTextBox_equal.Margin = new System.Windows.Forms.Padding(2);
            this.hintTextBox_equal.Name = "hintTextBox_equal";
            this.hintTextBox_equal.Size = new System.Drawing.Size(340, 21);
            this.hintTextBox_equal.TabIndex = 4;
            this.hintTextBox_equal.TextChanged += new System.EventHandler(this.hintTextBox_equal_TextChanged);
            // 
            // chemicalEquation1
            // 
            this.chemicalEquation1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chemicalEquation1.BackColor = System.Drawing.Color.White;
            this.chemicalEquation1.Condition = null;
            this.chemicalEquation1.ConditionColor = System.Drawing.Color.Black;
            this.chemicalEquation1.EqualColor = System.Drawing.Color.Black;
            this.chemicalEquation1.FontColor = System.Drawing.Color.Black;
            this.chemicalEquation1.Location = new System.Drawing.Point(9, 156);
            this.chemicalEquation1.Margin = new System.Windows.Forms.Padding(2);
            this.chemicalEquation1.Name = "chemicalEquation1";
            this.chemicalEquation1.Products = null;
            this.chemicalEquation1.Reactant = null;
            this.chemicalEquation1.Size = new System.Drawing.Size(582, 110);
            this.chemicalEquation1.SubColor = System.Drawing.Color.Black;
            this.chemicalEquation1.SupColor = System.Drawing.Color.Black;
            this.chemicalEquation1.TabIndex = 0;
            // 
            // ChemicalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 280);
            this.Controls.Add(this.label_conditioncolor);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label_equalcolor);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label_subcolor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label_supcolor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label_color);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_fontsize);
            this.Controls.Add(this.trackBar_fontsize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_fontfamily);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hintTextBox_condition);
            this.Controls.Add(this.hintTextBox_equal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chemicalEquation1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ChemicalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "绘制化学方程式";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_fontsize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChemicalEquation chemicalEquation1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private HintTextBox hintTextBox_equal;
        private HintTextBox hintTextBox_condition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_fontfamily;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar_fontsize;
        private System.Windows.Forms.Label label_fontsize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_color;
        private System.Windows.Forms.Label label_supcolor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_subcolor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_equalcolor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label_conditioncolor;
        private System.Windows.Forms.Label label14;
    }
}