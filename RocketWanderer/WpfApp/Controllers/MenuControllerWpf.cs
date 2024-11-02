using Logic.Controllers;
using Logic.Models.Menus;
using Logic.Views.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Views.Menus;

namespace WpfApp.Controllers
{
  /// <summary>
  /// Контроллер главного меню для WPF
  /// </summary>
  public class MenuControllerWpf : MenuController
  {
    /// <summary>
    /// Представление меню для WPF
    /// </summary>
    private MenuViewWpf _menuView;

    /// <summary>
    /// Конструктор
    /// </summary>
    public MenuControllerWpf()
    {
      _menuView = new MenuViewWpf(Menu);

      Menu[MenuItemAction.Exit].Selected += () => { _menuView.Close(); };

      foreach (MenuItem elMenuItem in Menu.Items)
      {
        ((MenuItemViewWpf)_menuView[elMenuItem.Action]).Enter += (action) =>
        {
          Menu.Focus(action);
          Menu.SelectFocusedItem();
          _menuView.Draw();
        };

        ((MenuItemViewWpf)_menuView[elMenuItem.Action]).Focused += (action) =>
        {
          Menu.Focus(action);
          _menuView.Draw();
        };
      }
    }

  }
}
