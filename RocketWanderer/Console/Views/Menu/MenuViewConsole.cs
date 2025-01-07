using ConsoleApp.App;
using Logic.Models.Menus;
using Logic.Utils;
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
      MenuItemView menuItemView = new MenuItemViewConsole(parMenuItem);
      this.AddChild(menuItemView);

      return menuItemView;
    }

    /// <summary>
    /// Отрисовывает меню
    /// </summary>
    public override void Draw()
    {
      base.Draw();
      
      Vector2 parentSize = Parent.AbsoluteSize;

      int yOffset = -(Items.Length - 1);

      int i = 0;
      foreach (MenuItemView elViewMenuItem in Items)
      {
        elViewMenuItem.Position = new Vector2((int)(parentSize.X / 2), parentSize.Y / 2 + i * 2 + yOffset);
        i++;
      }

      DrawChildren();
    }
  }
}
