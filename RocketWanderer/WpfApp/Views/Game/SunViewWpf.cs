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
  /// Представленеие солнца от Wpf
  /// </summary>
  public class SunViewWpf : SunView, IWpfItem
  {
    /// <summary>
    /// Картинка солнца
    /// </summary>
    private Image _sunImage = new Image();

    /// <summary>
    /// Картинка, представляющая объект
    /// </summary>
    public UIElement Control
    {
      get { return _sunImage; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parSun">Модель солнца</param>
    public SunViewWpf(Sun parSun) 
      : base(parSun)
    {
      _sunImage.Stretch = System.Windows.Media.Stretch.Uniform;
      _sunImage.Source = new BitmapImage(new Uri("Images\\sun.png", UriKind.Relative));
    }

    /// <summary>
    /// Отрисовывает солнце
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;

      _sunImage.Width = parentSize.X * Sun.Size.X / Map.VisibleSize.X;
      _sunImage.Height = parentSize.Y * Sun.Size.Y / Map.VisibleSize.Y;

      Canvas.SetLeft(_sunImage, parentSize.X * Sun.Position.X / Map.VisibleSize.X - _sunImage.Width / 2);
      Canvas.SetTop(_sunImage, parentSize.Y * Sun.Position.Y / Map.VisibleSize.Y - _sunImage.Height / 2);
    }

  }
}
