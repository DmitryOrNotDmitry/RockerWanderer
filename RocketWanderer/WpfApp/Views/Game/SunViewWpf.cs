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
      _sunImage.Source = new BitmapImage(new Uri(ImagesFolder._path + "sun.png", UriKind.Relative));
    }

    /// <summary>
    /// Отрисовывает солнце
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;

      if (Sun.Position.X + Sun.Size.X / 2 > Map.XCameraOffset)
      {
        double scale = parentSize.Y / Map.Size.Y;

        _sunImage.Width = Sun.Size.X * scale;
        _sunImage.Height = Sun.Size.Y * scale;

        Canvas.SetLeft(_sunImage, (Sun.Position.X - Map.XCameraOffset) * scale - _sunImage.Width / 2);
        Canvas.SetTop (_sunImage, Sun.Position.Y * scale - _sunImage.Height / 2);
      }

    }

  }
}
