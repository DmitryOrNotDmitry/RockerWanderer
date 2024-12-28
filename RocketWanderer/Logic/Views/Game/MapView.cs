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
    /// Представление солнца
    /// </summary>
    private SunView _sunView;

    /// <summary>
    /// Представление солнца
    /// </summary>
    public SunView SunView
    {
      get { return _sunView; }
    }

    /// <summary>
    /// Представление верхнего пояса астероидов
    /// </summary>
    private AsteroidBeltView _topBeltView;

    /// <summary>
    /// Представление верхнего пояса астероидов
    /// </summary>
    public AsteroidBeltView TopBeltView
    {
      get { return _topBeltView; }
    }

    /// <summary>
    /// Представление нижнего пояса астероидов
    /// </summary>
    private AsteroidBeltView _bottomBeltView;

    /// <summary>
    /// Представление нижнего пояса астероидов
    /// </summary>
    public AsteroidBeltView BottomBeltView
    {
      get { return _bottomBeltView; }
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
      _sunView = CreateSunView();
      _topBeltView = CreateAsteroidBeltView(Map.TopAsteroidBelt);
      _bottomBeltView = CreateAsteroidBeltView(Map.BottomAsteroidBelt);

      RocketView.Map = parMap;
      StartPlanetView.Map = parMap;
      SunView.Map = parMap;
      TopBeltView.Map = parMap;
      BottomBeltView.Map = parMap;
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

    /// <summary>
    /// Создает представление солнца
    /// </summary>
    /// <returns>Представление солнца</returns>
    public abstract SunView CreateSunView();

    /// <summary>
    /// Создает представление пояса астероидов
    /// </summary>
    /// <returns>Представление пояса астероидов</returns>
    public abstract AsteroidBeltView CreateAsteroidBeltView(AsteroidBelt parAsteroidBelt);

  }
}
