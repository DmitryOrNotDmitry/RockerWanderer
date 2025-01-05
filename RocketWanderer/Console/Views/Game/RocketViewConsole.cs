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
  public class RocketViewConsole : RocketView
  {
    public RocketViewConsole(Rocket parRocket)
      : base(parRocket)
    {
    }

    /// <summary>
    /// Отрисовывает ракету
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;

      double scale = parentSize.Y / Map.Size.Y;

      Vector2 center = Rocket.Center;
      Vector2 consoleCenter = center.Scale(scale);

      char fillChar = '#';
      Console.SetCursorPosition((int)consoleCenter.X, (int)consoleCenter.Y);
      Console.Write(fillChar);

    }
  }
}
