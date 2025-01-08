using ConsoleApp.App;
using Logic.Models.Game;
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
  /// Представление меню конца игры от Console
  /// </summary>
  public class GameOverMenuViewConsole : GameOverMenuView
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenu">Модель меню</param>
    /// <param name="parScores">Модель очков игрока</param>
    public GameOverMenuViewConsole(Logic.Models.Menus.Menu parMenu, Scores parScores) 
      : base(parMenu, parScores)
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
    /// Отрисовывает меню конца игры
    /// </summary>
    public override void Draw()
    {
      if (((SwitchedMenu)Menu).IsEnabled)
      {
        base.Draw();
        
        ConsoleAdapter console = ConsoleAdapter.Instance;

        int sizeX = 20;
        int startX = (console.Width - sizeX) / 2;
        int endX = startX + sizeX;

        int sizeY = 9;
        int startY = (console.Height - sizeY) / 2;
        int endY = startY + sizeY;

        for (int y = startY; y < endY; y++)
        {
          for (int x = startX; x < endX; x++)
          {
            console.WriteBuffer(x, y, ' ');
          }
        }

        console.WriteBuffer(startX + sizeX / 2 - 4, startY + 1, "Конец игры");

        string scoreLabel = "Очки: " + Scores.Current;
        console.WriteBuffer(startX + (sizeX - scoreLabel.Length + 2) / 2, startY + 3, scoreLabel);

        Vector2 parentSize = Parent.AbsoluteSize;

        int yOffset = -(Items.Length - 2);

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
}
