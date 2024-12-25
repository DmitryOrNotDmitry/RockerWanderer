using Logic.Models.Game;
using Logic.Models.Windows;
using Logic.Utils;
using Logic.Views.Game;
using Logic.Views.Screens;
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
    public GameController(WindowData parWindowData) 
    {
      _map = new Map(new Vector2(1920, 1080));
      
      _mapView = CreateMapView();

      parWindowData.ScreenChanged += 
        (parScreenType) =>
      {
        if (parScreenType == ScreenType.Game)
        {
          Task.Run(() =>
          {
            _isGameProcessed = true;

            Stopwatch stopwatch = Stopwatch.StartNew();
            double lastFrameTime = stopwatch.Elapsed.TotalSeconds;
            double currentFrameTime = 0;

            while (_isGameProcessed) 
            {
              currentFrameTime = stopwatch.Elapsed.TotalSeconds;

              Map.Update(currentFrameTime - lastFrameTime);

              lastFrameTime = currentFrameTime;
            }

          });
        }
        else
        {
          _isGameProcessed = false;
        }

      };
    }

    /// <summary>
    /// Создает представление карты
    /// </summary>
    /// <returns>Представление карты</returns>
    public abstract MapView CreateMapView();    

  }
}
