
using Logic.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logic.Views.Menus
{
  public abstract class MenuView : BaseView
  {
    private readonly Menu _menu;
    private Dictionary<MenuItemAction, MenuItemView> _items = new();

    public MenuItemView[] Items
    {
      get { return _items.Values.ToArray(); }
    }

    public MenuView(Menu parMenu)
    {
      _menu = parMenu;
      foreach (MenuItem elMenuItem in parMenu.Items)
      {
        _items.Add(elMenuItem.Action, CreateMenuItemView(elMenuItem));
      }
    }

    public MenuItemView this[MenuItemAction parAction]
    {
      get { return _items[parAction]; }
    }

    public abstract MenuItemView CreateMenuItemView(MenuItem parMenuItem);

  }
}
