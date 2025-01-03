using Logic.Controllers;
using Logic.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Controllers;

namespace WpfApp.App
{
  public class ControllerFactoryWpf : ControllerFactory
  {
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

    public override MenuController CreateMenuController()
    {
      return new MenuControllerWpf(
        App.WindowController.WindowView,
        App.ScreenController.MainMenuScreenView
      );
    }

    public override ScreenController CreateScreenController()
    {
      return new ScreenControllerWpf(App.WindowController.WindowView);
    }

    public override WindowController CreateWindowController()
    {
      return new WindowControllerWpf();
    }
  }
}
