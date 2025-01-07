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
  public class MenuItemViewConsole : MenuItemView
  {
    public MenuItemViewConsole(MenuItem parMenuItem) 
      : base(parMenuItem)
    {
    }

    private Vector2 prevPosition = new Vector2(0, 0);

    /// <summary>
    /// Отрисовывает пункт меню
    /// </summary>
    public override void Draw()
    {
      base.Draw();
      
      int xOffset = -(Item.Title.Length - 1) / 2;

      ConsoleAdapter console = ConsoleAdapter.Instance;
      
      Vector2 curPosition = new Vector2(Position.X + xOffset, Position.Y);

      if (curPosition != prevPosition)
      {
        prevPosition = curPosition;

        ConsoleColor savColor = Console.ForegroundColor;

        if (Item.State == MenuItemState.Focused)
        {
          Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else if (Item.State == MenuItemState.Selected)
        {
          Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
          Console.ForegroundColor = ConsoleColor.Green;
        }

        console.Write((int)curPosition.X, (int)curPosition.Y, Item.Title);
        Console.ForegroundColor = savColor;
      }

    }
  }
}
