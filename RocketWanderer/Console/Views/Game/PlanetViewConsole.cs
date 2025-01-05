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
  public class PlanetViewConsole : PlanetView
  {
    public PlanetViewConsole(Planet parPlanet) 
      : base(parPlanet)
    {
    }

    /// <summary>
    /// Отрисовывает планету
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;

      if (Planet.Position.X + Planet.Size.X / 2 > Map.XCameraOffset)
      {
        double scaleX = parentSize.X / Map.Size.X;
        double scaleY = parentSize.Y / Map.Size.Y;

        double width = Planet.Size.X * scaleX;
        double height = Planet.Size.Y * scaleY;

        double xPosOffset = (Planet.Position.X - Map.XCameraOffset) * scaleX;
        double yPosOffset = Planet.Position.Y * scaleY;

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

        double thickness = 1;

        // Расчёт масштабированных радиусов орбиты
        int orbitRadiusX = (int)(Planet.OrbitRadius * scaleX);
        int orbitRadiusY = (int)(Planet.OrbitRadius * scaleY);

        for (int y = -orbitRadiusY; y <= orbitRadiusY; y++)
        {
          for (int x = -orbitRadiusX; x <= orbitRadiusX; x++)
          {
            // Нормализуем координаты по радиусам эллипса
            double normalizedX = (double)x / orbitRadiusX;
            double normalizedY = (double)y / orbitRadiusY;

            // Вычисляем расстояние до границы эллипса
            double distance = Math.Sqrt(normalizedX * normalizedX + normalizedY * normalizedY);

            // Если точка находится в пределах окружности эллипса с учётом толщины
            if (Math.Abs(distance - 1) <= thickness / orbitRadiusX) // Корректируем толщину для масштабирования
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
