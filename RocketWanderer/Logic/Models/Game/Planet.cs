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
    /// Радиус
    /// </summary>
    private double _radius;

    /// <summary>
    /// Радиус
    /// </summary>
    public double Radius
    {
      get { return _radius; }
      set { _radius = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parRadius">Радиус</param>
    public Planet(double parRadius)
    {
      _radius = parRadius;

      Size = new Vector2(_radius * 2, _radius * 2);
    }
  }
}
