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
      Stroke = new SolidColorBrush(Color.FromArgb(50, 0, 0, 200)),
      StrokeThickness = 5,  
      Fill = new SolidColorBrush(Color.FromArgb(50, 0, 255, 255))
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

      double scale = parentSize.Y / Map.Size.Y;

      _planetImage.Width = Planet.Size.X * scale;
      _planetImage.Height = Planet.Size.Y * scale;

      Canvas.SetLeft(_planetImage, Planet.Position.X * scale - _planetImage.Width / 2);
      Canvas.SetTop (_planetImage, Planet.Position.Y * scale - _planetImage.Height / 2);


      _orbit.Width = 2 * Planet.OrbitRadius * scale;
      _orbit.Height = 2 * Planet.OrbitRadius * scale;

      Canvas.SetLeft(_orbit, Planet.Position.X * scale - _orbit.Width / 2);
      Canvas.SetTop (_orbit, Planet.Position.Y * scale - _orbit.Height / 2);
    }

  }
}
