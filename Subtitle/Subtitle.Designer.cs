
namespace BilibiliProjects
{
    partial class Subtitle
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
            this.textBox_filename = new System.Windows.Forms.TextBox();
            this.button_scan = new System.Windows.Forms.Button();
            this.label_sep = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_font = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_italic = new System.Windows.Forms.Label();
            this.label_bold = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_fontsize = new BilibiliProjects.HintTextBox();
            this.panel = new BilibiliProjects.MyPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_bg_alpha = new BilibiliProjects.HintTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label_bgcolor = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label_strokecolor2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label_txtcolor2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label_strokecolor1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label_txtcolor1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_offsety = new BilibiliProjects.HintTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBox_Y = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox_offsetx = new BilibiliProjects.HintTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBox_X = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_strokewidth = new BilibiliProjects.HintTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_height = new BilibiliProjects.HintTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_width = new BilibiliProjects.HintTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_saveFolder = new System.Windows.Forms.TextBox();
            this.button_scan2 = new System.Windows.Forms.Button();
            this.comboBox_format = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox_picname = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择文本";
            // 
            // textBox_filename
            // 
            this.textBox_filename.Location = new System.Drawing.Point(71, 6);
            this.textBox_filename.Name = "textBox_filename";
            this.textBox_filename.Size = new System.Drawing.Size(368, 21);
            this.textBox_filename.TabIndex = 1;
            this.textBox_filename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_filename_KeyDown);
            // 
            // button_scan
            // 
            this.button_scan.Location = new System.Drawing.Point(445, 4);
            this.button_scan.Name = "button_scan";
            this.button_scan.Size = new System.Drawing.Size(58, 23);
            this.button_scan.TabIndex = 2;
            this.button_scan.Text = "选择";
            this.button_scan.UseVisualStyleBackColor = true;
            this.button_scan.Click += new System.EventHandler(this.button_scan_Click);
            // 
            // label_sep
            // 
            this.label_sep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_sep.BackColor = System.Drawing.Color.DarkViolet;
            this.label_sep.Location = new System.Drawing.Point(12, 136);
            this.label_sep.Name = "label_sep";
            this.label_sep.Size = new System.Drawing.Size(1160, 1);
            this.label_sep.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(14, 161);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(320, 509);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            this.columnHeader1.Width = 46;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "内容";
            this.columnHeader2.Width = 142;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "第二行内容";
            this.columnHeader3.Width = 120;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "内容";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "预览";
            // 
            // comboBox_font
            // 
            this.comboBox_font.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_font.FormattingEnabled = true;
            this.comboBox_font.Location = new System.Drawing.Point(6, 29);
            this.comboBox_font.Name = "comboBox_font";
            this.comboBox_font.Size = new System.Drawing.Size(122, 20);
            this.comboBox_font.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_italic);
            this.groupBox1.Controls.Add(this.label_bold);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_fontsize);
            this.groupBox1.Controls.Add(this.comboBox_font);
            this.groupBox1.Location = new System.Drawing.Point(14, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "字体";
            // 
            // label_italic
            // 
            this.label_italic.AutoSize = true;
            this.label_italic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_italic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_italic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_italic.Font = new System.Drawing.Font("黑体", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_italic.Location = new System.Drawing.Point(109, 60);
            this.label_italic.Name = "label_italic";
            this.label_italic.Size = new System.Drawing.Size(19, 18);
            this.label_italic.TabIndex = 12;
            this.label_italic.Text = "I";
            this.label_italic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_bold
            // 
            this.label_bold.AutoSize = true;
            this.label_bold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_bold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_bold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_bold.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_bold.Location = new System.Drawing.Point(84, 60);
            this.label_bold.Name = "label_bold";
            this.label_bold.Size = new System.Drawing.Size(19, 18);
            this.label_bold.TabIndex = 11;
            this.label_bold.Text = "B";
            this.label_bold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "字号";
            // 
            // textBox_fontsize
            // 
            this.textBox_fontsize.HintColor = System.Drawing.Color.Gray;
            this.textBox_fontsize.HintText = null;
            this.textBox_fontsize.InputType = BilibiliProjects.HintInputType.Number;
            this.textBox_fontsize.Location = new System.Drawing.Point(41, 59);
            this.textBox_fontsize.Name = "textBox_fontsize";
            this.textBox_fontsize.Size = new System.Drawing.Size(29, 21);
            this.textBox_fontsize.TabIndex = 9;
            this.textBox_fontsize.Text = "50";
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Location = new System.Drawing.Point(352, 161);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(820, 509);
            this.panel.TabIndex = 9;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_strokewidth);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_bg_alpha);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label_bgcolor);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label_strokecolor2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label_txtcolor2);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label_strokecolor1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label_txtcolor1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(160, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "颜色";
            // 
            // textBox_bg_alpha
            // 
            this.textBox_bg_alpha.HintColor = System.Drawing.Color.Gray;
            this.textBox_bg_alpha.HintText = null;
            this.textBox_bg_alpha.InputType = BilibiliProjects.HintInputType.Number;
            this.textBox_bg_alpha.Location = new System.Drawing.Point(156, 54);
            this.textBox_bg_alpha.Name = "textBox_bg_alpha";
            this.textBox_bg_alpha.Size = new System.Drawing.Size(29, 21);
            this.textBox_bg_alpha.TabIndex = 11;
            this.textBox_bg_alpha.Text = "50";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(90, 58);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 10;
            this.label15.Text = "背景透明度";
            // 
            // label_bgcolor
            // 
            this.label_bgcolor.BackColor = System.Drawing.Color.Gray;
            this.label_bgcolor.Location = new System.Drawing.Point(70, 58);
            this.label_bgcolor.Name = "label_bgcolor";
            this.label_bgcolor.Size = new System.Drawing.Size(15, 15);
            this.label_bgcolor.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "文字背景色";
            // 
            // label_strokecolor2
            // 
            this.label_strokecolor2.BackColor = System.Drawing.Color.Blue;
            this.label_strokecolor2.Location = new System.Drawing.Point(154, 37);
            this.label_strokecolor2.Name = "label_strokecolor2";
            this.label_strokecolor2.Size = new System.Drawing.Size(15, 15);
            this.label_strokecolor2.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(90, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "第二行描边";
            // 
            // label_txtcolor2
            // 
            this.label_txtcolor2.BackColor = System.Drawing.Color.Red;
            this.label_txtcolor2.Location = new System.Drawing.Point(70, 37);
            this.label_txtcolor2.Name = "label_txtcolor2";
            this.label_txtcolor2.Size = new System.Drawing.Size(15, 15);
            this.label_txtcolor2.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "第二行颜色";
            // 
            // label_strokecolor1
            // 
            this.label_strokecolor1.BackColor = System.Drawing.Color.Blue;
            this.label_strokecolor1.Location = new System.Drawing.Point(142, 17);
            this.label_strokecolor1.Name = "label_strokecolor1";
            this.label_strokecolor1.Size = new System.Drawing.Size(15, 15);
            this.label_strokecolor1.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(90, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "描边颜色";
            // 
            // label_txtcolor1
            // 
            this.label_txtcolor1.BackColor = System.Drawing.Color.Red;
            this.label_txtcolor1.Location = new System.Drawing.Point(58, 17);
            this.label_txtcolor1.Name = "label_txtcolor1";
            this.label_txtcolor1.Size = new System.Drawing.Size(15, 15);
            this.label_txtcolor1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "文字颜色";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_offsety);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.comboBox_Y);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.textBox_offsetx);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.comboBox_X);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Location = new System.Drawing.Point(366, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "位置";
            // 
            // textBox_offsety
            // 
            this.textBox_offsety.HintColor = System.Drawing.Color.Gray;
            this.textBox_offsety.HintText = null;
            this.textBox_offsety.InputType = BilibiliProjects.HintInputType.Number;
            this.textBox_offsety.Location = new System.Drawing.Point(149, 56);
            this.textBox_offsety.Name = "textBox_offsety";
            this.textBox_offsety.Size = new System.Drawing.Size(29, 21);
            this.textBox_offsety.TabIndex = 16;
            this.textBox_offsety.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(114, 59);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 15;
            this.label18.Text = "偏移";
            // 
            // comboBox_Y
            // 
            this.comboBox_Y.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Y.FormattingEnabled = true;
            this.comboBox_Y.Items.AddRange(new object[] {
            "上",
            "中",
            "下"});
            this.comboBox_Y.Location = new System.Drawing.Point(65, 56);
            this.comboBox_Y.Name = "comboBox_Y";
            this.comboBox_Y.Size = new System.Drawing.Size(43, 20);
            this.comboBox_Y.TabIndex = 14;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 59);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 13;
            this.label19.Text = "纵向位置";
            // 
            // textBox_offsetx
            // 
            this.textBox_offsetx.HintColor = System.Drawing.Color.Gray;
            this.textBox_offsetx.HintText = null;
            this.textBox_offsetx.InputType = BilibiliProjects.HintInputType.Number;
            this.textBox_offsetx.Location = new System.Drawing.Point(149, 24);
            this.textBox_offsetx.Name = "textBox_offsetx";
            this.textBox_offsetx.Size = new System.Drawing.Size(29, 21);
            this.textBox_offsetx.TabIndex = 12;
            this.textBox_offsetx.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(114, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 9;
            this.label17.Text = "偏移";
            // 
            // comboBox_X
            // 
            this.comboBox_X.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_X.FormattingEnabled = true;
            this.comboBox_X.Items.AddRange(new object[] {
            "左",
            "中",
            "右"});
            this.comboBox_X.Location = new System.Drawing.Point(65, 24);
            this.comboBox_X.Name = "comboBox_X";
            this.comboBox_X.Size = new System.Drawing.Size(43, 20);
            this.comboBox_X.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "横向位置";
            // 
            // textBox_strokewidth
            // 
            this.textBox_strokewidth.HintColor = System.Drawing.Color.Gray;
            this.textBox_strokewidth.HintText = null;
            this.textBox_strokewidth.InputType = BilibiliProjects.HintInputType.Decimal;
            this.textBox_strokewidth.Location = new System.Drawing.Point(65, 76);
            this.textBox_strokewidth.Name = "textBox_strokewidth";
            this.textBox_strokewidth.Size = new System.Drawing.Size(29, 21);
            this.textBox_strokewidth.TabIndex = 13;
            this.textBox_strokewidth.Text = "2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "描边粗细";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_height);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.textBox_width);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(572, 33);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(88, 100);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "画布尺寸";
            // 
            // textBox_height
            // 
            this.textBox_height.HintColor = System.Drawing.Color.Gray;
            this.textBox_height.HintText = null;
            this.textBox_height.InputType = BilibiliProjects.HintInputType.Number;
            this.textBox_height.Location = new System.Drawing.Point(41, 56);
            this.textBox_height.Name = "textBox_height";
            this.textBox_height.Size = new System.Drawing.Size(29, 21);
            this.textBox_height.TabIndex = 20;
            this.textBox_height.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "高度";
            // 
            // textBox_width
            // 
            this.textBox_width.HintColor = System.Drawing.Color.Gray;
            this.textBox_width.HintText = null;
            this.textBox_width.InputType = BilibiliProjects.HintInputType.Number;
            this.textBox_width.Location = new System.Drawing.Point(41, 24);
            this.textBox_width.Name = "textBox_width";
            this.textBox_width.Size = new System.Drawing.Size(29, 21);
            this.textBox_width.TabIndex = 18;
            this.textBox_width.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "宽度";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox_picname);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.button_save);
            this.groupBox5.Controls.Add(this.comboBox_format);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.button_scan2);
            this.groupBox5.Controls.Add(this.textBox_saveFolder);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Location = new System.Drawing.Point(666, 33);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(300, 100);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "保存";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "保存位置";
            // 
            // textBox_saveFolder
            // 
            this.textBox_saveFolder.Location = new System.Drawing.Point(65, 14);
            this.textBox_saveFolder.Name = "textBox_saveFolder";
            this.textBox_saveFolder.Size = new System.Drawing.Size(159, 21);
            this.textBox_saveFolder.TabIndex = 2;
            // 
            // button_scan2
            // 
            this.button_scan2.Location = new System.Drawing.Point(230, 12);
            this.button_scan2.Name = "button_scan2";
            this.button_scan2.Size = new System.Drawing.Size(58, 23);
            this.button_scan2.TabIndex = 3;
            this.button_scan2.Text = "选择";
            this.button_scan2.UseVisualStyleBackColor = true;
            // 
            // comboBox_format
            // 
            this.comboBox_format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_format.FormattingEnabled = true;
            this.comboBox_format.Items.AddRange(new object[] {
            "png",
            "jpg",
            "bmp"});
            this.comboBox_format.Location = new System.Drawing.Point(65, 44);
            this.comboBox_format.Name = "comboBox_format";
            this.comboBox_format.Size = new System.Drawing.Size(95, 20);
            this.comboBox_format.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 9;
            this.label13.Text = "保存格式";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(230, 39);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(58, 58);
            this.button_save.TabIndex = 11;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 76);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 12;
            this.label20.Text = "文件名前缀";
            // 
            // textBox_picname
            // 
            this.textBox_picname.Location = new System.Drawing.Point(77, 73);
            this.textBox_picname.Name = "textBox_picname";
            this.textBox_picname.Size = new System.Drawing.Size(83, 21);
            this.textBox_picname.TabIndex = 13;
            this.textBox_picname.Text = "字幕";
            // 
            // Subtitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 682);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label_sep);
            this.Controls.Add(this.button_scan);
            this.Controls.Add(this.textBox_filename);
            this.Controls.Add(this.label1);
            this.Name = "Subtitle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "字幕生成";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_filename;
        private System.Windows.Forms.Button button_scan;
        private System.Windows.Forms.Label label_sep;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_font;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private HintTextBox textBox_fontsize;
        private MyPanel panel;
        private System.Windows.Forms.Label label_italic;
        private System.Windows.Forms.Label label_bold;
        private System.Windows.Forms.GroupBox groupBox2;
        private HintTextBox textBox_bg_alpha;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label_bgcolor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label_strokecolor2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_txtcolor2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label_strokecolor1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_txtcolor1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private HintTextBox textBox_offsety;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboBox_Y;
        private System.Windows.Forms.Label label19;
        private HintTextBox textBox_offsetx;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBox_X;
        private System.Windows.Forms.Label label16;
        private HintTextBox textBox_strokewidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private HintTextBox textBox_height;
        private System.Windows.Forms.Label label7;
        private HintTextBox textBox_width;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox_picname;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.ComboBox comboBox_format;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button_scan2;
        private System.Windows.Forms.TextBox textBox_saveFolder;
        private System.Windows.Forms.Label label11;
    }
}