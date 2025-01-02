using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Game
{
  /// <summary>
  /// Солнце
  /// </summary>
  public class Sun : MapItem, IRocketDestroyer
  {
    /// <summary>
    /// Проверяет столкнулась ли ракета с солнцем
    /// </summary>
    /// <param name="parRocket">Ракета</param>
    /// <returns>true - столкновение произошло, иначе false</returns>
    public bool IsCollideWith(Rocket parRocket)
    {
      double sunRadius = Size.X / 2;
      double rocketRadius = (parRocket.Size.Y + parRocket.Size.X) / 4;
      rocketRadius *= 0.5;

      Vector2 rocketToSun = parRocket.Position + Position.Scale(-1);

      return rocketToSun.Length <= (sunRadius + rocketRadius);
    }
  }
}
