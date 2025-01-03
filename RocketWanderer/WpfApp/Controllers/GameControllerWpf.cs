using Logic.Controllers;
using Logic.Models.Windows;
using Logic.Views.Game;
using Logic.Views.Menus;
using Logic.Views.Screens;
using Logic.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Views;
using WpfApp.Views.Game;
using WpfApp.Views.Menus;
using WpfApp.Views.Windows;

namespace WpfApp.Controllers
{
  /// <summary>
  /// Контроллер для процесса игры от Wpf
  /// </summary>
  public class GameControllerWpf : GameController
  {
    /// <summary>
    /// Контроллер
    /// </summary>
    /// <param name="parGameScreenView">Представление экрана игры</param>
    /// <param name="parWindowView">Модель окна приложения</param>
    public GameControllerWpf(GameScreenView parGameScreenView, WindowView parWindowView) 
      : base(parWindowView)
    {
      IWpfItem.AddChild(parGameScreenView, MapView);
      IWpfItem.AddChild(parGameScreenView, PauseMenuView);
      IWpfItem.AddChild(parGameScreenView, ScoresView);
      IWpfItem.AddChild(parGameScreenView, GameOverMenuView);

      ((Window)(((WindowViewWpf)parWindowView).Control)).KeyDown += (s, e) =>
      {
        if (e.Key == Key.Space)
        {
          RocketDepartAction();
        }

        if (e.Key == Key.Escape)
        {
          OnPauseAction();
        }
      };

    }

    /// <summary>
    /// Создает представление меню конца игры от Wpf
    /// </summary>
    /// <returns>Представление меню конца игры от Wpf</returns>
    public override GameOverMenuView CreateGameOverMenuView()
    {
      return new GameOverMenuViewWpf(GameOverMenu, Scores);
    }

    /// <summary>
    /// Создает представление карты от Wpf
    /// </summary>
    /// <returns>Представление карты от Wpf</returns>
    public override MapView CreateMapView()
    {
      return new MapViewWpf(Map);
    }

    /// <summary>
    /// Создает представление меню паузы от Wpf
    /// </summary>
    /// <returns>Представление меню паузы от Wpf</returns>
    public override MenuView CreatePauseMenuView()
    {
      return new PauseMenuViewWpf(PauseMenu);
    }

    /// <summary>
    /// Создает представление очков игрока
    /// </summary>
    /// <returns>Представление очков игрока</returns>
    public override ScoresView CreateScoresView()
    {
      return new ScoresViewWpf(Scores, Map);
    }
  }
}
