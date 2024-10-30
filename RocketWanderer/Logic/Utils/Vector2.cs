using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Utils
{
  /// <summary>
  /// Вектор из 2 компонент x и y
  /// </summary>
  public class Vector2
  {
    /// <summary>
    /// Компонент x
    /// </summary>
    private int _x;

    /// <summary>
    /// Компонент y
    /// </summary>
    private int _y;

    /// <summary>
    /// Компонент x
    /// </summary>
    public int X
    {
      get { return _x; }
      set { _x = value; }
    }

    /// <summary>
    /// Компонент y
    /// </summary>
    public int Y
    {
      get { return _y; }
      set { _y = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parX">Компонент x</param>
    /// <param name="parY">Компонент y</param>
    public Vector2(int parX, int parY)
    {
      _x = parX;
      _y = parY;
    }

    /// <summary>
    /// Коструктор единичного вектора
    /// </summary>
    public Vector2() : this(1, 1)
    {
      
    }
  }
}
