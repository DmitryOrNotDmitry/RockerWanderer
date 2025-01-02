using Logic.Models.Game;
using Logic.Models.Windows;
using Logic.Utils;
using Logic.Views.Game;
using Logic.Views.Screens;
using Logic.Views.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Controllers
{
  /// <summary>
  /// Контроллер для процесса игры
  /// </summary>
  public abstract class GameController : BaseController
  {
    /// <summary>
    /// Рассчитываются ли сейчас данные игры
    /// </summary>
    private bool _isGameProcessed = false;

    /// <summary>
    /// На паузе ли сейчас игра
    /// </summary>
    private bool _isGamePaused = false;

    /// <summary>
    /// Модель карты
    /// </summary>
    private Map _map;

    /// <summary>
    /// Представление карты
    /// </summary>
    private MapView _mapView;
 
    /// <summary>
    /// Модель карты
    /// </summary>
    public Map Map
    {
      get { return _map; }
    }

    /// <summary>
    /// Представление карты
    /// </summary>
    public MapView MapView
    {
      get { return _mapView; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public GameController(WindowView parWindowView) 
    {
      _map = new Map(new Vector2(1920, 1080));
      _mapView = CreateMapView();

      Map.Rocket.Destroyed += () =>
      {
        _isGameProcessed = false;
        parWindowView.Window.ChangeScreen(ScreenType.MainMenu);
      };

      parWindowView.Window.ScreenChanged += 
        (parScreenType) =>
      {
        if (parScreenType == ScreenType.Game)
        {
          Map.Reset();
          RunGameCalculating();
        }
      };
    }

    /// <summary>
    /// Запускает отдельный поток с вычислением данных игры
    /// </summary>
    private void RunGameCalculating()
    {
      Task.Run(() =>
      {
        _isGamePaused = false;
        _isGameProcessed = true;

        Stopwatch stopwatch = Stopwatch.StartNew();
        double lastFrameTime = stopwatch.Elapsed.TotalSeconds;
        double currentFrameTime = 0;

        while (_isGameProcessed && !_isGamePaused)
        {
          currentFrameTime = stopwatch.Elapsed.TotalSeconds;

          Map.Update(currentFrameTime - lastFrameTime);

          lastFrameTime = currentFrameTime;
        }

      });
    }

    /// <summary>
    /// Запускает отстыковывание ракеты по действию пользователя
    /// </summary>
    public void RocketDepartAction()
    {
      if (_isGameProcessed)
      {
        Map.RocketDepart();
      }
    }

    /// <summary>
    /// Останавливает/возобновляет игру по действию пользователя
    /// </summary>
    public void OnPauseAction()
    {
      if (_isGameProcessed)
      {
        if (_isGamePaused)
        {
          RunGameCalculating();
        }
        else
        {
          _isGamePaused = true;
        }
      }
    }

    /// <summary>
    /// Создает представление карты
    /// </summary>
    /// <returns>Представление карты</returns>
    public abstract MapView CreateMapView();    

  }
}
