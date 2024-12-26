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
      
      _rocketImage.Width  = parentSize.X * Rocket.Size.X / Map.VisibleSize.X;
      _rocketImage.Height = parentSize.Y * Rocket.Size.Y / Map.VisibleSize.Y;

      Canvas.SetLeft(_rocketImage, parentSize.X * Rocket.Position.X / Map.VisibleSize.X - _rocketImage.Width / 2);
      Canvas.SetTop (_rocketImage, parentSize.Y * Rocket.Position.Y / Map.VisibleSize.Y - _rocketImage.Height / 2);
    }
  }
}
