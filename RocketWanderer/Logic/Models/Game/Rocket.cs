using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Game
{
  /// <summary>
  /// Ракета
  /// </summary>
  public class Rocket : MovableItem
  {
    /// <summary>
    /// Угол поворота
    /// </summary>
    private double _rotation;

    /// <summary>
    /// Угол поворота
    /// </summary>
    public double Rotation
    {
      get { return _rotation; }
      set { _rotation = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public Rocket() 
    {
      _rotation = 0;
    }

  }
}
