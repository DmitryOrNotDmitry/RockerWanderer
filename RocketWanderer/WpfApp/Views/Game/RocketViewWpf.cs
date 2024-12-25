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
      _rocketImage.Source = new BitmapImage(new Uri("C:\\Users\\cuzne\\Downloads\\rocket.png", UriKind.Absolute));
      _rocketImage.RenderTransform = new RotateTransform(90);
    }

    /// <summary>
    /// Отрисовывает ракету
    /// </summary>
    /// <param name="parParentSize"></param>
    public override void Draw(Vector2 parParentSize)
    {
      _rocketImage.Width = Rocket.Size.X;
      _rocketImage.Height = Rocket.Size.Y;

      Canvas.SetLeft(_rocketImage, Rocket.Position.X - _rocketImage.Width / 2);
      Canvas.SetTop(_rocketImage, Rocket.Position.Y - _rocketImage.Height / 2);
    }
  }
}
