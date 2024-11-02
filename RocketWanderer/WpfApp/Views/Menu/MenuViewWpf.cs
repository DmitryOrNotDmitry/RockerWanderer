using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Logic.Models.Menus;
using Logic.Views.Menus;

namespace WpfApp.Views.Menus
{
  /// <summary>
  /// Представление меню
  /// </summary>
  public class MenuViewWpf : MenuView, IWpfItem
  {
    private Window _window = null;
    
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
      _window = new Window();
      _window.ShowActivated = true;
      _window.WindowState = WindowState.Maximized;

      _stackPanel = new System.Windows.Controls.StackPanel();
      _stackPanel.VerticalAlignment = VerticalAlignment.Center;
      _stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
      _window.Content = _stackPanel;

      foreach (IWpfItem elViewMenuItem in Items)
      {
        ((IWpfItem)this).AddChild(elViewMenuItem);
      }

      Draw();

      _window.Show();
    }

    public void Close()
    {
      _window.Close();
    }

    /// <summary>
    /// Отрисовывает меню
    /// </summary>
    public override void Draw()
    {
      foreach (MenuItemView elViewMenuItem in Items)
      {
        elViewMenuItem.Draw();
      }
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
