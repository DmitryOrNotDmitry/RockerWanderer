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

namespace WpfApp.Views.Game
{
  /// <summary>
  /// Представление пояса астероидов от Wpf
  /// </summary>
  public class AsteroidBeltViewWpf : AsteroidBeltView, IWpfItem
  {
    /// <summary>
    /// Картинка пояса астероидов
    /// </summary>
    private Image _beltImage = new Image();

    /// <summary>
    /// Картинка, представляющая объект
    /// </summary>
    public UIElement Control
    {
      get { return _beltImage; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parAsteroidBelt">Модель пояса астероидов</param>
    public AsteroidBeltViewWpf(AsteroidBelt parAsteroidBelt) 
      : base(parAsteroidBelt)
    {
      _beltImage.Stretch = System.Windows.Media.Stretch.Uniform;
      _beltImage.Source = new BitmapImage(new Uri("Images\\asteroid_belt.png", UriKind.Relative));
    }

    /// <summary>
    /// Отрисовывает пояс астероидов
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;

      _beltImage.Width = parentSize.X * AsteroidBelt.Size.X / Map.VisibleSize.X;
      _beltImage.Height = parentSize.Y * AsteroidBelt.Size.Y / Map.VisibleSize.Y;

      Canvas.SetLeft(_beltImage, parentSize.X * AsteroidBelt.Position.X / Map.VisibleSize.X - _beltImage.Width / 2);
      Canvas.SetTop(_beltImage, parentSize.Y * AsteroidBelt.Position.Y / Map.VisibleSize.Y - _beltImage.Height / 2);
    }
  }
}
