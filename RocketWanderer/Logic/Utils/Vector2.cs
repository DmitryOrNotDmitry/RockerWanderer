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
    private double _x;

    /// <summary>
    /// Компонент y
    /// </summary>
    private double _y;

    /// <summary>
    /// Компонент x
    /// </summary>
    public double X
    {
      get { return _x; }
      set { _x = value; }
    }

    /// <summary>
    /// Компонент y
    /// </summary>
    public double Y
    {
      get { return _y; }
      set { _y = value; }
    }

    /// <summary>
    /// Длина вектора
    /// </summary>
    public double Length
    { 
      get { return Math.Sqrt(X * X + Y * Y); }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parX">Компонент x</param>
    /// <param name="parY">Компонент y</param>
    public Vector2(double parX, double parY)
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

    /// <summary>
    /// Масштабирует вектор
    /// </summary>
    /// <param name="parFactor">Множитель</param>
    /// <returns>Новый вектор, умноженный на множитель</returns>
    public Vector2 Scale(double parFactor)
    {
      return new Vector2(this.X * parFactor, this.Y * parFactor);
    }

    /// <summary>
    /// Складывает 2 вектора
    /// </summary>
    /// <param name="v1">вектор 1</param>
    /// <param name="v2">вектор 2</param>
    /// <returns>Новый вектор как сумма v1 и v2</returns>
    public static Vector2 operator +(Vector2 v1, Vector2 v2)
    {
      return new Vector2( v1.X + v2.X, v1.Y + v2.Y );
    }
  }
}
