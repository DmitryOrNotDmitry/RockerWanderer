using ConsoleApp.App;
using Logic.Models.Game;
using Logic.Utils;
using Logic.Views.Game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Views.Game
{
  /// <summary>
  /// Представление карты от Console
  /// </summary>
  public class MapViewConsole : MapView
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMap">Модель карты</param>
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
      this.AddChild(rocketView);

      return rocketView;
    }

    /// <summary>
    /// Создает представление стартовой планеты от Console
    /// </summary>
    /// <returns>Представление стартовой планеты от Console</returns>
    public override PlanetView CreateStartPlanetView()
    {
      PlanetView newStartPlanetView = new PlanetViewConsole(Map.StartPlanet);
      this.AddChild(newStartPlanetView);

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
        this.RemoveChild(planetView);
      };

      return planetView;
    }

    /// <summary>
    /// Обрабатывает новое представление планеты
    /// </summary>
    /// <param name="parNewPlanet">Модель планеты</param>
    protected override void ProcessCreatePlanetView(Planet parNewPlanet)
    {
      base.ProcessCreatePlanetView(parNewPlanet);
      if (PlanetsView.Last != null)
      {
        this.SetFirstChild(PlanetsView.Last.ValueRef);
      }
    }

    /// <summary>
    /// Создает представление солнца от Console
    /// </summary>
    /// <returns>Представление солнца от Console</returns>
    public override SunView CreateSunView()
    {
      SunView sunView = new SunViewConsole(Map.Sun);
      this.AddChild(sunView);

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
      this.AddChild(newAsteroidBeltView);

      return newAsteroidBeltView;
    }

    /// <summary>
    /// Сбрасывает представление карты от Console
    /// </summary>
    public override void Reset()
    {
      foreach (PlanetView elPlanetView in PlanetsView)
      {
        this.RemoveChild(elPlanetView);
      }
      base.Reset();
    }

    /// <summary>
    /// Отрисовывает карту
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      string mangeButtonsInfo = "Пауза [Backspace], Действие [Space]";

      ConsoleAdapter console = ConsoleAdapter.Instance;

      console.ClearBuffer(((SunViewConsole)SunView).PrevLocation.Positive());
      console.ClearBuffer(((PlanetViewConsole)StartPlanetView).PrevLocation.Positive());
      foreach (PlanetViewConsole elPlanetView in PlanetsView)
      {
        console.ClearBuffer(elPlanetView.PrevLocation.Positive());
      }

      Vector2 parentSize = Parent.AbsoluteSize;

      double scaleY = parentSize.Y / Map.Size.Y;

      int y = (int)(Map.TopAsteroidBelt.Size.Y * scaleY);
      int x = 2;

      console.WriteBuffer(x, y, mangeButtonsInfo);

      DrawChildren();
    }
  }
}
