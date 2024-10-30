using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Menu
{
  /// <summary>
  /// Действия пунктов в меню
  /// </summary>
  public enum MenuItemAction
  {
    /// <summary>
    /// Новая игра
    /// </summary>
    NewGame,

    /// <summary>
    /// Рекорды
    /// </summary>
    Records,

    /// <summary>
    /// Описание
    /// </summary>
    Description,

    /// <summary>
    /// Выход
    /// </summary>
    Exit,

    /// <summary>
    /// Назад
    /// </summary>
    Back,
  }
}
