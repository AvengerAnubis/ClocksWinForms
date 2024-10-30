using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clocks
{
	public partial class ColorPicker : UserControl
	{
		public event EventHandler<Color> ColorChanged;

		private Color _color = Color.Black;
		public Color Color
		{
			get => _color;
			set
			{
				_color = value;
				UpdateElements();
				ColorChanged?.Invoke(this, _color);
			}
		}

		public ColorPicker()
		{
			InitializeComponent();
			this.buttonPickColor.BackgroundImage = Image.FromFile("Resources\\IconColorPicker.png");
			UpdateElements();
		}

		private void UpdateElements()
		{
			textBoxRed.Text = _color.R.ToString();
			textBoxGreen.Text = _color.G.ToString();
			textBoxBlue.Text = _color.B.ToString();
			textBoxHex.Text = BitConverter.ToString(new byte[] { _color.R, _color.G, _color.B }).Replace("-", string.Empty);

			panelColorDisplay.BackColor = _color;
			colorDialog1.Color = _color;
		}

		private void buttonPickColor_Click(object sender, EventArgs e)
		{
			colorDialog1.ShowDialog();
			Color = colorDialog1.Color;
		}

		private void textBoxHex_TextChanged(object sender, EventArgs e)
		{
			if (Regex.Match(textBoxHex.Text, "^([0-F]|[a-f]){6}$").Success)
			{
				textBoxHex.Text = textBoxHex.Text.ToUpper();
				Color = Color.FromArgb(
					Convert.ToByte(textBoxHex.Text.Substring(0, 2), 16),
					Convert.ToByte(textBoxHex.Text.Substring(2, 2), 16),
					Convert.ToByte(textBoxHex.Text.Substring(4, 2), 16)
				);
			}
			else if (Regex.Match(textBoxHex.Text, "^([0-F]|[a-f]){3}(=){1}$").Success)
			{
                textBoxHex.Text = textBoxHex.Text.ToUpper();
                Color = Color.FromArgb(
					Convert.ToByte($"{textBoxHex.Text[0]}", 16) * 17,
					Convert.ToByte($"{textBoxHex.Text[1]}", 16) * 17,
                    Convert.ToByte($"{textBoxHex.Text[2]}", 16) * 17
                );
            }
        }

		private void textBoxRed_TextChanged(object sender, EventArgs e)
		{
			byte r = 0;
			if (byte.TryParse(textBoxRed.Text, out r))
			{
				Color = Color.FromArgb(
                    r,
                    _color.G,
                    _color.B
                );
			}
		}

		private void textBoxGreen_TextChanged(object sender, EventArgs e)
		{
            byte g = 0;
            if (byte.TryParse(textBoxGreen.Text, out g))
            {
                Color = Color.FromArgb(
                    _color.R,
                    g,
                    _color.B
                );
            }
        }

		private void textBoxBlue_TextChanged(object sender, EventArgs e)
		{
            byte b = 0;
            if (byte.TryParse(textBoxBlue.Text, out b))
            {
                Color = Color.FromArgb(
                    _color.R,
                    _color.G,
                    b
                );
            }
        }
	}
}
