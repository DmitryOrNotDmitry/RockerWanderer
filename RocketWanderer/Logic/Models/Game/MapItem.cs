using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Game
{
  /// <summary>
  /// Базовый клас для объктов, располагаемых на карте
  /// </summary>
  public abstract class MapItem
  {
    /// <summary>
    /// Блокировка для синхронизации
    /// </summary>
    protected Object _lock = new Object();

    /// <summary>
    /// Позиция
    /// </summary>
    private Vector2 _position = new Vector2();

    /// <summary>
    /// Размер
    /// </summary>
    private Vector2 _size = new Vector2();

    /// <summary>
    /// Позиция центра объекта
    /// </summary>
    public Vector2 Position
    {
      get
      {
        lock (_lock)
        {
          return _position;
        }
      }
      set
      {
        lock (_lock)
        {
          _position = value;
        }
      }
    }

    /// <summary>
    /// Размер
    /// </summary>
    public Vector2 Size
    {
      get
      {
        lock (_lock)
        {
          return _size;
        }
      }
      set
      {
        lock (_lock)
        {
          _size = value;
        }
      }
    }

  }
}
