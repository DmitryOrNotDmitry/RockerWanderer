using Logic.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Game
{
  /// <summary>
  /// Представление пояса астероидов
  /// </summary>
  public class AsteroidBeltView : GameView
  {
    /// <summary>
    /// Модель пояса астероидов
    /// </summary>
    private AsteroidBelt _asteroidBelt;

    /// <summary>
    /// Модель пояса астероидов
    /// </summary>
    public AsteroidBelt AsteroidBelt 
    { 
      get { return _asteroidBelt; } 
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parAsteroidBelt">Модель пояса астероидов</param>
    public AsteroidBeltView(AsteroidBelt parAsteroidBelt)
    {
      _asteroidBelt = parAsteroidBelt;
    }
  }
}
