using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Logic.Models.Menus;
using Logic.Models.Windows;
using Logic.Utils;
using Logic.Views;
using Logic.Views.Menus;
using WpfApp.Views.Windows;

namespace WpfApp.Views.Menus
{
  /// <summary>
  /// Представление меню
  /// </summary>
  public class MenuViewWpf : MenuView, IWpfItem
  {    
    /// <summary>
    /// Контейнер для пунктов меню
    /// </summary>
    private System.Windows.Controls.StackPanel _stackPanel = null;

    /// <summary>
    /// Элемент WPF, представляющий данный объект
    /// </summary>
    public UIElement Control
    {
      get { return _stackPanel; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parSubMenuItem"></param>
    public MenuViewWpf(Menu parSubMenuItem) : base(parSubMenuItem)
    {
      Size = new UDim2(0.2, 0.25);

      _stackPanel = new System.Windows.Controls.StackPanel();
      _stackPanel.VerticalAlignment = VerticalAlignment.Center;
      _stackPanel.HorizontalAlignment = HorizontalAlignment.Center;

      //foreach (IWpfItem elViewMenuItem in Items)
      //{

        //((IWpfItem)this).AddChild(elViewMenuItem);
      //}

      foreach (MenuItemViewWpf elViewMenuItem in Items)
      {
        IWpfItem.AddChild(this, elViewMenuItem);
        elViewMenuItem.Size = new UDim2(0.95, 0.2);
      }
    }

    /// <summary>
    /// Отрисовывает меню
    /// </summary>
    public override void Draw(Vector2 parParentSize)
    {
      Vector2 menuSize = AbsoluteSize(parParentSize);

      _stackPanel.Width = menuSize.X;
      _stackPanel.Height = menuSize.Y;

      int leftOffset = parParentSize.X / 2 - menuSize.X / 2;
      int topOffset  = parParentSize.Y / 2 - menuSize.Y / 2;

      System.Windows.Controls.Canvas.SetLeft(_stackPanel, leftOffset);
      System.Windows.Controls.Canvas.SetTop(_stackPanel, topOffset);

      DrawChildren(menuSize);
    }

    /// <summary>
    /// Создает представление пункта меню для WPF
    /// </summary>
    /// <param name="parMenuItem">Модель пункта меню</param>
    /// <returns>Представление пункта меню</returns>
    public override MenuItemView CreateMenuItemView(MenuItem parMenuItem)
    {
      return new MenuItemViewWpf(parMenuItem);
    }
  }
}
