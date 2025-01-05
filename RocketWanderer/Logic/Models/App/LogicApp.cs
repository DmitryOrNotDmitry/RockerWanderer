using Logic.Controllers;
using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.App
{
  /// <summary>
  /// Главный класс приложения
  /// </summary>
  public class LogicApp
  {
    /// <summary>
    /// Контроллер рекордов
    /// </summary>
    private RecordsController _recordsController;

    /// <summary>
    /// Контроллер окна приложения
    /// </summary>
    private WindowController _windowController;

    /// <summary>
    /// Контроллер экранов
    /// </summary>
    private ScreenController _screenController;

    /// <summary>
    /// Контроллер главного меню
    /// </summary>
    private MenuController _menuController;

    /// <summary>
    /// Контроллер игры
    /// </summary>
    private GameController _gameController;

    /// <summary>
    /// Контроллер рекордов
    /// </summary>
    public RecordsController RecordsController
    {
      get { return _recordsController; }
    }

    /// <summary>
    /// Контроллер окна приложения
    /// </summary>
    public WindowController WindowController
    {
      get { return _windowController; }
    }

    /// <summary>
    /// Контроллер экранов
    /// </summary>
    public ScreenController ScreenController
    {
      get { return _screenController; }
    }

    /// <summary>
    /// Контроллер главного меню
    /// </summary>
    public MenuController MenuController
    {
      get { return _menuController; }
    }

    /// <summary>
    /// Контроллер игры
    /// </summary>
    public GameController GameController
    {
      get { return _gameController; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parFactory">Фабрика по созданию контроллеров</param>
    public LogicApp(ControllerFactory parFactory) 
    {
      parFactory.App = this;

      _windowController = parFactory.CreateWindowController();
     
      _screenController = parFactory.CreateScreenController();
      
      _menuController = parFactory.CreateMenuController();
     
      _gameController = parFactory.CreateGameController();
      
      _recordsController = parFactory.CreateRecordsController();


      Task.Run(() =>
      {
        {
          try
          {
            while (true)
            {
              if (Redrawer.NeedRedraw)
              {
                Redrawer.NeedRedraw = false;
                _windowController.WindowView.Draw();
              }
            }
          }
          catch (TaskCanceledException e)
          {

          }
        }
      }
      );
    }

    /// <summary>
    /// Срабатывает при закрытии приложения
    /// </summary>
    public void OnExit()
    {
      _recordsController.FillRecordsFile();
    }
  }
}
