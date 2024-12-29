using Logic.Models.Game;
using Logic.Utils;
using Logic.Views.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp.Views.Game
{
  /// <summary>
  /// Представление карты от Wpf
  /// </summary>
  public class MapViewWpf : MapView, IWpfItem
  {
    /// <summary>
    /// Относительные пути к изображениям
    /// </summary>
    private static List<string> _imagesPath = new List<string>
    {
      "planet_1.png",
      "planet_2.png",
      "planet_3.png",
      "planet_4.png",
    };

    /// <summary>
    /// Путь к папке с изображениями
    /// </summary>
    private static string _imagesFolder = "Images\\";

    /// <summary>
    /// Главный контролл представления
    /// </summary>
    private Canvas _canvasControl = new Canvas();

    /// <summary>
    /// Canvas, представляющий объект
    /// </summary>
    public UIElement Control
    {
      get { return _canvasControl; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMap"></param>
    public MapViewWpf(Map parMap)
      : base(parMap)
    {
      IWpfItem.AddChild(this, StartPlanetView);
      IWpfItem.AddChild(this, SunView);
      IWpfItem.AddChild(this, TopBeltView);
      IWpfItem.AddChild(this, BottomBeltView);

      foreach (PlanetView elPlanetView in PlanetsView)
      {
        IWpfItem.AddChild(this, elPlanetView);
      }

      IWpfItem.AddChild(this, RocketView);

      ImageBrush imageBrush = new ImageBrush
      {
        ImageSource = new BitmapImage(new Uri("Images\\space_background.jpg", UriKind.Relative)),
        Stretch = Stretch.UniformToFill
      };
      
      _canvasControl.Background = imageBrush;
    }

    /// <summary>
    /// Отрисовывает карту
    /// </summary>
    public override void Draw()
    {
      Vector2 parentSize = Parent.AbsoluteSize;

      _canvasControl.Width = parentSize.X;
      _canvasControl.Height = Math.Max(parentSize.Y - 40, 0);

      AbsoluteSize = new Vector2(_canvasControl.Width, _canvasControl.Height);

      DrawChildren();
    }

    /// <summary>
    /// Создает представление ракеты от Wpf
    /// </summary>
    /// <returns>Представление ракеты от Wpf</returns>
    public override RocketView CreateRocketView()
    {
      return new RocketViewWpf(Map.Rocket);
    }

    /// <summary>
    /// Создает представление стартовой планеты от Wpf
    /// </summary>
    /// <returns>Представление стартовой планеты от Wpf</returns>
    public override PlanetView CreateStartPlanetView()
    {
      return new PlanetViewWpf(Map.StartPlanet, "Images\\start_planet.png");
    }

    /// <summary>
    /// Создает представление генерируемой планеты от Wpf
    /// </summary>
    /// <param name="parPlanet">Модель планеты</param>
    /// <returns>Представление генерируемой планеты от Wpf</returns>
    public override PlanetView CreatePlanetView(Planet parPlanet)
    {
      return new PlanetViewWpf(parPlanet, _imagesFolder + _imagesPath[new Random().Next(_imagesPath.Count)]);
    }

    /// <summary>
    /// Создает представление солнца от Wpf
    /// </summary>
    /// <returns>Представление солнца от Wpf</returns>
    public override SunView CreateSunView()
    {
      return new SunViewWpf(Map.Sun);
    }

    /// <summary>
    /// Создает представление пояса астероидов от Wpf
    /// </summary>
    /// <param name="parAsteroidBelt">Модель пояса астероидов</param>
    /// <returns>Представление пояса астероидов от Wpf</returns>
    public override AsteroidBeltView CreateAsteroidBeltView(AsteroidBelt parAsteroidBelt)
    {
      return new AsteroidBeltViewWpf(parAsteroidBelt);
    }

  }
}
