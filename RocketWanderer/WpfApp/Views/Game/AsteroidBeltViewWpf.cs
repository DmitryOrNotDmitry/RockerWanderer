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
  /// Представление пояса астероидов от Wpf
  /// </summary>
  public class AsteroidBeltViewWpf : AsteroidBeltView, IWpfItem
  {
    /// <summary>
    /// Максимальное количество элементов массива _beltImages
    /// </summary>
    private const int _maxBeltImagesSize = 5;

    /// <summary>
    /// Контейнер для изображений астероидов
    /// </summary>
    private Canvas _canvas = new Canvas();

    /// <summary>
    /// Контролы для отображения пояса астероидов
    /// </summary>
    private List<Image> _beltImages = new List<Image>();

    /// <summary>
    /// Изображение астероидов
    /// </summary>
    private BitmapImage _bitmap;

    /// <summary>
    /// Картинка, представляющая объект
    /// </summary>
    public UIElement Control
    {
      get { return _canvas; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parAsteroidBelt">Модель пояса астероидов</param>
    public AsteroidBeltViewWpf(AsteroidBelt parAsteroidBelt) 
      : base(parAsteroidBelt)
    {
      _bitmap = new BitmapImage(new Uri(ImagesFolder.RelativePath + "asteroid_belt.png", UriKind.Relative));
      
      CreateNewBeltImage();
    }

    /// <summary>
    /// Создает новый контрол изображения
    /// </summary>
    /// <returns>Новый контрол изображения</returns>
    private Image CreateNewBeltImage()
    {
      Image beltImage = new Image();

      beltImage.Stretch = System.Windows.Media.Stretch.Uniform;
      beltImage.Source = _bitmap;

      _beltImages.Add(beltImage);
      _canvas.Children.Add(beltImage);

      return beltImage;
    }

    /// <summary>
    /// Отрисовывает пояс астероидов
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;

      _canvas.Width = parentSize.X * AsteroidBelt.Size.X / Map.Size.X;
      _canvas.Height = parentSize.Y * AsteroidBelt.Size.Y / Map.Size.Y;

      int needBeltImage = 1;
      if (_beltImages[0].ActualWidth != 0)
      {
        needBeltImage = (int) (parentSize.X / _beltImages[0].ActualWidth + 1);
      }
      needBeltImage = Math.Min(needBeltImage, _maxBeltImagesSize);

      while (_beltImages.Count < needBeltImage)
      {
        CreateNewBeltImage();
      }

      for (int idx = 0; idx < _beltImages.Count; idx++)
      {
        Image elBeltImage = _beltImages[idx];

        elBeltImage.Visibility = Visibility.Visible;

        elBeltImage.Height = _canvas.Height;

        Canvas.SetLeft(elBeltImage, elBeltImage.ActualWidth * idx);
      }

      Canvas.SetLeft(_canvas, parentSize.X * AsteroidBelt.Position.X / Map.Size.X - _canvas.Width / 2);
      Canvas.SetTop(_canvas, parentSize.Y * AsteroidBelt.Position.Y / Map.Size.Y - _canvas.Height / 2);
    }
  }
}
