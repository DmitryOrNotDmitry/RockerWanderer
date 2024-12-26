using Logic.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Game
{
  /// <summary>
  /// Представление карты
  /// </summary>
  public abstract class MapView : GameView
  {
    /// <summary>
    /// Представление ракеты
    /// </summary>
    private RocketView _rocketView;

    /// <summary>
    /// Представление ракеты
    /// </summary>
    public RocketView RocketView
    {
      get { return _rocketView; }
    }

    /// <summary>
    /// Представление стратовой планеты
    /// </summary>
    private PlanetView _startPlanetView;

    /// <summary>
    /// Представление ракеты
    /// </summary>
    public PlanetView StartPlanetView
    {
      get { return _startPlanetView; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMap">Модель карты</param>
    public MapView(Map parMap) 
    {
      Map = parMap;

      _rocketView = CreateRocketView();
      _startPlanetView = CreateStartPlanetView();

      RocketView.Map = parMap;
      StartPlanetView.Map = parMap;
    }

    /// <summary>
    /// Создает представление ракеты
    /// </summary>
    /// <returns>Представление ракеты</returns>
    public abstract RocketView CreateRocketView();

    /// <summary>
    /// Создает представление стартовой планеты
    /// </summary>
    /// <returns>Представление стартовой планеты</returns>
    public abstract PlanetView CreateStartPlanetView();

  }
}
