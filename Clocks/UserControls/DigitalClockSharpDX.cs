using SharpDX.Direct2D1;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX;

using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using SharpDX.Mathematics.Interop;
using System.Diagnostics;
using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using SharpDX.Direct2D1.Effects;

using Clocks.Utils;
using System.Globalization;
using SharpDX.DirectWrite;
using System.Text;

namespace Clocks
{
	public partial class DigitalClockPanelSharpDX : PanelSharpDX
	{
        /// <summary>
        /// Структура с данными об изменённых цветах
        /// </summary>
        public struct ChangeColorEventArgs
		{
			/*
			/// <summary>
			/// Новые цвета (порядок цветов может отличаться от оригинального)
			/// </summary>
			public List<Color> color;
			/// <summary>
			/// Идентификаторы цветов, которые были изменены
			/// </summary>
			public List<int> colorIds;
			*/

			/// <summary>
			/// Новый цвет
			/// </summary>
			public Color color;
			/// <summary>
			/// Идентификатор (индекс в списке) цвета, который нужно изменить
			/// </summary>
			public int id;
		}

		/// <summary>
		/// Структура с данными об изменённых индексах
		/// </summary>
		public struct ChangeSelectedBitmapsEventArgs
		{
			/// <summary>
			/// Индекс стрелок аналоговых часов
			/// </summary>
			public int? numberSetBitmapId;
			/// <summary>
			/// Индекс циферблата аналоговых часов
			/// </summary>
			public int? backgroundBitmapId;
		}

		// Делегаты событий, для изменения данных отрисовки во время работы программы
        public delegate void ChangeColorEvent(ChangeColorEventArgs args);
        public delegate void ChangeSelectedBitmapsEvent(ChangeSelectedBitmapsEventArgs args);

		/// <summary>
		/// Direct2D1 Bitmap'ы для стрелок часов. Выбор, какой именно отрисовывать, осуществляется по индексам
		/// </summary>
		private List<Bitmap1> _numberSetBitmaps;

        /// <summary>
        /// Direct2D1 Bitmap'ы для циферблатов. Выбор, какой именно отрисовывать, осуществляется по индексам
        /// </summary>
        private List<Bitmap1> _backgroundBitmaps;

        /// <summary>
        /// Эффекты заливки (для перекраски bitmap'ов)
        /// </summary>
        private List<Flood> _floodEffects;
		/// <summary>
		/// Маски для изображений
		/// </summary>
		private List<Composite> _compositeEffects;

		/// <summary>
		/// Событие вызывается для получения времени, которое нужно отобразить
		/// </summary>
		public Func<TimeSpan> TimeSpanToDisplay = () => { return TimeSpan.Zero; };

		/// <summary>
		/// Центральная точка отрисовки
		/// </summary>
		private Vector2 _center;
		/// <summary>
		/// Масштаб
		/// </summary>
		private float _scale;


		public DigitalClockPanelSharpDX() : base()
		{
			Initialize(640, 240);

			_center = new Vector2(640 / 2, 240 / 2);
			_scale = 0.5f;

            //RunDrawingLoop();
        }

        ///////////////////////////////////////////////////
        ///												///
        /// МЕТОДЫ ДЛЯ ИНИЦИАЛИЗАЦИИ ДАННЫХ ОТРИСОВКИ	///
        ///												///
        ///////////////////////////////////////////////////

        /// <summary>
        /// Инициализировать изображения из объектов Image
        /// </summary>
        /// <param name="numberSetImages">Изображения наборов цифр</param>
        /// <param name="backgroundImages">Изображения фона</param>
        public void SetBitmaps(IEnumerable<System.Drawing.Image> numberSetImages, IEnumerable<System.Drawing.Image> backgroundImages)
		{
			// Инициализируем битмапы стрелок
			_numberSetBitmaps = new List<Bitmap1>();
			foreach (System.Drawing.Image image in numberSetImages)
			{
                _numberSetBitmaps.Add(ImageToDXBitmap(_d2dContext, image));
			}
            // Инициализируем битмапы циферблатов
            _backgroundBitmaps = new List<Bitmap1>();
            foreach (System.Drawing.Image image in backgroundImages)
            {
                _backgroundBitmaps.Add(ImageToDXBitmap(_d2dContext, image));
            }
			InitializeEffectsAndBrushes();
        }

		protected void InitializeEffectsAndBrushes()
		{
			// Инициализация эффектов заливки
			Flood numbersFlood = new Flood(_d2dContext);
			numbersFlood.Color = Color.Black;
			Flood backgroundFlood = new Flood(_d2dContext);
			backgroundFlood.Color = Color.Black;

            _floodEffects = new List<Flood>
			{
				numbersFlood,
				backgroundFlood
			};

			// Инициализация эффектов маски
			Composite numbersComposite = new Composite(_d2dContext);
            numbersComposite.Mode = CompositeMode.SourceIn;
            numbersComposite.SetInput(0, _numberSetBitmaps[0], true);
            numbersComposite.SetInputEffect(1, _floodEffects[0], true);

			Composite backgroundComposite = new Composite(_d2dContext);
            backgroundComposite.Mode = CompositeMode.SourceAtop;
            backgroundComposite.SetInput(0, _backgroundBitmaps[0], true);
            backgroundComposite.SetInputEffect(1, _floodEffects[1], true);

            _compositeEffects = new List<Composite>
			{
                numbersComposite,
                backgroundComposite
            };
        }


        ///////////////////////////////////////////////////
        ///												///
        ///	  МЕТОДЫ ДЛЯ ИЗМЕНЕНИЯ ДАННЫХ ОТРИСОВКИ		///
        ///												///
        ///////////////////////////////////////////////////

        /// <summary>
        /// Изменить цвета
        /// </summary>
        /// <param name="args">Структура с данными об изменённых цветах</param>
        public void ChangeColor(ChangeColorEventArgs args)
		{
			_floodEffects[args.id].Color = args.color;
		}

		/// <summary>
		/// Изменить индексы выбранных спрайтов
		/// </summary>
		/// <param name="args">Структура с индексами</param>
		public void ChangeSelectedBitmaps(ChangeSelectedBitmapsEventArgs args)
		{
			if (args.numberSetBitmapId != null)
			{
                _compositeEffects[0].SetInput(0, _numberSetBitmaps[args.numberSetBitmapId.Value], true);
            }
            if (args.backgroundBitmapId != null)
            {
                _compositeEffects[1].SetInput(0, _backgroundBitmaps[args.backgroundBitmapId.Value], true);
            }
        }

        /// <summary>
        /// Отрисовать кадр
        /// </summary>
        /// <param name="deltaTime">Время предыдущего кадра</param>
        protected override void Draw(float deltaTime)
		{
			////////////////////////////////////////////////////////////////////////////////////////////////////
			///
			/// ОТРИСОВКА КАДРА
			/// ЭТАПЫ:
			///     1.	Инициализация начальных данных и значений
			///     2.	Отрисовка статичных изображений (фон)
			///     3.	Отрисовка цифр
			/// 
			////////////////////////////////////////////////////////////////////////////////////////////////////


			_d2dContext.Transform = Matrix3x2.Transformation(_scale, _scale, 0, _center.X, _center.Y);

			_d2dContext.DrawImage(_compositeEffects[1], new Vector2(-1312f/2f, -416f/2f));

			TimeSpan timeToDisplay = TimeSpanToDisplay();
			int days = timeToDisplay.Days;
            int ms = timeToDisplay.Milliseconds;
            int seconds = timeToDisplay.Seconds;
            int minutes = timeToDisplay.Minutes;
            int hours = timeToDisplay.Hours;

            string stringDisplayed = timeToDisplay.ToString(@"hh\:mm\:ss\:fff");

            byte[] asciiBytes = Encoding.ASCII.GetBytes(stringDisplayed);

			float adjustOffset = 0;
			float colonOffset = 0;

            for (int i = 0; i < asciiBytes.Length; i++)
			{
				if (i == 9)
				{
					_d2dContext.Transform = Matrix3x2.Transformation(0.5f, 0.5f, 0, 184, 0) * _d2dContext.Transform;
				}
				float offsetX = asciiBytes[i] - Encoding.ASCII.GetBytes("0")[0];
				float widthOfDigit = 128;

				Vector2 offset = new Vector2(0, 0);
				offset += new Vector2(100f, 100f);
				offset += new Vector2(-1312f / 2f, -416f / 2f);
				offset.X += 128 * i;
				offset.X += adjustOffset;
				if (days != 0)
				{
					offsetX = 10;

                }
				if (stringDisplayed[i] == ':')
				{
					adjustOffset -= 128f - 32f;
					if (days == 0)
					{
						offsetX = 12;
					}
					else
					{
						offsetX = 13;
						colonOffset = 128f - 32f;
					}
					widthOfDigit = 32;
                }

                LayerParameters layerParameters = new LayerParameters()
                {
                    ContentBounds = new RectangleF(offset.X, offset.Y, widthOfDigit, 224),
                    GeometricMask = null,
                    LayerOptions = LayerOptions.None,
                    MaskAntialiasMode = AntialiasMode.PerPrimitive,
                    MaskTransform = Matrix3x2.Identity,
                    Opacity = 1,
                    OpacityBrush = null
                };

				offset.X += -128 * offsetX;
				offset.X += colonOffset;



                _d2dContext.PushLayer(ref layerParameters, null);
                _d2dContext.DrawImage(_compositeEffects[0], new Vector2(offset.X, offset.Y), SharpDX.Direct2D1.InterpolationMode.Linear, CompositeMode.SourceOver);
                _d2dContext.PopLayer();

				colonOffset = 0;
            }
        }
    }
}
