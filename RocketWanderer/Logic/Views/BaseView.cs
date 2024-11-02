using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views
{
  /// <summary>
  /// Базовый класс всех представлений
  /// </summary>
  public abstract class BaseView
  {
    /// <summary>
    /// Отрисовывает объект
    /// </summary>
    public abstract void Draw();
  }
}
