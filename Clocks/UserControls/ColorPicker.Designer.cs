namespace Clocks
{
    partial class ColorPicker
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonPickColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxBlue = new System.Windows.Forms.TextBox();
            this.textBoxGreen = new System.Windows.Forms.TextBox();
            this.textBoxRed = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxHex = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panelColorDisplay = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelTitle, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.5102F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.4898F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(386, 294);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonPickColor, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.panelColorDisplay, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 48);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(380, 243);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 80);
            this.label2.TabIndex = 1;
            this.label2.Text = "HEX";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPickColor
            // 
            this.buttonPickColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPickColor.AutoSize = true;
            this.buttonPickColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPickColor.Location = new System.Drawing.Point(3, 183);
            this.buttonPickColor.MaximumSize = new System.Drawing.Size(16, 16);
            this.buttonPickColor.MinimumSize = new System.Drawing.Size(36, 36);
            this.buttonPickColor.Name = "buttonPickColor";
            this.buttonPickColor.Size = new System.Drawing.Size(36, 36);
            this.buttonPickColor.TabIndex = 3;
            this.buttonPickColor.UseVisualStyleBackColor = true;
            this.buttonPickColor.Click += new System.EventHandler(this.buttonPickColor_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 80);
            this.label1.TabIndex = 0;
            this.label1.Text = "RGB";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel5.Controls.Add(this.textBoxBlue, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.textBoxGreen, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.textBoxRed, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(45, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(332, 74);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // textBoxBlue
            // 
            this.textBoxBlue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxBlue.Location = new System.Drawing.Point(263, 27);
            this.textBoxBlue.Name = "textBoxBlue";
            this.textBoxBlue.Size = new System.Drawing.Size(26, 20);
            this.textBoxBlue.TabIndex = 2;
            this.textBoxBlue.Text = "255";
            this.textBoxBlue.TextChanged += new System.EventHandler(this.textBoxBlue_TextChanged);
            // 
            // textBoxGreen
            // 
            this.textBoxGreen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxGreen.Location = new System.Drawing.Point(152, 27);
            this.textBoxGreen.Name = "textBoxGreen";
            this.textBoxGreen.Size = new System.Drawing.Size(26, 20);
            this.textBoxGreen.TabIndex = 1;
            this.textBoxGreen.Text = "255";
            this.textBoxGreen.TextChanged += new System.EventHandler(this.textBoxGreen_TextChanged);
            // 
            // textBoxRed
            // 
            this.textBoxRed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxRed.Location = new System.Drawing.Point(42, 27);
            this.textBoxRed.Name = "textBoxRed";
            this.textBoxRed.Size = new System.Drawing.Size(26, 20);
            this.textBoxRed.TabIndex = 0;
            this.textBoxRed.Text = "255";
            this.textBoxRed.TextChanged += new System.EventHandler(this.textBoxRed_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxHex, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(45, 83);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(332, 74);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "#";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxHex
            // 
            this.textBoxHex.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxHex.Location = new System.Drawing.Point(23, 27);
            this.textBoxHex.Name = "textBoxHex";
            this.textBoxHex.Size = new System.Drawing.Size(68, 20);
            this.textBoxHex.TabIndex = 2;
            this.textBoxHex.Text = "FFFFFF";
            this.textBoxHex.TextChanged += new System.EventHandler(this.textBoxHex_TextChanged);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(3, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(57, 45);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "Название";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelColorDisplay
            // 
            this.panelColorDisplay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelColorDisplay.Location = new System.Drawing.Point(170, 190);
            this.panelColorDisplay.Margin = new System.Windows.Forms.Padding(9);
            this.panelColorDisplay.Name = "panelColorDisplay";
            this.panelColorDisplay.Size = new System.Drawing.Size(82, 23);
            this.panelColorDisplay.TabIndex = 5;
            // 
            // ColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel4);
            this.Name = "ColorPicker";
            this.Size = new System.Drawing.Size(386, 294);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonPickColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox textBoxBlue;
        private System.Windows.Forms.TextBox textBoxGreen;
        private System.Windows.Forms.TextBox textBoxRed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxHex;
        public System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panelColorDisplay;
    }
}
