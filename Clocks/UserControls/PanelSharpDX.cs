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

namespace Clocks
{
	/// <summary>
	/// Основной класс элемента WinForms для отрисовки элементов через DirectX
	/// </summary>
	public partial class PanelSharpDX : UserControl
	{
		/// <summary>
		/// Была ли инициализация?
		/// </summary>
		bool _isInitialized = false;
		/// <summary>
		/// Стандартный интерфейс графического устройства DirectX
		/// </summary>
		protected SharpDX.Direct3D11.Device _device;
		/// <summary>
		/// Контекст стандартного устройства DirectX
		/// </summary>
		protected SharpDX.Direct3D11.DeviceContext _d3dContext;
		/// <summary>
		/// Контекст устройства Direct2D1
		/// </summary>
		protected SharpDX.Direct2D1.DeviceContext _d2dContext;
		/// <summary>
		/// Цепочка буферов (для двойной буферизации)
		/// </summary>
		protected SwapChain _swapChain;
		/// <summary>
		/// Задний буфер
		/// </summary>
		protected Bitmap1 _backBufferTarget;
		/// <summary>
		/// Фабрика объектов Direct2D1 (для создания ресурсов, кистей, отрисовки)
		/// </summary>
		protected SharpDX.Direct2D1.Factory _factory2D;
		/// <summary>
		/// Фабрика для создания объектов обработки и отрисовки текста
		/// </summary>
		protected SharpDX.DirectWrite.Factory _factoryDWrite;

		/// <summary>
		/// Должно ли окно продолжать выполнять отрисовку?
		/// </summary>
		protected bool _shouldRun = true;
		/// <summary>
		/// FPS
		/// </summary>
		protected int FrameRate
		{
			get
			{
				return 60;
            }
		}

        [DllImport("Winuser.dll")]
        static extern bool EnumDisplaySettingsA(IntPtr lpszDeviceName, int iModeNum, IntPtr lpDevMode);


        protected bool _isRunning = false;

		/// <summary>
		/// Переводит изображение из формата System.Drawing.Image в Bitmap для DirectX
		/// </summary>
		/// <param name="renderTarget">RenderTarget, куда будет выполняться отрисовка изображения</param>
		/// <param name="image">Изображение</param>
		/// <returns>D2D1 Bitmap</returns>
		public static Bitmap1 ImageToDXBitmap(SharpDX.Direct2D1.DeviceContext d2dContext, System.Drawing.Image image)
		{
			//Конвертируем Image в Bitmap
			using (var bitmap = (System.Drawing.Bitmap)image)
			{
				// Определения области изображения (всё изображение целиком, в нашем случае)
				var sourceArea = new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height);
				// Создаем структуру с параметрами Direct2D1 Bitmap'а
				var bitmapProperties = new BitmapProperties1(new SharpDX.Direct2D1.PixelFormat(Format.R8G8B8A8_UNorm, SharpDX.Direct2D1.AlphaMode.Premultiplied), 96, 96, BitmapOptions.None);
				// Размер изображения
				var size = new Size2(bitmap.Width, bitmap.Height);

				/*
				 *  Перевод пикселей из формата BGRA в RGBA 
				 */
				// Длина строки в байтах (ширина изображения * кол-во битов в пикселе)
				int stride = bitmap.Width * sizeof(int);
				// Буфер для хранения данных об конвертированном изображении (временный, для передачи в Direct2D1 Bitmap)
				using (var tempStream = new DataStream(bitmap.Height * stride, true, true))
				{
					// Блокируем память объекта (предотвращение доступа извне (другие процессы), безопасный доступ напрямую)
					var bitmapData = bitmap.LockBits(sourceArea, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

					// Конвертация пикселей
					for (int y = 0; y < bitmap.Height; y++)
					{
						int offset = bitmapData.Stride * y;
						for (int x = 0; x < bitmap.Width; x++)
						{
							// Читаем данные пикселя (32 бита)
							int pixelData = Marshal.ReadInt32(bitmapData.Scan0, offset);
							// Увеличиваем сдвиг
							offset += 4;
							// Считываем байты по порядку с помощью побитовых операций
							byte B = (byte)(pixelData & 0xFF);
							byte G = (byte)((pixelData >> 8) & 0xFF);
							byte R = (byte)((pixelData >> 16) & 0xFF);
							byte A = (byte)((pixelData >> 24) & 0xFF);
							// Записываем в int в порядке RGBA
							int rgba = R | (G << 8) | (B << 16) | (A << 24);

							// Записываем в буфер
							tempStream.Write(rgba);
						}

					}
					// Разблокируем память
					bitmap.UnlockBits(bitmapData);
					// Задаем позицию буфера в начало, чтобы считать его с начала
					tempStream.Position = 0;

					// Создаем объект Direct2D1 Bitmap, возвращаем
					return new Bitmap1(d2dContext, size, tempStream, stride, bitmapProperties);
				}
			}
		}

		/// <summary>
		/// Загружает файл изображения в Bitmap для DirectX
		/// </summary>
		/// <param name="renderTarget">RenderTarget, куда будет выполняться отрисовка изображения</param>
		/// <param name="file">Файл изображения</param>
		/// <returns>D2D1 Bitmap</returns>
		public static Bitmap1 FileToDXBitmap(SharpDX.Direct2D1.DeviceContext d2dContext, string file)
		{
			// Получаем полный путь
			// file = Path.GetFullPath(file);

			// Загружаем изображение из файла в System.Drawing.Image, вызываем метод выше
			return ImageToDXBitmap(d2dContext, System.Drawing.Image.FromFile(file));
		}

		public PanelSharpDX()
		{
			InitializeComponent();
		}

		public PanelSharpDX(int width, int height)
		{
			InitializeComponent();
			Initialize(width, height);
		}

		public void Initialize(int width, int height)
		{
			// Описание цепочки буферов
			var desc = new SwapChainDescription()
			{
				BufferCount = 1,
				ModeDescription = new ModeDescription(
					width,                                              // ширина экрана
					height,                                             // высота экрана
					new Rational(FrameRate, 1), Format.R8G8B8A8_UNorm  // FPS, цветовой режим
																		// (32 бит + альфа канал)
				),
				IsWindowed = true,                                  // ставим режим "в окне"
																	// (нужно для отрисовки в окно элемента)
				OutputHandle = this.Handle,                         // задаем отрисовку в дескриптор окна элемента
				SampleDescription = new SampleDescription(1, 0),    // отключаем мультисэмплинг
				SwapEffect = SwapEffect.Discard,
				Usage = Usage.RenderTargetOutput					// задаем режим вывода (отрисовки) 
			};

			// Создаем экземпляр устройства с цепочкой буферов
			SharpDX.Direct3D11.Device.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.BgraSupport, new[] { SharpDX.Direct3D.FeatureLevel.Level_10_0 }, desc, out _device, out _swapChain);
			_d3dContext = new SharpDX.Direct3D11.DeviceContext(_device);

			// Продвинутые DXGI объекты (для D2D1)
			SharpDX.DXGI.Device2 dxgiDevice2 = _device.QueryInterface<SharpDX.DXGI.Device2>();
			SharpDX.DXGI.Adapter dxgiAdapter = dxgiDevice2.Adapter;
			SharpDX.DXGI.Factory factory = _swapChain.GetParent<SharpDX.DXGI.Factory>();
			// Экземпляр устройства D2D1
			SharpDX.Direct2D1.Device d2dDevice = new SharpDX.Direct2D1.Device(dxgiDevice2);
			// Задаем ассоциацию фабрики объектов с нашим окном
			// (игнорируем все события окна)
			factory.MakeWindowAssociation(this.Handle, WindowAssociationFlags.IgnoreAll);

			// Создаем контекст, связанный с задним буфером
			using (var dxgiBackBuffer = _swapChain.GetBackBuffer<SharpDX.DXGI.Surface>(0))
			{
				_d2dContext = new SharpDX.Direct2D1.DeviceContext(d2dDevice, DeviceContextOptions.None);
				BitmapProperties1 bitmapProperties = new BitmapProperties1(
					// Формат пикселей (32 бит+альфа канал)
					new SharpDX.Direct2D1.PixelFormat(Format.R8G8B8A8_UNorm, SharpDX.Direct2D1.AlphaMode.Premultiplied),
					// DPI экрана (0 - текущий/стандартный для системы)
					dpiX: 0, dpiY: 0,
					// Битмап используется как цель отрисовки | Не может быть отрисована
					BitmapOptions.Target | BitmapOptions.CannotDraw
				);

				_backBufferTarget = new Bitmap1(_d2dContext, dxgiBackBuffer, bitmapProperties);

				_d2dContext.Target = _backBufferTarget;
			}
			// Фабрика объектов для D2D1
			_factory2D = new SharpDX.Direct2D1.Factory();
			// Фабрика объектов для DirectWrite (отрисовка текста)
			_factoryDWrite = new SharpDX.DirectWrite.Factory();
			// Инициализация была проведена, меняем флаг на true
			_isInitialized = true;
		}

		public void Stop()
		{
			_shouldRun = false;
		}

		/// <summary>
		/// Запустить цикл отрисовки
		/// </summary>
		/// <returns></returns>
		public async Task RunDrawingLoop()
		{
            // todo:	посмотреть, можно ли выделить отрисовку в отдельный поток
            //			чтобы можно было отрисовывать с большим фпс
            //			(в т.ч. с бесконечным, при этом формы параллейно
            //			могли отвечать на запросы системы)

            // Цикл не запущен еще И инициализация прошла
            if (!_isRunning && _isInitialized)
			{
				// Цикл запущен, предотвращаем запуск второго цикла отрисовки
				_isRunning = true;
				_shouldRun = true;
				// Время предыдущего кадра
				float deltaTime = 0.014f;
				// Выполняем отрисовку, пока нужно (не был вызван Stop() или Dispose())
				while (_shouldRun)
				{
					// Замеряем время кадра
					Stopwatch sw = Stopwatch.StartNew();
					// Отрисовываем кадр
					BeginDraw();
					Draw(deltaTime);
					EndDraw();
					// Останавливаем замер времени
					sw.Stop();
					// задаем время кадра
					deltaTime = sw.ElapsedMilliseconds;
                    // Получаем время, которое нужно подождать перед следующим кадром
                    // (в зависимости от FPS)
                    float timeToWait = (1000.0f / FrameRate) - deltaTime;
					if (timeToWait > 0)
					{
						// Ждем перед выполнением следующего кадра
						await Task.Delay(TimeSpan.FromMilliseconds(timeToWait));
					}
				}

				_isRunning = false;
			}
		}

		/// <summary>
		/// Подготовить отрисовку
		/// </summary>
		protected void BeginDraw()
		{
			_d2dContext.BeginDraw();
			_d2dContext.Clear(Color.White);
		}
		/// <summary>
		/// Отрисовать кадр
		/// </summary>
		/// <param name="deltaTime">Время предыдущего кадра</param>
		protected virtual void Draw(float deltaTime)
		{
			
		}

		/// <summary>
		/// Закончить отрисовку
		/// </summary>
		protected void EndDraw()
		{
			_d2dContext.EndDraw();
			// Меняем буферы местами
			_swapChain.Present(1, PresentFlags.None);
		}

		~PanelSharpDX()
		{
			_shouldRun = false;
			Dispose();
		}

		protected new void Dispose()
		{

		}
	}
}
