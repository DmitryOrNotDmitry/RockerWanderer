using Logic.Models.Menus;
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
    protected Menu Menu
    {
      get { return _menu; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public MenuController()
    {
      _menu = new Menu();

      _menu.AddItem(new MenuItem(MenuItemAction.NewGame, "Новая игра"));
      _menu.AddItem(new MenuItem(MenuItemAction.Records, "Рекорды"));
      _menu.AddItem(new MenuItem(MenuItemAction.Description, "Описание"));
      _menu.AddItem(new MenuItem(MenuItemAction.Exit, "Выход"));

      _menu.Focus(MenuItemAction.NewGame);
    }
  }
}
