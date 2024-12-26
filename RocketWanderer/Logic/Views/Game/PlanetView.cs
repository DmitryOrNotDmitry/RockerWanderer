using Logic.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Game
{
  /// <summary>
  /// Представление планеты
  /// </summary>
  public abstract class PlanetView : GameView
  {
    /// <summary>
    /// Модель планеты
    /// </summary>
    private Planet _planet;

    /// <summary>
    /// Модель планеты
    /// </summary>
    public Planet Planet
    { 
      get { return _planet; } 
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlanet">Модель планеты</param>
    public PlanetView(Planet parPlanet) 
    {
      _planet = parPlanet;
    }

  }
}
