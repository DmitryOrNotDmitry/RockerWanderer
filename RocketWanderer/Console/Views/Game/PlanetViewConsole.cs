using ConsoleApp.App;
using Logic.Models.Game;
using Logic.Utils;
using Logic.Views.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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

    private Rect prevLocation = new Rect();

    public Rect PrevLocation
    {
      get { return prevLocation; }
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
        double scaleY = parentSize.Y / Map.Size.Y;
        double scaleX = scaleY * FontInfo.FontYScale;

        double width = Planet.Size.X * scaleX;
        double height = Planet.Size.Y * scaleY;

        double xPosOffset = (Planet.Position.X - Map.XCameraOffset) * scaleX;
        double yPosOffset = Planet.Position.Y * scaleY;

        int radiusX = (int)(width / 2);
        int radiusY = (int)(height / 2);
        char fillChar = '@';

        CircleDrawer.Draw(radiusX, radiusY, xPosOffset, yPosOffset, fillChar,
          (distance) =>
          {
            return distance <= 1.1;
          });

        double thickness = 1;
        fillChar = '-';

        int orbitRadiusX = (int)(Planet.OrbitRadius * scaleX);
        int orbitRadiusY = (int)(Planet.OrbitRadius * scaleY);

        prevLocation = new Rect((int)xPosOffset - orbitRadiusX - 1, (int)yPosOffset - orbitRadiusY - 1, (int)orbitRadiusX * 2 + 2, (int)orbitRadiusX * 2 + 2);

        CircleDrawer.Draw(orbitRadiusX, orbitRadiusY, xPosOffset, yPosOffset, fillChar, 
          (distance) =>
          {
            return Math.Abs(distance - 1) <= thickness / orbitRadiusX;
          });
      }
    }

  }
}
