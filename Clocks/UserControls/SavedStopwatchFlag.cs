using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clocks.UserControls
{
    public partial class SavedStopwatchFlag : UserControl
    {
        public SavedStopwatchFlag()
        {
            InitializeComponent();
        }

        public SavedStopwatchFlag(int numberOfFlag, TimeSpan time)
        {
            InitializeComponent();
            this.label1.Text = numberOfFlag.ToString();
            this.label2.Text = time.ToString(@"hh\:mm\:ss\.fff");
        }
    }
}
