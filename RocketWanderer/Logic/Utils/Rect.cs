using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Utils
{
  /// <summary>
  /// Прямоугольник
  /// </summary>
  public class Rect
  {
    /// <summary>
    /// Координата левого вехнего угла
    /// </summary>
    private int _x;

    /// <summary>
    /// Координата левого вехнего угла
    /// </summary>
    private int _y;

    /// <summary>
    /// Ширина (по X)
    /// </summary>
    private int _width;
    
    /// <summary>
    /// Высота (по Y)
    /// </summary>
    private int _height;

    /// <summary>
    /// Координата левого вехнего угла
    /// </summary>
    public int X
    {
      get { return _x; }
      set { _x = value; }
    }

    /// <summary>
    /// Координата левого вехнего угла
    /// </summary>
    public int Y
    {
      get { return _y; }
      set { _y = value; }
    }

    /// <summary>
    /// Ширина (по X)
    /// </summary>
    public int Width
    {
      get { return _width; }
      set { _width = value; }
    }

    /// <summary>
    /// Высота (по Y)
    /// </summary>
    public int Height
    {
      get { return _height; }
      set { _height = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parX">Координата по X</param>
    /// <param name="parY">Координата по Y</param>
    /// <param name="parWidth">Ширина</param>
    /// <param name="parHeight">Высота</param>
    public Rect(int parX, int parY, int parWidth, int parHeight)
    {
      _x = parX;
      _y = parY;
      _width = parWidth;
      _height = parHeight;
    }

    /// <summary>
    /// Пустой конструктор
    /// </summary>
    public Rect()
      : this(0, 0, 0, 0)
    {
    }

    /// <summary>
    /// Изменяет состояние прямоугольника таким образом, чтобы он полностью лежал в положительных координатах
    /// </summary>
    public Rect Positive()
    {
      if (_x < 0)
      {
        _width -= Math.Abs(_x);
        _x = 0;
      }

      if (_y < 0)
      {
        _height -= Math.Abs(_y);
        _y = 0;
      }

      _width = Math.Max(0, _width);
      _height = Math.Max(0, _height);

      return this;
    }
  }
}
