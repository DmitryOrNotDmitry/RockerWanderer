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
      Vector2 rocketRightBottom = parRocket.Position + parRocket.Size;

      Vector2 beltLeftTop = Position;
      Vector2 beltRightBottom = Position + Size;

      double epsilon = 0.35;
      beltLeftTop     =     beltLeftTop + new Vector2(0,  Size.Y * epsilon);
      beltRightBottom = beltRightBottom + new Vector2(0, -Size.Y * epsilon);

      bool intersectsY = beltLeftTop.Y <= rocketRightBottom.Y && beltRightBottom.Y >= parRocket.Position.Y;

      return intersectsY;
    }
  }
}
