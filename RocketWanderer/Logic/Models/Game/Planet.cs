using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Game
{
  /// <summary>
  /// Планета
  /// </summary>
  public class Planet : MapItem
  {
    /// <summary>
    /// Делегат, представляющий метод, который будет вызываться при срабатывании события уничтожения
    /// </summary>
    public delegate void dDespawned();

    /// <summary>
    /// Событие, которое возникает при уничтожении планеты
    /// </summary>
    public event dDespawned? Despawned;

    /// <summary>
    /// Радиус
    /// </summary>
    private double _radius;

    /// <summary>
    /// Радиус
    /// </summary>
    public double Radius
    {
      get
      {
        lock (_lock)
        {
          return _radius;
        }
      }
      set
      {
        lock (_lock)
        {
          _radius = value;
        }
      }
    }

    /// <summary>
    /// Радиус орбиты
    /// </summary>
    public double OrbitRadius
    {
      get 
      {
        lock (_lock)
        {
          return _radius * 3; 
        }
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parRadius">Радиус</param>
    public Planet(double parRadius)
    {
      Radius = parRadius;

      Size = new Vector2(_radius * 2, _radius * 2);
    }

    /// <summary>
    /// Активирует событие Despawned
    /// </summary>
    public void Despawn()
    {
      Despawned?.Invoke();
    }
  }
}
