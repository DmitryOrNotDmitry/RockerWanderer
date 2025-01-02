using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Game
{
  /// <summary>
  /// Интерфейс для объектов, которые могут уничтожить корабль
  /// </summary>
  public interface IRocketDestroyer
  {
    /// <summary>
    /// Проверяет столкнулась ли ракета с объектом
    /// </summary>
    /// <param name="parRocket">Ракета</param>
    /// <returns>true - столкновение произошло, иначе false</returns>
    bool IsCollideWith(Rocket parRocket);
  }
}
