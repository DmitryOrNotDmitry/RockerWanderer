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
  public class PauseMenuViewConsole : MenuViewConsole
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
      return new MenuItemViewConsole(parMenuItem);
    }

    /// <summary>
    /// Отрисовывает меню паузы
    /// </summary>
    public override void Draw()
    {
      if (((SwitchedMenu)Menu).IsEnabled)
      {        
        ConsoleAdapter console = ConsoleAdapter.Instance;

        int sizeX = 20;
        int startX = (Console.BufferWidth - sizeX) / 2;
        int endX = startX + sizeX;
        
        int sizeY = 8;
        int startY = (Console.BufferHeight - sizeY) / 2;
        int endY = startY + sizeY;

        for (int y = startY; y < endY; y++)
        {
          for (int x = startX; x < endX; x++)
          {
            console.WriteBuffer(x, y, ' ');
          }
        }
        
        console.Write(startX + sizeX / 2 - 2, startY + 1, "Пауза");

        base.Draw();
      }
    }
  }
}
