using Logic.Controllers;
using Logic.Views.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.App
{
  /// <summary>
  /// Фабрика по созданию контроллеров
  /// </summary>
  public abstract class ControllerFactory
  {
    /// <summary>
    /// Объект текущего приложения
    /// </summary>
    private LogicApp _app;

    /// <summary>
    /// Объект текущего приложения
    /// </summary>
    public LogicApp App 
    { 
      get { return _app; } 
      set { _app = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public ControllerFactory()
    {
    }

    /// <summary>
    /// Создает контроллер игры
    /// </summary>
    /// <returns>Контроллер игры</returns>
    public abstract GameController CreateGameController();

    /// <summary>
    /// Создает контроллер главного меню
    /// </summary>
    /// <returns>Контроллер главного меню</returns>
    public abstract MenuController CreateMenuController();

    /// <summary>
    /// Создает контроллер экранов
    /// </summary>
    /// <returns>Контроллер экранов</returns>
    public abstract ScreenController CreateScreenController();

    /// <summary>
    /// Создает контроллер окна приложения
    /// </summary>
    /// <returns>Контроллер окна приложения</returns>
    public abstract WindowController CreateWindowController();

    /// <summary>
    /// Создает контроллер рекордов
    /// </summary>
    /// <returns>Контроллер рекордов</returns>
    public virtual RecordsController CreateRecordsController()
    {
      return new RecordsController(_app.ScreenController.RecordsScreenView.RecordsTableView.RecordsTable);
    }
  }
}
