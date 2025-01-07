using ConsoleApp.App;
using ConsoleApp.Controllers;
using Logic.App;
using Logic.Controllers;
using Logic.Models.Menus;
using Logic.Utils;

/// <summary>
/// Приложение Wpf
/// </summary>
public class AppConsole
{
  /// <summary>
  /// Главный объект приложения
  /// </summary>
  private static LogicApp _app;

  /// <summary>
  /// Запускает компоненты приложения
  /// </summary>
  private static void Main()
  {
    ControllerFactory factory = new ControllerFactoryConsole();

    _app = new LogicApp(factory);
    
    AppDomain.CurrentDomain.ProcessExit += (sender, e) =>
    {
      _app.OnExit();
    };

    FontInfo.Init();
    
    while (true) 
    {
      ConsoleKeyInfo keyInfo = Console.ReadKey(true);
      
      ((ScreenControllerConsole)_app.ScreenController).OnNickEnter(keyInfo);

      switch (keyInfo.Key)
      {
        case ConsoleKey.UpArrow:
          ((MenuControllerConsole)_app.MenuController).OnArrowUp();
          ((GameControllerConsole)_app.GameController).OnArrowUp();
          break;
        case ConsoleKey.DownArrow:
          ((MenuControllerConsole)_app.MenuController).OnArrowDown();
          ((GameControllerConsole)_app.GameController).OnArrowDown();
          break;
        case ConsoleKey.Enter:
          ((MenuControllerConsole)_app.MenuController).OnEnter();
          ((GameControllerConsole)_app.GameController).OnEnter();
          break;
        case ConsoleKey.Backspace:
          ((ScreenControllerConsole)_app.ScreenController).OnBackspace();
          _app.GameController.OnPauseAction();
          break;
        case ConsoleKey.Spacebar:
          _app.GameController.RocketDepartAction();
          break;
      }

      Redrawer.NeedRedraw = true;
    }
  }

}