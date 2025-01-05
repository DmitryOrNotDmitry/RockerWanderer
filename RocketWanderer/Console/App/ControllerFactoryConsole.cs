using ConsoleApp.Controllers;
using Logic.Controllers;
using Logic.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.App
{
  /// <summary>
  /// Фабрика по созданию контроллеров от Console
  /// </summary>
  public class ControllerFactoryConsole : ControllerFactory
  {
    /// <summary>
    /// Создает контроллер игры
    /// </summary>
    /// <returns>Контроллер игры</returns>
    public override GameController CreateGameController()
    {
      GameController gameController = new GameControllerConsole(
        App.ScreenController.GameScreenView,
        App.WindowController.WindowView
      );

      gameController.RecordsTable = App.ScreenController.RecordsScreenView.RecordsTableView.RecordsTable;
      gameController.PlayerSettings = App.ScreenController.MainMenuScreen.PlayerSettings;

      return gameController;
    }

    /// <summary>
    /// Создает контроллер главного меню
    /// </summary>
    /// <returns>Контроллер главного меню</returns>
    public override MenuController CreateMenuController()
    {
      return new MenuControllerConsole(
        App.WindowController.WindowView,
        App.ScreenController.MainMenuScreenView
      );
    }

    /// <summary>
    /// Создает контроллер экранов
    /// </summary>
    /// <returns>Контроллер экранов</returns>
    public override ScreenController CreateScreenController()
    {
      return new ScreenControllerConsole(App.WindowController.WindowView);
    }

    /// <summary>
    /// Создает контроллер окна приложения
    /// </summary>
    /// <returns>Контроллер игры окна приложения</returns>
    public override WindowController CreateWindowController()
    {
      return new WindowControllerConsole();
    }
  }
}
