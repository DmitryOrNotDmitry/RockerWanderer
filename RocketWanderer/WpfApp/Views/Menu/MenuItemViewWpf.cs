﻿using Logic.Models.Menus;
using Logic.Views.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WpfApp.Views.Menus
{
  /// <summary>
  /// Представление пункта меню для WPF
  /// </summary>
  public class MenuItemViewWpf : MenuItemView, IWpfItem
  {
    /// <summary>
    /// Обработчик события с представлением пункта меню
    /// </summary>
    /// <param name="parAction">Действие пункта меню</param>
    public delegate void dEnter(MenuItemAction parAction);

    /// <summary>
    /// Событие нажатия на пункт меню
    /// </summary>
    public event dEnter Enter = null;

    /// <summary>
    /// Событие получение фокуса на пункте
    /// </summary>
    public event dEnter Focused = null;

    /// <summary>
    /// Кнопка, представляющая пункт меню
    /// </summary>
    System.Windows.Controls.Button _button = null;

    /// <summary>
    /// Кисть для нормального состояния пункта меню
    /// </summary>
    Brush _brush = null;

    /// <summary>
    /// Элемент WPF, представляющий данный объект
    /// </summary>
    public UIElement Control
    {
      get { return _button; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenuItem">Модель пункта меню</param>
    public MenuItemViewWpf(MenuItem parMenuItem) : base(parMenuItem)
    {
      _button = new System.Windows.Controls.Button();
      _button.Content = parMenuItem.Title;

      _button.Click += (s, e) => { Enter?.Invoke(Item.Action); };
      _button.GotFocus += (s, e) => { Focused?.Invoke(Item.Action); };
    }

    /// <summary>
    /// Отрисовывает объект
    /// </summary>
    public override void Draw()
    {
      if (Item.State == MenuItemState.Focused)
      {
        _button.Background = Brushes.Magenta;
        _button.Focus();
      }
      else if (Item.State == MenuItemState.Selected)
        _button.Background = Brushes.Red;
      else
        _button.Background = _brush;
    }

  }
}
