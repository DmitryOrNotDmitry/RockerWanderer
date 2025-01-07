using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Game
{
  /// <summary>
  /// Пояс астероидов
  /// </summary>
  public class AsteroidBelt : MapItem, IRocketDestroyer
  {
    /// <summary>
    /// Проверяет столкнулась ли ракета с поясом астероидов
    /// </summary>
    /// <param name="parRocket">Ракета</param>
    /// <returns>true - столкновение произошло, иначе false</returns>
    public bool IsCollideWith(Rocket parRocket)
    {
      double tolerance = 0.2;

      Vector2 rocketLeftUp = parRocket.Position + parRocket.Size.Scale(-(0.5 - tolerance));
      Vector2 rocketRightBottom = parRocket.Position + parRocket.Size.Scale(0.5 - tolerance);

      Vector2 beltLeftTop = Position + Size.Scale(-0.5);
      Vector2 beltRightBottom = Position + Size.Scale(0.5);

      bool intersectsY = beltLeftTop.Y <= rocketRightBottom.Y && beltRightBottom.Y >= rocketLeftUp.Y;

      return intersectsY;
    }
  }
}
