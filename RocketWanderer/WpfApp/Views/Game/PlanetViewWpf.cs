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
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Reflection;
using System.Windows.Shapes;

namespace WpfApp.Views.Game
{
  /// <summary>
  /// Представление планеты от Wpf
  /// </summary>
  public class PlanetViewWpf : PlanetView, IWpfItem
  {
    /// <summary>
    /// Полотно для планеты и орбиты
    /// </summary>
    private Canvas _canvas = new Canvas();

    /// <summary>
    /// Картинка планеты
    /// </summary>
    private Image _planetImage = new Image();

    /// <summary>
    /// Canvas, представляющая объект
    /// </summary>
    public UIElement Control
    {
      get { return _canvas; }
    }

    /// <summary>
    /// Круг-орбита
    /// </summary>
    private Ellipse _orbit = new Ellipse
    {
      Width = 100,  // Ширина круга
      Height = 100, // Высота круга
      Stroke = Brushes.Blue,          // Цвет обводки
      StrokeThickness = 5,            // Толщина обводки
      Fill = Brushes.Yellow           // Цвет заливки
    };

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlanet">Модель планеты</param>
    public PlanetViewWpf(Planet parPlanet, string parImagePath)
      : base(parPlanet)
    {
      _planetImage.Stretch = System.Windows.Media.Stretch.Uniform;
      _planetImage.Source = new BitmapImage(new Uri(parImagePath, UriKind.Relative));

      _canvas.Children.Add(_orbit);
      _canvas.Children.Add(_planetImage);
    }

    /// <summary>
    /// Отрисовывает планету
    /// </summary>
    public override void Draw()
    {
      base.Draw();
      
      Vector2 parentSize = Parent.AbsoluteSize;

      double scaleFactorPlanet = Planet.Radius / Map.VisibleSize.Y;

      _planetImage.Width = parentSize.Y * scaleFactorPlanet;
      _planetImage.Height = parentSize.Y * scaleFactorPlanet;

      Canvas.SetLeft(_planetImage, parentSize.X * Planet.Position.X / Map.VisibleSize.X - _planetImage.Width / 2);
      Canvas.SetTop(_planetImage, parentSize.Y * Planet.Position.Y / Map.VisibleSize.Y - _planetImage.Height / 2);


      double scaleFactorOrbit = Planet.OrbitRadius / Map.VisibleSize.Y;

      _orbit.Width = parentSize.Y * scaleFactorOrbit;
      _orbit.Height = parentSize.Y * scaleFactorOrbit;

      Canvas.SetLeft(_orbit, parentSize.X * Planet.Position.X / Map.VisibleSize.X - _orbit.Width / 2);
      Canvas.SetTop(_orbit, parentSize.Y * Planet.Position.Y / Map.VisibleSize.Y - _orbit.Height / 2);
    }

  }
}
