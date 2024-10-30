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

namespace Clocks
{
	public partial class ClockPanelSharpDX : PanelSharpDX
	{
        /// <summary>
        /// Стрелки часов
        /// </summary>
        public enum Clockhand
        {
            SECONDS = 0, MINUTES = 1, HOURS = 2
        }

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

		public string Font
		{
			get; set;
		}

		/// <summary>
		/// Структура с данными об изменённых индексах
		/// </summary>
		public struct ChangeSelectedBitmapsEventArgs
		{
			/// <summary>
			/// Индекс стрелок аналоговых часов
			/// </summary>
			public int? clockhandsBitmapId;
			/// <summary>
			/// Индекс циферблата аналоговых часов
			/// </summary>
			public int? clockfacesBitmapId;
		}

		// Делегаты событий, для изменения данных отрисовки во время работы программы
        public delegate void ChangeColorEvent(ChangeColorEventArgs args);
        public delegate void ChangeSelectedBitmapsEvent(ChangeSelectedBitmapsEventArgs args);

		/// <summary>
		/// Direct2D1 Bitmap'ы для стрелок часов. Выбор, какой именно отрисовывать, осуществляется по индексам
		/// </summary>
		private List<Bitmap1> _clockhandsBitmaps;

        /// <summary>
        /// Direct2D1 Bitmap'ы для циферблатов. Выбор, какой именно отрисовывать, осуществляется по индексам
        /// </summary>
        private List<Bitmap1> _clockfacesBitmaps;

        /// <summary>
        /// Эффекты заливки (для перекраски bitmap'ов)
        /// </summary>
        private List<Flood> _floodEffects;
		/// <summary>
		/// Маски для изображений
		/// </summary>
		private List<Composite> _compositeEffects;
		/// <summary>
		/// Кисти (сплошной цвет)
		/// </summary>
		private List<SolidColorBrush> _solidColorBrushes;

		
		/// <summary>
		/// Функции анимаций (возвращают массив оффсетов для каждой из стрелок)
		/// </summary>
		private List<Func<int, int, int, int, Clockhand, float>> _animationFuncs = new List<Func<int, int, int, int, Clockhand, float>>
		{ 
			// Плавная анимация, ускорение->замедление
			(ms, s, m, h, clockhand) => 
			{
				// Смещение
				float offset;
				// Смещение плавной анимации (косинусоида)
                float msAnimOffset = (0.5f - (float)Math.Cos((float)ms / 1000.0f * Math.PI) / 2.0f);
				// задаем смещение в зависимости от выбранной стрелки
				if (clockhand == Clockhand.SECONDS)
				{
					// Сумма смещений полных секунд и анимации,
					// умноженная на размер шага секунды
					// (360 градусов в окружности / 60 секунд в минуте = 6 градусов шаг секунды)
                    offset = Convertors.DegreesToRadians((s + msAnimOffset) * 6.0f);
				}
				else if (clockhand == Clockhand.MINUTES)
				{
					// Плавная анимация прямо перед началом следующей минуты
					if (s == 59)
					{
						offset = Convertors.DegreesToRadians((m + msAnimOffset) * 6.0f);
                    }
					// иначе статичная
                    else
                    {
						offset = Convertors.DegreesToRadians(m * 6);
					}
                }
				else
				{
					// Плавная анимация прямо перед началом следующего часа
					if (m == 59 && s == 59)
                    {
                        offset = Convertors.DegreesToRadians((h + msAnimOffset) * 30.0f);
                    }
					// иначе статичная
                    else
                    {
                        offset = Convertors.DegreesToRadians(h * 30);
                    }
                }
				return offset;
            },
			// Линейная анимация
			(ms, s, m, h, clockhand) =>
            {
				// Смещение
				float offset;
				// Линейное смещение по миллисекундам
				float msAnimOffset = ((float)ms / 1000.0f);
				// Линейное смещение по секундам
				float sAnimOffset = ((float)s / 60.0f);
				// Линейное смещение по минутам
				float mAnimOffset = ((float)m / 60.0f);
				// задаем смещение в зависимости от выбранной стрелки
				if (clockhand == Clockhand.SECONDS)
                {
					
					// Сумма смещений полных секунд и анимации,
					// умноженная на размер шага секунды
					// (360 градусов в окружности / 60 секунд в минуте = 6 градусов шаг секунды)
                    offset = Convertors.DegreesToRadians((s + msAnimOffset) * 6.0f);
                }
                else if (clockhand == Clockhand.MINUTES)
                {
                    offset = Convertors.DegreesToRadians((m + sAnimOffset) * 6.0f);
                }
                else
                {
					offset = Convertors.DegreesToRadians((h * 30.0f) + (mAnimOffset * 30.0f));
                }
                return offset;
            },
			// Без анимации
			(ms, s, m, h, clockhand) =>
            {
				// Смещение
				float offset;
				// задаем смещение в зависимости от выбранной стрелки
				if (clockhand == Clockhand.SECONDS)
                {
					// Смещение от секунд
					// (360 градусов в окружности / 60 секунд в минуте = 6 градусов шаг секунды)
                    offset = Convertors.DegreesToRadians(s * 6.0f);
                }
                else if (clockhand == Clockhand.MINUTES)
                {
                    offset = Convertors.DegreesToRadians(m * 6.0f);
                }
                else
                {
                    offset = Convertors.DegreesToRadians(h * 30.0f);
                }
                return offset;
            },
        };

		/// <summary>
		/// Индексы выбранных анимаций (для каждой из стрелок)
		/// </summary>
		private List<int> _selectedAnimations = new List<int>{ 0, 0, 0 };

		/// <summary>
		/// Задаваемая функция для получения времени
		/// </summary>
		public Func<TimeSpan> TimeSpanToDisplay = () => { return TimeSpan.Zero; };

		/// <summary>
		/// Смещение центра часов от левого верхнего угла
		/// </summary>
		private int _offsetX, _offsetY;


		public ClockPanelSharpDX() : base()
		{
			Initialize(640, 640);

			_offsetX = 640 / 2;
			_offsetY = 640 / 2;

			Font = "Arial";

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
        /// <param name="clockhandsImages">Изображения стрелок часов</param>
        /// <param name="clockfacesImages">Изображения циферблатов</param>
        public void SetBitmaps(IEnumerable<System.Drawing.Image> clockhandsImages, IEnumerable<System.Drawing.Image> clockfacesImages)
		{
			// Инициализируем битмапы стрелок
			_clockhandsBitmaps = new List<Bitmap1>();
			foreach (System.Drawing.Image image in clockhandsImages)
			{
                _clockhandsBitmaps.Add(ImageToDXBitmap(_d2dContext, image));
			}
            // Инициализируем битмапы циферблатов
            _clockfacesBitmaps = new List<Bitmap1>();
            foreach (System.Drawing.Image image in clockfacesImages)
            {
                _clockfacesBitmaps.Add(ImageToDXBitmap(_d2dContext, image));
            }
			InitializeEffectsAndBrushes();
        }

		public void InitializeEffectsAndBrushes()
		{
			// Инициализация эффектов заливки
			Flood clockhandFlood1 = new Flood(_d2dContext);
			clockhandFlood1.Color = Color.Black;
			Flood clockhandFlood2 = new Flood(_d2dContext);
            clockhandFlood2.Color = Color.Black;
			Flood clockhandFlood3 = new Flood(_d2dContext);
            clockhandFlood3.Color = Color.Black;
			Flood clockfaceFlood = new Flood(_d2dContext);
            clockfaceFlood.Color = Color.Black;

            _floodEffects = new List<Flood>
			{
				clockhandFlood1,	////
				clockhandFlood2,	//		Стрелки
				clockhandFlood3,	////
				clockfaceFlood		//		Циферблат
			};

			// Инициализация эффектов маски
			Composite clockhandComposite1 = new Composite(_d2dContext);
			clockhandComposite1.Mode = CompositeMode.SourceIn;
			clockhandComposite1.SetInput(0, _clockhandsBitmaps[0], true);
			clockhandComposite1.SetInputEffect(1, _floodEffects[0], true);

			Composite clockhandComposite2 = new Composite(_d2dContext);
            clockhandComposite2.Mode = CompositeMode.SourceIn;
            clockhandComposite2.SetInput(0, _clockhandsBitmaps[0], true);
			clockhandComposite2.SetInputEffect(1, _floodEffects[1], true);

			Composite clockhandComposite3 = new Composite(_d2dContext);
            clockhandComposite3.Mode = CompositeMode.SourceIn;
            clockhandComposite3.SetInput(0, _clockhandsBitmaps[0], true);
			clockhandComposite3.SetInputEffect(1, _floodEffects[2], true);

			Composite clockfaceComposite = new Composite(_d2dContext);
            clockfaceComposite.Mode = CompositeMode.SourceIn;
            clockfaceComposite.SetInput(0, _clockfacesBitmaps[0], true);
			clockfaceComposite.SetInputEffect(1, _floodEffects[3], true);

            _compositeEffects = new List<Composite>
			{
				clockhandComposite1,
				clockhandComposite2,
				clockhandComposite3,
				clockfaceComposite
			};

			// Инициализация кистей
			_solidColorBrushes = new List<SolidColorBrush>
			{
				new SolidColorBrush(_d2dContext, Color.Black)	// Цифры
			};
        }


        ///////////////////////////////////////////////////
        ///												///
        ///	  МЕТОДЫ ДЛЯ ИЗМЕНЕНИЯ ДАННЫХ ОТРИСОВКИ		///
        ///												///
        ///////////////////////////////////////////////////
        
        /// <summary>
        /// Изменить шрифт
        /// </summary>
        /// <param name="font">Название шрифта</param>
        public void ChangeFont(string font)
        {
            Font = font;
        }

        /// <summary>
        /// Изменить цвета
        /// </summary>
        /// <param name="args">Структура с данными об изменённых цветах</param>
        public void ChangeColor(ChangeColorEventArgs args)
		{
			// Цвет относится к заливке bitmap'а (см. примечание к _colors)
			if (args.id <= 3)
			{
				_floodEffects[args.id].Color = args.color;
			}
			// Цвет относится к кистям (цвет цифр на циферблате, ...)
			else
			{
				_solidColorBrushes[args.id - 4].Color = args.color;
			}
		}

		/// <summary>
		/// Изменить индексы выбранных спрайтов
		/// </summary>
		/// <param name="args">Структура с индексами</param>
		public void ChangeSelectedBitmaps(ChangeSelectedBitmapsEventArgs args)
		{
			if (args.clockhandsBitmapId != null)
			{
                _compositeEffects[0].SetInput(0, _clockhandsBitmaps[args.clockhandsBitmapId.Value], true);
                _compositeEffects[1].SetInput(0, _clockhandsBitmaps[args.clockhandsBitmapId.Value], true);
                _compositeEffects[2].SetInput(0, _clockhandsBitmaps[args.clockhandsBitmapId.Value], true);
            }
            if (args.clockfacesBitmapId != null)
            {
                _compositeEffects[3].SetInput(0, _clockfacesBitmaps[args.clockfacesBitmapId.Value], true);
            }
        }

		/// <summary>
		/// Изменить используемую функцию анимации для выбранной стрелки
		/// </summary>
		/// <param name="clockhandIndex">Стрелка, для которой изменить анимацию (0 - секундная, 1 - минутная, 2 - часовая)</param>
		/// <param name="animIndex">Индекс выбранной анимации</param>
		public void ChangeAnimation(Clockhand clockhandIndex, int animIndex)
		{
			_selectedAnimations[(int)clockhandIndex] = animIndex;
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
			///     2.	Отрисовка статичных изображений (циферблат, цифры ...) 
			///			(является бэкграундом в большинстве своем, на котором уже отображаются стрелки и т.д.)
			///     3.	Отрисовка стрелок
			/// 
			////////////////////////////////////////////////////////////////////////////////////////////////////

			// Отрисовываем фон за циферблатом //
			// todo: добавить отрисовку фона по возможности

			// Отрисовываем циферблат //

			_d2dContext.Transform = Matrix3x2.Identity;
			_d2dContext.DrawImage(_compositeEffects[3]);

			// Отрисовываем цифры //

			SharpDX.DirectWrite.TextFormat textFormat = new SharpDX.DirectWrite.TextFormat(
				_factoryDWrite, Font, 48
			);
			// Задаем начальную точку в центр циферблата
            _d2dContext.Transform = Matrix3x2.Translation(_offsetX - 14, _offsetY - 24);

			for (int i = 1; i <= 12; i++)
			{
				RectangleF pos = new RectangleF();
				// Радиус окружности, от центра до цифр циферблата
				float numberAreaRadius = 240.0f;
				// Находим X в зависимости от числа
				pos.X = (float)Math.Sin(Convertors.DegreesToRadians(30 * i)) * numberAreaRadius;
				// Смещение для двухзначных чисел
				pos.X -= 14.0f * (i / 10);
				pos.Y = (float)-Math.Cos(Convertors.DegreesToRadians(30 * i)) * numberAreaRadius;
				pos.Width = 124;
				pos.Height = 48;
				_d2dContext.DrawText(i.ToString(), textFormat, pos, _solidColorBrushes[0], DrawTextOptions.NoSnap);
            }

			// Получаем переменные времени (мс, с, м, ч)
			TimeSpan timeToDisplay = TimeSpanToDisplay();
			int ms = timeToDisplay.Milliseconds;
			int seconds = timeToDisplay.Seconds;
			int minutes = timeToDisplay.Minutes;
			int hours = timeToDisplay.Hours;

			float offsetS = _animationFuncs[_selectedAnimations[0]](ms, seconds, minutes, hours, Clockhand.SECONDS);
            float offsetM = _animationFuncs[_selectedAnimations[1]](ms, seconds, minutes, hours, Clockhand.MINUTES);
            float offsetH = _animationFuncs[_selectedAnimations[2]](ms, seconds, minutes, hours, Clockhand.HOURS);


			// Матрица, которую будем трансформировать
			// нужна для смещения центральной точки отрисовки и её вращения
			// (отрисовывать под углом)
            Matrix3x2 rotated = Matrix3x2.Identity;
            LayerParameters layerParameters = new LayerParameters()
            {
                ContentBounds = new RectangleF(0, -480, 60, 960),
                GeometricMask = null,
                LayerOptions = LayerOptions.None,
                MaskAntialiasMode = AntialiasMode.PerPrimitive,
                MaskTransform = Matrix3x2.Identity,
                Opacity = 1,
                OpacityBrush = null
            };

            // Отрисовка секундной стрелки //
            Matrix3x2.Transformation(0.5f, 0.5f, 0, _offsetX - 15, _offsetY, out rotated);
            rotated *= Matrix3x2.Rotation(offsetS, new Vector2(_offsetX, _offsetY));
            _d2dContext.Transform = rotated;
            _d2dContext.PushLayer(ref layerParameters, null);
            _d2dContext.DrawImage(_compositeEffects[0], new Vector2(0, -480), SharpDX.Direct2D1.InterpolationMode.Linear, CompositeMode.SourceOver);
            _d2dContext.PopLayer();

            // Отрисовка минутной стрелки //
            Matrix3x2.Transformation(0.5f, 0.5f, 0, _offsetX - 15, _offsetY, out rotated);
            rotated *= Matrix3x2.Rotation(offsetM, new Vector2(_offsetX, _offsetY));
            _d2dContext.Transform = rotated;
            _d2dContext.PushLayer(ref layerParameters, null);
            _d2dContext.DrawImage(_compositeEffects[1], new Vector2(-60, -480), SharpDX.Direct2D1.InterpolationMode.Linear, CompositeMode.SourceOver);
			_d2dContext.PopLayer();

            // Отрисовка часовой стрелки //
            Matrix3x2.Transformation(0.5f, 0.5f, 0, _offsetX - 15, _offsetY, out rotated);
            rotated *= Matrix3x2.Rotation(offsetH, new Vector2(_offsetX, _offsetY));
            _d2dContext.Transform = rotated;
            _d2dContext.PushLayer(ref layerParameters, null);
            _d2dContext.DrawImage(_compositeEffects[2], new Vector2(-120, -480), SharpDX.Direct2D1.InterpolationMode.Linear, CompositeMode.SourceOver);
			_d2dContext.PopLayer();
        }
    }
}
