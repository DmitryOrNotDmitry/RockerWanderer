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
  public class MenuItemViewConsole : MenuItemView
  {
    public MenuItemViewConsole(MenuItem parMenuItem) 
      : base(parMenuItem)
    {
    }

    /// <summary>
    /// Отрисовывает пункт меню
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      int xOffset = -(Item.Title.Length) / 2;

      Console.CursorLeft = (int)(Position.X) + xOffset;
      Console.CursorTop = (int)(Position.Y);
      ConsoleColor savColor = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Write(Item.Title);
      Console.ForegroundColor = savColor;
    }
  }
}
