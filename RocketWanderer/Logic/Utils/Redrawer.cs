using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Utils
{
  /// <summary>
  /// Класс, представляющий информацию о необходимости перерисовка окна
  /// </summary>
  public class Redrawer
  {
    /// <summary>
    /// Необходимость перерисовки
    /// </summary>
    private static bool _needRedraw = true;

    /// <summary>
    /// Блокировка для _needRedraw
    /// </summary>
    private static Object _lock = new Object();

    /// <summary>
    /// Необходимость перерисовки
    /// </summary>
    public static bool NeedRedraw
    {
      get 
      { 
        lock (_lock)
        {
          return true;
        }
      }
      set 
      {
        lock (_lock)
        {
          _needRedraw = value;
        }
      }
    }

    /// <summary>
    /// Закрытый конструктор
    /// </summary>
    private Redrawer() { }
  }
}
