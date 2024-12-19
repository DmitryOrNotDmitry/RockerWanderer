using Logic.Models.Menus;
using Logic.Models.Windows;
using Logic.Views.Menus;
using Logic.Views.Screens;
using Logic.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Controllers
{
  /// <summary>
  /// Контроллер главного меню
  /// </summary>
  public abstract class MenuController : BaseController
  {
    /// <summary>
    /// Модель главного меню
    /// </summary>
    private Menu _menu;

    /// <summary>
    /// Модель главного меню
    /// </summary>
    public Menu Menu
    {
      get { return _menu; }
    }

    /// <summary>
    /// Представление главного меню
    /// </summary>
    private MenuView _menuView;

    /// <summary>
    /// Представление главного меню
    /// </summary>
    public MenuView MenuView
    {
      get { return _menuView; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public MenuController(WindowView parWindowView)
    {
      _menu = new Menu();

      _menu.AddItem(new MenuItem(MenuItemAction.NewGame, "Новая игра"));
      _menu.AddItem(new MenuItem(MenuItemAction.Records, "Рекорды"));
      _menu.AddItem(new MenuItem(MenuItemAction.Description, "Описание"));
      _menu.AddItem(new MenuItem(MenuItemAction.Exit, "Выход"));

      _menu.Focus(MenuItemAction.NewGame);

      
      WindowData windowData = parWindowView.Window;

      _menu[MenuItemAction.NewGame].Selected += () => { windowData.ChangeScreen(ScreenType.Game); };
      _menu[MenuItemAction.Records].Selected += () => { windowData.ChangeScreen(ScreenType.Records); };
      _menu[MenuItemAction.Description].Selected += () => { windowData.ChangeScreen(ScreenType.Description); };

      _menu[MenuItemAction.Exit].Selected += () => { parWindowView.Close(); };


      _menuView = CreateMenuView();

      foreach (MenuItem elMenuItem in Menu.Items)
      {
        (MenuView[elMenuItem.Action]).Enter += (action) =>
        {
          Menu.Focus(action);
          Menu.SelectFocusedItem();
        };
      }
    }

    /// <summary>
    /// Создает представление меню
    /// </summary>
    /// <returns>Представление меню</returns>
    public abstract MenuView CreateMenuView();
  }
}
