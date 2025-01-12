using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Utils
{
  /// <summary>
  /// Компонент относительного масштаба и смещения для 2-ух измерений X и Y
  /// </summary>
  public class UDim2
  {
    /// <summary>
    /// X компонент
    /// </summary>
    private UDim _x;

    /// <summary>
    /// Y компонент
    /// </summary>
    private UDim _y;

    /// <summary>
    /// X компонент
    /// </summary>
    public UDim X
    {
      get { return _x; }
      set { _x = value; }
    }

    /// <summary>
    /// Y компонент
    /// </summary>
    public UDim Y
    { 
      get { return _y; }
      set { _y = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parXScale">Масштаб по оси X</param>
    /// <param name="parXOffset">Смещение по оси X</param>
    /// <param name="parYScale">Масштаб по оси Y</param>
    /// <param name="parYOffset">Смещение по оси Y</param>
    public UDim2(double parXScale, int parXOffset, double parYScale, int parYOffset)
    {
      _x = new UDim(parXScale, parXOffset);
      _y = new UDim(parYScale, parYOffset);
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parXScale">Масштаб по оси X</param>
    /// <param name="parYScale">Масштаб по оси Y</param>
    public UDim2(double parXScale, double parYScale)
      : this(parXScale, 0, parYScale, 0)
    {
    }

    /// <summary>
    /// Создает UDim2 по offset
    /// </summary>
    /// <param name="parXOffset">Смещение по оси X</param>
    /// <param name="parYOffset">Смещение по оси Y</param>
    public static UDim2 FromOffset(int parXOffset, int parYOffset)
    {
      return new UDim2(0, parXOffset, 0, parYOffset);
    }

    /// <summary>
    /// Возвращает UDim2 с нулевыми компонентами
    /// </summary>
    /// <returns></returns>
    public static UDim2 Zero()
    {
      return new UDim2(0, 0, 0, 0);
    }
  }
}
