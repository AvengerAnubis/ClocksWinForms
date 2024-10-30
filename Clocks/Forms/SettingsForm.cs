using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clocks.Forms;
using Clocks.Properties;
using Clocks.UserControls;
using Clocks.Utils;
using static Clocks.ClockPanelSharpDX;

namespace Clocks
{
	public partial class SettingsForm : Form
	{
		private AnalogClockForm _analogClockForm;
		private DigitalClockForm _digitalClockForm;

        private string[] _fonts = new string[]
        {
            "Arial", "Impact", "Courier New"
        };

        private Stopwatch _stopwatch = new Stopwatch();
        public TimeSpan TimeElapsed 
        { 
            get => _stopwatch.Elapsed;
        }

		public SettingsForm()
		{
			InitializeComponent();
			// Включаем двойную буферизацию (убирает мерцание)
			DoubleBuffered = true;
			// Отключаем фуллскрин
            this.MaximizeBox = false;
            // Инициализируем форму с аналоговыми часами
            _analogClockForm = new AnalogClockForm();
			_analogClockForm.Show();
			_analogClockForm.Disposed += (o, e) =>
			{
				this.Dispose();
			};

            _digitalClockForm = new DigitalClockForm();
			_digitalClockForm.Show();

            // Инициализация панелей выбора цвета
            InitColorPickers();
			// Инициализация картинок и панелей для их изменения
			InitBitmaps();
			// Инициализация панелей выбора анимаций
			InitAnimationSelectors();
            // Инициализация шрифтов
            InitFonts();
            // Инициализируем время, отображаемое на часах
            _analogClockForm.ClockPanel.TimeSpanToDisplay = () => 
			{ 
				DateTime now = DateTime.Now;
				return new TimeSpan(now.Day, now.Hour, now.Minute, now.Second, now.Millisecond); 
			
			};
            _digitalClockForm.ClockPanel.TimeSpanToDisplay = () =>
            {
                DateTime now = DateTime.Now;
                return new TimeSpan((checkBox1.Checked) ? 0 : 1, now.Hour, now.Minute, now.Second, now.Millisecond);

            };
            _digitalClockForm.Hided += (o, e) =>
            {
                checkBox1.Checked = false;
                _digitalClockForm.ClockPanel.Stop();
            };
            

            // Запускаем цикл отрисовки
            _analogClockForm.ClockPanel.RunDrawingLoop();
			_digitalClockForm.ClockPanel.RunDrawingLoop();

            buttonSwFlag.BackgroundImage = Image.FromFile("Resources\\IconFlag.png");
		}

        private void InitAnimationSelectors()
		{
			// Инициализируем лэйблы для панели выбора анимаций
			Label labelAnimS1 = new Label();
			labelAnimS1.Text = "Плавная";
			labelAnimS1.TextAlign = ContentAlignment.MiddleCenter;
			labelAnimS1.Dock = DockStyle.Fill;

			Label labelAnimS2 = new Label();
			labelAnimS2.Text = "Линейная (точная)";
			labelAnimS2.TextAlign = ContentAlignment.MiddleCenter;
			labelAnimS2.Dock = DockStyle.Fill;

			Label labelAnimS3 = new Label();
			labelAnimS3.Text = "Мгновенная";
			labelAnimS3.TextAlign = ContentAlignment.MiddleCenter;
			labelAnimS3.Dock = DockStyle.Fill;

			List<Control> labelsAnimS = new List<Control>()
			{
				labelAnimS1, labelAnimS2, labelAnimS3
			};

			Label labelAnimM1 = new Label();
			labelAnimM1.Text = "Плавная";
			labelAnimM1.TextAlign = ContentAlignment.MiddleCenter;
			labelAnimM1.Dock = DockStyle.Fill;

			Label labelAnimM2 = new Label();
			labelAnimM2.Text = "Линейная (точная)";
			labelAnimM2.TextAlign = ContentAlignment.MiddleCenter;
			labelAnimM2.Dock = DockStyle.Fill;

			Label labelAnimM3 = new Label();
			labelAnimM3.Text = "Мгновенная";
			labelAnimM3.TextAlign = ContentAlignment.MiddleCenter;
			labelAnimM3.Dock = DockStyle.Fill;

			List<Control> labelsAnimM = new List<Control>()
			{
				labelAnimM1, labelAnimM2, labelAnimM3
			};

			Label labelAnimH1 = new Label();
			labelAnimH1.Text = "Плавная";
			labelAnimH1.TextAlign = ContentAlignment.MiddleCenter;
			labelAnimH1.Dock = DockStyle.Fill;

			Label labelAnimH2 = new Label();
			labelAnimH2.Text = "Линейная (точная)";
			labelAnimH2.TextAlign = ContentAlignment.MiddleCenter;
			labelAnimH2.Dock = DockStyle.Fill;

			Label labelAnimH3 = new Label();
			labelAnimH3.Text = "Мгновенная";
			labelAnimH3.TextAlign = ContentAlignment.MiddleCenter;
			labelAnimH3.Dock = DockStyle.Fill;

			List<Control> labelsAnimH = new List<Control>()
			{
				labelAnimH1, labelAnimH2, labelAnimH3
			};

			SelectorContainer<Control> selectorContainerAnimsS = new SelectorContainer<Control>(labelsAnimS);
			selectorAnimS.Items = selectorContainerAnimsS;
			selectorAnimS.Items.SelectedItemChanged += (o, item) =>
			{
                _analogClockForm.ClockPanel.ChangeAnimation(ClockPanelSharpDX.Clockhand.SECONDS, item.SelectedIndex);
			};

			SelectorContainer<Control> selectorContainerAnimsM = new SelectorContainer<Control>(labelsAnimM);
			selectorAnimM.Items = selectorContainerAnimsM;
			selectorAnimM.Items.SelectedItemChanged += (o, item) =>
			{
                _analogClockForm.ClockPanel.ChangeAnimation(ClockPanelSharpDX.Clockhand.MINUTES, item.SelectedIndex);
			};

			SelectorContainer<Control> selectorContainerAnimsH = new SelectorContainer<Control>(labelsAnimH);
			selectorAnimH.Items = selectorContainerAnimsH;
			selectorAnimH.Items.SelectedItemChanged += (o, item) =>
			{
                _analogClockForm.ClockPanel.ChangeAnimation(ClockPanelSharpDX.Clockhand.HOURS, item.SelectedIndex);
			};
		}
		private void InitBitmaps()
		{
			List<string> files = Directory.EnumerateFiles("Resources\\").ToList();

			List<Image> clockHandsImages = new List<Image>();
            List<Image> clockFacesImages = new List<Image>();
			List<Image> digitalClockBGs = new List<Image>();
            List<Image> numberSetsImages = new List<Image>();

            List<Control> clockHandsControls = new List<Control>();
			List<Control> clockFacesControls = new List<Control>();
            List<Control> digitalClockBGControls = new List<Control>();
            List<Control> numberSetsControls = new List<Control>();
            //

            foreach (string file in files)
			{
				string strWoutExtinsion = file.Replace("Resources\\", string.Empty);
				if (file.EndsWith(".png"))
				{
                    strWoutExtinsion = strWoutExtinsion.Replace(".png", string.Empty);
                    if (strWoutExtinsion.StartsWith("ClockHand"))
                    {
                        if (int.TryParse(strWoutExtinsion.Remove(0, 9), out _))
                        {
                            clockHandsImages.Add(Image.FromFile(file));

							PictureBox pictureBox = new PictureBox();
                            pictureBox.Image = Image.FromFile(file);
                            pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            pictureBox.Margin = new Padding(0);
                            pictureBox.Dock = DockStyle.Fill;
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                            clockHandsControls.Add(pictureBox);
                        }
                    }
					else if (strWoutExtinsion.StartsWith("ClockFace"))
					{
                        if (int.TryParse(strWoutExtinsion.Remove(0, 9), out _))
                        {
                            clockFacesImages.Add(Image.FromFile(file));

                            PictureBox pictureBox = new PictureBox();
                            pictureBox.Image = Image.FromFile(file);
                            pictureBox.Margin = new Padding(0);
                            pictureBox.Dock = DockStyle.Fill;
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                            clockFacesControls.Add(pictureBox);
                        }
                    }
                    else if (strWoutExtinsion.StartsWith("DigitalClockBG"))
                    {
                        if (int.TryParse(strWoutExtinsion.Remove(0, 14), out _))
                        {
                            digitalClockBGs.Add(Image.FromFile(file));

                            PictureBox pictureBox = new PictureBox();
                            pictureBox.Image = Image.FromFile(file);
                            pictureBox.Margin = new Padding(0);
                            pictureBox.Dock = DockStyle.Fill;
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                            digitalClockBGControls.Add(pictureBox);
                        }
                    }
                    else if (strWoutExtinsion.StartsWith("NumberSet"))
                    {
                        if (int.TryParse(strWoutExtinsion.Remove(0, 9), out _))
                        {
                            numberSetsImages.Add(Image.FromFile(file));

                            PictureBox pictureBox = new PictureBox();
                            pictureBox.Image = Image.FromFile(file);
                            pictureBox.Margin = new Padding(0);
                            pictureBox.Dock = DockStyle.Fill;
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                            numberSetsControls.Add(pictureBox);
                        }
                    }
                }
			}

            _analogClockForm.ClockPanel.SetBitmaps(clockHandsImages, clockFacesImages);
			_digitalClockForm.ClockPanel.SetBitmaps(numberSetsImages, digitalClockBGs);

            // Создаем SelectorContainer's для элементов
            SelectorContainer<Control> selectorContainerClockHands = new SelectorContainer<Control>(clockHandsControls);

            selectorClockHands.Items = selectorContainerClockHands;
            selectorClockHands.Items.SelectedItemChanged += (o, item) =>
            {
                _analogClockForm.ClockPanel.ChangeSelectedBitmaps(new ClockPanelSharpDX.ChangeSelectedBitmapsEventArgs { clockhandsBitmapId = item.SelectedIndex, clockfacesBitmapId = null });
            };

            SelectorContainer<Control> selectorContainerClockFaces = new SelectorContainer<Control>(clockFacesControls);

            selectorClockFaces.Items = selectorContainerClockFaces;
            selectorClockFaces.Items.SelectedItemChanged += (o, item) =>
            {
                _analogClockForm.ClockPanel.ChangeSelectedBitmaps(new ClockPanelSharpDX.ChangeSelectedBitmapsEventArgs { clockhandsBitmapId = null, clockfacesBitmapId = item.SelectedIndex });
            };

            SelectorContainer<Control> selectorContainerDCBGs = new SelectorContainer<Control>(digitalClockBGControls);

            selectorDCBG.Items = selectorContainerDCBGs;
            selectorDCBG.Items.SelectedItemChanged += (o, item) =>
            {
                _digitalClockForm.ClockPanel.ChangeSelectedBitmaps(new DigitalClockPanelSharpDX.ChangeSelectedBitmapsEventArgs { backgroundBitmapId = item.SelectedIndex, numberSetBitmapId = null });
            };

            SelectorContainer<Control> selectorContainerDCNumberSets = new SelectorContainer<Control>(numberSetsControls);

            selectorDCNumSet.Items = selectorContainerDCNumberSets;
            selectorDCNumSet.Items.SelectedItemChanged += (o, item) =>
            {
                _digitalClockForm.ClockPanel.ChangeSelectedBitmaps(new DigitalClockPanelSharpDX.ChangeSelectedBitmapsEventArgs { backgroundBitmapId = null, numberSetBitmapId = item.SelectedIndex });
            };
        }
		private void InitColorPickers()
		{
            // Инициализируем ColorPicker'ы (панели выбора цвета)
            colorPickerS.labelTitle.Text = "Секундная стрелка";
            colorPickerS.ColorChanged += (o, e) =>
            {
                _analogClockForm.ClockPanel.ChangeColor(new ClockPanelSharpDX.ChangeColorEventArgs() { color = new SharpDX.Color(e.R, e.G, e.B), id = 0 });
            };

            colorPickerM.labelTitle.Text = "Минутная стрелка";
            colorPickerM.ColorChanged += (o, e) =>
            {
                _analogClockForm.ClockPanel.ChangeColor(new ClockPanelSharpDX.ChangeColorEventArgs() { color = new SharpDX.Color(e.R, e.G, e.B), id = 1 });
            };

            colorPickerH.labelTitle.Text = "Часовая стрелка";
            colorPickerH.ColorChanged += (o, e) =>
            {
                _analogClockForm.ClockPanel.ChangeColor(new ClockPanelSharpDX.ChangeColorEventArgs() { color = new SharpDX.Color(e.R, e.G, e.B), id = 2 });
            };

            colorPickerN.labelTitle.Text = "Циферблат";
            colorPickerN.ColorChanged += (o, e) =>
            {
                _analogClockForm.ClockPanel.ChangeColor(new ClockPanelSharpDX.ChangeColorEventArgs() { color = new SharpDX.Color(e.R, e.G, e.B), id = 3 });
            };

            colorPickerF.labelTitle.Text = "Цифры";
            colorPickerF.ColorChanged += (o, e) =>
            {
                _analogClockForm.ClockPanel.ChangeColor(new ClockPanelSharpDX.ChangeColorEventArgs() { color = new SharpDX.Color(e.R, e.G, e.B), id = 4 });
            };

            colorPickerDigits.labelTitle.Text = "Цифры цифровых часов";
            colorPickerDigits.ColorChanged += (o, e) =>
            {
                _digitalClockForm.ClockPanel.ChangeColor(new DigitalClockPanelSharpDX.ChangeColorEventArgs() { color = new SharpDX.Color(e.R, e.G, e.B), id = 0 });
            };

            colorPickerDClockBG.labelTitle.Text = "Фон цифровых часов";
            colorPickerDClockBG.ColorChanged += (o, e) =>
            {
                _digitalClockForm.ClockPanel.ChangeColor(new DigitalClockPanelSharpDX.ChangeColorEventArgs() { color = new SharpDX.Color(e.R, e.G, e.B), id = 1 });
            };
        }
        private void InitFonts()
        {
            List<Control> labels = new List<Control>(); 

            foreach (string font in _fonts)
            {
                Label fontLabel = new Label();
                fontLabel.Text = font;
                fontLabel.Dock = DockStyle.Fill;
                fontLabel.TextAlign = ContentAlignment.MiddleCenter;

                labels.Add(fontLabel);
            }    
            selectorFont.Items = new SelectorContainer<Control>(labels);

            selectorFont.Items.SelectedItemChanged += (o, e) =>
            {
                _analogClockForm.ClockPanel.ChangeFont(_fonts[e.SelectedIndex]);
            };
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                _digitalClockForm.Show();
                _digitalClockForm.ClockPanel.RunDrawingLoop();
            }
        }

        private void buttonSwFlag_Click(object sender, EventArgs e)
        {
            if (_stopwatch.IsRunning)
            {
                SavedStopwatchFlag flag = new SavedStopwatchFlag(flowLayoutPanelFlags.Controls.Count + 1, _stopwatch.Elapsed);
                this.flowLayoutPanelFlags.Controls.Add(flag);
            }
        }

        private void buttonSwStart_Click(object sender, EventArgs e)
        {
            buttonSwStart.Enabled = false;
            buttonSwStop.Enabled = true;
            buttonSwReset.Enabled = true;
            buttonSwFlag.Enabled = true;

            _stopwatch.Start();
        }

        private void buttonSwStop_Click(object sender, EventArgs e)
        {
            buttonSwStart.Enabled = true;
            buttonSwStop.Enabled = false;
            buttonSwReset.Enabled = true;
            buttonSwFlag.Enabled = false;

            _stopwatch.Stop();
        }

        private void buttonSwRestart_Click(object sender, EventArgs e)
        {
            buttonSwStart.Enabled = true;
            buttonSwStop.Enabled = false;
            buttonSwReset.Enabled = false;
            buttonSwFlag.Enabled = false;

            _stopwatch.Reset();
            this.flowLayoutPanelFlags.Controls.Clear();
        }

        private void checkBoxSwMode_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSwMode.Checked)
            {
                buttonSwStart.Enabled = true;
                buttonSwStop.Enabled = false;
                buttonSwReset.Enabled = false;
                buttonSwFlag.Enabled = false;

                _digitalClockForm.ClockPanel.TimeSpanToDisplay = () =>
                {
                    return new TimeSpan(
                        (checkBox1.Checked) ? 0 : 1, 
                        _stopwatch.Elapsed.Hours,
                        _stopwatch.Elapsed.Minutes,
                        _stopwatch.Elapsed.Seconds,
                        _stopwatch.Elapsed.Milliseconds
                    );
                };
                _analogClockForm.ClockPanel.TimeSpanToDisplay = () =>
                {
                    return this.TimeElapsed;
                };
            }
            else
            {
                flowLayoutPanelFlags.Controls.Clear();

                buttonSwStart.Enabled = false;
                buttonSwStop.Enabled = false;
                buttonSwReset.Enabled = false;
                buttonSwFlag.Enabled = false;

                _stopwatch.Reset();

                _analogClockForm.ClockPanel.TimeSpanToDisplay = () =>
                {
                    DateTime now = DateTime.Now;
                    return new TimeSpan(now.Day, now.Hour, now.Minute, now.Second, now.Millisecond);

                };
                _digitalClockForm.ClockPanel.TimeSpanToDisplay = () =>
                {
                    DateTime now = DateTime.Now;
                    return new TimeSpan((checkBox1.Checked) ? 0 : 1, now.Hour, now.Minute, now.Second, now.Millisecond);

                };
            }
        }
    }
}
