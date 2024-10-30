namespace Clocks.Forms
{
    partial class DigitalClockForm
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
            this.digitalClockPanelSharpDX1 = new Clocks.DigitalClockPanelSharpDX();
            this.clockPanelSharpDX1 = new Clocks.ClockPanelSharpDX();
            this.SuspendLayout();
            // 
            // digitalClockPanelSharpDX1
            // 
            this.digitalClockPanelSharpDX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.digitalClockPanelSharpDX1.Location = new System.Drawing.Point(0, 0);
            this.digitalClockPanelSharpDX1.Margin = new System.Windows.Forms.Padding(0);
            this.digitalClockPanelSharpDX1.Name = "digitalClockPanelSharpDX1";
            this.digitalClockPanelSharpDX1.Size = new System.Drawing.Size(624, 201);
            this.digitalClockPanelSharpDX1.TabIndex = 1;
            // 
            // clockPanelSharpDX1
            // 
            this.clockPanelSharpDX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clockPanelSharpDX1.Location = new System.Drawing.Point(0, 0);
            this.clockPanelSharpDX1.Name = "clockPanelSharpDX1";
            this.clockPanelSharpDX1.Size = new System.Drawing.Size(624, 201);
            this.clockPanelSharpDX1.TabIndex = 0;
            // 
            // DigitalClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 201);
            this.Controls.Add(this.digitalClockPanelSharpDX1);
            this.Controls.Add(this.clockPanelSharpDX1);
            this.MaximumSize = new System.Drawing.Size(640, 240);
            this.MinimumSize = new System.Drawing.Size(640, 240);
            this.Name = "DigitalClockForm";
            this.Text = "AnalogClockForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ClockPanelSharpDX clockPanelSharpDX1;
        private DigitalClockPanelSharpDX digitalClockPanelSharpDX1;
    }
}