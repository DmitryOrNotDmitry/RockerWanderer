using ConsoleApp.App;
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
  /// <summary>
  /// Представление пояса астероидов от Console
  /// </summary>
  public class AsteroidBeltViewConsole : AsteroidBeltView
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parAsteroidBelt">Модель пояса астероидов</param>
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

      ConsoleAdapter console = ConsoleAdapter.Instance;

      double scale = parentSize.Y / Map.Size.Y;

      int countStrs = (int)(AsteroidBelt.Size.Y * scale);

      int startY = (int)Math.Round((AsteroidBelt.Position.Y - AsteroidBelt.Size.Y / 2) * scale);
      int endY =   startY + countStrs;
      endY = Math.Min(endY, console.Height);

      char fillChar = '+';

      for (int y = startY; y < endY; y++)
      {
        for (int x = 0; x < console.Width; x++)
        {
          console.WriteBuffer(x, y, fillChar);
        }
      }
    }
  }
}
