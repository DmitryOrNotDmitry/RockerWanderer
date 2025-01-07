using ConsoleApp.App;
using Logic.Models.Game;
using Logic.Utils;
using Logic.Views.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp.Views.Game
{
  /// <summary>
  /// Представление ракеты от Console
  /// </summary>
  public class RocketViewConsole : RocketView
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parRocket">Модель ракеты</param>
    public RocketViewConsole(Rocket parRocket)
      : base(parRocket)
    {
    }

    /// <summary>
    /// Предыдущая позиция ракеты
    /// </summary>
    private Vector2 _prevPosition = new Vector2(0, 0);

    /// <summary>
    /// Отрисовывает ракету
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      ConsoleAdapter console = ConsoleAdapter.Instance;
      
      Vector2 parentSize = Parent.AbsoluteSize;

      double scaleY = parentSize.Y / Map.Size.Y;
      double scaleX = scaleY * FontInfo.FontYScale;

      Vector2 center = Rocket.Position;
      Vector2 rocketCenter = new Vector2((center.X - Map.XCameraOffset) * scaleX, center.Y * scaleY);

      char fillChar = '#';

      console.WriteBuffer((int)_prevPosition.X, (int)_prevPosition.Y, ' ');
      console.WriteBuffer((int)rocketCenter.X, (int)rocketCenter.Y, fillChar);
      _prevPosition = rocketCenter;
    }
  }
}
