 using Logic.Controllers;
using Logic.Models.Menus;
using Logic.Models.Windows;
using Logic.Views.Menus;
using Logic.Views.Screens;
using Logic.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Views;
using WpfApp.Views.Menus;
using WpfApp.Views.Windows;

namespace WpfApp.Controllers
{
  /// <summary>
  /// Контроллер главного меню для WPF
  /// </summary>
  public class MenuControllerWpf : MenuController
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    public MenuControllerWpf(WindowView parAppWindowView, MainMenuScreenView parMainMenuScreen)
      : base(parAppWindowView)
    {
      IWpfItem.AddChild(parMainMenuScreen, MenuView);

      foreach (MenuItem elMenuItem in Menu.Items)
      {
        ((MenuItemViewWpf)MenuView[elMenuItem.Action]).MoveEnter += Menu.Focus;
      }
    }

    /// <summary>
    /// Создает представление меню от Wpf
    /// </summary>
    /// <returns>Представление меню</returns>
    public override MenuView CreateMenuView()
    {
      return new MenuViewWpf(Menu);
    }
  }
}
