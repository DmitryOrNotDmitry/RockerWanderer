using Logic.Models.Menus;
using Logic.Models.Menus;
using Logic.Utils;
using Logic.Views.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using WpfApp.Views.Menus;

namespace WpfApp.Views.Menus
{
    /// <summary>
    /// Представление меню паузы от Wpf
    /// </summary>
    public class PauseMenuViewWpf : MenuViewWpf, IWpfItem
  {
    /// <summary>
    /// Заголовок меню
    /// </summary>
    private System.Windows.Controls.Label _menuCapture;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenu"></param>
    public PauseMenuViewWpf(Menu parMenu)
      : base(parMenu)
    {
      Size = new UDim2(0.25, 0.25);

      _stackPanel.Background = new SolidColorBrush(Color.FromArgb(128, 105, 105, 105));

      _menuCapture = new System.Windows.Controls.Label();
      _menuCapture.Content = "Пауза";
      _menuCapture.HorizontalContentAlignment = HorizontalAlignment.Center;
      _menuCapture.HorizontalAlignment = HorizontalAlignment.Stretch;
      _menuCapture.Foreground = Brushes.White;

      _menuCapture.Effect = new DropShadowEffect
      {
        Color = Colors.Gray,
        ShadowDepth = 4,
        BlurRadius = 8,
        Opacity = 0.8
      };

      _stackPanel.Children.Insert(0, _menuCapture);

      foreach (MenuItemViewWpf elViewMenuItem in Items)
      {
        elViewMenuItem.Size = new UDim2(0.90, 0.25);
        elViewMenuItem.Control.Effect = _menuCapture.Effect;
      }
    }

    /// <summary>
    /// Возвращает позицию меню
    /// </summary>
    /// <returns>Позицию меню</returns>
    protected override Vector2 GetPosition(Vector2 parParentSize)
    {
      Vector2 menuSize = AbsoluteSize;

      double leftOffset = parParentSize.X / 2 - menuSize.X / 2;
      double topOffset = parParentSize.Y / 2 - menuSize.Y / 2;

      return new Vector2(leftOffset, topOffset);
    }

    /// <summary>
    /// Отрисовывает меню
    /// </summary>
    public override void Draw()
    {
      if (((SwitchedMenu)Menu).IsEnabled)
      {
        Control.IsEnabled = true;
        Control.Visibility = Visibility.Visible;
        
        _menuCapture.FontSize = Math.Max(1, AbsoluteSize.Y / 5);

        base.Draw();
      }
      else
      {
        Control.IsEnabled = false;
        Control.Visibility = Visibility.Hidden;
      }
    }

    /// <summary>
    /// Создает представление пункта меню паузы для WPF
    /// </summary>
    /// <param name="parMenuItem">Модель пункта меню</param>
    /// <returns>Представление пункта меню</returns>
    public override MenuItemView CreateMenuItemView(MenuItem parMenuItem)
    {
      return new PauseMenuItemViewWpf(parMenuItem);
    }
  }
}
