using Logic.Models.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Menus
{
  /// <summary>
  /// Представление пункта меню
  /// </summary>
  public abstract class MenuItemView : BaseView
  {
    /// <summary>
    /// Обработчик события с представлением пункта меню
    /// </summary>
    /// <param name="parAction">Действие пункта меню</param>
    public delegate void dMenuItemAction(MenuItemAction parAction);

    /// <summary>
    /// Событие нажатия на пункт меню
    /// </summary>
    public event dMenuItemAction Enter = null;

    /// <summary>
    /// Модель пункта меню
    /// </summary>
    private MenuItem _menuItem;

    /// <summary>
    /// Модель пункта меню
    /// </summary>
    protected MenuItem Item
    {
      get { return _menuItem; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenuItem">Модель пункта меню</param>
    public MenuItemView(MenuItem parMenuItem)
    {
      _menuItem = parMenuItem;
    }
  }
}
