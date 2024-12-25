using Logic.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Game
{
  /// <summary>
  /// Представление карты
  /// </summary>
  public abstract class MapView : GameView
  {
    /// <summary>
    /// Модель карты
    /// </summary>
    private Map _map;

    /// <summary>
    /// Представление ракеты
    /// </summary>
    private RocketView _rocketView;

    /// <summary>
    /// Модель карты
    /// </summary>
    public Map Map
    {
      get { return _map; }
    }

    /// <summary>
    /// Представление ракеты
    /// </summary>
    public RocketView RocketView
    {
      get { return _rocketView; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMap">Модель карты</param>
    public MapView(Map parMap) 
    {
      _map = parMap;

      _rocketView = CreateRocketView();
    }

    /// <summary>
    /// Создает представление ракеты
    /// </summary>
    /// <returns>Представление ракеты</returns>
    public abstract RocketView CreateRocketView();

  }
}
