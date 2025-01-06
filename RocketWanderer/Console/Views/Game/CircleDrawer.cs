using ConsoleApp.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp.Views.Game.PlanetViewConsole;

namespace ConsoleApp.Views.Game
{
  /// <summary>
  /// Художник по кругу
  /// </summary>
  public class CircleDrawer
  {
    /// <summary>
    /// Делегат, который проверяет подходящая ли дистанция
    /// </summary>
    /// <param name="distance">Дистанция</param>
    /// <returns>true - переданная дистанция успешно прошла проверку, иначе false</returns>
    public delegate bool dDistanceChecker(double distance);

    /// <summary>
    /// Рисует круг в консоли
    /// </summary>
    /// <param name="parRadiusX">Радиус круга по X</param>
    /// <param name="parRadiusY">Радиус круга по Y</param>
    /// <param name="parXOffset">Смещение позиции по X</param>
    /// <param name="parYOffset">Смещение позиции по Y</param>
    /// <param name="parFillChar">Символ для заполнения</param>
    /// <param name="parDistanceChecker">Условие для отрисовки символа</param>
    public static void Draw(int parRadiusX, int parRadiusY,
          double parXOffset, double parYOffset,
          char parFillChar, dDistanceChecker parDistanceChecker)
    {
      ConsoleAdapter console = ConsoleAdapter.Instance;

      for (int y = -parRadiusY; y <= parRadiusY; y++)
      {
        for (int x = -parRadiusX; x <= parRadiusX; x++)
        {
          double normalizedX = (double)x / parRadiusX;
          double normalizedY = (double)y / parRadiusY;

          double distance = Math.Sqrt(normalizedX * normalizedX + normalizedY * normalizedY);

          if (parDistanceChecker(distance))
          {
            double xPos = x + parXOffset;
            double yPos = y + parYOffset;

            console.WriteBuffer((int)xPos, (int)yPos, parFillChar);
          }
        }
      }
    }
  }
}
