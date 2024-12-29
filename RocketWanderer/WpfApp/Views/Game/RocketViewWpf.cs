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
  /// Представление ракеты от Wpf
  /// </summary>
  public class RocketViewWpf : RocketView, IWpfItem
  {
    /// <summary>
    /// Картинка ракеты
    /// </summary>
    private Image _rocketImage = new Image();

    /// <summary>
    /// Картинка, представляющая объект
    /// </summary>
    public UIElement Control
    {
      get { return _rocketImage; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parRocket">Модель ракеты</param>
    public RocketViewWpf(Rocket parRocket) 
      : base(parRocket)
    {
      _rocketImage.Stretch = System.Windows.Media.Stretch.Uniform;
      _rocketImage.Source = new BitmapImage(new Uri("Images\\rocket.png", UriKind.Relative));
      _rocketImage.RenderTransform = new RotateTransform(Rocket.Rotation);
      _rocketImage.RenderTransformOrigin = new Point(0.5, 0.5);
    }

    /// <summary>
    /// Отрисовывает ракету
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;

      double scale = parentSize.Y / Map.Size.Y;

      _rocketImage.Width  = Rocket.Size.X * scale;
      _rocketImage.Height = Rocket.Size.Y * scale;

      _rocketImage.RenderTransform = new RotateTransform(Rocket.Rotation);

      Canvas.SetLeft(_rocketImage, Rocket.Position.X * scale - _rocketImage.Width / 2);
      Canvas.SetTop (_rocketImage, Rocket.Position.Y * scale - _rocketImage.Height / 2);
    }
  }
}
