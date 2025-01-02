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
      Vector2 beltRightBottom = Position + Size;

      bool intersectsY = Position.Y <= rocketRightBottom.Y && beltRightBottom.Y >= parRocket.Position.Y;

      return intersectsY;
    }
  }
}
