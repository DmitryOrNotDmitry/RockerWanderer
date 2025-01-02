using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Game
{
  /// <summary>
  /// Модель очков игрока
  /// </summary>
  public class Scores
  {
    /// <summary>
    /// Текущие очки игрока
    /// </summary>
    private int _current;

    /// <summary>
    /// Текущие очки игрока
    /// </summary>
    public int Current
    {
      get { return _current; }
      set { _current = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public Scores()
    {
      _current = 0;
    }
  }
}
