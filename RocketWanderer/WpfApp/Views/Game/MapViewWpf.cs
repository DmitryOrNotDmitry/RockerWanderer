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

namespace WpfApp.Views.Game
{
  /// <summary>
  /// Представление карты от Wpf
  /// </summary>
  public class MapViewWpf : MapView, IWpfItem
  {
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
      IWpfItem.AddChild(this, RocketView);
      IWpfItem.AddChild(this, StartPlanetView);

    }

    /// <summary>
    /// Отрисовывает карту
    /// </summary>
    public override void Draw()
    {
      Vector2 parentSize = Parent.AbsoluteSize;

      _canvasControl.Width = parentSize.X;
      _canvasControl.Height = Math.Max(parentSize.Y - 50, 0);

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
  }
}
