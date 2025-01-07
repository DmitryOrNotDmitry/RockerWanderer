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
  /// <summary>
  /// Представление меню паузы от Console
  /// </summary>
  public class PauseMenuViewConsole : MenuViewConsole
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenu">Модель меню</param>
    public PauseMenuViewConsole(Logic.Models.Menus.Menu parMenu) 
      : base(parMenu)
    {
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
        int startX = (console.Width - sizeX) / 2;
        int endX = startX + sizeX;
        
        int sizeY = 8;
        int startY = (console.Height - sizeY) / 2;
        int endY = startY + sizeY;

        for (int y = startY; y < endY; y++)
        {
          for (int x = startX; x < endX; x++)
          {
            console.WriteBuffer(x, y, ' ');
          }
        }
        
        console.WriteBuffer(startX + sizeX / 2 - 2, startY + 1, "Пауза", ConsoleColor.White);

        base.Draw();
      }
    }
  }
}
