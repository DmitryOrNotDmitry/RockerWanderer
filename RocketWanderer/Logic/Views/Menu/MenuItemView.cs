using Logic.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Menus
{
  public abstract class MenuItemView : BaseView
  {
    private MenuItem _menuItem;

    protected MenuItem Item
    {
      get { return _menuItem; }
    }

    public MenuItemView(MenuItem parMenuItem)
    {
      _menuItem = parMenuItem;
    }
  }
}
