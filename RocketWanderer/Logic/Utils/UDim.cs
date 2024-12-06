using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Utils
{
  /// <summary>
  /// Компонент относительного масштаба и смещения
  /// </summary>
  public class UDim
  {
    /// <summary>
    /// Относительный масштаб
    /// </summary>
    private double _scale;

    /// <summary>
    /// Смещение
    /// </summary>
    private int _offset;

    /// <summary>
    /// Относительный масштаб
    /// </summary>
    public double Scale
    {
      get { return _scale; }
      set { _scale = value; }
    }

    /// <summary>
    /// Смещение
    /// </summary>
    public int Offset
    {
      get { return _offset; }
      set { _offset = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parScale">Относительный масштаб</param>
    /// <param name="parOffset">Смещение</param>
    public UDim(double parScale, int parOffset)
    {
      _scale = parScale;
      _offset = parOffset;
    }
  }
}
