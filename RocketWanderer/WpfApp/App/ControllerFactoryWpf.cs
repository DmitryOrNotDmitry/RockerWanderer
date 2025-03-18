using Logic.App;
using Logic.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Controllers;

namespace WpfApp.App
{
    /// <summary>
    /// Фабрика по созданию контроллеров от Wpf
    /// </summary>
    public class ControllerFactoryWpf : ControllerFactory
  {
    /// <summary>
    /// Создает контроллер игры
    /// </summary>
    /// <returns>Контроллер игры</returns>
    public override GameController CreateGameController()
    {
      GameController gameController = new GameControllerWpf(
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
      return new MenuControllerWpf(
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
      return new ScreenControllerWpf(App.WindowController.WindowView);
    }

    /// <summary>
    /// Создает контроллер окна приложения
    /// </summary>
    /// <returns>Контроллер игры окна приложения</returns>
    public override WindowController CreateWindowController()
    {
      return new WindowControllerWpf();
    }
  }
}
