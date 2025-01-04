using Logic.Models.Menus;
using Logic.Views.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Views.Menu
{
  public class MenuViewConsole : MenuView
  {
    public MenuViewConsole(Logic.Models.Menus.Menu parMenu) 
      : base(parMenu)
    {
    }

    /// <summary>
    /// Создает представление пункта меню от Console
    /// </summary>
    /// <param name="parMenuItem">Модель пункта меню</param>
    /// <returns>Представление пункта меню</returns>
    public override MenuItemView CreateMenuItemView(MenuItem parMenuItem)
    {
      return new MenuItemViewConsole(parMenuItem);
    }
  }
}
