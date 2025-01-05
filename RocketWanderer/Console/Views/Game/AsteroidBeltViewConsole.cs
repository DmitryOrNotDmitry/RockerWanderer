using Logic.Models.Game;
using Logic.Utils;
using Logic.Views.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Views.Game
{
  public class AsteroidBeltViewConsole : AsteroidBeltView
  {
    public AsteroidBeltViewConsole(AsteroidBelt parAsteroidBelt) 
      : base(parAsteroidBelt)
    {
    }

    /// <summary>
    /// Отрисовывает пояс астероидов
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;

      double scale = parentSize.Y / Map.Size.Y;

      int startY = (int)((AsteroidBelt.Position.Y - AsteroidBelt.Size.Y / 2) * scale);
      int endY =   (int)((AsteroidBelt.Position.Y + AsteroidBelt.Size.Y / 2) * scale);

      char fillChar = '+';

      for (int y = startY; y < endY; y++)
      {
        for (int x = 0; x < Console.BufferWidth; x++)
        {
          Console.SetCursorPosition(x, y);
          Console.Write(fillChar);
        }
      }
    }
  }
}
