using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Game
{
  public abstract class MapItem
  {
    /// <summary>
    /// Позиция
    /// </summary>
    private Vector2 _position = new Vector2();

    /// <summary>
    /// Размер
    /// </summary>
    private Vector2 _size = new Vector2();

    /// <summary>
    /// Позиция
    /// </summary>
    public Vector2 Position
    {
      get { return _position; }
      set { _position = value; }
    }

    /// <summary>
    /// Размер
    /// </summary>
    public Vector2 Size
    { 
      get { return _size; }
      set { _size = value; }
    }    

  }
}
