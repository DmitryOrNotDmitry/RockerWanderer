﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Logic.Models.Menus;
using Logic.Utils;
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
    protected System.Windows.Controls.StackPanel _stackPanel = null;

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
    /// <param name="parMenu"></param>
    public MenuViewWpf(Menu parMenu) : base(parMenu)
    {
      Size = new UDim2(0.2, 0.25);

      _stackPanel = new System.Windows.Controls.StackPanel();
      _stackPanel.VerticalAlignment = VerticalAlignment.Center;
      _stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
      
      foreach (MenuItemViewWpf elViewMenuItem in Items)
      {
        IWpfItem.AddChild(this, elViewMenuItem);
        elViewMenuItem.Size = new UDim2(0.95, 0.2);
      }
    }

    /// <summary>
    /// Отрисовывает меню
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;

      Vector2 menuSize = AbsoluteSize;

      _stackPanel.Width = menuSize.X;
      _stackPanel.Height = menuSize.Y;

      Vector2 position = GetPosition(parentSize);

      System.Windows.Controls.Canvas.SetLeft(_stackPanel, position.X);
      System.Windows.Controls.Canvas.SetTop(_stackPanel, position.Y);

      DrawChildren();
    }

    /// <summary>
    /// Возвращает позицию меню
    /// </summary>
    /// <returns>Позицию меню</returns>
    protected virtual Vector2 GetPosition(Vector2 parParentSize)
    {
      Vector2 menuSize = AbsoluteSize;
     
      double leftOffset = parParentSize.X / 2 - menuSize.X / 2;
      double topOffset = parParentSize.Y / 2 - menuSize.Y / 2 + parParentSize.Y / 20;

      return new Vector2(leftOffset, topOffset);
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
