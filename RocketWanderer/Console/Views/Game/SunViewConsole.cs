using ConsoleApp.App;
using Logic.Models.Game;
using Logic.Utils;
using Logic.Views.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp.Views.Game.PlanetViewConsole;

namespace ConsoleApp.Views.Game
{
  /// <summary>
  /// Представление солнца от Console
  /// </summary>
  public class SunViewConsole : SunView
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parSun">Модель солнца</param>
    public SunViewConsole(Sun parSun) 
      : base(parSun)
    {
    }

    /// <summary>
    /// Прямоугольник, который был отрисован последний раз
    /// </summary>
    private Rect prevLocation = new Rect();

    /// <summary>
    /// Прямоугольник, который был отрисован последний раз
    /// </summary>
    public Rect PrevLocation
    {
      get { return prevLocation; }
    }

    /// <summary>
    /// Отрисовывает солнце
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;
      
      ConsoleAdapter console = ConsoleAdapter.Instance;

      if (Sun.Position.X + Sun.Size.X / 2 > Map.XCameraOffset)
      {
        double scaleY = parentSize.Y / Map.Size.Y;
        double scaleX = scaleY * FontInfo.FontYScale;

        double width = Sun.Size.X * scaleX;
        double height = Sun.Size.Y * scaleY;

        double xPosOffset = (Sun.Position.X - Map.XCameraOffset) * scaleX;
        double yPosOffset = Sun.Position.Y * scaleY;

        int radiusX = (int)(width / 2);
        int radiusY = (int)(height / 2);
        char fillChar = '@';
        
        prevLocation = new Rect((int)xPosOffset - radiusX, (int)yPosOffset - radiusY, (int)width, (int)height);

        CircleDrawer.Draw(radiusX, radiusY, xPosOffset, yPosOffset, fillChar,
          (distance) =>
          {
            return distance <= 1;
          });
      }
    }

    
  }
}
