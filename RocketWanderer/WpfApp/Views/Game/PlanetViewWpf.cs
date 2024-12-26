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

namespace WpfApp.Views.Game
{
  /// <summary>
  /// Представление планеты от Wpf
  /// </summary>
  public class PlanetViewWpf : PlanetView, IWpfItem
  {
    /// <summary>
    /// Картинка планеты
    /// </summary>
    private Image _planetImage = new Image();

    /// <summary>
    /// Картинка, представляющая объект
    /// </summary>
    public UIElement Control
    {
      get { return _planetImage; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlanet">Модель планеты</param>
    public PlanetViewWpf(Planet parPlanet, string parImagePath)
      : base(parPlanet)
    {
      _planetImage.Stretch = System.Windows.Media.Stretch.Uniform;
      _planetImage.Source = new BitmapImage(new Uri(parImagePath, UriKind.Relative));
    }

    /// <summary>
    /// Отрисовывает ракету
    /// </summary>
    public override void Draw()
    {
      base.Draw();
      
      Vector2 parentSize = Parent.AbsoluteSize;

      _planetImage.Width = parentSize.X * Planet.Size.X / Map.VisibleSize.X;
      _planetImage.Height = parentSize.Y * Planet.Size.Y / Map.VisibleSize.Y;

      Canvas.SetLeft(_planetImage, parentSize.X * Planet.Position.X / Map.VisibleSize.X - _planetImage.Width / 2);
      Canvas.SetTop (_planetImage, parentSize.Y * Planet.Position.Y / Map.VisibleSize.Y - _planetImage.Height / 2);
    }

  }
}
