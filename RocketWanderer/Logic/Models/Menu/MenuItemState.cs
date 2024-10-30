using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Menu
{
  /// <summary>
  /// Состояния пунктов меню
  /// </summary>
  public enum MenuItemState
  {
    /// <summary>
    /// Обычный
    /// </summary>
    Normal,

    /// <summary>
    /// Сфокусированный
    /// </summary>
    Focused,

    /// <summary>
    /// Выбранный
    /// </summary>
    Selected,
  }
}
