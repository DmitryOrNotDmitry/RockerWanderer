using ConsoleApp.App;
using Logic.Models.App;

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

    while (true) 
    {
      
    }
  }

}