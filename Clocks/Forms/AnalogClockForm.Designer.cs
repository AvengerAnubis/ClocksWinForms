namespace Clocks.Forms
{
    partial class AnalogClockForm
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
            this.clockPanelSharpDX1 = new Clocks.ClockPanelSharpDX();
            this.SuspendLayout();
            // 
            // clockPanelSharpDX1
            // 
            this.clockPanelSharpDX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clockPanelSharpDX1.Location = new System.Drawing.Point(0, 0);
            this.clockPanelSharpDX1.Name = "clockPanelSharpDX1";
            this.clockPanelSharpDX1.Size = new System.Drawing.Size(624, 601);
            this.clockPanelSharpDX1.TabIndex = 0;
            // 
            // AnalogClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 601);
            this.Controls.Add(this.clockPanelSharpDX1);
            this.MaximumSize = new System.Drawing.Size(640, 640);
            this.MinimumSize = new System.Drawing.Size(640, 640);
            this.Name = "AnalogClockForm";
            this.Text = "AnalogClockForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ClockPanelSharpDX clockPanelSharpDX1;
    }
}