using ConsoleApp.App;
using ConsoleApp.Views.Game;
using ConsoleApp.Views.Menu;
using Logic.Controllers;
using Logic.Models.Menus;
using Logic.Models.Screens;
using Logic.Models.Windows;
using Logic.Records;
using Logic.Utils;
using Logic.Views.Game;
using Logic.Views.Menus;
using Logic.Views.Screens;
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
    public GameControllerConsole(GameScreenView parGameScreenView, WindowView parWindowView) 
      : base(parWindowView)
    {
      parGameScreenView.AddChild(MapView);
      parGameScreenView.AddChild(PauseMenuView);
      parGameScreenView.AddChild(ScoresView);
      parGameScreenView.AddChild(GameOverMenuView);
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

    /// <summary>
    /// Останавливает/возобновляет игру по действию пользователя
    /// </summary>
    public override void OnPauseAction()
    {
      base.OnPauseAction();
      if (IsGameProcessed)
      {
        if (!PauseMenu.IsEnabled)
        {
          ConsoleAdapter.Instance.Clear();
        }
      }
    }

    /// <summary>
    /// Заканчивает рассчет логики игровых объектов
    /// </summary>
    protected override void StopGame()
    {
      if (IsGameProcessed)
      {
        ConsoleAdapter.Instance.Clear();
        base.StopGame();
      }
    }

    /// <summary>
    /// Обработчик события на нажатие клавиши "Вверх"
    /// </summary>
    public void OnArrowUp()
    {
      if (PauseMenu.IsEnabled)
      {
        PauseMenu.FocusPrev();
      }

      if (GameOverMenu.IsEnabled)
      {
        GameOverMenu.FocusPrev();
      }
    }

    /// <summary>
    /// Обработчик события на нажатие клавиши "Вниз"
    /// </summary>
    public void OnArrowDown()
    {
      if (PauseMenu.IsEnabled)
      {
        PauseMenu.FocusNext();
      }

      if (GameOverMenu.IsEnabled)
      {
        GameOverMenu.FocusNext();
      }
    }

    /// <summary>
    /// Обработчик события на нажатие клавиши "Enter"
    /// </summary>
    public void OnEnter()
    {
      if (GameOverMenu.IsEnabled)
      {
        GameOverMenu.SelectFocusedItem();
        GameOverMenu.Unfocus();
      }
      
      if (PauseMenu.IsEnabled)
      {
        PauseMenu.SelectFocusedItem();
        PauseMenu.Unfocus();
      }
    }
  }
}
