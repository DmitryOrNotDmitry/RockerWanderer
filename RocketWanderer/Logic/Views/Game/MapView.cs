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
    /// Представление планет
    /// </summary>
    private LinkedList<PlanetView> _planetsView;

    /// <summary>
    /// Представление планет
    /// </summary>
    public LinkedList<PlanetView> PlanetsView
    {
      get { return _planetsView; }
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
      
      _planetsView = new LinkedList<PlanetView>();
      foreach (Planet elPlanet in Map.Planets)
      {
        ProcessCreatePlanetView(elPlanet);
      }

      Map.PlanetCreated += ProcessCreatePlanetView;

      RocketView.Map = parMap;
      StartPlanetView.Map = parMap;
      SunView.Map = parMap;
      TopBeltView.Map = parMap;
      BottomBeltView.Map = parMap;

      Map.Reseted += Reset;
    }

    /// <summary>
    /// Создает и добавляет в массив новое представление планеты
    /// </summary>
    /// <param name="parNewPlanet">Модель планеты</param>
    protected virtual void ProcessCreatePlanetView(Planet parNewPlanet)
    {
      PlanetView newPlanetView = CreatePlanetView(parNewPlanet);
      newPlanetView.Map = Map;
      _planetsView.AddLast(newPlanetView);

      parNewPlanet.Despawned += () =>
      {
        _planetsView.Remove(newPlanetView);
      };
    }

    /// <summary>
    /// Сбрасывает представление карты
    /// </summary>
    public virtual void Reset()
    {
      _planetsView.Clear();      
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
    /// Создает представление генерируемой планеты от Wpf
    /// </summary>
    /// <param name="parPlanet">Модель планеты</param>
    /// <returns>Представление генерируемой планеты от Wpf</returns>
    public abstract PlanetView CreatePlanetView(Planet parPlanet);

    /// <summary>
    /// Создает представление солнца
    /// </summary>
    /// <returns>Представление солнца</returns>
    public abstract SunView CreateSunView();

    /// <summary>
    /// Создает представление пояса астероидов
    /// </summary>
    /// <param name="parAsteroidBelt">Модель пояса астероидов</param>
    /// <returns>Представление пояса астероидов</returns>
    public abstract AsteroidBeltView CreateAsteroidBeltView(AsteroidBelt parAsteroidBelt);

  }
}
