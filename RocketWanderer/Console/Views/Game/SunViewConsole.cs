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
  public class SunViewConsole : SunView
  {
    public SunViewConsole(Sun parSun) 
      : base(parSun)
    {
    }

    /// <summary>
    /// Отрисовывает солнце
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;

      if (Sun.Position.X + Sun.Size.X / 2 > Map.XCameraOffset)
      {
        double scaleX = parentSize.X / Map.Size.X;
        double scaleY = parentSize.Y / Map.Size.Y;

        double width = Sun.Size.X * scaleX;
        double height = Sun.Size.Y * scaleY;

        double xPosOffset = (Sun.Position.X - Map.XCameraOffset) * scaleX;
        double yPosOffset = Sun.Position.Y * scaleY;

        int radiusX = (int)(width / 2);
        int radiusY = (int)(height / 2);
        char fillChar = '@';

        for (int y = -radiusY; y <= radiusY; y++)
        {
          for (int x = -radiusX; x <= radiusX; x++)
          {
            if (x * x + y * y <= radiusX * radiusY)
            {
              double xPos = x + xPosOffset;
              double yPos = y + yPosOffset;

              if (xPos >= 0 && yPos >= 0 && xPos < Console.WindowWidth && yPos < Console.WindowHeight)
              {
                Console.SetCursorPosition((int)xPos, (int)yPos);
                Console.Write(fillChar);
              }
            }
          }
        }
      }
    } 
  }
}
