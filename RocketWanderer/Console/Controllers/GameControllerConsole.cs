using ConsoleApp.Views.Game;
using ConsoleApp.Views.Menu;
using Logic.Controllers;
using Logic.Views.Game;
using Logic.Views.Menus;
using Logic.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Controllers
{
  /// <summary>
  /// Контроллер для процесса игры от Console
  /// </summary>
  public class GameControllerConsole : GameController
  {
    public GameControllerConsole(WindowView parWindowView) 
      : base(parWindowView)
    {
    }

    /// <summary>
    /// Создает представление меню конца игры от Console
    /// </summary>
    /// <returns>Представление меню конца игры от Console</returns>
    public override GameOverMenuView CreateGameOverMenuView()
    {
      return new GameOverMenuViewConsole(GameOverMenu, Scores);
    }

    /// <summary>
    /// Создает представление карты от Console
    /// </summary>
    /// <returns>Представление карты от Console</returns>
    public override MapView CreateMapView()
    {
      return new MapViewConsole(Map);
    }

    /// <summary>
    /// Создает представление меню паузы от Console
    /// </summary>
    /// <returns>Представление меню паузы от Console</returns>
    public override MenuView CreatePauseMenuView()
    {
      return new PauseMenuViewConsole(PauseMenu);
    }

    /// <summary>
    /// Создает представление очков игрока
    /// </summary>
    /// <returns>Представление очков игрока</returns>
    public override ScoresView CreateScoresView()
    {
      return new ScoresViewConsole(Scores, Map);
    }
  }
}
