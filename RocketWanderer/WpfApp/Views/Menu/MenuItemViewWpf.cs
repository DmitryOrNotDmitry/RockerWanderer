using Logic.Models.Menus;
using Logic.Utils;
using Logic.Views.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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
    /// Событие наведения курсора на пункте
    /// </summary>
    public event dMenuItemAction MoveEnter = null;

    /// <summary>
    /// Кнопка, представляющая пункт меню
    /// </summary>
    protected System.Windows.Controls.Button _button = null;

    /// <summary>
    /// Кисть для нормального состояния пункта меню
    /// </summary>
    private Brush _brush = null;

    /// <summary>
    /// Кисть для наведенного состояния пункта меню
    /// </summary>
    private Brush _focusedBrush = Brushes.Magenta;

    /// <summary>
    /// Кисть для выбранного состояния пункта меню
    /// </summary>
    private Brush _selectedBrush = Brushes.Red;

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
      _button.Margin = new Thickness(5);
      
      _button.FontSize = 20;

      _button.Click += (s, e) => { TriggerEnter(Item.Action); };
      _button.GotFocus += (s, e) => { TriggerFocus(Item.Action); };

      _button.LostFocus += (s, e) =>
      {
        Item.State = MenuItemState.Normal;
      };
    }

    /// <summary>
    /// Отрисовывает пункт меню
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;
      
      Vector2 buttinSize = AbsoluteSize;
      _button.Width = buttinSize.X;
      _button.Height = buttinSize.Y;

      _button.FontSize = parentSize.Y * 0.08;
      _button.Margin = new Thickness(buttinSize.Y / 10);

      if (Item.State == MenuItemState.Focused)
      {
        _button.Background = _focusedBrush;
        _button.Focus();
      }
      else if (Item.State == MenuItemState.Selected)
        _button.Background = _selectedBrush;
      else
        _button.Background = _brush;
    }

  }
}
