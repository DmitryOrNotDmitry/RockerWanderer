
using Logic.Models.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logic.Views.Menus
{
  /// <summary>
  /// Представление меню
  /// </summary>
  public abstract class MenuView : BaseView
  {
    /// <summary>
    /// Модель меню
    /// </summary>
    private readonly Menu _menu;

    /// <summary>
    /// Модель меню
    /// </summary>
    public Menu Menu
    { 
      get { return _menu; } 
    }

    /// <summary>
    /// Словарь представлений пунктов меню, индексированных по действиям
    /// </summary>
    private Dictionary<MenuItemAction, MenuItemView> _items = new();

    /// <summary>
    /// Все представления пунктов меню
    /// </summary>
    public MenuItemView[] Items
    {
      get { return _items.Values.ToArray(); }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenu"></param>
    public MenuView(Menu parMenu)
    {
      _menu = parMenu;
      foreach (MenuItem elMenuItem in parMenu.Items)
      {
        MenuItemView itemView = CreateMenuItemView(elMenuItem);
        _items.Add(elMenuItem.Action, itemView);
        
        AddChild(itemView);
      }
    }

    /// <summary>
    /// Возвращает представление пункта меню, соответсвующее действию
    /// </summary>
    /// <param name="parAction">Действие</param>
    /// <returns>Представление пункта меню</returns>
    public MenuItemView this[MenuItemAction parAction]
    {
      get { return _items[parAction]; }
    }

    /// <summary>
    /// Создает представление пункта меню
    /// </summary>
    /// <param name="parMenuItem">Модель пункта меню</param>
    /// <returns>Представление пункта меню</returns>
    public abstract MenuItemView CreateMenuItemView(MenuItem parMenuItem);

  }
}
