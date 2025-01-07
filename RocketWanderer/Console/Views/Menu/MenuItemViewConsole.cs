using ConsoleApp.App;
using Logic.Models.Menus;
using Logic.Utils;
using Logic.Views.Menus;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Views.Menu
{
  /// <summary>
  /// Представление пункта меню от Console
  /// </summary>
  public class MenuItemViewConsole : MenuItemView
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenuItem">Модель пункта меню</param>
    public MenuItemViewConsole(MenuItem parMenuItem) 
      : base(parMenuItem)
    {
    }

    /// <summary>
    /// Предыдущая позиция пункта меню
    /// </summary>
    private Vector2 _prevPosition = new Vector2(0, 0);

    /// <summary>
    /// Отрисовывает пункт меню
    /// </summary>
    public override void Draw()
    {
      base.Draw();
      
      int xOffset = -(Item.Title.Length - 1) / 2;

      ConsoleAdapter console = ConsoleAdapter.Instance;
      
      Vector2 curPosition = new Vector2(Position.X + xOffset, Position.Y);

      if (curPosition != _prevPosition)
      {
        _prevPosition = curPosition;

        ConsoleColor color;

        if (Item.State == MenuItemState.Focused)
        {
          color = ConsoleColor.Yellow;
        }
        else if (Item.State == MenuItemState.Selected)
        {
          color = ConsoleColor.Red;
        }
        else
        {
          color = ConsoleColor.Green;
        }

        console.WriteBuffer((int)curPosition.X, (int)curPosition.Y, Item.Title, color);
      }

    }
  }
}
