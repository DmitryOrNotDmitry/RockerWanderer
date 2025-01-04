using Logic.Models.Game;
using Logic.Utils;
using Logic.Views.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Views.Game
{
  public class MapViewConsole : MapView
  {
    public MapViewConsole(Map parMap) 
      : base(parMap)
    {
    }

    /// <summary>
    /// Создает представление ракеты от Console
    /// </summary>
    /// <returns>Представление ракеты от Console</returns>
    public override RocketView CreateRocketView()
    {
      RocketView rocketView = new RocketViewConsole(Map.Rocket);
      //IWpfItem.AddChild(this, rocketView);

      return rocketView;
    }

    /// <summary>
    /// Создает представление стартовой планеты от Console
    /// </summary>
    /// <returns>Представление стартовой планеты от Console</returns>
    public override PlanetView CreateStartPlanetView()
    {
      PlanetView newStartPlanetView = new PlanetViewConsole(Map.StartPlanet);
      //IWpfItem.AddChild(this, newStartPlanetView);

      return newStartPlanetView;
    }

    /// <summary>
    /// Создает представление генерируемой планеты от Console
    /// </summary>
    /// <param name="parPlanet">Модель планеты</param>
    /// <returns>Представление генерируемой планеты от Console</returns>
    public override PlanetView CreatePlanetView(Planet parPlanet)
    {
      PlanetView planetView = new PlanetViewConsole(parPlanet);

      parPlanet.Despawned += () =>
      {
        //IWpfItem.RemoveChild(this, planetView);
      };

      return planetView;
    }

    /// <summary>
    /// Обрабатывает новое представление планеты
    /// </summary>
    /// <param name="parNewPlanet">Модель планеты</param>
    protected override void ProcessCreatePlanetView(Planet parNewPlanet)
    {
    }

    /// <summary>
    /// Создает представление солнца от Console
    /// </summary>
    /// <returns>Представление солнца от Console</returns>
    public override SunView CreateSunView()
    {
      SunView sunView = new SunViewConsole(Map.Sun);
      //IWpfItem.AddChild(this, sunView);

      return sunView;
    }

    /// <summary>
    /// Создает представление пояса астероидов от Console
    /// </summary>
    /// <param name="parAsteroidBelt">Модель пояса астероидов</param>
    /// <returns>Представление пояса астероидов от Console</returns>
    public override AsteroidBeltView CreateAsteroidBeltView(AsteroidBelt parAsteroidBelt)
    {
      AsteroidBeltView newAsteroidBeltView = new AsteroidBeltViewConsole(parAsteroidBelt);
      //IWpfItem.AddChild(this, newAsteroidBeltView);

      return newAsteroidBeltView;
    }

    /// <summary>
    /// Сбрасывает представление карты от Console
    /// </summary>
    public override void Reset()
    {
      base.Reset();
    }
  }
}
