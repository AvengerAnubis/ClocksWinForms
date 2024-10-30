using System.Drawing;

namespace Clocks
{
    partial class SettingsForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSwStart = new System.Windows.Forms.Button();
            this.buttonSwStop = new System.Windows.Forms.Button();
            this.buttonSwReset = new System.Windows.Forms.Button();
            this.buttonSwFlag = new System.Windows.Forms.Button();
            this.flowLayoutPanelFlags = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxSwMode = new System.Windows.Forms.CheckBox();
            this.selectorClockHands = new Clocks.Selector();
            this.selectorClockFaces = new Clocks.Selector();
            this.selectorDCNumSet = new Clocks.Selector();
            this.selectorFont = new Clocks.Selector();
            this.selectorDCBG = new Clocks.Selector();
            this.colorPickerDClockBG = new Clocks.ColorPicker();
            this.colorPickerDigits = new Clocks.ColorPicker();
            this.colorPickerN = new Clocks.ColorPicker();
            this.colorPickerF = new Clocks.ColorPicker();
            this.colorPickerH = new Clocks.ColorPicker();
            this.colorPickerM = new Clocks.ColorPicker();
            this.colorPickerS = new Clocks.ColorPicker();
            this.selectorAnimH = new Clocks.Selector();
            this.selectorAnimM = new Clocks.Selector();
            this.selectorAnimS = new Clocks.Selector();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.selectorClockHands);
            this.flowLayoutPanel1.Controls.Add(this.selectorClockFaces);
            this.flowLayoutPanel1.Controls.Add(this.selectorDCNumSet);
            this.flowLayoutPanel1.Controls.Add(this.selectorDCBG);
            this.flowLayoutPanel1.Controls.Add(this.selectorFont);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox6);
            this.flowLayoutPanel1.Controls.Add(this.groupBox7);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(12, 12, 24, 12);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(624, 841);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 515);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 181);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Цвета";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.colorPickerDClockBG);
            this.panel1.Controls.Add(this.colorPickerDigits);
            this.panel1.Controls.Add(this.colorPickerN);
            this.panel1.Controls.Add(this.colorPickerF);
            this.panel1.Controls.Add(this.colorPickerH);
            this.panel1.Controls.Add(this.colorPickerM);
            this.panel1.Controls.Add(this.colorPickerS);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 162);
            this.panel1.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(0, 145);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(12, 696);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(594, 109);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Анимации";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(588, 90);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox5, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(588, 90);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.selectorAnimH);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(393, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(192, 84);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Часовая стрелка";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.selectorAnimM);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(198, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(189, 84);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Минутная стрелка";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.selectorAnimS);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(189, 84);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Секундная стрелка";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tableLayoutPanel4);
            this.groupBox6.Location = new System.Drawing.Point(12, 805);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(594, 68);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Цифровые часы";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.checkBox1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(588, 49);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 16);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(158, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Включить цифровые часы";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tableLayoutPanel2);
            this.groupBox7.Location = new System.Drawing.Point(12, 873);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(594, 199);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Секундомер";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxSwMode, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(588, 180);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSwFlag, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelFlags, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 41);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(588, 139);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.buttonSwStart);
            this.flowLayoutPanel3.Controls.Add(this.buttonSwStop);
            this.flowLayoutPanel3.Controls.Add(this.buttonSwReset);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(90, 133);
            this.flowLayoutPanel3.TabIndex = 0;
            this.flowLayoutPanel3.WrapContents = false;
            // 
            // buttonSwStart
            // 
            this.buttonSwStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSwStart.Enabled = false;
            this.buttonSwStart.Location = new System.Drawing.Point(3, 3);
            this.buttonSwStart.Name = "buttonSwStart";
            this.buttonSwStart.Size = new System.Drawing.Size(87, 23);
            this.buttonSwStart.TabIndex = 0;
            this.buttonSwStart.Text = "Старт";
            this.buttonSwStart.UseVisualStyleBackColor = true;
            this.buttonSwStart.Click += new System.EventHandler(this.buttonSwStart_Click);
            // 
            // buttonSwStop
            // 
            this.buttonSwStop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSwStop.Enabled = false;
            this.buttonSwStop.Location = new System.Drawing.Point(3, 32);
            this.buttonSwStop.Name = "buttonSwStop";
            this.buttonSwStop.Size = new System.Drawing.Size(87, 23);
            this.buttonSwStop.TabIndex = 1;
            this.buttonSwStop.Text = "Стоп";
            this.buttonSwStop.UseVisualStyleBackColor = true;
            this.buttonSwStop.Click += new System.EventHandler(this.buttonSwStop_Click);
            // 
            // buttonSwReset
            // 
            this.buttonSwReset.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSwReset.Enabled = false;
            this.buttonSwReset.Location = new System.Drawing.Point(3, 61);
            this.buttonSwReset.Name = "buttonSwReset";
            this.buttonSwReset.Size = new System.Drawing.Size(87, 23);
            this.buttonSwReset.TabIndex = 2;
            this.buttonSwReset.Text = "Сброс";
            this.buttonSwReset.UseVisualStyleBackColor = true;
            this.buttonSwReset.Click += new System.EventHandler(this.buttonSwRestart_Click);
            // 
            // buttonSwFlag
            // 
            this.buttonSwFlag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSwFlag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSwFlag.Enabled = false;
            this.buttonSwFlag.Location = new System.Drawing.Point(553, 3);
            this.buttonSwFlag.Name = "buttonSwFlag";
            this.buttonSwFlag.Size = new System.Drawing.Size(32, 32);
            this.buttonSwFlag.TabIndex = 1;
            this.buttonSwFlag.UseVisualStyleBackColor = true;
            this.buttonSwFlag.Click += new System.EventHandler(this.buttonSwFlag_Click);
            // 
            // flowLayoutPanelFlags
            // 
            this.flowLayoutPanelFlags.AutoScroll = true;
            this.flowLayoutPanelFlags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFlags.Location = new System.Drawing.Point(99, 3);
            this.flowLayoutPanelFlags.Name = "flowLayoutPanelFlags";
            this.flowLayoutPanelFlags.Size = new System.Drawing.Size(448, 133);
            this.flowLayoutPanelFlags.TabIndex = 2;
            // 
            // checkBoxSwMode
            // 
            this.checkBoxSwMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxSwMode.AutoSize = true;
            this.checkBoxSwMode.Location = new System.Drawing.Point(12, 12);
            this.checkBoxSwMode.Margin = new System.Windows.Forms.Padding(12);
            this.checkBoxSwMode.Name = "checkBoxSwMode";
            this.checkBoxSwMode.Size = new System.Drawing.Size(131, 17);
            this.checkBoxSwMode.TabIndex = 2;
            this.checkBoxSwMode.Text = "Режим секундомера";
            this.checkBoxSwMode.UseVisualStyleBackColor = true;
            this.checkBoxSwMode.CheckedChanged += new System.EventHandler(this.checkBoxSwMode_CheckedChanged);
            // 
            // selectorClockHands
            // 
            this.selectorClockHands.Items = null;
            this.selectorClockHands.Location = new System.Drawing.Point(12, 12);
            this.selectorClockHands.Margin = new System.Windows.Forms.Padding(0);
            this.selectorClockHands.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.selectorClockHands.Name = "selectorClockHands";
            this.selectorClockHands.Size = new System.Drawing.Size(594, 100);
            this.selectorClockHands.TabIndex = 0;
            // 
            // selectorClockFaces
            // 
            this.selectorClockFaces.Items = null;
            this.selectorClockFaces.Location = new System.Drawing.Point(12, 112);
            this.selectorClockFaces.Margin = new System.Windows.Forms.Padding(0);
            this.selectorClockFaces.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.selectorClockFaces.Name = "selectorClockFaces";
            this.selectorClockFaces.Size = new System.Drawing.Size(594, 100);
            this.selectorClockFaces.TabIndex = 1;
            // 
            // selectorDCNumSet
            // 
            this.selectorDCNumSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectorDCNumSet.Items = null;
            this.selectorDCNumSet.Location = new System.Drawing.Point(12, 212);
            this.selectorDCNumSet.Margin = new System.Windows.Forms.Padding(0);
            this.selectorDCNumSet.Name = "selectorDCNumSet";
            this.selectorDCNumSet.Size = new System.Drawing.Size(594, 100);
            this.selectorDCNumSet.TabIndex = 8;
            // 
            // selectorFont
            // 
            this.selectorFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectorFont.Items = null;
            this.selectorFont.Location = new System.Drawing.Point(12, 412);
            this.selectorFont.Margin = new System.Windows.Forms.Padding(0);
            this.selectorFont.Name = "selectorFont";
            this.selectorFont.Size = new System.Drawing.Size(594, 103);
            this.selectorFont.TabIndex = 9;
            // 
            // selectorDCBG
            // 
            this.selectorDCBG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectorDCBG.Items = null;
            this.selectorDCBG.Location = new System.Drawing.Point(12, 312);
            this.selectorDCBG.Margin = new System.Windows.Forms.Padding(0);
            this.selectorDCBG.Name = "selectorDCBG";
            this.selectorDCBG.Size = new System.Drawing.Size(594, 100);
            this.selectorDCBG.TabIndex = 7;
            // 
            // colorPickerDClockBG
            // 
            this.colorPickerDClockBG.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorPickerDClockBG.Dock = System.Windows.Forms.DockStyle.Left;
            this.colorPickerDClockBG.Location = new System.Drawing.Point(894, 0);
            this.colorPickerDClockBG.Name = "colorPickerDClockBG";
            this.colorPickerDClockBG.Size = new System.Drawing.Size(149, 145);
            this.colorPickerDClockBG.TabIndex = 11;
            // 
            // colorPickerDigits
            // 
            this.colorPickerDigits.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorPickerDigits.Dock = System.Windows.Forms.DockStyle.Left;
            this.colorPickerDigits.Location = new System.Drawing.Point(745, 0);
            this.colorPickerDigits.Name = "colorPickerDigits";
            this.colorPickerDigits.Size = new System.Drawing.Size(149, 145);
            this.colorPickerDigits.TabIndex = 10;
            // 
            // colorPickerN
            // 
            this.colorPickerN.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorPickerN.Dock = System.Windows.Forms.DockStyle.Left;
            this.colorPickerN.Location = new System.Drawing.Point(596, 0);
            this.colorPickerN.Name = "colorPickerN";
            this.colorPickerN.Size = new System.Drawing.Size(149, 145);
            this.colorPickerN.TabIndex = 9;
            // 
            // colorPickerF
            // 
            this.colorPickerF.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorPickerF.Dock = System.Windows.Forms.DockStyle.Left;
            this.colorPickerF.Location = new System.Drawing.Point(447, 0);
            this.colorPickerF.Name = "colorPickerF";
            this.colorPickerF.Size = new System.Drawing.Size(149, 145);
            this.colorPickerF.TabIndex = 8;
            // 
            // colorPickerH
            // 
            this.colorPickerH.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorPickerH.Dock = System.Windows.Forms.DockStyle.Left;
            this.colorPickerH.Location = new System.Drawing.Point(298, 0);
            this.colorPickerH.Name = "colorPickerH";
            this.colorPickerH.Size = new System.Drawing.Size(149, 145);
            this.colorPickerH.TabIndex = 7;
            // 
            // colorPickerM
            // 
            this.colorPickerM.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorPickerM.Dock = System.Windows.Forms.DockStyle.Left;
            this.colorPickerM.Location = new System.Drawing.Point(149, 0);
            this.colorPickerM.Name = "colorPickerM";
            this.colorPickerM.Size = new System.Drawing.Size(149, 145);
            this.colorPickerM.TabIndex = 6;
            // 
            // colorPickerS
            // 
            this.colorPickerS.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorPickerS.Dock = System.Windows.Forms.DockStyle.Left;
            this.colorPickerS.Location = new System.Drawing.Point(0, 0);
            this.colorPickerS.Name = "colorPickerS";
            this.colorPickerS.Size = new System.Drawing.Size(149, 145);
            this.colorPickerS.TabIndex = 5;
            // 
            // selectorAnimH
            // 
            this.selectorAnimH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectorAnimH.Items = null;
            this.selectorAnimH.Location = new System.Drawing.Point(3, 16);
            this.selectorAnimH.Name = "selectorAnimH";
            this.selectorAnimH.Size = new System.Drawing.Size(186, 65);
            this.selectorAnimH.TabIndex = 0;
            // 
            // selectorAnimM
            // 
            this.selectorAnimM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectorAnimM.Items = null;
            this.selectorAnimM.Location = new System.Drawing.Point(3, 16);
            this.selectorAnimM.Name = "selectorAnimM";
            this.selectorAnimM.Size = new System.Drawing.Size(183, 65);
            this.selectorAnimM.TabIndex = 0;
            // 
            // selectorAnimS
            // 
            this.selectorAnimS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectorAnimS.Items = null;
            this.selectorAnimS.Location = new System.Drawing.Point(3, 16);
            this.selectorAnimS.Name = "selectorAnimS";
            this.selectorAnimS.Size = new System.Drawing.Size(183, 65);
            this.selectorAnimS.TabIndex = 0;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 841);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(640, 880);
            this.MinimumSize = new System.Drawing.Size(640, 880);
            this.Name = "SettingsForm";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Selector selectorClockFaces;
        private Selector selectorClockHands;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private ColorPicker colorPickerDClockBG;
        private ColorPicker colorPickerDigits;
        private ColorPicker colorPickerN;
        private ColorPicker colorPickerF;
        private ColorPicker colorPickerH;
        private ColorPicker colorPickerM;
        private ColorPicker colorPickerS;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox5;
        private Selector selectorAnimH;
        private System.Windows.Forms.GroupBox groupBox4;
        private Selector selectorAnimM;
        private System.Windows.Forms.GroupBox groupBox3;
        private Selector selectorAnimS;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button buttonSwStart;
        private System.Windows.Forms.Button buttonSwStop;
        private System.Windows.Forms.Button buttonSwReset;
        private System.Windows.Forms.Button buttonSwFlag;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBoxSwMode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFlags;
        private Selector selectorDCBG;
        private Selector selectorDCNumSet;
        private Selector selectorFont;
    }
}

