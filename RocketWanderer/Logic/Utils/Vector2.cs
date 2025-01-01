using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

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
    /// <param name="parV1">вектор 1</param>
    /// <param name="parV2">вектор 2</param>
    /// <returns>Новый вектор как сумма v1 и v2</returns>
    public static Vector2 operator +(Vector2 parV1, Vector2 parV2)
    {
      return new Vector2(parV1.X + parV2.X, parV1.Y + parV2.Y);
    }

    /// <summary>
    /// Поворачивает вектор против часовой стрелки на 90 градусов
    /// </summary>
    /// <returns>Новыый вектор, повернутый на 90 градусов</returns>
    public Vector2 Rotate90()
    {
      return new Vector2(-Y, X);
    }

    /// <summary>
    /// Находит скалярное произведение векторов
    /// </summary>
    /// <param name="parOther">вектор 2</param>
    /// <returns>Cкалярное произведение векторов</returns>
    public double ScalarProduct(Vector2 parOther)
    {
      return X * parOther.X + Y * parOther.Y;
    }

    /// <summary>
    /// Находит векторное произведение векторов
    /// </summary>
    /// <param name="parOther">вектор 2</param>
    /// <returns>Векторное произведение векторов</returns>
    public double Product(Vector2 parOther)
    {
      return X * parOther.Y - Y * parOther.X;
    }

    /// <summary>
    /// Находит угог между 2 векторами
    /// </summary>
    /// <param name="parV1">Вектор 1</param>
    /// <param name="parV2">Вектор 1</param>
    /// <returns>Угол между 2 векторами</returns>
    public static double AngleBetween(Vector2 parV1, Vector2 parV2)
    {
      double cos = parV1.ScalarProduct(parV2) / (parV1.Length * parV2.Length);

      cos = Math.Max(-1.0, Math.Min(1.0, cos));

      return Math.Acos(cos);
    }
  }
}
