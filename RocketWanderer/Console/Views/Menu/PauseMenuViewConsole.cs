using Logic.Models.Menus;
using Logic.Views.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Views.Menu
{
  public class PauseMenuViewConsole : MenuView
  {
    public PauseMenuViewConsole(Logic.Models.Menus.Menu parMenu) 
      : base(parMenu)
    {
    }

    /// <summary>
    /// Создает представление пункта меню паузы от Console
    /// </summary>
    /// <param name="parMenuItem">Модель пункта меню</param>
    /// <returns>Представление пункта меню</returns>
    public override MenuItemView CreateMenuItemView(MenuItem parMenuItem)
    {
      return new PauseMenuItemViewConsole(parMenuItem);
    }
  }
}
