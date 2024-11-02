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
    public UDim2(int parXScale, int parXOffset, int parYScale, int parYOffset)
    {
      _x = new UDim(parXScale, parXOffset);
      _y = new UDim(parYScale, parYOffset);
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parXScale">Масштаб по оси X</param>
    /// <param name="parYScale">Масштаб по оси Y</param>
    public UDim2(int parXScale, int parYScale) 
      : this(parXScale, 0, parYScale, 0)
    {
    }
  }
}
