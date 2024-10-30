using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clocks.Forms
{
    public partial class DigitalClockForm : Form
    {
        public DigitalClockPanelSharpDX ClockPanel
        {
            get => digitalClockPanelSharpDX1;
        }

        public EventHandler Hided;

        public DigitalClockForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.Hide();
            Hided?.Invoke(this, new EventArgs());
            e.Cancel = true;
        }
    }
}
