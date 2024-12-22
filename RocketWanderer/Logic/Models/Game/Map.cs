using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Game
{
  /// <summary>
  /// Карта
  /// </summary>
  public class Map
  {
    /// <summary>
    /// Размер видимой части карты
    /// </summary>
    private Vector2 _visibleSize;

    /// <summary>
    /// Размер видимой части карты
    /// </summary>
    public Vector2 VisibleSize
    {
      get { return _visibleSize; }
      set { _visibleSize = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parVisibleSize">Размер видимой части карты</param>
    public Map(Vector2 parVisibleSize)
    {
      _visibleSize = parVisibleSize;
    }

  }
}
